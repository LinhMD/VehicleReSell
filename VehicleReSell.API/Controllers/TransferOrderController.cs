using CrudApiTemplate.CustomBinding;
using CrudApiTemplate.CustomException;
using CrudApiTemplate.Model;
using CrudApiTemplate.Repository;
using CrudApiTemplate.Request;
using CrudApiTemplate.Response;
using CrudApiTemplate.Services;
using CrudApiTemplate.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VehicleReSell.Business.DTO.TransferOrderDto;
using VehicleReSell.Business.Service.Core;
using VehicleReSell.Data.Model;

namespace VehicleReSell.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class TransferOrderController : ControllerBase
{
    private readonly IServiceCrud<TransferOrder> _transferOrderService;
    private readonly IRepository<TransferOrder> _repo;
    private readonly ITransactionService _transactionService;
    private readonly IUnitOfWork _work;

    public TransferOrderController(IUnitOfWork work, ILogger<TransferOrderController> logger, ITransactionService transactionService)
    {
        _work = work;
        _transactionService = transactionService;
        _transferOrderService = new ServiceCrud<TransferOrder>(work, logger);
        _repo = work.Get<TransferOrder>();
    }

    [HttpGet("{id:int}")]
    [SwaggerResponse(200, "TransferOrder view", typeof(TransferOrderSView))]
    public async Task<ActionResult<TransferOrderSView>> Get(int id)
    {
        return Ok(await _repo.Find<TransferOrderSView>(transferOrder => transferOrder.Id == id).FirstOrDefaultAsync() ??
                  throw new ModelNotFoundException($"Not Found {nameof(TransferOrder)} with id {id}"));
    }
    [HttpGet]
    [SwaggerResponse(200, "TransferOrder view page", typeof(PagingResponse<TransferOrderSView>))]
    public async Task<ActionResult<PagingResponse<TransferOrderSView>>> Get(
        [FromQuery] FindTransferOrder request,
        [FromQuery] PagingRequest paging,
        [FromQuery] string? orderBy)
    {
        var (transferOrderViews, total) = await _transferOrderService.GetAsync<TransferOrderSView>(new GetRequest<TransferOrder>
        {
            FindRequest = request,
            OrderRequest = orderBy.ToOrderRequest<TransferOrder>(),
            PagingRequest = paging
        });

        return Ok((transferOrderViews, total).ToPagingResponse(paging));
    }

    [HttpPost]
    [SwaggerResponse(200, "Create TransferOrder", typeof(TransferOrder))]
    public async Task<ActionResult<TransferOrder>> Create([FromBody] CreateTransferOrder request, [FromClaim("StaffId")] int? staffId)
    {
        request.StaffId = staffId;
        return Ok(await _transferOrderService.CreateAsync(request));
    }
    [HttpPut("{id:int}")]
    [SwaggerResponse(200, "Update TransferOrder", typeof(TransferOrder))]
    public async Task<ActionResult<TransferOrder>> Update([FromBody] UpdateTransferOrder request, int id)
    {
        var transferOrderUpdate = await _transferOrderService.UpdateAsync(id, request);
        if (request.ApprovalStatus == ApprovalStatus.Approved)
        {
            var transferOrder = await _work.Get<TransferOrder>().GetAsync(id);
            if (transferOrder?.TransactionId != null)
            {
                if (transferOrder.ToLocationId != null)
                {
                    await _transactionService.UpdateVehicleLocationAsync(transferOrder.TransactionId.Value, transferOrder.ToLocationId.Value);
                }
                await _work.Get<Transaction>().UpdateFieldAsync(t => t.TransactionStatus, new Transaction()
                {
                    Id = transferOrder.TransactionId.Value,
                    TransactionStatus = TransactionStatus.Success
                });
            }
        }
        if (request.Transaction != null)
        {
            var transaction = await _transactionService.UpdateTransactionAsync(request.Transaction);
        }
        return Ok(transferOrderUpdate);
    }
    [HttpDelete("{id:int}")]
    [SwaggerResponse(200, "Soft Delete TransferOrder", typeof(TransferOrder))]
    public async Task<ActionResult<TransferOrder>> Delete(int id)
    {
        var transferOrder = await _transferOrderService.UpdateAsync(id, new SoftDeleteDto<TransferOrder>());
        if (transferOrder.TransactionId != null)
            await _work.Get<Transaction>().UpdateFieldAsync(t => t.TransactionStatus, new Transaction()
            {
                Id = transferOrder.TransactionId.Value,
                TransactionStatus = TransactionStatus.Success
            });
        return Ok(transferOrder);
    }

}

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
using VehicleReSell.Business.DTO.SaleOrderDto;
using VehicleReSell.Business.Service.Core;
using VehicleReSell.Data.Model;

namespace VehicleReSell.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class SaleOrderController : ControllerBase
{
    private readonly IServiceCrud<SaleOrder> _saleOrderService;
    private readonly IRepository<SaleOrder> _repo;
    private readonly ITransactionService _transactionService;
    private readonly IUnitOfWork _work;

    public SaleOrderController(IUnitOfWork work, ILogger<SaleOrderController> logger, ITransactionService transactionService)
    {
        _work = work;
        _transactionService = transactionService;
        _saleOrderService = new ServiceCrud<SaleOrder>(work, logger);
        _repo = work.Get<SaleOrder>();
    }

    [HttpGet("{id:int}")]
    [SwaggerResponse(200, "SaleOrder view", typeof(SaleOrderSView))]
    public async Task<ActionResult<SaleOrderSView>> Get(int id)
    {
        return Ok(await _repo.Find<SaleOrderSView>(saleOrder => saleOrder.Id == id).FirstOrDefaultAsync() ??
                  throw new ModelNotFoundException($"Not Found {nameof(SaleOrder)} with id {id}"));
    }
    [HttpGet]
    [SwaggerResponse(200, "SaleOrder view page", typeof(PagingResponse<SaleOrderSView>))]
    public async Task<ActionResult<PagingResponse<SaleOrderSView>>> Get(
        [FromQuery] FindSaleOrder request,
        [FromQuery] PagingRequest paging,
        [FromQuery] string? orderBy)
    {
        var (saleOrderViews, total) = await _saleOrderService.GetAsync<SaleOrderSView>(new GetRequest<SaleOrder>
        {
            FindRequest = request,
            OrderRequest = orderBy.ToOrderRequest<SaleOrder>(),
            PagingRequest = paging
        });

        return Ok((saleOrderViews, total).ToPagingResponse(paging));
    }

    [HttpPost]
    [SwaggerResponse(200, "SaleOrder", typeof(SaleOrder))]
    public async Task<ActionResult<SaleOrder>> Create([FromBody] CreateSaleOrder request, [FromClaim("SellerId")] int? sellerId)
    {
        request.SellerId = sellerId;
        var saleOrder = await _saleOrderService.CreateAsync(request);
        if (saleOrder.TransactionId != null)
        {
            await _transactionService.UpdateVehicleStatusAsync(saleOrder.TransactionId.Value,
                VehicleStatus.Inventory,
                VehicleStatus.Order);
        }
        return Ok(saleOrder);
    }
    [HttpPut("{id:int}")]
    [SwaggerResponse(200, "SaleOrder", typeof(SaleOrder))]
    public async Task<ActionResult<SaleOrder>> Update([FromBody] UpdateSaleOrder request, int id)
    {
        if (request.ApprovalStatus == ApprovalStatus.Approved)
        {
            var saleOrder = await _work.Get<SaleOrder>().GetAsync(id);
            if (saleOrder?.TransactionId != null)
            {
                await _transactionService.UpdateVehicleStatusAsync(saleOrder.TransactionId.Value,
                    VehicleStatus.Order,
                    VehicleStatus.Sold);
                await _work.Get<Transaction>().UpdateFieldAsync(t => t.TransactionStatus, new Transaction()
                {
                    Id = saleOrder.TransactionId.Value,
                    TransactionStatus = TransactionStatus.Success
                });
            }
        }
        var updated = await _saleOrderService.UpdateAsync(id, request);
        if (request.Transaction != null)
        {
            var transaction = await _transactionService.UpdateTransactionAsync(request.Transaction);
        }

        return Ok(updated);
    }
    [HttpDelete("{id:int}")]
    [SwaggerResponse(200, "SaleOrder", typeof(SaleOrder))]
    public async Task<ActionResult<SaleOrder>> Delete(int id)
    {
        var saleOrder = await _saleOrderService.UpdateAsync(id, new SoftDeleteDto<SaleOrder>());
        if (saleOrder.TransactionId != null)
            await _work.Get<Transaction>().UpdateFieldAsync(t => t.TransactionStatus, new Transaction()
            {
                Id = saleOrder.TransactionId.Value,
                TransactionStatus = TransactionStatus.Failed
            });
        return Ok(saleOrder);
    }

}

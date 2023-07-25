using CrudApiTemplate.CustomBinding;
using CrudApiTemplate.CustomException;
using CrudApiTemplate.Model;
using CrudApiTemplate.Repository;
using CrudApiTemplate.Request;
using CrudApiTemplate.Response;
using CrudApiTemplate.Services;
using CrudApiTemplate.Utilities;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VehicleReSell.Business.DTO.ItemReceiptDto;
using VehicleReSell.Business.Service.Core;
using VehicleReSell.Data.Model;

namespace VehicleReSell.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class ItemReceiptController : ControllerBase
{
    private readonly IServiceCrud<ItemReceipt> _itemReceiptService;
    private readonly IRepository<ItemReceipt> _repo;
    private readonly IUnitOfWork _work;
    private ITransactionService _transactionService;
    public ItemReceiptController(IUnitOfWork work, ILogger<ItemReceiptController> logger, ITransactionService transactionService)
    {
        _work = work;
        _transactionService = transactionService;
        _itemReceiptService = new ServiceCrud<ItemReceipt>(work, logger);
        _repo = work.Get<ItemReceipt>();
    }

    [HttpGet("{id:int}")]
    [SwaggerResponse(200, "ItemReceipt view", typeof(ItemReceiptSView))]
    public async Task<ActionResult<ItemReceiptSView>> Get(int id)
    {
        return Ok(await _repo.Find<ItemReceiptSView>(itemReceipt => itemReceipt.Id == id).FirstOrDefaultAsync() ??
                  throw new ModelNotFoundException($"Not Found {nameof(ItemReceipt)} with id {id}"));
    }
    [HttpGet]
    [SwaggerResponse(200, "ItemReceipt view page", typeof(PagingResponse<ItemReceiptSView>))]
    public async Task<ActionResult<PagingResponse<ItemReceiptSView>>> Get(
        [FromQuery] FindItemReceipt request,
        [FromQuery] PagingRequest paging,
        [FromQuery] string? orderBy)
    {
        var (itemReceiptViews, total) = await _itemReceiptService.GetAsync<ItemReceiptSView>(new GetRequest<ItemReceipt>
        {
            FindRequest = request,
            OrderRequest = orderBy.ToOrderRequest<ItemReceipt>(),
            PagingRequest = paging
        });

        return Ok((itemReceiptViews, total).ToPagingResponse(paging));
    }

    [HttpPost]
    [SwaggerResponse(200, "Create ItemReceipt", typeof(ItemReceipt))]
    public async Task<ActionResult<ItemReceiptSView>> Create([FromBody] CreateItemReceipt request, [FromClaim("StaffId")] int? staffId)
    {
        request.StaffId = staffId;
        return Ok((await _itemReceiptService.CreateAsync(request)).Adapt<ItemReceiptSView>());
    }
    [HttpPut("{id:int}")]
    [SwaggerResponse(200, "Update ItemReceipt", typeof(ItemReceipt))]
    public async Task<ActionResult<ItemReceipt>> Update([FromBody] UpdateItemReceipt request, int id)
    {
        if (request.ItemReceiptStatus == ItemReceiptStatus.Approved)
        {
            var itemReceipt = await _work.Get<ItemReceipt>().GetAsync(id);
            if (itemReceipt?.TransactionId != null)
            {
                await _transactionService.UpdateVehicleStatusAsync(itemReceipt.TransactionId.Value,
                    VehicleStatus.Draft,
                    VehicleStatus.Inventory);
                await _work.Get<Transaction>().UpdateFieldAsync(t => t.TransactionStatus, new Transaction()
                {
                    Id = itemReceipt.TransactionId.Value,
                    TransactionStatus = TransactionStatus.Success
                });
            }
        }
        if (request.Transaction != null)
        {
            var transaction = await _transactionService.UpdateTransactionAsync(request.Transaction);
        }
        return Ok(await _itemReceiptService.UpdateAsync(id, request));
    }
    [HttpDelete("{id:int}")]
    [SwaggerResponse(200, "Soft Delete ItemReceipt", typeof(ItemReceipt))]
    public async Task<ActionResult<ItemReceipt>> Delete(int id)
    {
        var itemReceipt = await _work.Get<ItemReceipt>().GetAsync(id);
        if (itemReceipt?.TransactionId != null)
        {
            await _work.Get<Transaction>().UpdateFieldAsync(t => t.TransactionStatus, new Transaction()
            {
                Id = itemReceipt.TransactionId.Value,
                TransactionStatus = TransactionStatus.Failed
            });
        }
        return Ok(await _itemReceiptService.UpdateAsync(id, new SoftDeleteDto<ItemReceipt>()));
    }

}

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
using VehicleReSell.Business.DTO.ItemReceiptDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemReceiptController : ControllerBase
{
    private readonly IServiceCrud<ItemReceipt> _itemReceiptService;
    private readonly IRepository<ItemReceipt> _repo;

    public ItemReceiptController(IUnitOfWork work, ILogger logger)
    {
        _itemReceiptService = new ServiceCrud<ItemReceipt>(work, logger);
        _repo = work.Get<ItemReceipt>();
    }

    [HttpGet("{id:int}")]
    [SwaggerResponse(200,"ItemReceipt view", typeof(ItemReceiptSView))]
    public async Task<ActionResult<ItemReceiptSView>> Get(int id)
    {
        return Ok(await _repo.Find<ItemReceiptSView>(itemReceipt => itemReceipt.Id == id).FirstOrDefaultAsync() ??
                  throw new ModelNotFoundException($"Not Found {nameof(ItemReceipt)} with id {id}"));
    }
    [HttpGet]
    [SwaggerResponse(200,"ItemReceipt view page", typeof(PagingResponse<ItemReceiptSView>))]
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
    [SwaggerResponse(200,"Create ItemReceipt", typeof(ItemReceipt))]
    public async Task<ActionResult<ItemReceipt>> Create([FromBody] CreateItemReceipt request)
    {
        return Ok(await _itemReceiptService.CreateAsync(request));
    }
    [HttpPut("{id:int}")] 
    [SwaggerResponse(200,"Update ItemReceipt", typeof(ItemReceipt))]
    public async Task<ActionResult<ItemReceipt>> Update([FromBody] UpdateItemReceipt request, int id)
    {
        return Ok(await _itemReceiptService.UpdateAsync(id, request));
    }
    [HttpDelete("{id:int}")]
    [SwaggerResponse(200,"Soft Delete ItemReceipt", typeof(ItemReceipt))]
    public async Task<ActionResult<ItemReceipt>> Delete(int id)
    {
        return Ok(await _itemReceiptService.UpdateAsync(id, new SoftDeleteDto<ItemReceipt>()));
    }

}

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
using VehicleReSell.Data.Model;

namespace VehicleReSell.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransferOrderController : ControllerBase
{
    private readonly IServiceCrud<TransferOrder> _transferOrderService;
    private readonly IRepository<TransferOrder> _repo;

    public TransferOrderController(IUnitOfWork work, ILogger<TransferOrderController> logger)
    {
        _transferOrderService = new ServiceCrud<TransferOrder>(work, logger);
        _repo = work.Get<TransferOrder>();
    }

    [HttpGet("{id:int}")]
    [SwaggerResponse(200,"TransferOrder view", typeof(TransferOrderSView))]
    public async Task<ActionResult<TransferOrderSView>> Get(int id)
    {
        return Ok(await _repo.Find<TransferOrderSView>(transferOrder => transferOrder.Id == id).FirstOrDefaultAsync() ??
                  throw new ModelNotFoundException($"Not Found {nameof(TransferOrder)} with id {id}"));
    }
    [HttpGet]
    [SwaggerResponse(200,"TransferOrder view page", typeof(PagingResponse<TransferOrderSView>))]
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
    [SwaggerResponse(200,"Create TransferOrder", typeof(TransferOrder))]
    public async Task<ActionResult<TransferOrder>> Create([FromBody] CreateTransferOrder request)
    {
        return Ok(await _transferOrderService.CreateAsync(request));
    }
    [HttpPut("{id:int}")] 
    [SwaggerResponse(200,"Update TransferOrder", typeof(TransferOrder))]
    public async Task<ActionResult<TransferOrder>> Update([FromBody] UpdateTransferOrder request, int id)
    {
        return Ok(await _transferOrderService.UpdateAsync(id, request));
    }
    [HttpDelete("{id:int}")]
    [SwaggerResponse(200,"Soft Delete TransferOrder", typeof(TransferOrder))]
    public async Task<ActionResult<TransferOrder>> Delete(int id)
    {
        return Ok(await _transferOrderService.UpdateAsync(id, new SoftDeleteDto<TransferOrder>()));
    }

}

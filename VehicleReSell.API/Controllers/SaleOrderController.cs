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
using VehicleReSell.Data.Model;

namespace VehicleReSell.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SaleOrderController : ControllerBase
{    private readonly IServiceCrud<SaleOrder> _saleOrderService;
    private readonly IRepository<SaleOrder> _repo;

    public SaleOrderController(IUnitOfWork work, ILogger logger)
    {
        _saleOrderService = new ServiceCrud<SaleOrder>(work, logger);
        _repo = work.Get<SaleOrder>();
    }

    [HttpGet("{id:int}")]
    [SwaggerResponse(200,"SaleOrder view", typeof(SaleOrderSView))]
    public async Task<ActionResult<SaleOrderSView>> Get(int id)
    {
        return Ok(await _repo.Find<SaleOrderSView>(saleOrder => saleOrder.Id == id).FirstOrDefaultAsync() ??
                  throw new ModelNotFoundException($"Not Found {nameof(SaleOrder)} with id {id}"));
    }
    [HttpGet]
    [SwaggerResponse(200,"SaleOrder view page", typeof(PagingResponse<SaleOrderSView>))]
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

        return Ok(( saleOrderViews, total).ToPagingResponse(paging));
    }

    [HttpPost]
    [SwaggerResponse(200,"SaleOrder", typeof(SaleOrder))]
    public async Task<ActionResult<SaleOrder>> Create([FromBody] CreateSaleOrder request)
    {
        return Ok(await _saleOrderService.CreateAsync(request));
    }
    [HttpPut("{id:int}")] 
    [SwaggerResponse(200,"SaleOrder", typeof(SaleOrder))]
    public async Task<ActionResult<SaleOrder>> Update([FromBody] UpdateSaleOrder request, int id)
    {
        return Ok(await _saleOrderService.UpdateAsync(id, request));
    }
    [HttpDelete("{id:int}")]
    [SwaggerResponse(200,"SaleOrder", typeof(SaleOrder))]
    public async Task<ActionResult<SaleOrder>> Delete(int id)
    {
        return Ok(await _saleOrderService.UpdateAsync(id, new SoftDeleteDto<SaleOrder>()));
    }

}

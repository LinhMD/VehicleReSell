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
using VehicleReSell.Business.DTO.WareHouseDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class WareHouseController : ControllerBase
{    
    private readonly IServiceCrud<WareHouse> _wareHouseService;
    private readonly IRepository<WareHouse> _repo;

    public WareHouseController(IUnitOfWork work, ILogger<WareHouseController> logger)
    {
        _wareHouseService = new ServiceCrud<WareHouse>(work, logger);
        _repo = work.Get<WareHouse>();
    }

    [HttpGet("{id:int}")]
    [SwaggerResponse(200,"WareHouse view", typeof(WareHouseView))]
    public async Task<ActionResult<WareHouseView>> Get(int id)
    {
        return Ok(await _repo.Find<WareHouseView>(wareHouse => wareHouse.Id == id).FirstOrDefaultAsync() ??
                  throw new ModelNotFoundException($"Not Found {nameof(WareHouse)} with id {id}"));
    }
    [HttpGet]
    [SwaggerResponse(200,"WareHouse view page", typeof(PagingResponse<WareHouseView>))]
    public async Task<ActionResult<PagingResponse<WareHouseView>>> Get(
        [FromQuery] FindWareHouse request,
        [FromQuery] PagingRequest paging,
        [FromQuery] string? orderBy)
    {
        var (WareHouseViews, total) = await _wareHouseService.GetAsync<WareHouseView>(new GetRequest<WareHouse>
        {
            FindRequest = request,
            OrderRequest = orderBy.ToOrderRequest<WareHouse>(),
            PagingRequest = paging
        });

        return Ok((WareHouseViews, total).ToPagingResponse(paging));
    }

    [HttpPost]
    [SwaggerResponse(200,"Create WareHouse", typeof(WareHouse))]
    public async Task<ActionResult<WareHouse>> Create([FromBody] CreateWareHouse request)
    {
        return Ok(await _wareHouseService.CreateAsync(request));
    }
    [HttpPut("{id:int}")] 
    [SwaggerResponse(200,"Update WareHouse", typeof(WareHouse))]
    public async Task<ActionResult<WareHouse>> Update([FromBody] UpdateWareHouse request, int id)
    {
        return Ok(await _wareHouseService.UpdateAsync(id, request));
    }
    [HttpDelete("{id:int}")]
    [SwaggerResponse(200,"Soft Delete WareHouse", typeof(WareHouse))]
    public async Task<ActionResult<WareHouse>> Delete(int id)
    {
        return Ok(await _wareHouseService.UpdateAsync(id, new SoftDeleteDto<WareHouse>()));
    }

}

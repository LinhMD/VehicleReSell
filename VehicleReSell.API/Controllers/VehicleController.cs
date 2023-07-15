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
using VehicleReSell.Business.DTO.VehicleDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class VehicleController : ControllerBase
{
    private readonly IServiceCrud<Vehicle> _vehicleService;
    private readonly IRepository<Vehicle> _repo;
    private readonly IUnitOfWork _work;

    public VehicleController(IUnitOfWork work, ILogger<VehicleController> logger)
    {
        _work = work;
        _vehicleService = new ServiceCrud<Vehicle>(work, logger);
        _repo = work.Get<Vehicle>();
    }

    [HttpGet("{id:int}")]
    [SwaggerResponse(200,"Vehicle view", typeof(VehicleView))]
    public async Task<ActionResult<VehicleView>> Get(int id)
    {
        return Ok(await _repo.Find<VehicleView>(vehicle => vehicle.Id == id).FirstOrDefaultAsync() ??
                  throw new ModelNotFoundException($"Not Found {nameof(Vehicle)} with id {id}"));
    }
    [HttpGet]
    [SwaggerResponse(200,"Vehicle view page", typeof(PagingResponse<VehicleView>))]
    public async Task<ActionResult<PagingResponse<VehicleView>>> Get(
        [FromQuery] FindVehicle request,
        [FromQuery] PagingRequest paging,
        [FromQuery] string? orderBy)
    {
        var (vehicleViews, total) = await _vehicleService.GetAsync<VehicleView>(new GetRequest<Vehicle>
        {
            FindRequest = request,
            OrderRequest = orderBy.ToOrderRequest<Vehicle>(),
            PagingRequest = paging
        });

        return Ok(( vehicleViews, total).ToPagingResponse(paging));
    }

    [HttpPost]
    [SwaggerResponse(200,"Create Vehicle", typeof(Vehicle))]
    public async Task<ActionResult<Vehicle>> Create([FromBody] CreateVehicle request)
    {
        var vehicle = await _vehicleService.CreateAsync(request);

        await _work.Get<VehicleImg>().AddAllAsync(request.VehicleImgs.Select(i => new VehicleImg()
        {
            VehicleId = vehicle.Id,
            Image = i
        }));
        return Ok(await _vehicleService.GetAsync<VehicleView>(vehicle.Id));
    }
    [HttpPut("{id:int}")] 
    [SwaggerResponse(200,"Update Vehicle", typeof(Vehicle))]
    public async Task<ActionResult<Vehicle>> Update([FromBody] UpdateVehicle request, int id)
    {
        return Ok(await _vehicleService.UpdateAsync(id, request));
    }
    [HttpDelete("{id:int}")]
    [SwaggerResponse(200,"Soft Delete Vehicle", typeof(Vehicle))]
    public async Task<ActionResult<Vehicle>> Delete(int id)
    {
        return Ok(await _vehicleService.UpdateAsync(id, new SoftDeleteDto<Vehicle>()));
    }

}

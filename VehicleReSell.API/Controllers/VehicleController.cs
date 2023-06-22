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
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{
        private readonly IServiceCrud<Vehicle> _vehicleService;
    private readonly IRepository<Vehicle> _repo;

    public VehicleController(IUnitOfWork work, ILogger<VehicleController> logger)
    {
        _vehicleService = new ServiceCrud<Vehicle>(work, logger);
        _repo = work.Get<Vehicle>();
    }

    [HttpGet("{id:int}")]
    [SwaggerResponse(200,"Vehicle view", typeof(VehicleSView))]
    public async Task<ActionResult<VehicleSView>> Get(int id)
    {
        return Ok(await _repo.Find<VehicleSView>(vehicle => vehicle.Id == id).FirstOrDefaultAsync() ??
                  throw new ModelNotFoundException($"Not Found {nameof(Vehicle)} with id {id}"));
    }
    [HttpGet]
    [SwaggerResponse(200,"Vehicle view page", typeof(PagingResponse<VehicleSView>))]
    public async Task<ActionResult<PagingResponse<VehicleSView>>> Get(
        [FromQuery] FindVehicle request,
        [FromQuery] PagingRequest paging,
        [FromQuery] string? orderBy)
    {
        var (vehicleViews, total) = await _vehicleService.GetAsync<VehicleSView>(new GetRequest<Vehicle>
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
        return Ok(await _vehicleService.CreateAsync(request));
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

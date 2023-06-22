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
using VehicleReSell.Business.DTO.VehicleOwnerDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleOwnerController : ControllerBase
{    
    private readonly IServiceCrud<VehicleOwner> _vehicleOwnerService;
    private readonly IRepository<VehicleOwner> _repo;

    public VehicleOwnerController(IUnitOfWork work, ILogger<VehicleOwnerController> logger)
    {
        _vehicleOwnerService = new ServiceCrud<VehicleOwner>(work, logger);
        _repo = work.Get<VehicleOwner>();
    }

    [HttpGet("{id:int}")]
    [SwaggerResponse(200,"VehicleOwner view", typeof(VehicleOwnerSView))]
    public async Task<ActionResult<VehicleOwnerSView>> Get(int id)
    {
        return Ok(await _repo.Find<VehicleOwnerSView>(vehicleOwner => vehicleOwner.Id == id).FirstOrDefaultAsync() ??
                  throw new ModelNotFoundException($"Not Found {nameof(VehicleOwner)} with id {id}"));
    }
    [HttpGet]
    [SwaggerResponse(200,"VehicleOwner view page", typeof(PagingResponse<VehicleOwnerSView>))]
    public async Task<ActionResult<PagingResponse<VehicleOwnerSView>>> Get(
        [FromQuery] FindVehicleOwner request,
        [FromQuery] PagingRequest paging,
        [FromQuery] string? orderBy)
    {
        var (vehicleOwnerViews, total) = await _vehicleOwnerService.GetAsync<VehicleOwnerSView>(new GetRequest<VehicleOwner>
        {
            FindRequest = request,
            OrderRequest = orderBy.ToOrderRequest<VehicleOwner>(),
            PagingRequest = paging
        });

        return Ok(( vehicleOwnerViews, total).ToPagingResponse(paging));
    }

    [HttpPost]
    [SwaggerResponse(200,"Create VehicleOwner", typeof(VehicleOwner))]
    public async Task<ActionResult<VehicleOwner>> Create([FromBody] CreateVehicleOwner request)
    {
        return Ok(await _vehicleOwnerService.CreateAsync(request));
    }
    [HttpPut("{id:int}")] 
    [SwaggerResponse(200,"Update VehicleOwner", typeof(VehicleOwner))]
    public async Task<ActionResult<VehicleOwner>> Update([FromBody] UpdateVehicleOwner request, int id)
    {
        return Ok(await _vehicleOwnerService.UpdateAsync(id, request));
    }
    [HttpDelete("{id:int}")]
    [SwaggerResponse(200,"Soft Delete VehicleOwner", typeof(VehicleOwner))]
    public async Task<ActionResult<VehicleOwner>> Delete(int id)
    {
        return Ok(await _vehicleOwnerService.UpdateAsync(id, new SoftDeleteDto<VehicleOwner>()));
    }

}

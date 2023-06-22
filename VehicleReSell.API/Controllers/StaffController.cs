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
using VehicleReSell.Business.DTO.StaffDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StaffController : ControllerBase
{    
    private readonly IServiceCrud<Staff> _staffService;
    private readonly IRepository<Staff> _repo;

    public StaffController(IUnitOfWork work, ILogger logger)
    {
        _staffService = new ServiceCrud<Staff>(work, logger);
        _repo = work.Get<Staff>();
    }

    [HttpGet("{id:int}")]
    [SwaggerResponse(200,"Staff view", typeof(StaffSView))]
    public async Task<ActionResult<StaffSView>> Get(int id)
    {
        return Ok(await _repo.Find<StaffSView>(staff => staff.Id == id).FirstOrDefaultAsync() ??
                  throw new ModelNotFoundException($"Not Found {nameof(Staff)} with id {id}"));
    }
    [HttpGet]
    [SwaggerResponse(200,"Staff view page", typeof(PagingResponse<StaffSView>))]
    public async Task<ActionResult<PagingResponse<StaffSView>>> Get(
        [FromQuery] FindStaff request,
        [FromQuery] PagingRequest paging,
        [FromQuery] string? orderBy)
    {
        var (staffViews, total) = await _staffService.GetAsync<StaffSView>(new GetRequest<Staff>
        {
            FindRequest = request,
            OrderRequest = orderBy.ToOrderRequest<Staff>(),
            PagingRequest = paging
        });

        return Ok(( staffViews, total).ToPagingResponse(paging));
    }

    [HttpPost]
    [SwaggerResponse(200,"Create Staff", typeof(Staff))]
    public async Task<ActionResult<Staff>> Create([FromBody] CreateStaff request)
    {
        return Ok(await _staffService.CreateAsync(request));
    }
    [HttpPut("{id:int}")] 
    [SwaggerResponse(200,"Update Staff", typeof(Staff))]
    public async Task<ActionResult<Staff>> Update([FromBody] UpdateStaff request, int id)
    {
        return Ok(await _staffService.UpdateAsync(id, request));
    }
    [HttpDelete("{id:int}")]
    [SwaggerResponse(200,"Soft Delete Staff", typeof(Staff))]
    public async Task<ActionResult<Staff>> Delete(int id)
    {
        return Ok(await _staffService.UpdateAsync(id, new SoftDeleteDto<Staff>()));
    }

}

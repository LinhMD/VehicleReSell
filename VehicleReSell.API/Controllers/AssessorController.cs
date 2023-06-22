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
using VehicleReSell.Business.DTO.AssessorDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssessorController: ControllerBase
{
    private readonly IServiceCrud<Assessor> _assessorService;
    private readonly IRepository<Assessor> _repo;

    public AssessorController(IUnitOfWork work, ILogger<AssessorController> logger)
    {
        _assessorService = new ServiceCrud<Assessor>(work, logger);
        _repo = work.Get<Assessor>();
    }

    [HttpGet("{id:int}")]
    [SwaggerResponse(200,"Assessor view", typeof(AssessorSView))]
    public async Task<ActionResult<AssessorSView>> Get(int id)
    {
        return Ok(await _repo.Find<AssessorSView>(assessor => assessor.Id == id).FirstOrDefaultAsync() ??
                  throw new ModelNotFoundException($"Not Found {nameof(Assessor)} with id {id}"));
    }
    [HttpGet]
    [SwaggerResponse(200,"Assessor view page", typeof(PagingResponse<AssessorSView>))]
    public async Task<ActionResult<PagingResponse<AssessorSView>>> Get(
        [FromQuery] FindAssessor request,
        [FromQuery] PagingRequest paging,
        [FromQuery] string? orderBy)
    {
        var (assessorViews, total) = await _assessorService.GetAsync<AssessorSView>(new GetRequest<Assessor>
        {
            FindRequest = request,
            OrderRequest = orderBy.ToOrderRequest<Assessor>(),
            PagingRequest = paging
        });

        return Ok((assessorViews, total).ToPagingResponse(paging));
    }

    [HttpPost]
    [SwaggerResponse(200,"Assessor", typeof(Assessor))]
    public async Task<ActionResult<Assessor>> Create([FromBody] CreateAssessor request)
    {
        return Ok(await _assessorService.CreateAsync(request));
    }
    [HttpPut("{id:int}")] 
    [SwaggerResponse(200,"Assessor", typeof(Assessor))]
    public async Task<ActionResult<Assessor>> Update([FromBody] UpdateAssessor request, int id)
    {
        return Ok(await _assessorService.UpdateAsync(id, request));
    }
    [HttpDelete("{id:int}")]
    [SwaggerResponse(200,"Assessor", typeof(Assessor))]
    public async Task<ActionResult<Assessor>> Delete(int id)
    {
        return Ok(await _assessorService.UpdateAsync(id, new SoftDeleteDto<Assessor>()));
    }
}
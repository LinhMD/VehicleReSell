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
using VehicleReSell.Business.DTO.CustomerEventDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class CustomerEventController : ControllerBase
{
        private readonly IServiceCrud<CustomerEvent> _customerEventService;
    private readonly IRepository<CustomerEvent> _repo;

    public CustomerEventController(IUnitOfWork work, ILogger<CustomerEventController> logger)
    {
        _customerEventService = new ServiceCrud<CustomerEvent>(work, logger);
        _repo = work.Get<CustomerEvent>();
    }

    [HttpGet("{id:int}")]
    [SwaggerResponse(200,"CustomerEvent view", typeof(CustomerEventSView))]
    public async Task<ActionResult<CustomerEventSView>> Get(int id)
    {
        return Ok(await _repo.Find<CustomerEventSView>(customerEvent => customerEvent.Id == id).FirstOrDefaultAsync() ??
                  throw new ModelNotFoundException($"Not Found {nameof(CustomerEvent)} with id {id}"));
    }
    
    [HttpGet]
    [SwaggerResponse(200,"CustomerEvent view page", typeof(PagingResponse<CustomerEventSView>))]
    public async Task<ActionResult<PagingResponse<CustomerEventSView>>> Get(
        [FromQuery] FindCustomerEvent request,
        [FromQuery] PagingRequest paging,
        [FromQuery] string? orderBy)
    {
        var (customerEventViews, total) = await _customerEventService.GetAsync<CustomerEventSView>(new GetRequest<CustomerEvent>
        {
            FindRequest = request,
            OrderRequest = orderBy.ToOrderRequest<CustomerEvent>(),
            PagingRequest = paging
        });

        return Ok((customerEventViews, total).ToPagingResponse(paging));
    }

    [HttpPost]
    [SwaggerResponse(200,"Create CustomerEvent", typeof(CustomerEvent))]
    public async Task<ActionResult<CustomerEventSView>> Create([FromBody] CreateCustomerEvent request)
    {
        return Ok((await _customerEventService.CreateAsync(request)).Adapt<CustomerEventSView>());
    }
    
    [HttpPut("{id:int}")] 
    [SwaggerResponse(200,"Update CustomerEvent", typeof(CustomerEvent))]
    public async Task<ActionResult<CustomerEvent>> Update([FromBody] UpdateCustomerEvent request, int id)
    {
        return Ok(await _customerEventService.UpdateAsync(id, request));
    }
    
    [HttpDelete("{id:int}")]
    [SwaggerResponse(200,"Soft Delete CustomerEvent", typeof(CustomerEvent))]
    public async Task<ActionResult<CustomerEvent>> Delete(int id)
    {
        return Ok(await _customerEventService.UpdateAsync(id, new SoftDeleteDto<CustomerEvent>()));
    }

}
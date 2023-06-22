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
using VehicleReSell.Business.DTO.CustomerDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController: ControllerBase
{
    private readonly IServiceCrud<Customer> _customerService;
    private readonly IRepository<Customer> _repo;

    public CustomerController(IUnitOfWork work, ILogger logger)
    {
        _customerService = new ServiceCrud<Customer>(work, logger);
        _repo = work.Get<Customer>();
    }

    [HttpGet("{id:int}")]
    [SwaggerResponse(200,"Customer view", typeof(CustomerSView))]
    public async Task<ActionResult<CustomerSView>> Get(int id)
    {
        return Ok(await _repo.Find<CustomerSView>(customer => customer.Id == id).FirstOrDefaultAsync() ??
                  throw new ModelNotFoundException($"Not Found {nameof(Customer)} with id {id}"));
    }
    [HttpGet]
    [SwaggerResponse(200,"Customer view page", typeof(PagingResponse<CustomerSView>))]
    public async Task<ActionResult<PagingResponse<CustomerSView>>> Get(
        [FromQuery] FindCustomer request,
        [FromQuery] PagingRequest paging,
        [FromQuery] string? orderBy)
    {
        var (customerViews, total) = await _customerService.GetAsync<CustomerSView>(new GetRequest<Customer>
        {
            FindRequest = request,
            OrderRequest = orderBy.ToOrderRequest<Customer>(),
            PagingRequest = paging
        });

        return Ok((customerViews, total).ToPagingResponse(paging));
    }

    [HttpPost]
    [SwaggerResponse(200,"Customer", typeof(Customer))]
    public async Task<ActionResult<Customer>> Create([FromBody] CreateCustomer request)
    {
        return Ok(await _customerService.CreateAsync(request));
    }
    [HttpPut("{id:int}")] 
    [SwaggerResponse(200,"Customer", typeof(Customer))]
    public async Task<ActionResult<Customer>> Update([FromBody] UpdateCustomer request, int id)
    {
        return Ok(await _customerService.UpdateAsync(id, request));
    }
    [HttpDelete("{id:int}")]
    [SwaggerResponse(200,"Customer", typeof(Customer))]
    public async Task<ActionResult<Customer>> Delete(int id)
    {
        return Ok(await _customerService.UpdateAsync(id, new SoftDeleteDto<Customer>()));
    }

}

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
using VehicleReSell.Business.DTO.TransactionDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.API.Controllers;
[ApiController]
[Route("api/[controller]s")]
public class TransactionController: ControllerBase
{
    private readonly IServiceCrud<Transaction> _transactionService;
    private readonly IRepository<Transaction> _repo;

    public TransactionController(IUnitOfWork work, ILogger<TransactionController> logger)
    {
        _transactionService = new ServiceCrud<Transaction>(work, logger);
        _repo = work.Get<Transaction>();
    }

    [HttpGet("{id:int}")]
    [SwaggerResponse(200,"Transaction view", typeof(TransactionSView))]
    public async Task<ActionResult<TransactionSView>> Get(int id)
    {
        return Ok(await _repo.Find<TransactionSView>(t => t.Id == id).FirstOrDefaultAsync() ??
                  throw new ModelNotFoundException($"Not Found {nameof(Transaction)} with id {id}"));
    }
    [HttpGet]
    [SwaggerResponse(200,"Transaction view page", typeof(PagingResponse<TransactionSView>))]
    public async Task<ActionResult<PagingResponse<TransactionSView>>> Get(
        [FromQuery] FindTransaction request,
        [FromQuery] PagingRequest paging,
        [FromQuery] string? orderBy)
    {
        var (transactionViews, total) = await _transactionService.GetAsync<TransactionSView>(new GetRequest<Transaction>
        {
            FindRequest = request,
            OrderRequest = orderBy.ToOrderRequest<Transaction>(),
            PagingRequest = paging
        });

        return Ok((transactionViews, total).ToPagingResponse(paging));
    }

    [HttpPost]
    [SwaggerResponse(200,"Transaction", typeof(Transaction))]
    public async Task<ActionResult<Transaction>> Create([FromBody] CreateTransaction request)
    {
        return Ok(await _transactionService.CreateAsync(request));
    }
    [HttpPut("{id:int}")] 
    [SwaggerResponse(200,"Transaction", typeof(Transaction))]
    public async Task<ActionResult<Transaction>> Update([FromBody] UpdateTransaction request, int id)
    {
        return Ok(await _transactionService.UpdateAsync(id, request));
    }
    // [HttpDelete("{id:int}")]
    // [SwaggerResponse(200,"Transaction", typeof(Transaction))]
    // public async Task<ActionResult<Transaction>> Delete(int id)
    // {
    //     return Ok(await _transactionService.UpdateAsync(id, new SoftDeleteDto<Transaction>()));
    // }

}
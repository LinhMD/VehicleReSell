using CrudApiTemplate.CustomException;
using CrudApiTemplate.Repository;
using CrudApiTemplate.Request;
using CrudApiTemplate.Response;
using CrudApiTemplate.Services;
using CrudApiTemplate.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VehicleReSell.Business.DTO.TransactionLineDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.API.Controllers;
[ApiController]
[Route("api/[controller]s")]
public class TransactionLineController: ControllerBase
{
    private readonly IServiceCrud<TransactionLine> _transactionLineService;
    private readonly IRepository<TransactionLine> _repo;

    public TransactionLineController(IUnitOfWork work, ILogger<TransactionLineController> logger)
    {
        _transactionLineService = new ServiceCrud<TransactionLine>(work, logger);
        _repo = work.Get<TransactionLine>();
    }
    [HttpGet("{id:int}")]
    [SwaggerResponse(200,"Transaction view", typeof(LineView))]
    public async Task<ActionResult<LineView>> Get(int id)
    {
        return Ok(await _repo.Find<LineView>(t => t.Id == id).FirstOrDefaultAsync() ??
                  throw new ModelNotFoundException($"Not Found {nameof(TransactionLine)} with id {id}"));
    }
    [HttpGet]
    [SwaggerResponse(200,"Transaction view page", typeof(PagingResponse<LineView>))]
    public async Task<ActionResult<PagingResponse<LineView>>> Get(
        [FromQuery] FindLine request,
        [FromQuery] PagingRequest paging,
        [FromQuery] string? orderBy)
    {
        var (transactionViews, total) = await _transactionLineService.GetAsync<LineView>(new GetRequest<TransactionLine>
        {
            FindRequest = request,
            OrderRequest = orderBy.ToOrderRequest<TransactionLine>(),
            PagingRequest = paging
        });

        return Ok((transactionViews, total).ToPagingResponse(paging));
    }
    [HttpPut("{id:int}")] 
    [SwaggerResponse(200,"TransactionLine", typeof(TransactionLine))]
    public async Task<ActionResult<TransactionLine>> Update([FromBody] UpdateLine request, int id)
    {
        return Ok(await _transactionLineService.UpdateAsync(id, request));
    }

}
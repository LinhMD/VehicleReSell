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
using VehicleReSell.Business.DTO.SellerDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SellerController : ControllerBase
{
    private readonly IServiceCrud<Seller> _sellerService;
    private readonly IRepository<Seller> _repo;

    public SellerController(IUnitOfWork work, ILogger<SellerController> logger)
    {
        _sellerService = new ServiceCrud<Seller>(work, logger);
        _repo = work.Get<Seller>();
    }

    [HttpGet("{id:int}")]
    [SwaggerResponse(200,"Seller view", typeof(SellerSView))]
    public async Task<ActionResult<SellerSView>> Get(int id)
    {
        return Ok(await _repo.Find<SellerSView>(seller => seller.Id == id).FirstOrDefaultAsync() ??
                  throw new ModelNotFoundException($"Not Found {nameof(Seller)} with id {id}"));
    }
    [HttpGet]
    [SwaggerResponse(200,"Seller view page", typeof(PagingResponse<SellerSView>))]
    public async Task<ActionResult<PagingResponse<SellerSView>>> Get(
        [FromQuery] FindSeller request,
        [FromQuery] PagingRequest paging,
        [FromQuery] string? orderBy)
    {
        var (sellerViews, total) = await _sellerService.GetAsync<SellerSView>(new GetRequest<Seller>
        {
            FindRequest = request,
            OrderRequest = orderBy.ToOrderRequest<Seller>(),
            PagingRequest = paging
        });

        return Ok((sellerViews, total).ToPagingResponse(paging));
    }

    [HttpPost]
    [SwaggerResponse(200,"Create Seller", typeof(Seller))]
    public async Task<ActionResult<Seller>> Create([FromBody] CreateSeller request)
    {
        return Ok(await _sellerService.CreateAsync(request));
    }
    [HttpPut("{id:int}")] 
    [SwaggerResponse(200,"Update Seller", typeof(Seller))]
    public async Task<ActionResult<Seller>> Update([FromBody] UpdateSeller request, int id)
    {
        return Ok(await _sellerService.UpdateAsync(id, request));
    }
    [HttpDelete("{id:int}")]
    [SwaggerResponse(200,"Soft Delete Seller", typeof(Seller))]
    public async Task<ActionResult<Seller>> Delete(int id)
    {
        return Ok(await _sellerService.UpdateAsync(id, new SoftDeleteDto<Seller>()));
    }

}

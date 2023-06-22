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
using VehicleReSell.Business.DTO.UserDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
        private readonly IServiceCrud<User> _userService;
    private readonly IRepository<User> _repo;

    public UserController(IUnitOfWork work, ILogger<UserController> logger)
    {
        _userService = new ServiceCrud<User>(work, logger);
        _repo = work.Get<User>();
    }

    [HttpGet("{id:int}")]
    [SwaggerResponse(200,"User view", typeof(UserSView))]
    public async Task<ActionResult<UserSView>> Get(int id)
    {
        return Ok(await _repo.Find<UserSView>(User => User.Id == id).FirstOrDefaultAsync() ??
                  throw new ModelNotFoundException($"Not Found {nameof(User)} with id {id}"));
    }
    [HttpGet]
    [SwaggerResponse(200,"User view page", typeof(PagingResponse<UserSView>))]
    public async Task<ActionResult<PagingResponse<UserSView>>> Get(
        [FromQuery] FindUser request,
        [FromQuery] PagingRequest paging,
        [FromQuery] string? orderBy)
    {
        var (userViews, total) = await _userService.GetAsync<UserSView>(new GetRequest<User>
        {
            FindRequest = request,
            OrderRequest = orderBy.ToOrderRequest<User>(),
            PagingRequest = paging
        });

        return Ok(( userViews, total).ToPagingResponse(paging));
    }

    [HttpPost]
    [SwaggerResponse(200,"Create User", typeof(User))]
    public async Task<ActionResult<User>> Create([FromBody] CreateUser request)
    {
        return Ok(await _userService.CreateAsync(request));
    }
    [HttpPut("{id:int}")] 
    [SwaggerResponse(200,"Update User", typeof(User))]
    public async Task<ActionResult<User>> Update([FromBody] UpdateUser request, int id)
    {
        return Ok(await _userService.UpdateAsync(id, request));
    }
    [HttpDelete("{id:int}")]
    [SwaggerResponse(200,"Soft Delete User", typeof(User))]
    public async Task<ActionResult<User>> Delete(int id)
    {
        return Ok(await _userService.UpdateAsync(id, new SoftDeleteDto<User>()));
    }

}

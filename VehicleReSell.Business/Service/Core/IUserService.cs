using CrudApiTemplate.Model;
using CrudApiTemplate.Services;
using VehicleReSell.Business.DTO.UserDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.Service.Core;

public interface IUserService : IServiceCrud<User>
{
    public Task<UserSView> SignUpAsync(UserSignUp signUp, string hash, string salt, ModelStatus status = ModelStatus.Active);

}
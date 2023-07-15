using CrudApiTemplate.CustomException;
using CrudApiTemplate.Model;
using CrudApiTemplate.Repository;
using CrudApiTemplate.Services;
using CrudApiTemplate.Utilities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VehicleReSell.Business.DTO.AssessorDto;
using VehicleReSell.Business.DTO.SellerDto;
using VehicleReSell.Business.DTO.StaffDto;
using VehicleReSell.Business.DTO.UserDto;
using VehicleReSell.Business.Service.Core;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.Service.Implement;

public class UserService : ServiceCrud<User>, IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly IServiceCrud<Assessor> _assessorService;
    private readonly IServiceCrud<Seller> _sellerService;
    private readonly IServiceCrud<Staff> _staffService;
    public UserService(IUnitOfWork work, ILogger<UserService> logger) : base(work, logger)
    {
        _assessorService = new ServiceCrud<Assessor>(work, logger);
        
        _sellerService = new ServiceCrud<Seller>(work, logger);
        
        _staffService = new ServiceCrud<Staff>(work, logger);
        _logger = logger;
    }

    public async Task<UserSView> SignUpAsync(UserSignUp signUp, string hash, string salt, ModelStatus status = ModelStatus.Active)
    {
        var user = new User
        {
            Email = signUp.Email,
            UserName = signUp.UserName,
            Role = signUp.Role,
            Hash = hash,
            Salt = salt,
            Status = status,
            Phone = signUp.PhoneNumber
        };

        user.Validate();

        try
        {
            user = await Repository.AddAsync(user);

            switch (user.Role)
            {
                case Role.Assessor:
                    var createAssessor = new CreateAssessor()
                    {
                        Phone = user.Phone ?? "",
                        Address = null ?? "",
                        Name = user.UserName,
                        UserId = user.Id,
                    };
                    await _assessorService.CreateAsync(createAssessor);
                    break;
                case Role.Seller:
                    var createSeller = new CreateSeller()
                    {
                        Phone = user.Phone ?? "",
                        Address = null ?? "",
                        Name = user.UserName,
                        UserId = user.Id
                    };
                    await _sellerService.CreateAsync(createSeller);
                    break;
                case Role.Staff:
                    var createStaff = new CreateStaff()
                    {
                        Phone = user.Phone ?? "",
                        Address = null ?? "",
                        Name = user.UserName,
                        UserId = user.Id
                    };
                    await _staffService.CreateAsync(createStaff);
                    break;
                default:
                    
                    break;
            }
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e.InnerException, e.InnerException?.StackTrace ?? e.StackTrace);
            var exceptionMessage = e.InnerException?.Message ?? "";

            if (exceptionMessage.Contains("duplicate"))
            {
                var dupValue = exceptionMessage.Substring(exceptionMessage.IndexOf('(') + 1,
                    (exceptionMessage.IndexOf(')') - exceptionMessage.IndexOf('(') - 1));
                throw new DbQueryException($"Duplicate value: {dupValue}", DbError.Create);
            }

            throw new DbQueryException($"Error create {nameof(User)}  with message: {exceptionMessage}.", DbError.Create);
        }

        var view = user.Adapt<UserSView>();

        return view;
    }

    
    
}
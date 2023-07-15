using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using CrudApiTemplate.Model;
using CrudApiTemplate.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VehicleReSell.Business.DTO.LoginDto;
using VehicleReSell.Business.DTO.UserDto;
using VehicleReSell.Business.Service.Core;
using VehicleReSell.Data.Model;

namespace VehicleReSell.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _work;
    private readonly IConfiguration _config;

    public LoginController(IUserService userService, IUnitOfWork work, IConfiguration config)
    {
        _userService = userService;
        _work = work;
        _config = config;
    }
    [HttpGet]
    public async Task<IActionResult> GetUser(string username)
    {
        var user = await _work.Get<User>().Find(u => u.UserName == username && u.Status == ModelStatus.Active)
            .FirstOrDefaultAsync();
        
        return user == null ? BadRequest("User not found") : Ok(LoginHelper.GenerateJwt(user, _config, await LoginHelper.GetAdditionalClaims(user, _work)));
    }

    [HttpPost("signup")]
    public async Task<ActionResult<UserSView>> SignUpUser([FromBody]UserSignUp userSignUp)
    {
        var salt = LoginHelper.GenerateSalt();
        var hash = LoginHelper.ComputeHash(
            Encoding.UTF8.GetBytes(userSignUp.Password),
            Encoding.UTF8.GetBytes(salt));

        var userView = await _userService.SignUpAsync(userSignUp, hash, salt);
        return Ok(userView);
    }
    
    [HttpPost]
    public async Task<IActionResult> LoginWithPassword(LoginRequest request)
    {
        var repository = _work.Get<User>();
        var user = await repository.Find(user => user.Email == request.Email && user.Status == ModelStatus.Active).FirstOrDefaultAsync();
        if (user == null)
            return NotFound("User not found with email: " + request.Email);

        var hash = LoginHelper.ComputeHash(Encoding.UTF8.GetBytes(request.Password),
            Encoding.UTF8.GetBytes(user!.Salt ?? ""));
        if (hash != user.Hash)
            return Unauthorized("Wrong password");

        return Ok(LoginHelper.GenerateJwt(user, _config, await LoginHelper.GetAdditionalClaims(user, _work)));
    }

    
    private static class LoginHelper
    {
        public static string GenerateSalt()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(16));
        }

        public static async Task<IDictionary<string, string?>> GetAdditionalClaims(User? user, IUnitOfWork work)
        {
            var claims = new Dictionary<string, string?>();
            var keys = new List<string>()
            {
                "SellerId",
                "AssessorId",
                "StaffId",
            };
            switch (user?.Role)
            {
                case Role.Seller:
                    var seller = await work.Get<Seller>().Find(s => s.UserId == user.Id).FirstOrDefaultAsync();
                    claims.Add("SellerId", seller?.Id.ToString());
                    break;
                case Role.Staff:
                    var staff = await work.Get<Staff>().Find(s => s.UserId == user.Id).FirstOrDefaultAsync();
                    claims.Add("StaffId", staff?.Id.ToString());
                    break;
                case Role.Assessor:
                    var assessor = await work.Get<Assessor>().Find(s => s.UserId == user.Id).FirstOrDefaultAsync();
                    claims.Add("AssessorId", assessor?.Id.ToString());
                    break;
            }
            return claims;
        }
        public static string ComputeHash(byte[] password, byte[] salt)
        {
            var byteResult = new Rfc2898DeriveBytes(password, salt, 10000);
            return Convert.ToBase64String(byteResult.GetBytes(24));
        }


        public static string GenerateJwt(User user, IConfiguration configuration, IDictionary<string, string?>? additionalClaims = null)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSetting:SecurityKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            
            var claims = new List<Claim>()
            {
                new("Id", user.Id.ToString()),
                new(ClaimTypes.NameIdentifier,user.UserName),
                new(ClaimTypes.Role, user.Role.ToString()),
                new(ClaimTypes.Email, user.Email)
            };
            
            if (additionalClaims != null)
            {
                claims.AddRange(additionalClaims.Where(pair => pair.Value != null).Select(pair =>  new Claim(pair.Key, pair.Value!)));
            }

            var token = new JwtSecurityToken(configuration["JwtSetting:Issuer"],
                configuration["JwtSetting:Audience"],
                claims,
                expires: DateTime.Now.AddSeconds(double.Parse(configuration["JwtSetting:ExpiredSeconds"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
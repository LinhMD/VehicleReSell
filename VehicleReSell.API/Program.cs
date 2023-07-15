using System.Text;
using CrudApiTemplate.CustomBinding;
using CrudApiTemplate.ExceptionFilter;
using CrudApiTemplate.Repository;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using VehicleReSell.Business.DTO;
using VehicleReSell.Business.Service.Core;
using VehicleReSell.Business.Service.Implement;
using VehicleReSell.Data.Repository;

var builder = WebApplication.CreateBuilder(args);
TypeAdapterConfig.GlobalSettings.Default.IgnoreNullValues(true);
TypeAdapterConfig.GlobalSettings.RequireDestinationMemberSource = false;
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigOrder();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
DTOConfig.ConfigMapper();
builder.Services.AddDbContext<VehicleReSellDbContext>();
builder.Services.AddScoped<IUnitOfWork, VrsUnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFirebaseServiceIntegration, FirebaseService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddCors(o => o.AddPolicy("AllowAnyOrigin",
    policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
));
// Add services to the container.

builder.Services.AddControllers(option =>
{
    option.Filters.Add<CrudExceptionFilterAttribute>();
});
//Authenticate
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["JwtSetting:Issuer"],
            ValidAudience = configuration["JwtSetting:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSetting:SecurityKey"]))
        };
    });

builder.Services.AddLogging(config =>
{
    config.AddDebug();
    config.AddConsole();
});
//Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "VehicleReSell", Version = "v1"});
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Put **_ONLY_** your JWT Bearer token on text box below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {jwtSecurityScheme, Array.Empty<string>()}
    });
    var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
    xmlFiles.ForEach(xmlFile => c.IncludeXmlComments(xmlFile));
    c.OperationFilter<OpenApiParameterIgnoreFilter>();
    c.EnableAnnotations();
});
//Custom Binding
builder.Services.AddControllersWithViews(options => options.ValueProviderFactories.Add(new ClaimValueProviderFactory()));

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
});
var app = builder.Build();

app.UseRouting();
// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix  = string.Empty;
    
});

app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseEndpoints(x => x.MapControllers());
app.MapControllers();

app.Run();

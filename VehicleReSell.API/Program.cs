
using CrudApiTemplate.Repository;
using Mapster;
using VehicleReSell.Data.Repository;

var builder = WebApplication.CreateBuilder(args);
TypeAdapterConfig.GlobalSettings.Default.IgnoreNullValues(true);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VehicleReSellDbContext>();
builder.Services.AddScoped<IUnitOfWork , VRSUnitOfWork>();
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

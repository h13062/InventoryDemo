using InventoryDemo.Core.Contract.Repositories;
using InventoryDemo.Core.Contract.Services;
using InventoryDemo.Infrastructure.Data;
using InventoryDemo.Infrastructure.Repository;
using InventoryDemo.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<InventoryDemoDbContext>(option => {
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    //this need for migrations
    option.UseSqlServer(builder.Configuration.GetConnectionString("InventoryDemoDb")); // this line of code help Program.cs locate the connection string in appsetting.json
});
// dependency injection
builder.Services.AddScoped<IRecordRepositoryAsync, RecordRepositoryAsync>();
builder.Services.AddScoped<IMachineRepositoryAsync, MachineRepositoryAsync>();
builder.Services.AddScoped<IMaterialRepositoryAsync, MaterialRepositoryAsync>();
builder.Services.AddScoped<IOperatorRepositoryAsync, OperatorRepositoryAsync>();

builder.Services.AddScoped<IRecordServiceAsync, RecordServiceAync>();
builder.Services.AddScoped<IMachineServiceAsync, MachineServiceAsync>();
builder.Services.AddScoped<IMaterialServiceAsync, MaterialServiceAsync>();
builder.Services.AddScoped<IOperatorServiceAsync, OperatorServiceAsync>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

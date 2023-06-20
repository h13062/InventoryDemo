using InventoryDemo.Core.Contract.Repositories;
using InventoryDemo.Infrastructure.Data;
using InventoryDemo.Infrastructure.Repository;
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
builder.Services.AddScoped<IRecordRepositoryAsync, RecordRepositoryAsync>();

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

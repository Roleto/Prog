using MainApp.Logic.Classes;
using MainApp.Logic.Interfaces;
using MainApp.Models.DBModels;
using MainApp.Repository.Class;
using MainApp.Repository.Interface;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddTransient<StrongholdDbContext>();

builder.Services.AddTransient<IRepository<WareHouse>, WarehouseRepository>();
builder.Services.AddTransient<IRepository<Blacksmith>, BlacksmithRepository>();
builder.Services.AddTransient<IRepository<Generalstore>, GeneralstoreRepository>();
builder.Services.AddTransient<IRepository<Recepie>, RecepieRepository>();

builder.Services.AddTransient<IWarehouseLogic, WarehouseLogic>();
builder.Services.AddTransient<IBlacksmithLogic, BlacksmithLogic>();
builder.Services.AddTransient<IGeneralstoreLogic, GeneralstoreLogic>();
builder.Services.AddTransient<IRecepieLogic, RecepieLogic>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(c => c.Run(async context =>
{
    var exeption = context.Features
        .Get<IExceptionHandlerPathFeature>()
        .Error;
    var response = new { Msg = exeption.Message };
    await context.Response.WriteAsJsonAsync(response);
}));
app.UseRouting();

//app.UseAuthorization();

app.MapControllers();

app.Run();

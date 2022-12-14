using MainApp.Endpoint;
using MainApp.Logic.Classes;
using MainApp.Logic.Interfaces;
using MainApp.Models.DBModels;
using MainApp.Repository.Class;
using MainApp.Repository.Interface;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddTransient<StrongholdDbContext>();

builder.Services.AddTransient<IRepository<Warehouse>, WarehouseRepository>();
builder.Services.AddTransient<IRepository<Blacksmith>, BlacksmithRepository>();
builder.Services.AddTransient<IRepository<Generalstore>, GeneralstoreRepository>();
builder.Services.AddTransient<IRepository<Recepie>, RecepieRepository>();

builder.Services.AddTransient<IWarehouseLogic, WarehouseLogic>();
builder.Services.AddTransient<IBlacksmithLogic, BlacksmithLogic>();
builder.Services.AddTransient<IGeneralstoreLogic, GeneralstoreLogic>();
builder.Services.AddTransient<IRecepieLogic, RecepieLogic>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MainApp.Endpoint", Version = "v1" });
});
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MainApp.Endpoint v1"));
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

app.UseCors(x => x
    .AllowCredentials()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins("http://localhost:32435"));


app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<SignalRHub>("/hub");
});


app.MapControllers();

app.Run();

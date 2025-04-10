using XBank.TransactionService.Repositories;
using XBank.TransactionService.Services;
using XBank.EventBus.Extensions; 
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XBank.TransactionService.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

builder.Services.AddEventBus("localhost");
var connectionString = builder.Configuration.GetConnectionString("OracleDb");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(connectionString));


var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();

using BankingApi.Interfaces;
using BankingApi.Middleware;
using BankingApi.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add serilog configuration
// builder.Host.UseSerilog((context, configuration) => 
//     configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
builder.Services.AddSingleton<ICustomerService, CustomerService>();
builder.Services.AddSingleton<IAccountService, AccountService>();
// builder.Services.AddSingleton<ITransactionService, TransactionService>();
builder.Services.AddSingleton<IApiKeyValidationService, ApiKeyValidationService>();
builder.Services.AddSingleton<ApiKeyMiddleware>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// app.UseSerilogRequestLogging();
app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();

app.Run();

using BankingApi.Interfaces;
using BankingApi.Middleware;
using BankingApi.Providers;
using BankingApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add serilog configuration

// Add services to the container.
builder.Services.AddSingleton<ICustomerService, CustomerService>();
builder.Services.AddSingleton<IAccountService, AccountService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IJwtProvider, JwtProvider>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtOptions:Issuer"],
        ValidAudience = builder.Configuration["JwtOptions:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:Signingkey"] ?? string.Empty)
        )
    };
});


var options = new JwtOptions();
builder.Configuration.GetSection("JwtOptions").Bind(options);

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

app.MapControllers();

app.Run();

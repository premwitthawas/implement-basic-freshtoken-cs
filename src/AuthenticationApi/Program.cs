using AuthenticationApi.Helpers;
using AuthenticationApi.Infrastures.Data;
using AuthenticationApi.Repositories;
using AuthenticationApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AuthDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConection"));
});
builder.Services.AddScoped<PasswordHelper>();
builder.Services.AddScoped<JwtHelper>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthService,AuthServic>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
var app = builder.Build();
app.MapControllers();

app.MapGet("/", () => new { message = "API RUNNING 🚀" });

app.Run();

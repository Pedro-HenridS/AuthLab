
using AuthLab.Application.Services.Account;
using AuthLab.Application.UseCases;
using AuthLab.Communication.Requests.Validator;
using AuthLab.Domain.Interfaces.Users;
using AuthLab.Infra;
using AuthLab.Infra.Data.Repositories;
using AuthLab.Infra.Data.Security;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors()); 

builder.Services.AddScoped<IUserRegisterRepository, UserRegisterRepository>();    
builder.Services.AddScoped<IUserFindByEmailRepository, FindByEmailRepository>();
builder.Services.AddScoped<IPasswordHashService, BCryptPasswordHasher>();

builder.Services.AddScoped<CreateUserService>();
builder.Services.AddScoped<FindByEmailService>();
builder.Services.AddScoped<PasswordHasherService>();

builder.Services.AddScoped<RegisterUserUseCase>();
builder.Services.AddScoped<FindByEmailService>();
builder.Services.AddScoped<PasswordHasherService>();
builder.Services.AddScoped<CreateUserValidator>();

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

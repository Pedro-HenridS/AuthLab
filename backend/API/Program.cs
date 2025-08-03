
using API.Filters;
using Application.Services.Account;
using Application.UseCases;
using Communication.Requests.Validator;
using Domain.Interfaces.Users;
using Infra;
using Infra.Data.Repositories;
using Infra.Data.Security;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionsFilter>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors());

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddScoped<IUserRegisterRepository, UserRegisterRepository>();    
builder.Services.AddScoped<IUserFindByEmailRepository, FindByEmailRepository>();
builder.Services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();

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

//app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();

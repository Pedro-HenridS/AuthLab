
using API.Filters;
using Application.Interfaces.Token;
using Application.Services.Account;
using Application.Services.Token;
using Application.Services.UserServices;
using Application.UseCases;
using Communication.Requests.Validator;
using Domain.Interfaces.Security;
using Domain.Interfaces.Users;
using Domain.Repositories;
using Infra;
using Infra.Data.Repositories;
using Infra.Data.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
builder.Services.AddScoped<IVerifyPasswordHash, VerifyPasswordHash>();
builder.Services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
builder.Services.AddScoped<IGetUser, GetUser>();

builder.Services.AddScoped<CreateUserService>();
builder.Services.AddScoped<FindByEmailService>();
builder.Services.AddScoped<PasswordHasherService>();

builder.Services.AddScoped<RegisterUserUseCase>();
builder.Services.AddScoped<LoginUserUseCase>();

builder.Services.AddScoped<FindByEmailService>();
builder.Services.AddScoped<PasswordHasherService>();
builder.Services.AddScoped<CreateUserValidator>();
builder.Services.AddScoped<VerifyPasswordHashService>();
builder.Services.AddScoped<GetUserByEmail>();


builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
            )
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

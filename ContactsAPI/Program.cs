using API.Validators;
using Core.Abstractions.Repositories;
using Core.Abstractions.Services;
using Core.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Repositories;
using Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    };
                });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //define which claim requires to check
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            //store the value in appsettings.json
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
        };
    });
//Validators
builder.Services.AddScoped<IValidator<LoginInfoDTO>, LoginInfoDTOValidator>();
builder.Services.AddScoped<IValidator<ContactDTO>, ContactDTOValidator>();
builder.Services.AddScoped<IValidator<CreateContactDTO>, CreateContactDTOValidator>();
builder.Services.AddScoped<IValidator<UpdateContactDTO>, UpdateContactDTOValidator>();
builder.Services.AddScoped<IValidator<SkillDTO>, SkillDTOValidator>();
builder.Services.AddScoped<IValidator<CreateSkillDTO>, CreateSkillDTOValidator>();
builder.Services.AddScoped<IValidator<UpdateSkillDTO>, UpdateSkillDTOValidator>();
builder.Services.AddScoped<IValidator<UserSkillDTO>, UserSkillDTOValidator>();


// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();

// Business
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJwtAuthenticationService, JwtAuthenticationService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<ISkillService, SkillService>();

// EF
string connectionString = builder.Configuration.GetConnectionString("SQLServer");
builder.Services.AddDbContext<IContactsDbContext, ContactsDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contacts API", Version = "v1" });
});
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contacts API v1");
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

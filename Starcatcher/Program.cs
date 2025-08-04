using Microsoft.EntityFrameworkCore;
using Starcatcher.Contracts;
using Starcatcher.Entities.Context;
using Starcatcher.Entities;
using Starcatcher.Repository;
using Starcatcher.DTOs;
using Starcatcher.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//Adicionando os controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
//Cotas
builder.Services.AddScoped<IRepositoryCota<Cota, int>, CotaRepository>();
builder.Services.AddScoped<IService<CotaDTOExit, int, int, CotaDTOUpdate>, CotaService>();
//Grupos
builder.Services.AddScoped<IRepositoryGrupo<GrupoConsorcio, int, Cota>, GrupoConsorcioRepository>();
builder.Services.AddScoped<IService<GrupoConsorcio, GrupoConsorcioDTOEntry, int, GrupoConsorcio>, GrupoConsorcioService>();
//validadores
builder.Services.AddScoped<ValidationExecutor>();
//Users
builder.Services.AddScoped<IRepositoryUser<User, int, Cota>, UserRepository>();
builder.Services.AddScoped<IServiceUser<User, UserDTOEntry, UserDTOUpdate>, UserService>();
//Hash de senha para o db
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

//TODO autentication mas só depois de acabar tudo
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)//Configurando o que será necessário para a configuração do token
    .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
            };
        });

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "StarcatcherAPI", Version = "v1" });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Auth",
        Description = "Insira o Token JWt no formato: Bearer {seu_token}",
        In = ParameterLocation.Header, //TODO aqui eu troco pra por o cookie
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securityScheme);

    var securityRequirement = new OpenApiSecurityRequirement
    {
        {
            securityScheme,
            Array.Empty<string>()
        }
    };
    c.AddSecurityRequirement(securityRequirement);
});



var app = builder.Build();
//Redireciona da raiz para o swagger
app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseMiddleware<ExceptionMiddleware>();//aqui eu injeto o middleware que é responsável por automatizar o tratamento das exceções

//adicionando o uso de autenticação
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();//<= aqui eu mapeio os controllers com [ApiController]

app.Run();
using Microsoft.EntityFrameworkCore;
using Starcatcher.Contracts;
using Starcatcher.Entities.Context;
using Starcatcher.Entities;
using Starcatcher.Repository;
using Starcatcher.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Starcatcher.Middleware;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IRepositoryCota, CotaRepository>();
builder.Services.AddScoped<IServiceCota, CotaService>();

builder.Services.AddScoped<IRepositoryGrupo, GrupoConsorcioRepository>();
builder.Services.AddScoped<IServiceGrupo, GrupoConsorcioService>();

builder.Services.AddScoped<ValidationExecutor>();

builder.Services.AddScoped<IRepositoryUser, UserRepository>();
builder.Services.AddScoped<IServiceUser, UserService>();

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddHttpContextAccessor();

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

//TODO remover o swagger
// builder.Services.AddSwaggerGen(c =>
// {
//     c.SwaggerDoc("v1", new OpenApiInfo { Title = "StarcatcherAPI", Version = "v1" });

//     var securityScheme = new OpenApiSecurityScheme
//     {
//         Name = "Auth",
//         Description = "Insira o Token JWt no formato: Bearer {seu_token}",
//         In = ParameterLocation.Header, //TODO aqui eu troco pra por o cookie
//         Type = SecuritySchemeType.Http,
//         Scheme = "bearer",
//         BearerFormat = "JWT",
//         Reference = new OpenApiReference
//         {
//             Type = ReferenceType.SecurityScheme,
//             Id = "Bearer"
//         }
//     };

//     c.AddSecurityDefinition("Bearer", securityScheme);

//     var securityRequirement = new OpenApiSecurityRequirement
//     {
//         {
//             securityScheme,
//             Array.Empty<string>()
//         }
//     };
//     c.AddSecurityRequirement(securityRequirement);
// });

var app = builder.Build();

// app.MapGet("/", context =>
// {
//     context.Response.Redirect("/swagger");
//     return Task.CompletedTask;
// });

// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
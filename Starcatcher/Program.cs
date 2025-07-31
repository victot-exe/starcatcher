using Microsoft.EntityFrameworkCore;
using Starcatcher.Contracts;
using Starcatcher.Entities.Context;
using Starcatcher.Entities;
using Starcatcher.Repository;
using Starcatcher.DTOs;
using Starcatcher.Services;
using Starcatcher.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//Adicionando os controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
//Cotas
builder.Services.AddScoped<IRepository<Cota, int>, CotaRepository>();
builder.Services.AddScoped<IService<CotaDTOExit, CotaDTOEntry, int, CotaDTOUpdate>, CotaService>();
//Grupos
builder.Services.AddScoped<IRepositoryGrupo<GrupoConsorcio, int, Cota>, GrupoConsorcioRepository>();
builder.Services.AddScoped<IService<GrupoConsorcio, GrupoConsorcioDTOEntry, int, GrupoConsorcio>, GrupoConsorcioService>();
//TODO regras de negocio que não permitem criar novos grupos a partir de cotas, a conta já deve vir pertencente a um grupo
builder.Services.AddScoped<ValidationExecutor>();

//TODO autentication mas só depois de acabar tudo

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
app.UseMiddleware<ExceptionMiddleware>();//aqui eu injeto o middleware que é responsável por automatizar o tratamento das exceções

app.MapControllers();//<= aqui eu mapeio os controllers com [ApiController]

app.Run();
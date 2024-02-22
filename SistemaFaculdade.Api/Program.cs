using System.Reflection;
using System.Text.Json.Serialization;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.OpenApi.Models;
using NHibernate;
using SistemaFaculdade.Aplicacao.Alunos.Profiles;
using SistemaFaculdade.Aplicacao.Alunos.Servicos;
using SistemaFaculdade.Dominio.Alunos.Servicos;
using SistemaFaculdade.Infra.Alunos.Mapeamentos;
using SistemaFaculdade.Infra.Alunos.Repositorios;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(op =>
{
    op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    op.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SistemaFaculdade.Api", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddSingleton<ISessionFactory>(factory =>
{
    string connectionString = "Conexão com o Banco";

    return Fluently.Configure()

    .Database(MySQLConfiguration.Standard.ConnectionString(connectionString)
    .FormatSql()
    .ShowSql())
    .Mappings(x =>
    {
        x.FluentMappings.AddFromAssemblyOf<AlunosMap>();
    }).BuildSessionFactory();

});


builder.Services.AddScoped(factory => factory.GetRequiredService<ISessionFactory>().OpenSession());
builder.Services.AddScoped<ITransaction>(factory => factory.GetService<NHibernate.ISession>()!.BeginTransaction());

builder.Services.AddAutoMapper(typeof(AlunoProfile));
builder.Services.Scan(scan => scan
    .FromAssemblyOf<AlunoAppServico>()
        .AddClasses()
            .AsImplementedInterfaces()
                .WithScopedLifetime());

builder.Services.Scan(scan => scan
    .FromAssemblyOf<AlunoServico>()
        .AddClasses()
            .AsImplementedInterfaces()
                .WithScopedLifetime());

builder.Services.Scan(scan => scan
    .FromAssemblyOf<AlunoRepositorio>()
        .AddClasses()
            .AsImplementedInterfaces()
                .WithScopedLifetime());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
  {
      c.SwaggerEndpoint("../swagger/v1/swagger.json", "SistemaFaculdade.Api v1");
      c.DisplayRequestDuration();
  });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
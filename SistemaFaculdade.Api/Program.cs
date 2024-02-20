using System.Text.Json.Serialization;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
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
builder.Services.AddSwaggerGen();

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
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
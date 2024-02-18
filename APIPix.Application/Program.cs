using APIPix.CrossCutting.DependencyInjection;
using APIPix.Data.Context;
using APIPix.Data.Repository;
using APIPix.Domain.Interfaces;
using Microsoft.SqlServer.Management.Common;
using System.Text.Json.Serialization;

namespace APIPix.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configura a injeção de dependência
            ConfigureRepository.ConfiguracaoDependenciaRepository(builder.Services);

            // Adiciona serviços ao contêiner.
            builder.Services.AddControllers();

            // Aprenda mais sobre como configurar o Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configura o pipeline de solicitação HTTP.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
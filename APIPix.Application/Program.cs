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

            // Configura a inje��o de depend�ncia
            ConfigureRepository.ConfiguracaoDependenciaRepository(builder.Services);

            // Adiciona servi�os ao cont�iner.
            builder.Services.AddControllers();

            // Aprenda mais sobre como configurar o Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configura o pipeline de solicita��o HTTP.
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
using APIPix.CrossCutting.AutoMapper;
using APIPix.CrossCutting.DependencyInjection;
using APIPix.Data.Context;
using APIPix.Data.Repository;
using APIPix.Domain.Interfaces;
using AutoMapper;
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
            ConfigureService.ConfiguracaoDependenciaService(builder.Services);


            //Configurando o AutoMapper para adicionar um perfil chamado DtoToEntityProfile, que é responsável por configurar os mapeamentos entre DTOs e entidades.
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToEntityProfile());
            });

            IMapper mapper = config.CreateMapper();
            builder.Services.AddSingleton(mapper);


            //Controller com o JsonOptions para evitar objetos circulares
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });

            // Adiciona serviços ao contêiner.       

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
﻿using APIPix.Data.Context;
using APIPix.Data.Repository;
using APIPix.Domain.Interfaces;
using APIPix.Domain.Interfaces.Repository;
using APIPix.Domain.Interfaces.Services;
using APIPix.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfiguracaoDependenciaRepository(IServiceCollection serviceCollection)
        {
           
            serviceCollection.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddTransient<ITransacaoRepository, TransacaoRepository>();
            var stringConnection = "server=.\\SQLEXPRESS2017;Initial Catalog=ApiPixDDD;MultipleActiveResultSets=true;TrustServerCertificate=True;User ID=sa;Password=admin123;";
            serviceCollection.AddDbContext<MyContext>(options => options.UseSqlServer(stringConnection));
        }
    }
}

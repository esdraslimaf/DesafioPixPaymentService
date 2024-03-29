﻿using APIPix.Data.Context;
using APIPix.Data.Repository;
using APIPix.Domain.Interfaces.Services;
using APIPix.Domain.Interfaces;
using APIPix.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIPix.Domain.Interfaces.Repository;

namespace APIPix.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfiguracaoDependenciaService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IChaveService, ChaveService>();
            serviceCollection.AddTransient<IClienteService, ClienteService>();
            serviceCollection.AddTransient<ITransacaoService, TransacaoService>();
            
            


        }
    }
}

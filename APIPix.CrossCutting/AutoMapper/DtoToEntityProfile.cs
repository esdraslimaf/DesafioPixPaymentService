using APIPix.Domain.Dtos.ChavePix;
using APIPix.Domain.Dtos.Cliente;
using APIPix.Domain.Dtos.Transacao;
using APIPix.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.CrossCutting.AutoMapper
{
    public class DtoToEntityProfile:Profile
    {
        public DtoToEntityProfile()
        {
            //ChavePix
            CreateMap<ChavePix, ChavePixDtoCreate>().ReverseMap();
            CreateMap<ChavePix, ChavePixDtoResult>().ReverseMap();
            CreateMap<ChavePix, ChavePixDtoUpdate>().ReverseMap();

            // Cliente
            CreateMap<Cliente, ClienteDtoCreate>().ReverseMap();
            CreateMap<Cliente, ClienteDtoResult>().ReverseMap();
            CreateMap<Cliente, ClienteDtoUpdate>().ReverseMap();
       
            //Transacao
            CreateMap<Transacao, TransacaoDtoCreate>().ReverseMap();
            CreateMap<Transacao, TransacaoDtoResult>().ReverseMap();
            CreateMap<Transacao, TransacaoDtoUpdate>().ReverseMap();
        }

    }
}

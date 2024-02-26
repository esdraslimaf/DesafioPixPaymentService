using APIPix.Domain.Dtos.ChavePix;
using APIPix.Domain.Dtos.Pagador;
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
            
            //Pagador
            CreateMap<OrigemPagamento, PagadorDtoCreate>().ReverseMap();
            CreateMap<OrigemPagamento, PagadorDtoResult>().ReverseMap();
            CreateMap<OrigemPagamento, PagadorDtoUpdate>().ReverseMap();
        }

    }
}

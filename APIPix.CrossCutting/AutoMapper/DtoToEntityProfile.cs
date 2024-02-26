using APIPix.Domain.Dtos.Beneficiario;
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
            CreateMap<Pagador, PagadorDtoCreate>().ReverseMap();
            CreateMap<Pagador, PagadorDtoResult>().ReverseMap();
            CreateMap<Pagador, PagadorDtoUpdate>().ReverseMap();

            //Beneficiario
            CreateMap<Beneficiario, BeneficiarioDtoCreate>().ReverseMap();
            CreateMap<Beneficiario, BeneficiarioDtoResult>().ReverseMap();
            CreateMap<Beneficiario, BeneficiarioDtoUpdate>().ReverseMap();
        }

    }
}

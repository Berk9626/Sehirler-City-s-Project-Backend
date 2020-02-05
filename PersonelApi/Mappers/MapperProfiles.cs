using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PersonelApi.Data.PersonelContext;
using AutoMapper;
using PersonelApi.DTOs;

namespace PersonelApi.Mappers
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Sehir, SehirDTO>().ForMember(des =>
           des.ad, opt => opt.MapFrom(src => src.Ad)).
           ForMember(des => des.id, opt => opt.MapFrom(src => src.Id)).
            ForMember(des => des.resimYol, opt => opt.MapFrom(src => src.ResimYol));

            CreateMap<SehirDTO, Sehir>().ForMember(des =>
          des.Ad, opt => opt.MapFrom(src => src.ad)).
          ForMember(des => des.Id, opt => opt.MapFrom(src => src.id)).
           ForMember(des => des.ResimYol, opt => opt.MapFrom(src => src.resimYol));
        }

    }
}

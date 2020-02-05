using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonelApi.DTOs;
using static PersonelApi.Data.PersonelContext;
using static PersonelApi.Repositories.BusinessRepository;

namespace PersonelApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SehirController : ControllerBase
    {
        RepSehir _repSehir;
        IMapper _mapper;
        public SehirController(RepSehir repSehir,IMapper mapper)
        {
            _repSehir = repSehir;
            _mapper = mapper;
        }
        [HttpGet("GetSehirler")]
        public   ICollection<SehirDTO> GetSehirler()
        {
            return _repSehir.Doldur();
        }
        [HttpGet("GetSehir/{id}") ]
        public async Task<Sehir>   GetSehir(int id)
        {
            return await _repSehir.Find(id);
        }
        [HttpPut("UpdateSehir")]
        public  async Task<SehirDTO> UpdateSehir(  [FromBody] SehirDTO sehirDTO)
        {
            Sehir secSehir = await _repSehir.Find(sehirDTO.id);
            secSehir = _mapper.Map(sehirDTO, secSehir);
          // secSehir.ResimYol = sehirDTO.resimYol;
          //  secSehir.Ad = sehirDTO.ad;

            _repSehir.Update(secSehir);
            await _repSehir.Comit();
            return sehirDTO;
        }
        [HttpPost("EntrySehir")]
        public async Task<SehirDTO> EntrySehir([FromBody] SehirDTO sehirDTO)
        {
            Sehir yeniSehir = new Sehir();
            yeniSehir = _mapper.Map(sehirDTO, yeniSehir);
         //   yeniSehir.ResimYol = sehirDTO.resimYol;
         //   yeniSehir.Id = sehirDTO.id;
         //   yeniSehir.Ad = sehirDTO.ad;
            _repSehir.Entry(yeniSehir);
            await _repSehir.Comit();
            return sehirDTO;
        }
        [HttpDelete("DeleteSehir/{id}")]
        public async Task<Sehir> DeleteSehir(int id )
        {
            Sehir silinenSehir = await _repSehir.Find(id);
            _repSehir.Delete( silinenSehir);
            await _repSehir.Comit();
            return silinenSehir;
        }
    }
}
using PersonelApi.Data;
using PersonelApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PersonelApi.Data.PersonelContext;

namespace PersonelApi.Repositories
{
    public class BusinessRepository
    {
        public class RepSehir : BaseRepository<Sehir>
        {
            public RepSehir(PersonelContext db) : base(db)
            {

            }
            public ICollection<SehirDTO> Doldur()
            { 
              return  Set().Select(x => new SehirDTO
                {
                    id = x.Id,
                    ad = x.Ad,
                    resimYol = x.ResimYol
                }).ToList();
            }
        }
        public class RepEgitim :
        BaseRepository<Egitim>
        {
            public RepEgitim(PersonelContext db) : base(db)
            {

            }
        }
        public class RepPersonel : BaseRepository<Personel>
        {
            public RepPersonel(PersonelContext db) : base(db)
            {

            }
        }
    }
}

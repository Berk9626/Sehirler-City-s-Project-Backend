using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelApi.Data
{
    public class PersonelContext:DbContext

    {
        public PersonelContext(DbContextOptions<PersonelContext> op):base(op)
        {

        }
        DbSet<Personel> personel { get; set; }
        DbSet<Egitim> egitim { get; set; }
        DbSet<Sehir> sehir { get; set; }
        public  class Personel
        {
            [Key]
            public int Id { get; set; }
            public string Ad{ get; set; }
            public string Soyad { get; set; }
            public int SehirId { get; set; }
            public int EgitimId{ get; set; }

            [ForeignKey("SehirId")]
            public Sehir Sehir{ get; set; }
            [ForeignKey("EgitimId")]
            public Egitim  Egitim  { get; set; }
        }
         
        public class Sehir

        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            [Key]
            public int Id { get; set; }
            public string Ad { get; set; }
            public string ResimYol{ get; set; }
            public ICollection<Personel> Plist { get; set; }

        }
        public class Egitim 
        {
            [Key]
            public int Id { get; set; }
            public string Ad { get; set; }
            public ICollection<Personel> Elist { get; set; }

        }
    }
}

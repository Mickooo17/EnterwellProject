using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    [Table("RacunStavke")]
    public class RacunStavka : EntityBase
    {
        public string Opis { get; set; }
        public float Kolicina { get; set; }
        public double CijenaBezPDV { get; set; }
        public double CijenaSaPDV
        {
            get
            {
                if (Racun == null) return 0;

                return CijenaBezPDV * (1 + Racun.PDV);
            }
        }
        public long RacunId { get; set; }
        public Racun Racun { get; set; }

        public bool IsDeleted { get; set; }


    }
}
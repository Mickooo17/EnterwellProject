using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat.Models.DTOs
{
    public class RacunStavkaDto
    {
        public long Id { get; set; }
        public Racun Racun { get; set; }
        public ICollection<RacunStavka> Stavke { get; set; }
        public double UkupnaCijenaSaPDVom { get; set; }
        public double UkupnaCijenaBezPDVa { get; set; }
    }
}
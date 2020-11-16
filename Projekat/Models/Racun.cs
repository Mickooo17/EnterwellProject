using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    [Table("Racuni")]
    public class Racun : EntityBase
    {
        [DisplayName("Broj fakture")]
        public int BrojFakture { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Datum dospjeća fakture")]
        public DateTime? DatumDospjecaFakture { get; set; }

        [DisplayName("Primatelj računa")]
        public string PrimateljRacuna { get; set; }
        
        [Required]
        public float PDV { get; set; }

        public string StvarateljRacunaId { get; set; }
        [DisplayName("Stvaratelj računa")]
        public ApplicationUser StvarateljRacuna { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<RacunStavka> RacunStavke { get; set; }
    }
}
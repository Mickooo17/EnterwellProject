using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class EntityBase
    {
        public long Id { get; set; }
        [DisplayName("Datum kreiranja")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? CreateDate { get; set; }
        [DisplayName("Datum izmjene")]
        public DateTime? UpdateDate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace Projekat.VATContainer
{
    [Export(typeof(IVATRate))]
    [ExportMetadata("Name", "HR")]
    public class VAT_HR : IVATRate
    {
        public string GetCountryName()
        {
            return "Hrvatska";
        }

        public int GetVATRate()
        {
            return 25;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace Projekat.VATContainer
{
    [Export(typeof(IVATRate))]
    [ExportMetadata("Name", "BA")]
    public class VAT_BA : IVATRate
    {
        public string GetCountryName()
        {
            return "Bosna i Hercegovina";
        }

        public int GetVATRate()
        {
            return 17;
        }
    }
}
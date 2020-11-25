using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace Projekat.VATContainer
{
    [Export(typeof(IVATRate))]
    [ExportMetadata("Name", "DE")]
    public class VAT_DE : IVATRate
    {
        public string GetCountryName()
        {
            return "Njemačka";
        }

        public int GetVATRate()
        {
            return 19;
        }
    }
}
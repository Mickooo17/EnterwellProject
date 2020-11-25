using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.VATContainer
{
    public interface IVATRate
    {
        string GetCountryName();
        int GetVATRate();
    }
}

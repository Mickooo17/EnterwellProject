using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Projekat.Helper
{
    public static class PDVHelper
    {
        public static List<SelectListItem> getPDVLista()
        {
            var PDVPreset = new Dictionary<string, int>
            {
                { "BiH", 17 },
                { "HR", 25 }
            };

            var list = new List<SelectListItem>();
            list.AddRange(PDVPreset.Select(x => new SelectListItem
            {
                Text = x.Key + " (" + x.Value + "%)",
                Value = ((float)x.Value / 100).ToString()
            }));

            return list;
        }
    }
}
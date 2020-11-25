using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Projekat.Models.DTOs;
using System.Threading;
using System.Text.RegularExpressions;
using System.ComponentModel.Composition;
using Projekat.VATContainer;
using Microsoft.Ajax.Utilities;
using Projekat.Container;

namespace Projekat.Controllers
{
    [Authorize]
    public class RacunController : Controller
    {
        ApplicationDbContext Context = new ApplicationDbContext();

        [ImportMany]
        public IEnumerable<Lazy<IVATRate, IVATRateMetaData>> MEFVATList { get; private set; }

        // GET: Racun
        public ActionResult Index()
        {
            List<Racun> Racuni = Context.Racuni.Where(x => x.IsDeleted == false).Include(x => x.StvarateljRacuna).ToList();
            return View(Racuni);
        }

        // GET: Racun/Details/5
        public ActionResult Details(int id)
        {
            var Racun = Context.Racuni.Where(x => x.IsDeleted == false).Include(x => x.StvarateljRacuna).FirstOrDefault(x => x.Id == id);
            if (Racun == null)
                return RedirectToAction("Index");

            var RacunStavke = Context.RacuniStavke.Where(x => x.RacunId == id && x.IsDeleted == false).ToList();

            RacunStavkaDto result = new RacunStavkaDto()
            {
                Id = id,
                Racun = Racun,
                Stavke = RacunStavke,
                UkupnaCijenaBezPDVa = RacunStavke.Sum(x => x.CijenaBezPDV * x.Kolicina),
                UkupnaCijenaSaPDVom = RacunStavke.Sum(x => x.CijenaSaPDV * x.Kolicina)
            };

            return View(result);

        }

        // GET: Racun/Create

        public ActionResult Create()
        {
            Racun racun = new Racun
            {
                CreateDate = DateTime.Today,
                BrojFakture = GetIduciBrojFakture(),
                DatumDospjecaFakture = null
            };

            ViewBag.VATList = MEFVATList
                .Select(x => x.Value)
                .DistinctBy(x => x.GetCountryName())
                .Select(x => new SelectListItem
            {
                Text = x.GetCountryName() + " (" + x.GetVATRate() + "%)",
                Value = ((float)x.GetVATRate() / 100).ToString()
            }).Distinct().ToList();

            return View(racun);
        }

        // POST: Racun/Create
        [HttpPost]
        public ActionResult Create(Racun racun)
        {

            try
            {
                // TODO: Add insert logic here
                racun.BrojFakture = GetIduciBrojFakture();
                racun.CreateDate = DateTime.Now;
                racun.UpdateDate = DateTime.Now;
                racun.StvarateljRacunaId = User.Identity.GetUserId();
                Context.Racuni.Add(racun);
                Context.SaveChanges();
                return RedirectToAction("Edit", new { @Id = racun.Id });
            }
            catch (Exception e)
            {
                return View();
            }
        }

        private int GetIduciBrojFakture()
        {
            int IduciBrojFakture = 1;

            int ZadnjiBrojFakture = Context.Racuni.Select(x => x.BrojFakture).DefaultIfEmpty(0).Max();
            if (ZadnjiBrojFakture != 0)
                IduciBrojFakture = ZadnjiBrojFakture + 1;
            return IduciBrojFakture;
        }

        // GET: Racun/Edit/5
        public ActionResult Edit(int id)
        {
            var Racun = Context.Racuni
                .Where(x => x.IsDeleted == false)
                .Where(x => x.Id == id)
                .Include(x => x.StvarateljRacuna)
                .FirstOrDefault();
            if (Racun == null)
            {
                return RedirectToAction("Index");
            }

            Racun.RacunStavke = Context.RacuniStavke.Where(x => x.RacunId == id && x.IsDeleted == false).ToList();

            string DecimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            ViewBag.PricePattern = "^[0-9]+(" + Regex.Escape(DecimalSeparator) + "[0-9]{2})?$";
            return View(Racun);
        }

        // GET: Racun/Delete/5
        public ActionResult Delete(int id)
        {
            var Racun = Context.Racuni.Find(id);
            if (Racun != null)
            {
                Racun.IsDeleted = true;
                Context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // POST: Racun/DodajStavku
        [HttpPost]
        public ActionResult DodajStavku(RacunStavka racunStavka)
        {
            var Racun = Context.Racuni.Find(racunStavka.RacunId);
            if (Racun == null)
                return RedirectToAction("Index");

            if (racunStavka.Id != 0)
            {
                var ExistingStavka = Context.RacuniStavke.Where(x => x.IsDeleted == false).FirstOrDefault(x => x.Id == racunStavka.Id);
                ExistingStavka.Opis = racunStavka.Opis;
                ExistingStavka.Kolicina = racunStavka.Kolicina;
                ExistingStavka.CijenaBezPDV = racunStavka.CijenaBezPDV;

                ExistingStavka.UpdateDate = DateTime.Now;
            }
            else
            {
                racunStavka.CreateDate = DateTime.Now;
                racunStavka.UpdateDate = DateTime.Now;
                Context.RacuniStavke.Add(racunStavka);
            }
            Context.SaveChanges();

            return RedirectToAction("Edit", new { Id = racunStavka.RacunId });
        }

        // GET: Racun/UkloniStavku/5
        public ActionResult UkloniStavku(int id)
        {
            var RacunStavka = Context.RacuniStavke.Find(id);
            if (RacunStavka != null)
            {
                RacunStavka.IsDeleted = true;
                Context.SaveChanges();

                return RedirectToAction("Edit", new { Id = RacunStavka.RacunId });
            }
            return RedirectToAction("Index");
        }
    }
}

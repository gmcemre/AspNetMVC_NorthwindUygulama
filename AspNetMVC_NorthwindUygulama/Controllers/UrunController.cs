using AspNetMVC_NorthwindUygulama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVC_NorthwindUygulama.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        NorthwindContext ctx = new NorthwindContext();
        public ActionResult Index()
        {
            List<Urunler> urunler = ctx.Urunlers.ToList();
            List<Kategoriler> kategoriler = ctx.Kategorilers.ToList();
            ViewBag.Kategoriler = kategoriler;
            return View(urunler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<Kategoriler> ktg = ctx.Kategorilers.ToList();
            List<Tedarikciler> ted = ctx.Tedarikcilers.ToList();
            ViewBag.Kategoriler = ktg;
            ViewBag.Tedarikciler = ted;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urunler urun)
        {
            ctx.Urunlers.Add(urun);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
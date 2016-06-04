using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicOnDemand.Models;

namespace MusicOnDemand.Controllers
{
    public class SearchController : Controller
    {
        private static MusicDB_Entities ctx = new MusicDB_Entities();
        //
        // GET: /Search/
        public ActionResult Index(string q)
        {
//  Console.Write(q);
            Result model = new Result();
           var izv = ctx.izvođač.AsNoTracking().ToList().Where(m => m.nazivIzvođač.Contains(q));
           model.izvodjaci = new List<izvođač>();
           model.albumi = new List<album>();
           model.pjesme = new List<pjesma>();
           model.zanrovi = new List<žanr>();
           model.drzave = new List<država>();
           foreach (var i in izv)
           {
               model.izvodjaci.Add(i);
           }
           var alb = ctx.album.AsNoTracking().ToList().Where(m => m.nazivAlbuma.Contains(q));
           var pjes = ctx.pjesma.AsNoTracking().ToList().Where(m => m.nazivPjesme.Contains(q));
           var zan = ctx.žanr.AsNoTracking().ToList().Where(m => m.nazivŽanra.Contains(q));
           var drz = ctx.država.AsNoTracking().ToList().Where(m => m.nazivDržave.Contains(q));
           foreach (var a in alb)
           {
               model.albumi.Add(a);
           }
           foreach (var p in pjes)
           {
               model.pjesme.Add(p);
           }
           foreach (var z in zan)
           {
               model.zanrovi.Add(z);
           }
           foreach (var d in drz)
           {
               model.drzave.Add(d);
           }
         /*   List<Result> rez = new List<Result>();
            rez.Add(model);
            Result model2 = new Result();
            Result model3= new Result();
            model2.name = "te2";
            model2.type = "album";
            model2.id = "5";
            rez.Add(model2);
            model3.name = "t3";
            model3.type = "pjesma";
            model3.id = "1";
            rez.Add(model3);*/
            return View(model);
        }
	}
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Game.Models;
using System.IO;
using Microsoft.AspNet.Identity;
using System.Web.Hosting;
using System.Resources;

namespace Game.Controllers
{
 
 //var current = System.Security.Principal.WindowsIdentity.GetCurrent();// текущий пользователь системы
 
    public class HeroesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
           // var current = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                var heroes = db.Heroes.Include(h => h.User);              
                return View(heroes.ToList());
            }            
            return View("NotUsersView");
        }

        // GET: Heroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hero hero = db.Heroes.Find(id);
            if (hero == null)
            {
                return HttpNotFound();
            }
            return PartialView(hero);
        }

        // GET: Heroes/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Heroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Include = "Id,Name,Level,FreePoints,Experience,Health,Protection,Attack,Evasion,Crit,Picture,UserId")] Hero hero, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
              //  ResourceManager
                string fileName = Path.GetFileName(file.FileName);
                string fullpath = Directory.GetCurrentDirectory()+ "~/UploadContent/" + fileName;
                file.SaveAs(Server.MapPath(fullpath));// Server.
                hero.Picture = fullpath;
                db.Heroes.Add(hero);
                db.SaveChanges();
                var z= Server.MachineName;
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", hero.UserId);
            return View(hero);
        }

        // GET: Heroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hero hero = db.Heroes.Find(id);
            if (hero == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", hero.UserId);
            return View(hero);
        }

        // POST: Heroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Level,FreePoints,Experience,Health,Protection,Attack,Evasion,Crit,Picture,UserId")] Hero hero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", hero.UserId);
            return View(hero);
        }

        // GET: Heroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hero hero = db.Heroes.Find(id);
            if (hero == null)
            {
                return HttpNotFound();
            }
            return View(hero);
        }

        // POST: Heroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hero hero = db.Heroes.Find(id);
            db.Heroes.Remove(hero);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        Dictionary<string, string> lst = new Dictionary<string, string>();
       // [HttpPost]
        public ActionResult Test(StrCl s)
        {
            
            lst.Add("1", "sting1");
            lst.Add("2", "sting2");
            lst.Add("3", "sting3");
            //List<ApplicationUser> users = db.Users.ToList
           /* Hero hero = new Hero();
            hero.Attack = 5;
            hero.Crit = 10;
            hero.Evasion = 40;
            hero.Experience = 100;
            hero.FreePoints = 200;
            hero.Health = 45;
            hero.Name = "sssssss";
            hero.UserId = "21167d23-98da-489f-8d91-6db06370cb41";
            db.Heroes.Add(hero);
            db.SaveChanges();*/
            return Json(lst.Where(n=>n.Key == s.St), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
    public class StrCl
    {
        public string St { get; set; }
        public int Lk { get; set; }
    }
}

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
                if (file != null)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string physicalPath = Server.MapPath("/UploadContent");
                    file.SaveAs(Path.Combine(physicalPath, fileName));
                    hero.Picture = Path.Combine("~/UploadContent", fileName);
                }
                string currentUserId = User.Identity.GetUserId();
                hero.UserId = currentUserId;                
                hero.FreePoints = 50;
                hero.Health = 200;
                hero.Protection = 5;
                hero.Attack = 50;
                hero.Crit = 5;

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
            Hero hero = db.Heroes.Include(x=>x.User).FirstOrDefault(n=>n.Id == id);
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
        public ActionResult Edit(Hero hero, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                Hero heroEdit = db.Heroes.Find(hero.Id);
                if (file != null)
                { 
                    string fileName = Path.GetFileName(file.FileName);
                    string physicalPath = Server.MapPath("/UploadContent");
                    file.SaveAs(Path.Combine(physicalPath, fileName));
                    heroEdit.Picture = Path.Combine("~/UploadContent", fileName);
                }
                //db.Entry(hero).State = EntityState.Modified;
                UpdateModel(heroEdit);
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
            string idLoginUser = User.Identity.GetUserId();
            if (idLoginUser != hero.UserId)
            {
                return View("ForbidDelete");
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
        public ActionResult Characteristic(int id)
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
        
       /* public ActionResult Test(StrCl s)
        {
            
            
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
            db.SaveChanges();
            return Json(lst.Where(n=>n.Key == s.St), JsonRequestBehavior.AllowGet);
        }*/

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

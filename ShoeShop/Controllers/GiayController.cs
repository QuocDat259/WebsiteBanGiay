using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoeShop.Models;  
using PagedList;
namespace ShoeShop.Controllers
{
    public class GiayController : Controller
    {
        private ShoeShopEntities db = new ShoeShopEntities();

        // GET: tb_Adv
        public ActionResult giay(int? page)
        {
            if (page == null) page = 1;
            var shoes = db.tb_Adv.OrderBy(b => b.Id);
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(shoes.ToPagedList(pageNumber, pageSize));
            //return View(db.tb_Adv.ToList());
        }

        // GET: tb_Adv/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Adv tb_Adv = db.tb_Adv.Find(id);
            if (tb_Adv == null)
            {
                return HttpNotFound();
            }
            return View(tb_Adv);
        }

        // GET: tb_Adv/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_Adv/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Type,Price,Published,Sex,img")] tb_Adv tb_Adv)
        {
            if (ModelState.IsValid)
            {
                db.tb_Adv.Add(tb_Adv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_Adv);
        }

        // GET: tb_Adv/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Adv tb_Adv = db.tb_Adv.Find(id);
            if (tb_Adv == null)
            {
                return HttpNotFound();
            }
            return View(tb_Adv);
        }

        // POST: tb_Adv/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Type,Price,Published,Sex,img")] tb_Adv tb_Adv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Adv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_Adv);
        }

        // GET: tb_Adv/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Adv tb_Adv = db.tb_Adv.Find(id);
            if (tb_Adv == null)
            {
                return HttpNotFound();
            }
            return View(tb_Adv);
        }

        // POST: tb_Adv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Adv tb_Adv = db.tb_Adv.Find(id);
            db.tb_Adv.Remove(tb_Adv);
            db.SaveChanges();
            return RedirectToAction("Index");
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
}

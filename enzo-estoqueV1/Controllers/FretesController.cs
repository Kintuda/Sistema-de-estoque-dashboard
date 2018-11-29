using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using enzo_estoqueV1.Models;

namespace enzo_estoqueV1.Controllers
{
    public class FretesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Fretes
        [Authorize]
        public ActionResult Index()
        {
            var fretes = db.Fretes.Include(f => f.Transportadora).Include(f => f.Venda);
            return View(fretes.ToList());
        }

        // GET: Fretes/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frete frete = db.Fretes.Find(id);
            if (frete == null)
            {
                return HttpNotFound();
            }
            return View(frete);
        }

        // GET: Fretes/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.TransportadoraID = new SelectList(db.Transportadoras, "ID", "Descricao");
            ViewBag.VendaID = new SelectList(db.Vendas, "ID", "Descricao");
            return View();
        }

        // POST: Fretes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Descricao,EnderecoEntrega,Status,VendaID,TransportadoraID")] Frete frete)
        {
            if (ModelState.IsValid)
            {
                db.Fretes.Add(frete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TransportadoraID = new SelectList(db.Transportadoras, "ID", "Descricao", frete.TransportadoraID);
            ViewBag.VendaID = new SelectList(db.Vendas, "ID", "Descricao", frete.VendaID);
            return View(frete);
        }

        // GET: Fretes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frete frete = db.Fretes.Find(id);
            if (frete == null)
            {
                return HttpNotFound();
            }
            ViewBag.TransportadoraID = new SelectList(db.Transportadoras, "ID", "Descricao", frete.TransportadoraID);
            ViewBag.VendaID = new SelectList(db.Vendas, "ID", "Descricao", frete.VendaID);
            return View(frete);
        }

        // POST: Fretes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Descricao,EnderecoEntrega,Status,VendaID,TransportadoraID")] Frete frete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(frete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TransportadoraID = new SelectList(db.Transportadoras, "ID", "Descricao", frete.TransportadoraID);
            ViewBag.VendaID = new SelectList(db.Vendas, "ID", "Descricao", frete.VendaID);
            return View(frete);
        }

        // GET: Fretes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frete frete = db.Fretes.Find(id);
            if (frete == null)
            {
                return HttpNotFound();
            }
            return View(frete);
        }

        // POST: Fretes/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Frete frete = db.Fretes.Find(id);
            db.Fretes.Remove(frete);
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

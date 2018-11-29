﻿using System;
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
    public class VendasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vendas
        [Authorize]
        public ActionResult Index()
        {
            var vendas = db.Vendas.Include(v => v.Produto).Include(v => v.Transportadora);
            return View(vendas.ToList());
        }

        // GET: Vendas/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // GET: Vendas/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ProdutoID = new SelectList(db.Produtoes, "ID", "Descricao");
            ViewBag.TransportadoraID = new SelectList(db.Transportadoras, "ID", "Descricao");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Descricao,Quantidade,EnderecoDeEntrega,ValorTotal,Situacao,Pagamento,ProdutoID,DataVenda,TransportadoraID")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                Produto produto = db.Produtoes.Find(venda.ProdutoID);
                venda.ValorTotal = produto.PrecoBase * venda.Quantidade;
                produto.EstoqueInicial = produto.EstoqueInicial - venda.Quantidade;
                db.Entry(produto).State = EntityState.Modified;
                var frete = new Frete
                {
                    Descricao = "FreteProduto",
                    EnderecoEntrega = venda.EnderecoDeEntrega,
                    Status = enzo_estoqueV1.Models.StatusFrete.PendenteProcessamento,
                    VendaID = venda.ID,
                    TransportadoraID = venda.TransportadoraID
                };
                db.Fretes.Add(frete);
                db.Vendas.Add(venda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoID = new SelectList(db.Produtoes, "ID", "Descricao", venda.ProdutoID);
            ViewBag.TransportadoraID = new SelectList(db.Transportadoras, "ID", "Descricao", venda.TransportadoraID);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoID = new SelectList(db.Produtoes, "ID", "Descricao", venda.ProdutoID);
            ViewBag.TransportadoraID = new SelectList(db.Transportadoras, "ID", "Descricao", venda.TransportadoraID);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Descricao,Quantidade,EnderecoDeEntrega,ValorTotal,Situacao,Pagamento,ProdutoID,DataVenda,TransportadoraID")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoID = new SelectList(db.Produtoes, "ID", "Descricao", venda.ProdutoID);
            ViewBag.TransportadoraID = new SelectList(db.Transportadoras, "ID", "Descricao", venda.TransportadoraID);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venda venda = db.Vendas.Find(id);
            db.Vendas.Remove(venda);
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

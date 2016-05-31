using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EC.Application.Interfaces;
using EC.Application.ViewModel;
using EC.Infra.Data.Context;

namespace EC.PresentationUI.Mvc.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoApp;

        public ProdutosController(IProdutoAppService produtoApp)
        {
            _produtoApp = produtoApp;
        }

        // GET: Produtos
        public ActionResult Index()
        {
            var produtos = _produtoApp.GetAll();
            return View(produtos);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(Guid id)
        {
            var produtoViewModel = _produtoApp.GetById(id);
            return View(produtoViewModel);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                _produtoApp.Add(produtoViewModel);
                return RedirectToAction("Index");
            }

            return View(produtoViewModel);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(Guid id)
        {
            var produtoViewModel = _produtoApp.GetById(id);
            return View(produtoViewModel);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                _produtoApp.Update(produtoViewModel);
                return RedirectToAction("Index");
            }
            return View(produtoViewModel);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(Guid id)
        {
            var produtoViewModel = _produtoApp.GetById(id);
            return View(produtoViewModel);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var produtoViewModel = _produtoApp.GetById(id);
            _produtoApp.Remove(produtoViewModel);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               _produtoApp.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

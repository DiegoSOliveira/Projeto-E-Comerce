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
    public class VendasController : Controller
    {
        private readonly IVendaAppService _vendaApp;
        private readonly IClienteAppService _clienteApp;
        private readonly IProdutoAppService _produtoApp;

        public VendasController(
            IVendaAppService vendaApp,
            IClienteAppService clienteApp,
            IProdutoAppService produtoApp
            )
        {
            _vendaApp = vendaApp;
            _clienteApp = clienteApp;
            _produtoApp = produtoApp;
        }

        // GET: Vendas
        public ActionResult Index()
        {
            var vendaViewModels = _vendaApp.GetAll();
            return View(vendaViewModels.ToList());
        }

        // GET: Vendas/Details/5
        public ActionResult Details(Guid id)
        {
            VendaViewModel vendaViewModel = _vendaApp.GetById(id);
            return View(vendaViewModel);
        }

        // GET: Vendas/Create
        public ActionResult Create()
        {
            ViewBag.Clientes = _clienteApp.GetAll();
            ViewBag.Produtos = _produtoApp.GetAll();
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendaViewModel vendaViewModel)
        {
            if (ModelState.IsValid)
            {
               _vendaApp.Add(vendaViewModel);
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = _clienteApp.GetAll();
            return View(vendaViewModel);
        }

        // GET: Vendas/Edit/5
        public ActionResult Edit(Guid id)
        {
            var vendaViewModel = _vendaApp.GetById(id);
            ViewBag.Clientes = _clienteApp.GetAll();
            return View(vendaViewModel);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VendaViewModel vendaViewModel)
        {
            if (ModelState.IsValid)
            {
                _vendaApp.Update(vendaViewModel);
                return RedirectToAction("Index");
            }
            ViewBag.Cliente = _clienteApp.GetAll();
            return View(vendaViewModel);
        }

        // GET: Vendas/Delete/5
        public ActionResult Delete(Guid id)
        {
            var vendaViewModel = _vendaApp.GetById(id);
            return View(vendaViewModel);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var vendaViewModel = _vendaApp.GetById(id);
            _vendaApp.Remove(vendaViewModel);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _vendaApp.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

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

namespace EC.UI.Mvc.Controllers
{
    public class EnderecosController : Controller
    {
        private readonly IEnderecoAppService _enderecoApp;
        private readonly IClienteAppService _clienteApp;

        public EnderecosController(IEnderecoAppService enderecoApp, IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;
            _enderecoApp = enderecoApp;
        }

        // GET: Enderecos
        public ActionResult Index()
        {
            return View(_enderecoApp.GetAll());
        }

        // GET: Enderecos/Details/5
        public ActionResult Details(Guid id)
        {
            var enderecoViewModel = _enderecoApp.GetById(id);
            return View(enderecoViewModel);
        }

        // GET: Enderecos/Create
        public ActionResult Create()
        {
            ViewBag.Cliente = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome");
            return View();
        }

        // POST: Enderecos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EnderecoViewModel enderecoViewModel)
        {
            ViewBag.Cliente = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome");
            if (ModelState.IsValid)
            {
                _enderecoApp.Add(enderecoViewModel);
                return RedirectToAction("Index");
            }

            return View(enderecoViewModel);
        }

        // GET: Enderecos/Edit/5
        public ActionResult Edit(Guid id)
        {
            var enderecoViewModel = _enderecoApp.GetById(id);
            return View(enderecoViewModel);
        }

        // POST: Enderecos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EnderecoViewModel enderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _enderecoApp.Update(enderecoViewModel);
                return RedirectToAction("Index");
            }
            return View(enderecoViewModel);
        }

        // GET: Enderecos/Delete/5
        public ActionResult Delete(Guid id)
        {
            var enderecoViewModel = _enderecoApp.GetById(id);
            return View(enderecoViewModel);
        }

        // POST: Enderecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var endereco = _enderecoApp.GetById(id);
            _enderecoApp.Remove(endereco);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _enderecoApp.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

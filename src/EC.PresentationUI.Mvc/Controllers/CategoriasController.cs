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
    public class CategoriasController : Controller
    {
        private readonly ICategoriaAppService _categoriaApp;

        public CategoriasController(ICategoriaAppService categoriaApp)
        {
            _categoriaApp = categoriaApp;
        }
        // GET: Categorias
        public ActionResult Index()
        {
            var categorias = _categoriaApp.GetAll();
            return View(categorias);
        }

        // GET: Categorias/Details/5
        public ActionResult Details(Guid id)
        {
            var categoriaViewModel = _categoriaApp.GetById(id);
            return View(categoriaViewModel);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                _categoriaApp.Add(categoriaViewModel);
                return RedirectToAction("Index");
            }

            return View(categoriaViewModel);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(Guid id)
        {
            var categoriaViewModel = _categoriaApp.GetById(id);
            return View(categoriaViewModel);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                _categoriaApp.Update(categoriaViewModel);
                return RedirectToAction("Index");
            }
            return View(categoriaViewModel);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(Guid id)
        {
            var categoriaViewModel = _categoriaApp.GetById(id);
            return View(categoriaViewModel);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var categoriaViewModel = _categoriaApp.GetById(id);
            _categoriaApp.Remove(categoriaViewModel);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _categoriaApp.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

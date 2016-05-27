using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EC.Application.Interfaces;
using EC.Application.ViewModel;

namespace EC.UI.Mvc.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteAppService _clienteApp;
        private readonly IEstadoAppService _estadoApp;
        private readonly ICidadeAppService _cidadeApp;
        private readonly IEnderecoAppService _enderecoApp;

        public ClienteController(
                   IClienteAppService clienteApp,
                   IEstadoAppService estadoApp,
                   ICidadeAppService cidadeApp,
                   IEnderecoAppService enderecoApp)
        {
            _clienteApp = clienteApp;
            _estadoApp = estadoApp;
            _cidadeApp = cidadeApp;
            _enderecoApp = enderecoApp;
        }
        // GET: Cliente
        public ActionResult Index()
        {
            return View(_clienteApp.GetAll().ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteViewModel = _clienteApp.GetById(id);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.EstadoId = new SelectList(_estadoApp.GetAll().OrderBy(e => e.Nome), "EstadoId", "Nome");
            ViewBag.CidadeId = new SelectList(_cidadeApp.GetAll().OrderBy(c => c.Nome), "CidadeId", "Nome");
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            ViewBag.EstadoId = new SelectList(_estadoApp.GetAll().OrderBy(e => e.Nome), "EstadoId", "Nome", clienteEnderecoViewModel.EstadoId);
            ViewBag.CidadeId = new SelectList(_cidadeApp.GetAll().OrderBy(c => c.Nome), "CidadeId", "Nome", clienteEnderecoViewModel.CidadeId);

            if (ModelState.IsValid)
            {
                var result = _clienteApp.Add(clienteEnderecoViewModel);

                if (!result.IsValid)
                {
                    foreach (var validationAppError in result.Erros)
                    {
                        ModelState.AddModelError(string.Empty, validationAppError.Message);
                    }
                    return View(clienteEnderecoViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteViewModel = _clienteApp.GetById(id);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteApp.Update(clienteViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteViewModel = _clienteApp.GetById(id);
            _clienteApp.Remove(clienteViewModel);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ClienteViewModel clienteViewModel = _clienteApp.GetById(id);
            _clienteApp.Remove(clienteViewModel);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteApp.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

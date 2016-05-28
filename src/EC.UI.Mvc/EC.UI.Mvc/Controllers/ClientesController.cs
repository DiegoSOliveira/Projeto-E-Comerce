using System;
using System.Web.Mvc;
using EC.Application.Interfaces;
using EC.Application.ViewModel;

namespace EC.UI.Mvc.Controllers
{
    public class ClientesController : Controller
    {
        private IClienteAppService _clienteApp;
        private IEnderecoAppService _enderecoApp;

        public ClientesController(
            IClienteAppService clienteApp,
            IEnderecoAppService enderecoApp
            )
        {
            _clienteApp = clienteApp;
            _enderecoApp = enderecoApp;
        }
        // GET: Clientes
        public ActionResult Index()
        {
            return View(_clienteApp.GetAll());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(Guid id)
        {
            var clienteViewModel = _clienteApp.GetById(id);
            return View(clienteViewModel);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEndereco)
        {
            if (ModelState.IsValid)
            {
                var result = _clienteApp.Add(clienteEndereco);
                if (!result.IsValid)
                {
                    foreach (var valdiationAppError in result.Erros)
                    {
                        ModelState.AddModelError(string.Empty, valdiationAppError.Message);
                    }
                    return View(clienteEndereco);
                }
                return RedirectToAction("Index");
            }

            return View(clienteEndereco);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(Guid id)
        {
            var clienteViewModel = _clienteApp.GetById(id);

            return View(clienteViewModel);
        }

        // POST: Clientes/Edit/5
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

        // GET: Clientes/Delete/5
        public ActionResult Delete(Guid id)
        {
            var clienteViewModel = _clienteApp.GetById(id);
            return View(clienteViewModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var cliente = _clienteApp.GetById(id);
            _clienteApp.Remove(cliente);

            return RedirectToAction("Index");
        }
    }
}

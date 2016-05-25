using System;
using System.Collections.Generic;
using EC.Application.Validation;
using EC.Application.ViewModel;

namespace EC.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ValidationAppResult Add(ClienteEnderecoViewModel clienteViewModel);
        ClienteViewModel GetById(Guid id);
        IEnumerable<ClienteViewModel> GetAll();
        void Update(ClienteViewModel clienteViewModel);
        void Remove(ClienteViewModel clienteViewModel);
        int ObterTotalRegistros(string pesquisa);
        IEnumerable<ClienteViewModel> ObterClientesGrid(int page, string pesquisa);
    }
}
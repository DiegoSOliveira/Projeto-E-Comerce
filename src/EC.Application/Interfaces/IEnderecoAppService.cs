using System;
using System.Collections.Generic;
using EC.Application.ViewModel;

namespace EC.Application.Interfaces
{
    public interface IEnderecoAppService : IDisposable
    {
        void Add(EnderecoViewModel enderecoViewModel);
        EnderecoViewModel GetById(Guid id);
        IEnumerable<EnderecoViewModel> GetAll();
        void Update(EnderecoViewModel enderecoViewModel);
        void Remove(EnderecoViewModel enderecoViewModel);
        IEnumerable<EnderecoViewModel> GetByCliente(Guid clienteId);
    }
}
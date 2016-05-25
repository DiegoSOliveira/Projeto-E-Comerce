using System;
using System.Collections.Generic;
using EC.Application.ViewModel;

namespace EC.Application.Interfaces
{
    public interface IVendaAppService : IDisposable
    {
        void Add(VendaViewModel vendaViewModel);
        VendaViewModel GetById(Guid id);
        IEnumerable<VendaViewModel> GetAll();
        void Update(VendaViewModel vendaViewModel);
        void Remove(VendaViewModel vendaViewModel);
    }
}
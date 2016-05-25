using System;
using System.Collections.Generic;
using EC.Application.ViewModel;

namespace EC.Application.Interfaces
{
    public interface IEstadoAppService : IDisposable
    {
        void Add(EstadoViewModel estadoViewModel);
        EstadoViewModel GetById(Guid id);
        IEnumerable<EstadoViewModel> GetAll();
        void Update(EstadoViewModel estadoViewModel);
        void Remove(EstadoViewModel estadoViewModel);
    }
}
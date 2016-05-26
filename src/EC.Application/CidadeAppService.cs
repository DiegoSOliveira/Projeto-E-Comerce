using System;
using System.Collections.Generic;
using AutoMapper;
using EC.Application.Interfaces;
using EC.Application.ViewModel;
using EC.Domain.Entities.Geografia;
using EC.Domain.Interfaces.Services;
using EC.Infra.Data.Context;

namespace EC.Application
{
    public class CidadeAppService : AppServiceBase<DataContext>, ICidadeAppService
    {
        private readonly ICidadeService _cidadeService;

        public CidadeAppService(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }

        public void Add(CidadeViewModel cidadeViewModel)
        {
            var cidade = Mapper.Map<CidadeViewModel, Cidade>(cidadeViewModel);
            BeginTransaction();
            _cidadeService.Add(cidade);
            Commit();
        }

        public CidadeViewModel GetById(Guid id)
        {
            return Mapper.Map<Cidade, CidadeViewModel>(_cidadeService.GetById(id));
        }

        public IEnumerable<CidadeViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Cidade>, IEnumerable<CidadeViewModel>>(_cidadeService.GetAll());
        }

        public void Update(CidadeViewModel cidadeViewModel)
        {
            var cidade = Mapper.Map<CidadeViewModel, Cidade>(cidadeViewModel);
            BeginTransaction();
            _cidadeService.Update(cidade);
            Commit();
        }

        public void Remove(CidadeViewModel cidadeViewModel)
        {
            var cidade = Mapper.Map<CidadeViewModel, Cidade>(cidadeViewModel);
            BeginTransaction();
            _cidadeService.Remove(cidade);
            Commit();
        }

        public void Dispose()
        {
            _cidadeService.Dispose();
        }
    }
}
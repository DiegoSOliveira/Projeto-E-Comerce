using System;
using System.Collections.Generic;
using EC.Domain.Entities.Geografia;
using EC.Domain.Interfaces.Repository;
using EC.Domain.Interfaces.Repository.ReadOnly;
using EC.Domain.Interfaces.Services;

namespace EC.Domain.Services
{
    public class EnderecoService : ServiceBase<Endereco>, IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IEnderecoReadOnlyRepository _enderecoReadOnlyRepository;

        public EnderecoService(
            IEnderecoRepository enderecoRepository,
            IEnderecoReadOnlyRepository enderecoReadOnlyRepository
            )
            : base(enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
            _enderecoReadOnlyRepository = enderecoReadOnlyRepository;
        }

        public IEnumerable<Endereco>GetByCliente(Guid clienteId)
        {
           return _enderecoReadOnlyRepository.GetByCliente(clienteId);
        }

        public override IEnumerable<Endereco> GetAll()
        {
            return _enderecoReadOnlyRepository.GetAll();
        }

        public override Endereco GetById(Guid id)
        {
            return _enderecoReadOnlyRepository.GetById(id);
        }
    }
}
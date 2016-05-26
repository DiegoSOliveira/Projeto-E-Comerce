using EC.Domain.Entities.Geografia;
using EC.Domain.Interfaces.Repository;
using EC.Domain.Interfaces.Services;

namespace EC.Domain.Services
{
    public class CidadeService : ServiceBase<Cidade>, ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeService(ICidadeRepository cidadeRepository)
            : base(cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }
    }
}
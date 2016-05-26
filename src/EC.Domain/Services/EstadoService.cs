using EC.Domain.Entities.Geografia;
using EC.Domain.Interfaces.Repository;
using EC.Domain.Interfaces.Services;

namespace EC.Domain.Services
{
    public class EstadoService : ServiceBase<Estado>, IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository;

        public EstadoService(IEstadoRepository estadoRepository)
            : base(estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }
    }
}
using EC.Application;
using EC.Application.Interfaces;
using EC.Domain.Interfaces.Repository;
using EC.Domain.Interfaces.Services;
using EC.Domain.Services;
using EC.Infra.Data.Context;
using EC.Infra.Data.Interfaces;
using EC.Infra.Data.Repositories;
using EC.Infra.Data.UoW;

namespace EC.Infra.CrossCutting
{
    public class NinjectModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            // app
            Bind<IClienteAppService>().To<ClienteAppService>();
            Bind<IProdutoAppService>().To<ProdutoAppService>();
            Bind<IEnderecoAppService>().To<EnderecoAppService>();
            Bind<IEstadoAppService>().To<EstadoAppService>();
            Bind<ICidadeAppService>().To<CidadeAppService>();
            Bind<IVendaAppService>().To<VendaAppService>();

            // service
            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<IClienteService>().To<ClienteService>();
            Bind<IProdutoService>().To<ProdutoService>();
            Bind<IEnderecoService>().To<EnderecoService>();
            Bind<IEstadoService>().To<EstadoService>();
            Bind<ICidadeService>().To<CidadeService>();
            Bind<IVendaService>().To<VendaService>();

            // data repos
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<,>));
            Bind<IClienteRepository>().To<ClienteRepository>();
            Bind<IProdutoRepository>().To<ProdutoRepository>();
            Bind<IEnderecoRepository>().To<EnderecoRepository>();
            Bind<IEstadoRepository>().To<EstadoRepository>();
            Bind<ICidadeRepository>().To<CidadeRepository>();
            Bind<IVendaRepository>().To<VendaRepository>();

            // data repos read only
            //Bind<IClienteReadOnlyRepository>().To<ClienteReadOnlyRepository>();
            //Bind<IFornecedorReadOnlyRepository>().To<FornecedorReadOnlyRepository>();
            //Bind<IVendaReadOnlyRepository>().To<VendaReadOnlyRepository>();
            //Bind<IProdutoReadOnlyRepository>().To<ProdutoReadOnlyRepository>();

            //// ado repos only
            //Bind<IClienteADORepository>().To<ClienteADORepository>();

            // data configs
            Bind(typeof(IContextManager<>)).To(typeof(ContextManager<>));
            Bind<IDbContext>().To<DataContext>();
            Bind(typeof(IUnitOfWork<>)).To(typeof(UnitOfWork<>));

        }
    }
}
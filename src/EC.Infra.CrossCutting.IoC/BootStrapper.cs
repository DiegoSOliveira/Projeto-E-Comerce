using EC.Application;
using EC.Application.Interfaces;
using EC.Domain.Interfaces.Repository;
using EC.Domain.Interfaces.Repository.ReadOnly;
using EC.Domain.Interfaces.Services;
using EC.Domain.Services;
using EC.Infra.CrossCutting.Identity;
using EC.Infra.CrossCutting.Identity.Context;
using EC.Infra.CrossCutting.Identity.Configuration;
using EC.Infra.Data.Context;
using EC.Infra.Data.Interfaces;
using EC.Infra.Data.Repositories;
using EC.Infra.Data.Repositories.ReadOnly;
using EC.Infra.Data.UoW;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;

namespace EC.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.RegisterPerWebRequest<IdentityContext>();
            container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new IdentityContext()));
            container.RegisterPerWebRequest<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(/*container.GetInstance<IdentityContext>()*/));
            container.RegisterPerWebRequest<ApplicationRoleManager>();
            container.RegisterPerWebRequest<ApplicationUserManager>();
            container.RegisterPerWebRequest<ApplicationSignInManager>();

            //App
            container.Register(typeof(IAppServiceBase), typeof(AppServiceBase), Lifestyle.Scoped);
            container.Register<IClienteAppService, ClienteAppService>();
            container.Register<IEnderecoAppService, EnderecoAppService>();
            container.Register<IProdutoAppService, ProdutoAppService>();
            container.Register<ICategoriaAppService, CategoriaAppService>();
            container.Register<IVendaAppService, VendaAppService>();

            //Service
            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>), Lifestyle.Scoped);
            container.Register<IClienteService, ClienteService>();
            container.Register<IEnderecoService, EnderecoService>();
            container.Register<IProdutoService, ProdutoService>();
            container.Register<ICategoriaService, CategoriaService>();
            container.Register<IVendaService, VendaService>();

            //Repository
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Scoped);
            container.Register<IClienteRepository, ClienteRepository>();
            container.Register<IEnderecoRepository, EnderecoRepository>();
            container.Register<IProdutoRepository, ProdutoRepository>();
            container.Register<ICategoriaRepository, CategoriaRepository>();
            container.Register<IVendaRepository, VendaRepository>();

            //ReadOnly
            container.Register<IClienteReadOnlyRepository, ClienteReadOnlyRepository>();
            container.Register<IEnderecoReadOnlyRepository, EnderecoReadOnlyRepository>();
            container.Register<IProdutoReadOnlyRepository, ProdutoReadOnlyRepository>();
            container.Register<ICategoriaReadOnlyRepository, CategoriaReadOnlyRepository>();
            container.Register<IVendaReadOnlyRepository, VendaReadOnlyRepository>();

            //DataConfigs
            container.Register(typeof(IContextManager), typeof(ContextManager), Lifestyle.Scoped);
            container.Register(typeof(IUnitOfWork), typeof(UnitOfWork), Lifestyle.Scoped);

        }
    }
}
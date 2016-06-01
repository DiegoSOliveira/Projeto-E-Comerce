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
            container.RegisterPerWebRequest<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>());
            container.RegisterPerWebRequest<ApplicationRoleManager>();
            container.RegisterPerWebRequest<ApplicationUserManager>();
            container.RegisterPerWebRequest<ApplicationSignInManager>();

            //App
            container.Register(typeof(IAppServiceBase<>), typeof(AppServiceBase<>), Lifestyle.Scoped);
            container.RegisterPerWebRequest<IClienteAppService, ClienteAppService>();
            container.RegisterPerWebRequest<IEnderecoAppService, EnderecoAppService>();
            container.RegisterPerWebRequest<IProdutoAppService, ProdutoAppService>();
            container.RegisterPerWebRequest<ICategoriaAppService, CategoriaAppService>();
            container.RegisterPerWebRequest<IVendaAppService, VendaAppService>();

            //Service
            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>), Lifestyle.Scoped);
            container.RegisterPerWebRequest<IClienteService, ClienteService>();
            container.RegisterPerWebRequest<IEnderecoService, EnderecoService>();
            container.RegisterPerWebRequest<IProdutoService, ProdutoService>();
            container.RegisterPerWebRequest<ICategoriaService, CategoriaService>();
            container.RegisterPerWebRequest<IVendaService, VendaService>();

            //Repository
            container.Register(typeof(IRepositoryBase<>), new[] {typeof(RepositoryBase<,>).Assembly });
            container.RegisterPerWebRequest<IClienteRepository, ClienteRepository>();
            container.RegisterPerWebRequest<IEnderecoRepository, EnderecoRepository>();
            container.RegisterPerWebRequest<IProdutoRepository, ProdutoRepository>();
            container.RegisterPerWebRequest<ICategoriaRepository, CategoriaRepository>();
            container.RegisterPerWebRequest<IVendaRepository, VendaRepository>();

            //ReadOnly
            container.RegisterPerWebRequest<IClienteReadOnlyRepository, ClienteReadOnlyRepository>();
            container.RegisterPerWebRequest<IEnderecoReadOnlyRepository, EnderecoReadOnlyRepository>();
            container.RegisterPerWebRequest<IProdutoReadOnlyRepository, ProdutoReadOnlyRepository>();
            container.RegisterPerWebRequest<ICategoriaReadOnlyRepository, CategoriaReadOnlyRepository>();
            container.RegisterPerWebRequest<IVendaReadOnlyRepository, VendaReadOnlyRepository>();

            //DataConfigs
            container.Register(typeof(IContextManager<>), typeof(ContextManager<>), Lifestyle.Scoped);
            container.RegisterPerWebRequest<IDbContext, DataContext>();
            container.Register(typeof(IUnitOfWork<>), typeof(UnitOfWork<>), Lifestyle.Scoped);

        }
    }
}
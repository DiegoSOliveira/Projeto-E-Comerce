using EC.Infra.CrossCutting.Identity;
using EC.Infra.CrossCutting.Identity.Context;
using EC.Infra.CrossCutting.Identity.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;

namespace EC.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(SimpleInjector.Container container)
        {
            container.RegisterPerWebRequest<IdentityContext>();
            container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new IdentityContext()));
            container.RegisterPerWebRequest<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>());
            container.RegisterPerWebRequest<ApplicationRoleManager>();
            container.RegisterPerWebRequest<ApplicationUserManager>();
            container.RegisterPerWebRequest<ApplicationSignInManager>();



        }
    }
}
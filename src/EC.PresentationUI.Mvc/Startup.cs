using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EC.PresentationUI.Mvc.Startup))]
namespace EC.PresentationUI.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

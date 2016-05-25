using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EC.UI.Mvc.Startup))]
namespace EC.UI.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

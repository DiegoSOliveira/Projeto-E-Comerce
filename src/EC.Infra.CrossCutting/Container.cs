using CommonServiceLocator.NinjectAdapter.Unofficial;
using Ninject;
using Ninject.Modules;
using ServiceLocation;

namespace EC.Infra.CrossCutting
{
    public class Container
    {
        public Container()
        {
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(GetModule()));
        }

        public StandardKernel GetModule()
        {
            return new StandardKernel(new NinjectModule());
        }
    }
}
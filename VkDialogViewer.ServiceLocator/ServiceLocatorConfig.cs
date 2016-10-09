using Castle.MicroKernel.Registration;
using Castle.Windsor;
using VkDialogViewer.ServiceLocator.CastleWindsorInstaller;

namespace VkDialogViewer.ServiceLocator
{
    public static class ServiceLocatorConfig
    {
        private static IWindsorContainer container;

        public static void RegisterContainer(IWindsorInstaller installer)
        {
            container = new WindsorContainer();
            container.Install(installer);
            Microsoft.Practices.ServiceLocation.ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
        }
    }
}
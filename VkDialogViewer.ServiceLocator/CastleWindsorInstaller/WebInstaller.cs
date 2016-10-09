using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using VkDialogViewer.DAL;
using VkDialogViewer.DAL.Repository;

namespace VkDialogViewer.ServiceLocator.CastleWindsorInstaller
{
    public class WebInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));
            container.Register(Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient());

            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifeStyle.PerWebRequest);
            container.Register(Component.For<VkViewerDbContext>().ImplementedBy<VkViewerDbContext>().LifeStyle.PerWebRequest);
        }
    }
}
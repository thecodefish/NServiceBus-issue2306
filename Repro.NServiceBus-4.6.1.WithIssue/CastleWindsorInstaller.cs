using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Repro.NServiceBus_4._6._1.WithIssue
{
	public class CastleWindsorInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Classes.FromAssemblyInThisApplication()
				.Pick()
				.WithServiceDefaultInterfaces()
				.LifestyleTransient());
		}
	}
}
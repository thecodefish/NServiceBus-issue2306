
using System;
using Castle.Windsor;
using Castle.Windsor.Installer;
using NServiceBus;

namespace Repro.NServiceBus_4._6._1.WithoutIssue
{
    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
	public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization, IWantToRunWhenBusStartsAndStops
    {
		private IWindsorContainer _container;

		public void Start()
		{
			Console.WriteLine("Endpoint started");
		}

		public void Stop()
		{
			Console.WriteLine("Endpoint stopped");
		}

		public void Init()
		{
			_container = new WindsorContainer().Install(FromAssembly.This());

			Configure.With()
				.CastleWindsorBuilder(_container);
		}
    }
}

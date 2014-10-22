
using System;
using Castle.Windsor;
using Castle.Windsor.Installer;
using NServiceBus.Features;

namespace Repro.NServiceBus_5._0._1
{
    using NServiceBus;

    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantToRunWhenBusStartsAndStops
    {
	    private IWindsorContainer _container;

        public void Customize(BusConfiguration configuration)
        {
			_container = new WindsorContainer().Install(FromAssembly.This());

			configuration.UseContainer<WindsorBuilder>(c => c.ExistingContainer(_container));

	        configuration.UsePersistence<NServiceBus.Persistence.Legacy.MsmqPersistence>();
			configuration.DisableFeature<TimeoutManager>();
        }

	    public void Start()
	    {
		    Console.WriteLine("Endpoint started");
	    }

	    public void Stop()
	    {
		    Console.WriteLine("Endpoint stopped");
	    }
    }
}

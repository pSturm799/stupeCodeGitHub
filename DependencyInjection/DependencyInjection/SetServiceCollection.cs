using System;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    /// <summary>
    ///     Sets SetServiceCollection
    /// </summary>
    public class SetServiceCollection
    {
        /// <summary>
        ///     Run logic
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Run(IServiceCollection serviceCollection)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            //Abhängigkeiten
            //new SetServiceCollectionForProjekt1().Run(serviceCollection);
            //new SetServiceCollectionForProjekt2().Run(serviceCollection);
            ConfigureService(serviceCollection);
        }

        /// <summary>
        ///     Configures ServiceBusConsumerCore
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void ConfigureService(IServiceCollection serviceCollection)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            serviceCollection.AddSingleton<IParser, Parser>();
            serviceCollection.AddSingleton<IRepository, Repository>();
            serviceCollection.AddSingleton<ITransformator, Transformator>();
            serviceCollection.AddSingleton<IManager, Manager>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var manager = (IManager)serviceProvider.GetService(typeof(IManager));


            var results = manager.Load();
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
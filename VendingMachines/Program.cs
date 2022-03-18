
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using VendingMachines.Services;

namespace VendingMachines
{
    class Program
    {

        static void Main(string[] args)
        {
            var service = CreateHostBuilder(LoadConfiguration());
            service.GetService<IBasicFlow>().GetBasicFlow();
        }

        public static IConfiguration LoadConfiguration()

        {

            var builder = new ConfigurationBuilder()

               .SetBasePath(Directory.GetCurrentDirectory())

               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder.Build();

        }

        public static ServiceProvider CreateHostBuilder(IConfiguration config)
        {

            var serviceProvider = new ServiceCollection()


               .AddSingleton(config)
              .AddSingleton<IBasicFlow, BasicFlow>()
              .AddTransient<ISnackMachine, SnackMachine>()
              .AddTransient<IPayment, Payment>()
              .AddTransient<IMoney, Money>()


                  // add other class 
                  .BuildServiceProvider();


            return serviceProvider;
        }
    }
}

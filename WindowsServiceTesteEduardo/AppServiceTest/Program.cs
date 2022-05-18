using Domain.Service.Test.Helper;
using Domain.Service.Test.Interface;
using Microsoft.Extensions.DependencyInjection;
using Services.Service.Test.Implementations;
using System;
using System.Configuration;
using Topshelf;

namespace AppServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var seviceCollection = new ServiceCollection();
            ConfigureServices(seviceCollection);
            var objSeviceProvider = seviceCollection.BuildServiceProvider();
            ConnectionHelper.ConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ToString();
            var rc = HostFactory.Run(x =>
            {
                x.Service<ServiceApp>(s =>
                {
                    s.ConstructUsing(name => new ServiceApp(objSeviceProvider.GetService<IControleWinServices>()));
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Teste Diebold Nixdorf");
                x.SetDisplayName("WindowsServiceTesteEduardo");
                x.SetServiceName("WindowsServiceTesteEduardo");
            });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ILogArquivo, LogArquivo>()
                .AddScoped<IControleWinServices, ControleWinServices>();
        }
    }
}

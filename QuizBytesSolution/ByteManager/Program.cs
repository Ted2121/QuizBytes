using ByteManager.Client_Singletons;
using ByteManager.WinFormsUI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WindowsApiClient;

namespace ByteManager.WinFormsUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
    static void Main()
    {
            Configuration configuration = new();
            ApplicationConfiguration.Initialize();
            Application.Run(new Chapters());

            //    Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //    Application.EnableVisualStyles();
            //    Application.SetCompatibleTextRenderingDefault(false);
            //    var host = CreateHostBuilder().Build();
            //    ServiceProvider = host.Services;

            //    Application.Run(new Dashboard());
            //}
            //public static IServiceProvider ServiceProvider { get; private set; }
            //static IHostBuilder CreateHostBuilder()
            //{
            //    return Host.CreateDefaultBuilder()
            //        .ConfigureServices((context, services) =>
            //        {
            //            services.AddTransient<IChapterFacadeApiClient, ChapterFacadeApiClient>();
            //            services.AddTransient<Chapters>();
            //        });
        }
}
}
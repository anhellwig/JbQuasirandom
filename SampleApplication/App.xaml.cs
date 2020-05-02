using SampleApplication.Applications.Controllers;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Waf.Applications.Services;
using System.Waf.Foundation;
using System.Windows;

namespace SampleApplication
{
    public partial class App : Application
    {
        private AggregateCatalog catalog;
        private CompositionContainer container;
        private ApplicationController controller;


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Model).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IMessageService).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));

            container = new CompositionContainer(catalog, CompositionOptions.DisableSilentRejection);
            CompositionBatch batch = new CompositionBatch();
            batch.AddExportedValue(container);
            container.Compose(batch);

            controller = container.GetExportedValue<ApplicationController>();
            controller.Initialize();
            controller.Run();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            controller.Shutdown();
            container.Dispose();
            catalog.Dispose();
            base.OnExit(e);
        }
    }
}

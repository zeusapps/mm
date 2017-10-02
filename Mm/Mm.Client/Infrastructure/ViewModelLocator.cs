using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Mm.Client.Services;
using Mm.Client.ViewModels;

namespace Mm.Client.Infrastructure
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            var continer = SimpleIoc.Default;

            ServiceLocator.SetLocatorProvider(() => continer);

            continer.Register<MainViewModel>();
            continer.Register<IDataService, HttpDataService>();
            continer.Register<IHttpConfiguration, RemoteHttpConfiguration>();
            continer.Register<IDataParser, JsonDataParser>();
        }

        public MainViewModel Main => SimpleIoc.Default.GetInstance<MainViewModel>();
    }
}

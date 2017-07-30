using BSA_UWP.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace BSA_UWP
{
    public class ViewModelLocator
    {
        public ForecastViewModel ForecastVMInstance => ServiceLocator.Current.GetInstance<ForecastViewModel>();

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            NavigationService navigationService = new NavigationService();
            navigationService.Configure(nameof(ForecastViewModel), typeof(ForecastViewModel));

            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            SimpleIoc.Default.Register<ForecastViewModel>();
        }
    }
}

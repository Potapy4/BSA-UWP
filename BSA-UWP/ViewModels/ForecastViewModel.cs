using BSA_UWP.Models.OpenWeatherMap;
using BSA_UWP.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace BSA_UWP.ViewModels
{
    public class ForecastViewModel : ViewModelBase
    {
        private ForecastService forecastService;

        public Weather forecastData { get; set; }
        public ICommand ForecastCommand { get; set; }

        public string CityName { get; set; }
        public int ForecastDays { get; set; }

        public ForecastViewModel()
        {
            forecastData = null;
            forecastService = new ForecastService();
            ForecastCommand = new RelayCommand(GetWeather);          

            ForecastDays = 1; // Default value
        }

        public async void GetWeather()
        {
            try
            {
                forecastData = await forecastService.GetForecast(CityName, ForecastDays);
                RaisePropertyChanged(() => forecastData);
            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog(ex.Message);
                await dialog.ShowAsync();
            }
        }

    }
}

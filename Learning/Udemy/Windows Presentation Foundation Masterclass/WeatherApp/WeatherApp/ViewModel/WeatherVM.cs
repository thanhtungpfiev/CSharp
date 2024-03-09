using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        public WeatherVM()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                Query = "Enter a city";
                City = new City() { LocalizedName = "Hanoi" };
                CurrentConditions = new CurrentConditions()
                {
                    WeatherText = "Partly Cloudly",
                    Temperature = new Temperature()
                    {
                        Metric = new Units()
                        {
                            Value = 21
                        }
                    }
                };
            }
            SearchCommand = new SearchCommand(this);
            Cities = new ObservableCollection<City>();
        }

        private string query;

        public string Query
        {
            get { return query; }
            set { query = value; OnPropertyChanged("Query"); }
        }

        private City city;

        public City City
        {
            get { return city; }
            set { city = value; OnPropertyChanged("City"); GetCurrentConditons(); }
        }

        private bool isGettingConditions = false;

        private async void GetCurrentConditons()
        {
            if (isGettingConditions)
                return;

            isGettingConditions = true;
            Query = string.Empty;
            Cities.Clear();
            if (City != null)
            {
                CurrentConditions = await AccWeatherHelper.GetCurrentConditions(City.Key);
            }
            isGettingConditions = false;
        }

        private CurrentConditions currentConditions;

        public CurrentConditions CurrentConditions
        {
            get { return currentConditions; }
            set { currentConditions = value; OnPropertyChanged("CurrentConditions"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public SearchCommand SearchCommand { get; set; }

        public ObservableCollection<City> Cities { get; set; }

        private void OnPropertyChanged(string propertyName)
        {
            if (propertyName == "Query" && query == null)
            {
                return; // Skip the method call if the property value hasn't changed
            }
            else if (propertyName == "City" && city == null)
            {
                return; // Skip the method call if the property value hasn't changed
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void MakeQuery()
        {
            var cities = await AccWeatherHelper.GetCities(Query);
            Cities.Clear();
            foreach (var city in cities)
            {
                Cities.Add(city);
            }
        }
    }
}

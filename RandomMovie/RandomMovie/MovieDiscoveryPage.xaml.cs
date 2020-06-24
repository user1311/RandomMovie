using RandomMovie.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RandomMovie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDiscoveryPage : ContentPage
    {
        public MovieDiscoveryPage()
        {
            InitializeComponent();

            var networkConnectivtiy = Connectivity.NetworkAccess;

            if (networkConnectivtiy != NetworkAccess.Internet)
            {
                DisplayAlert("Connection not available", "Please activate internet connection", "Exit");
                connectionStatusLabel.Opacity = 1;
                return;
            }

            BindingContext = new MainViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess == NetworkAccess.Internet)
            {
                connectionStatusLabel.FadeTo(0).ContinueWith((result) => { });
            }
            else
            {
                connectionStatusLabel.FadeTo(1).ContinueWith((result) => { });
            }
            
        }
    }
}
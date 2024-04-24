using System.Collections.ObjectModel;
using CustoViagemMaui.Models;

namespace CustoViagemMaui
{
    public partial class MainPage : ContentPage
    {
        private App PropriedadesApp;

        public MainPage()
        {
            InitializeComponent();

            PropriedadesApp = (App)Application.Current; 
        }

        private void Calcular(object sender, EventArgs e)
        {

        }

        private async void AddPedagiosTela(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.AdicionarPedagio());
        }

        private async void ListaPedagios(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.ListaPedagios());
        }
    }

}

using System.Collections.ObjectModel;
using CustoViagemMaui.Models;
using CustoViagemMaui.Views;

namespace CustoViagemMaui
{
    public partial class MainPage : ContentPage
    {
        private App PropriedadesApp;
        double ValorTotal;
        public MainPage()
        {
            InitializeComponent();

            PropriedadesApp = (App)Application.Current;
        }

        private async void Calcular(object sender, EventArgs e)
        {
           
            List<Pedagio> tmp = await App.Db.();
            foreach (Pedagio p in tmp)
            {
                ValorTotal += p;
            }
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

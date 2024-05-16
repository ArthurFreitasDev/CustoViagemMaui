using System.Collections.ObjectModel;
using CustoViagemMaui.Models;
using CustoViagemMaui.Views;

namespace CustoViagemMaui
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();

            PropriedadesApp = (App)Application.Current;
        }

        private async void Calcular(object sender, EventArgs e)
        {

            try
            {
                App.Current.MainPage = new NavigationPage(new CalculoFinal())
                {
                    BindingContext = new InfoViagem()
                    {
                        Origem = txtOrigem.Text,
                        Destino = txtDestino.Text,
                        Distancia = double.Parse(txtDistancia.Text),
                        Rendimento = double.Parse(txtRendimento.Text),
                        PrecoGas = double.Parse(txtPrecoGas.Text),
                    }
                };
            } catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
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

        private async void MainPageTela(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void Limpar(object sender, EventArgs e)
        {
            txtOrigem.Text = "";
            txtDistancia.Text = "";
            txtDestino.Text = "";
            txtPrecoGas.Text = "";
            txtRendimento.Text = "";
        }
    }

}

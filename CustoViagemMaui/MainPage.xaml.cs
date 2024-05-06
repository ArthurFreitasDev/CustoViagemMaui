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
            
            try
            {
                List<Pedagio> tmp = await App.Db.GetValue();
                foreach (Pedagio p in tmp)
                {
                    ValorTotal += p.ValorPedagio;
                }

                if (string.IsNullOrEmpty(txtOrigem.Text))
                    throw new Exception("Por favor, preencha a origem");
                if (string.IsNullOrEmpty(txtDistancia.Text))
                    throw new Exception("Por favor, preencha a distancia");
                if (string.IsNullOrEmpty(txtDestino.Text))
                    throw new Exception("Por favor, preencha o destino");
                if (string.IsNullOrEmpty(txtPrecoGas.Text))
                    throw new Exception("Por favor, preencha o preço da gasolina");
                if (string.IsNullOrEmpty(txtRendimento.Text))
                    throw new Exception("Por favor, preencha o rendimento");

                double rendimento = double.Parse(txtRendimento.Text);
                double distancia = double.Parse(txtDistancia.Text);
                double precoGas = double.Parse(txtPrecoGas.Text);

                ValorTotal += (distancia / rendimento) * precoGas;

                await DisplayAlert("Valor total da viagem",$"O valor total da viagem de {txtOrigem.Text} para {txtDestino.Text} custará um total de {ValorTotal.ToString()}", "OK");

                ValorTotal = 0;
            }
            catch(Exception ex)
            {
                await DisplayAlert("Ops", "Ocorreu um erro: " +  ex.Message, "OK");
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

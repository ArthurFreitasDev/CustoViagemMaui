namespace CustoViagemMaui.Views;
using CustoViagemMaui;
using CustoViagemMaui.Models;
using CustoViagemMaui.Views;

public partial class CalculoFinal : ContentPage
{
    private App PropriedadesApp;
    double ValorTotal;
    double rendimento;
    double distancia;
    double precoGas;
    public CalculoFinal()
	{
		InitializeComponent();
        
}

    private async void Calcular(object sender, EventArgs e)
    {
        List<Pedagio> tmp = await App.Db.GetValue();
        foreach (Pedagio p in tmp)
        {
            ValorTotal += p.ValorPedagio;
        };
        foreach (Pedagio p in tmp)
        {
            rendimento += p.Rendimento;
        }
        foreach (Pedagio p in tmp)
        {
            distancia += p.Distancia;
        };



        ValorTotal += (distancia / rendimento) * precoGas;

        await DisplayAlert("Valor total da viagem", $"O valor total da viagem de {} para {txtDestino.Text} custará um total de {ValorTotal.ToString()}", "OK");

        ValorTotal = 0;
    }
                    catch(Exception ex)
                    {
                        await DisplayAlert("Ops", "Ocorreu um erro: " +  ex.Message, "OK");
}
    }
}


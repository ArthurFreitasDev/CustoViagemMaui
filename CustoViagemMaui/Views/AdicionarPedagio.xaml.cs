using CustoViagemMaui.Models;

namespace CustoViagemMaui.Views;

public partial class AdicionarPedagio : ContentPage
{
	public AdicionarPedagio()
	{
		InitializeComponent();
	}

    private async void btnAdicionar(object sender, EventArgs e)
    {
        try
		{
            Pedagio p = new Pedagio
            {
                ValorPedagio = Convert.ToDouble(txtValorPedagio.Text),
                Local = txtLocalPedagio.Text,
            };
            await App.Db.Insert(p);
            await DisplayAlert("Sucesso", "Pedagio adicionado!", "OK");
            await Navigation.PushAsync(new MainPage());
        }
		catch(Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "OK");
		}
    }
}
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
			
		}
		catch(Exception ex)
		{

		}
    }
}
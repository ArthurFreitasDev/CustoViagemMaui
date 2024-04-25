using System.Collections.ObjectModel;
using CustoViagemMaui.Models;
namespace CustoViagemMaui.Views;

public partial class ListaPedagios : ContentPage
{

    ObservableCollection<Pedagio> Lista_Pedagios = new ObservableCollection<Pedagio>();

	public ListaPedagios()
	{
		InitializeComponent();
        lstPedagios.ItemsSource = Lista_Pedagios;
	}

    protected async override void OnAppearing()
    {
        if (Lista_Pedagios.Count == 0)
        {
            List<Pedagio> tpm = await App.Db.GetAll();
            foreach (Pedagio p in tpm)
            {
                Lista_Pedagios.Add(p);
            }
        }
    }

    private void lstPedagios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Pedagio? p = e.SelectedItem as Pedagio;
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {

    }
}
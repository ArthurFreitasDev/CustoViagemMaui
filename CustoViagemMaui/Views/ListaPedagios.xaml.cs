using System.Collections.ObjectModel;
using CustoViagemMaui.Models;
namespace CustoViagemMaui.Views;

public partial class ListaPedagios : ContentPage
{

    ObservableCollection<Pedagio> Lista_Pedagios = new ObservableCollection<Pedagio>();
    public ObservableCollection<Pedagio> publicLista_Pedagios { get { return Lista_Pedagios; } }

	public ListaPedagios()
	{
        InitializeComponent();
        ListaPedagiosView.ItemsSource = Lista_Pedagios;
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
    private void MenuItemRemover(object sender, EventArgs e)
    {

    }

    private void lstPedagios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Pedagio? p = e.SelectedItem as Pedagio;
    }

    private async void AddPedagiosTela(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.AdicionarPedagio());
    }

    private async void MainPageTela(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}
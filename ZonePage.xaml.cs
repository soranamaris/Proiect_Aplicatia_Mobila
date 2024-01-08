using Proiect_Aplicatia_Mobila.Models;

namespace Proiect_Aplicatia_Mobila;

public partial class ZonePage : ContentPage
{
	public ZonePage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
       

        listView.ItemsSource = await App.Database.GetZoneAsync();
    }
    async void OnZoneAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ZonePage
        {
            BindingContext = new Zone()
        });
    }
    async void OnZoneViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ZonePage
            {
                BindingContext = e.SelectedItem as Zone
            });
        }
    }
}
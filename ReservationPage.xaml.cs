using Proiect_Aplicatia_Mobila.Models;

namespace Proiect_Aplicatia_Mobila;

public partial class ReservationPage : ContentPage
{    
    public ReservationPage()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetReservationAsync();
    }
    async void OnShopListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ReservationPage
        {
            BindingContext = new Reservation()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ReservationPage
            {
                BindingContext = e.SelectedItem as Reservation
            });
        }
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var rlist = (Reservation)BindingContext;
       


        await App.Database.SaveReservationAsync(rlist);
        listView.ItemsSource = await App.Database.GetReservationAsync(); 
        
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var rlist = (Reservation)BindingContext;
        await App.Database.DeleteReservationAsync(rlist);
        listView.ItemsSource = await App.Database.GetReservationAsync();
    }
    async void OnReservationAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ReservationPage
        {
            BindingContext = new Reservation()
        });
    }

    async void OnReservationViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ReservationPage
            {
                BindingContext = e.SelectedItem as Reservation
            });
        }
    }
   public void OnZonePickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedZone = zonePicker.SelectedItem as string;
        
    }
    public void OnTablePickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedTable = tablePicker.SelectedItem as string;
        
    }
}
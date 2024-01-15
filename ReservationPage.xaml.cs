using Proiect_Aplicatia_Mobila.Models;
using System.Diagnostics;

namespace Proiect_Aplicatia_Mobila;

public partial class ReservationPage : ContentPage
{     
    public ReservationPage()
    {
        InitializeComponent();
        BindingContext = new Reservation
        {
            ReservationDate = DateTime.Now
        };
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //listView.ItemsSource = await App.Database.GetReservationAsync();
        var reservations = await App.Database.GetReservationAsync();
        foreach (var reservation in reservations)
        {
            Debug.WriteLine($"ID: {reservation.ID}, Nume: {reservation.Nume}, Date: {reservation.ReservationDate}, Time: {reservation.ReservationTime}, Duration: {reservation.ReservationDuration}");
        }

        
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
    async void ReservationOnSaveButtonClicked(object sender, EventArgs e)
    {
        var rlist = BindingContext as Reservation;
        if (rlist != null)
        {
            try
            {
                await App.Database.SaveReservationAsync(rlist);
                await Navigation.PopAsync(); // Sau folosește await Navigation.PushAsync(new ListReservationPage());
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var rlist = (Reservation)BindingContext;
        if (rlist != null)
        {
            await App.Database.DeleteReservationAsync(rlist);
            await Navigation.PopAsync(); // Sau folosește await Navigation.PushAsync(new ListReservationPage());
        }
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
        if (!string.IsNullOrEmpty(selectedZone))
        {
            var reservation = (Reservation)BindingContext;
            reservation.Zone = selectedZone;
        }
    }

    public void OnTablePickerSelectedIndexChanged(object sender, EventArgs e)
{
        var selectedTable = tablePicker.SelectedItem as int?;
        if (selectedTable.HasValue)
        {
            var reservation = (Reservation)BindingContext;
            reservation.NumarLocuri = selectedTable.Value;
        }
}

}
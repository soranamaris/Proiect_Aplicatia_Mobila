using Proiect_Aplicatia_Mobila.Models;
using System.Diagnostics;

namespace Proiect_Aplicatia_Mobila;

public partial class ReservationPage : ContentPage
{    
    public ReservationPage()
    {
        InitializeComponent();
        BindingContext = new Reservation();
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

        listView.ItemsSource = reservations;
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
        //var rlist = BindingContext as Reservation;

        //if (rlist == null)
        //{
        //    return;
        //}

        //await App.Database.SaveReservationAsync(rlist);
        //listView.ItemsSource = await App.Database.GetReservationAsync();

        try
        {
            var rlist = BindingContext as Reservation;

            if (rlist == null)
            {
                Debug.WriteLine("BindingContext is null");
                return;
            }

            Debug.WriteLine($"Nume: {rlist.Nume}, Date: {rlist.ReservationDate}, Time: {rlist.ReservationTime}, Duration: {rlist.ReservationDuration}");

            await App.Database.SaveReservationAsync(rlist);
            listView.ItemsSource = await App.Database.GetReservationAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex.Message}");
        }

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
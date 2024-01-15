using Proiect_Aplicatia_Mobila.Models;
using System.Diagnostics;

namespace Proiect_Aplicatia_Mobila
{
    public partial class ListReservationPage : ContentPage
    {
        public ListReservationPage()
        {
            InitializeComponent();
           
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetReservationAsync();
        }

        async void OnReservationAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReservationPage
            {
                BindingContext = new Reservation
                {
                    ReservationDate = DateTime.Now 
                }
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
    }
}

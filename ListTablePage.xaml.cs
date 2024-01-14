using Proiect_Aplicatia_Mobila.Models;
using System.Diagnostics;
namespace Proiect_Aplicatia_Mobila;

public partial class ListTablePage : ContentPage
{
    public ListTablePage()
    {
        InitializeComponent();
        BindingContext = new TableList();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //listView.ItemsSource = await App.Database.GetReservationAsync();
        var tables = await App.Database.GetTableListAsync();
        foreach (var table in tables)
        {
            Debug.WriteLine($"Descriere masa: {table.Description}, Zone: {table.Zone}, Num?r de Locuri: {table.Seats}, Selectat?: {table.IsSelected}");
        }

        listView.ItemsSource = tables;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        try
        {
            var tlist = BindingContext as TableList;

            if (tlist == null)
            {
                Debug.WriteLine("BindingContext is null");
                return;
            }

            Debug.WriteLine($"Descriere masa: {tlist.Description}, Zone: {tlist.Zone}, Num?r de Locuri: {tlist.Seats}, Selectat?: {tlist.IsSelected}");

            await App.Database.SaveTableListAsync(tlist);
            listView.ItemsSource = await App.Database.GetTableListAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex.Message}");
        }
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var tlist = (TableList)BindingContext;
        await App.Database.DeleteTableListAsync(tlist);
        await Navigation.PopAsync();
    }
    async void OnTableListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TablePage
        {
            BindingContext = new TableList()
        });
    }

    async void OnTableListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new TablePage
            {
                BindingContext = e.SelectedItem as TableList
            });
        }
    }
}
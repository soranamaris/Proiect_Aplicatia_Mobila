using Proiect_Aplicatia_Mobila.Models;
namespace Proiect_Aplicatia_Mobila;

public partial class TablePage : ContentPage
{
	public TablePage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var tlist = (TableList)BindingContext;
        if (tlist == null)
        {
            return;
        }

        await App.Database.SaveTableListAsync(tlist);
        await Navigation.PopAsync();
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
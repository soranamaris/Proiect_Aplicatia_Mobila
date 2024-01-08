using System;
using Proiect_Aplicatia_Mobila.Data;
using System.IO;
namespace Proiect_Aplicatia_Mobila;

public partial class App : Application
{
    static RestaurantDatabase database;
    public static RestaurantDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               RestaurantDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "RestaurantList.db3"));
            }
            return database;
        }
    }

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}

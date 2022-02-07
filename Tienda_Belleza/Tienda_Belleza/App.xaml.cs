using System;
using System.IO;
using Tienda_Belleza.DataBase;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tienda_Belleza
{
  
    public partial class App : Application
    {
        static SQLHeper db;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
        public static SQLHeper SQLiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new SQLHeper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Tienda.db"));
                }
                return db;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

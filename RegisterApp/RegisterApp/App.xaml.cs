using RegisterApp.Model;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace RegisterApp
{
    public partial class App : Application
    {
        string _filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "isLogged.txt");
        string _PESEL = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PESEL.txt");

        

        public App()
        {
            InitializeComponent();

            ApiHelper.InitializeClient();

            File.Delete(_filename);
            File.Delete(_PESEL);
            
            MainPage = new NavigationPage(new MainPage());
        }
        

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

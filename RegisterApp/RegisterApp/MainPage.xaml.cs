using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RegisterApp
{
    public partial class MainPage : ContentPage
    {
        string _filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "isLogged.txt");


        public MainPage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            if (File.Exists(_filename))
            {
                BTN_Login.IsEnabled = false;
                BTN_Doc.IsEnabled = true;
                BTN_His.IsEnabled = true;
                BTN_Reg.IsEnabled = true;
            }
            else
            {
                BTN_Login.IsEnabled = true;
                BTN_Doc.IsEnabled = false;
                BTN_His.IsEnabled = false;
                BTN_Reg.IsEnabled = false;
            }
        }

        private async void BTN_Reg_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void BTN_Doc_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DoctorsPage());
        }

        private async void BTN_His_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage());
        }

        private async void BTN_Login_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}

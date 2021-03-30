using RegisterApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegisterApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            List<Register> registers = new List<Register>();
            string url = "https://projektv320191207073507.azurewebsites.net/api/registrations/get/empty";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    registers = await response.Content.ReadAsAsync<List<Register>>();
                }
            }

            Register_View.ItemsSource = registers;
        }

        private async void Register_View_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new RegisterQuestion
                {
                    BindingContext = e.SelectedItem as Register
                });
            }
        }
    }
}
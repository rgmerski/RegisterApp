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
	public partial class DoctorInfoPage : ContentPage
	{
        public DoctorInfoPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            string id_temp = ID_Lab.Text;

            string url_hours = "https://projektv320191207073507.azurewebsites.net/api/registrations/get/empty/" + id_temp;
            List<Hours> hours = new List<Hours>();

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url_hours))
            {
                if (response.IsSuccessStatusCode)
                {
                    hours = await response.Content.ReadAsAsync<List<Hours>>();
                }
            }


            InfoView.ItemsSource = hours;
        }

        private async void InfoView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new RegisterToPage
                {
                    BindingContext = e.SelectedItem as Hours
                });
            }
        }
    }
}
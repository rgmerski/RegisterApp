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
	public partial class DoctorsPage : ContentPage
	{
		public DoctorsPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            List<Doctor> doctors = new List<Doctor>();
            string url = "https://projektv320191207073507.azurewebsites.net/api/doctors/getdoctors";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    doctors = await response.Content.ReadAsAsync<List<Doctor>>();
                }
            }
            listView.ItemsSource = doctors;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new DoctorInfoPage
                {
                    BindingContext = e.SelectedItem as Doctor
                });
            }
        }

       
    }
}
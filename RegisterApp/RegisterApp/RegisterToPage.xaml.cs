using RegisterApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegisterApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterToPage : ContentPage
	{

        string _ID = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ID.txt");

        string Id_reg;
		public RegisterToPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var temp = (Hours)BindingContext;
            Id_reg = temp.Id;
        }

        private async void BTN_Yes_Clicked(object sender, EventArgs e)
        {
            string id_r = Id_reg;
            string id_p;

            using (StreamReader sr = new StreamReader(_ID))
            {
                id_p = sr.ReadLine();
            }

            Data data = new Data
            {
                id = id_r,
                idpatient = id_p
            };

            string url = "https://projektv320191207073507.azurewebsites.net/api/registrations/add/bypatientid";

            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, data);
            await Navigation.PopAsync();
        }

        private async void BTN_No_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

    public class Data
    {
        public string id { get; set; }
        public string idpatient { get; set; }
    }
}
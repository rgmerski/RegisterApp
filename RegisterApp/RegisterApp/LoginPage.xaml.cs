using RegisterApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegisterApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        string _filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "isLogged.txt");
        string _PESEL = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PESEL.txt");
        string _ID = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ID.txt");

        public LoginPage ()
		{
			InitializeComponent ();
            
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            // ALREADY LOGGED
            if (File.Exists(_filename))
            {
                using (StreamReader sr = new StreamReader(_filename))
                {
                    string line = sr.ReadLine();
                    if (line == "LOGGED")
                    {
                        await Navigation.PopAsync();
                    }
                    
                }
            }
        }

        private async void BTN_Login_Clicked(object sender, EventArgs e)
        {
            
            string url = "https://projektv320191207073507.azurewebsites.net/api/patients/getpatients";

            List<Patient> patients = new List<Patient>();

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    patients = await response.Content.ReadAsAsync<List<Patient>>();
                }
            }

            foreach (Patient patient in patients)
            {
                if (pesel_ed.Text == patient.PESEL && pass_ed.Text == patient.Password)
                {
                    using (StreamWriter sw = new StreamWriter(_filename))
                    {
                        
                        sw.WriteLine("LOGGED");
                        using (StreamWriter sw2 = new StreamWriter(_PESEL))
                        {
                            sw2.WriteLine(patient.PESEL);
                        }
                        using (StreamWriter sw3 = new StreamWriter(_ID))
                        {
                            sw3.WriteLine(patient.Id);
                        }

                        await Navigation.PopAsync();
                        break;
                    }
                }
            }

        }


    }
}
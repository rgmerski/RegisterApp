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
	public partial class HistoryPage : ContentPage
	{

        string _ID = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ID.txt");
        string _PESEL = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PESEL.txt");
        List<Register> registers = new List<Register>();
        Register curr;

        public HistoryPage ()
		{
            curr = null;
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            string PESEL;

            using (StreamReader sr = new StreamReader(_PESEL))
            {
                PESEL = sr.ReadLine();
            }

            base.OnAppearing();

            string url = "https://projektv320191207073507.azurewebsites.net/api/registrations/get/bypatientpesel/" + PESEL;


            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    registers = await response.Content.ReadAsAsync<List<Register>>();
                }
            }

            listView.ItemsSource = registers;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            curr = (Register)e.SelectedItem;
        }

        private async void BTN_Del_Clicked(object sender, EventArgs e)
        {
            if (curr != null)
            {
                string id_p;
                using (StreamReader sr = new StreamReader(_ID))
                {
                    id_p = sr.ReadLine();
                }

                string url_del = "https://projektv320191207073507.azurewebsites.net/api/registrations/remove";
                temp temp = new temp
                {
                    id = curr.Id,
                    idpatient = id_p
                };
                HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url_del, temp);
                registers.Remove(curr);
            }
        }
    }

    public class temp
    {
        public string id { get; set; }
        public string idpatient { get; set; }
    }
}
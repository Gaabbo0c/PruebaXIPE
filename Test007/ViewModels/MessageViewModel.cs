using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Test007.ViewModels
{
    class MessageViewModel : BaseViewModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }

        private string _mesagge;
        public string Messages
        {
            get { return _mesagge; }
            set { _mesagge = value; OnPropertyChanged(); }
        }

        public ICommand SubmitCommand { private set; get; }

        public MessageViewModel()
        {
            SubmitCommand = new Command(async () => await SendEmail());

        }

        async Task SendEmail()
        {
            try
            {
                var vars = new Dictionary<string, string> { { "name", $"{Name}" }, { "email", $"{Email}" }, { "message", $"{Messages}" } };
                string resp = await PostMessage(vars);
                if (resp.Contains("Accepted"))
                {
                    await Application.Current.MainPage.DisplayAlert("Dinamic XAML", "Message sent", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Dinamic XAML", "Message fail", "OK");
                }
                

            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Dinamic XAML", "Error", "OK");
            }
        }

        private async static Task<string> PostMessage(IEnumerable<KeyValuePair<string, string>> queries)
        {
            string URL = "https://prod-116.westus.logic.azure.com/workflows/b2ce42a4838e44d28a898b03e3213db5/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=g6si3H1n_vXCvZTcQsWCtvGBPETsHusahQQEVTFpM3A";
            HttpContent q = new FormUrlEncodedContent(queries);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync(URL, q))
                {
                    using (HttpContent content = response.Content)
                    {
                        string micont = await content.ReadAsStringAsync();
                        HttpContentHeaders headers = content.Headers;
                        return response.StatusCode.ToString();
                    }
                }
            }
        }

    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Test007.Models
{
    class ViewModel
    {
        public static string form_heading { get; set; }

        public static string fields { get; set; }

        public static string submit_button { get; set; }

        public static async Task getValuesAsync()
        {
            string url = "https://prod-42.westus.logic.azure.com/workflows/b0a4ba32ccd44938b3ba5e9cc4d1d2fa/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=5FGR4qL3YLaJB7Wd7j7mEx1OKtXG7GVlG9XHlTwAWvA";
            string HTML = "";
            var httpClient = new HttpClient();
            var message = await httpClient.GetAsync(url);
            if (message.StatusCode == HttpStatusCode.OK)
            {
                 HTML = await message.Content.ReadAsStringAsync();
            }
            JObject json = JObject.Parse(HTML);

            if (json.Count > 0)
            {
                form_heading = json["form_heading"].ToString();
                submit_button = json["submit_button"]["text"].ToString();
                fields = json["fields"].ToString();
            }
        }
        public ViewModel()
        {
            getValuesAsync();
        }

    }
}

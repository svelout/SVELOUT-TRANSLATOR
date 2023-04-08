using System.Net;
using System.Text;

namespace SVELOUT_TRANSLATOR
{
    public class WebHook
    {
        private string URL { get; }

        public WebHook(string URL)
        {
            this.URL = URL;
        }

        public void SendMessage(string content)
        {
            WebClient client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            string payload = "{\"content\": \"" + content + "\"}";
            client.UploadData(URL, Encoding.UTF8.GetBytes(payload));
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace send_app
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public class Message
    {
        public string apikey { get; set; }
        public string numbers { get; set; }
        public string message { get; set; }
        public string sender { get; set; }
        
        static  async public void SendSMS(string Apikey, string Numbers, string Message, string Sender)
        {

            

            var formContent = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("apikey", Apikey),
            new KeyValuePair<string, string>("numbers", Numbers),
            new KeyValuePair<string, string>("message", Message),
            new KeyValuePair<string, string>("sendersender", Sender)
            });
            
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync("https://api.txtlocal.com/send/", formContent);
            HttpContent content =  response.Content;
            string data = await content.ReadAsStringAsync();
            dynamic obj = JsonConvert.DeserializeObject(data);
            string status = obj.status;
            //string error = obj.errors[0].code;
            MessageBox.Show("status " + status);
           


        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Message.SendSMS("jg/U5/zCrxQ-0buZ7q6f1qdCDWadJh2cu0RTiJdHoZ",TextBoxto.Text,TextBoxmessage.Text,TextBoxfrom.Text);
        }
    }
}

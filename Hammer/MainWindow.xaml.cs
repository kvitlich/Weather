using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace Hammer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            weatherCardToday.Content = $"Погода на {DateTime.Today.Date.GetDateTimeFormats().First()}";
            weatherCardTomorrow.Content = $"Погода на {DateTime.Today.Date.AddDays(1).GetDateTimeFormats().First()}";
            weatherCardThird.Content = $"Погодп на {DateTime.Today.Date.AddDays(2).GetDateTimeFormats().First()}";
            weatherCardFourth.Content = $"Погода на {DateTime.Today.Date.AddDays(3).GetDateTimeFormats().First()}";

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
            {
                JObject json = new JObject();
                try
                {
                    WebClient client = new WebClient();

                    json = JObject.Parse(client.DownloadString(new Uri($@"https://api.openweathermap.org/data/2.5/forecast?q={cityNameTextBox.Text}&units=metric&lang=ru&appid=9b8518fa8db7d363dbdb5ef9fefc9c13")));

                    string res = json["list"].ToString();

                    string Temp = $"Температура: {json["list"][0]["main"]["temp"].ToString()}";
                    string Pressure = $"Давление {json["list"][0]["main"]["pressure"].ToString()}";
                    string Wind = $"Ветер: {json["list"][0]["wind"]["speed"].ToString()}";
                    string Desc = $"Описание: {json["list"][0]["weather"][0]["description"].ToString()}";
                    weatherCardToday.Content = $"{weatherCardToday.Content.ToString()}\n{Temp}\n{Pressure}\n{Wind}\n{Desc}";

                    Temp = $"Температура: {json["list"][1]["main"]["temp"].ToString()}";
                    Pressure = $"Давление {json["list"][1]["main"]["pressure"].ToString()}";
                    Wind = $"Ветер: {json["list"][1]["wind"]["speed"].ToString()}";
                    Desc = $"Описание: {json["list"][1]["weather"][0]["description"].ToString()}";
                    weatherCardTomorrow.Content = $"{weatherCardTomorrow.Content.ToString()}\n{Temp}\n{Pressure}\n{Wind}\n{Desc}";

                    Temp = $"Температура: {json["list"][2]["main"]["temp"].ToString()}";
                    Pressure = $"Давление {json["list"][2]["main"]["pressure"].ToString()}";
                    Wind = $"Ветер: {json["list"][2]["wind"]["speed"].ToString()}";
                    Desc = $"Описание: {json["list"][2]["weather"][0]["description"].ToString()}";
                    weatherCardThird.Content = $"{weatherCardThird.Content.ToString()}\n{Temp}\n{Pressure}\n{Wind}\n{Desc}";

                    Temp = $"Температура: {json["list"][3]["main"]["temp"].ToString()}";
                    Pressure = $"Давление {json["list"][3]["main"]["pressure"].ToString()}";
                    Wind = $"Ветер: {json["list"][3]["wind"]["speed"].ToString()}";
                    Desc = $"Описание: {json["list"][3]["weather"][0]["description"].ToString()}";
                    weatherCardFourth.Content = $"{weatherCardFourth.Content.ToString()}\n{Temp}\n{Pressure}\n{Wind}\n{Desc}";

                    MessageBox.Show("Done!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}


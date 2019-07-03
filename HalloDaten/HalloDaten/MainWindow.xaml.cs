using Newtonsoft.Json;
using System.Net.Http;
using System.Windows;

namespace HalloDaten
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Suche(object sender, RoutedEventArgs e)
        {
            string url = $"https://www.googleapis.com/books/v1/volumes?q={suchTb.Text}";

            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);

                var result = JsonConvert.DeserializeObject<BooksResult>(json);

                lb.ItemsSource = result.items;
            }
        }
    }
}

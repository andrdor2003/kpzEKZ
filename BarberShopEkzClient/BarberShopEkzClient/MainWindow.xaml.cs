using BarberShopEkzClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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


namespace BarberShopEkzClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Appointment> Appointments { get; set; }

        public List<Customer> Customers { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Customers = new List<Customer>();
            Appointments = new List<Appointment>();

            GetCustomers();
            GetAppointments();
        }

        private async void GetCustomers()
        {
            HttpClient httpClient = new HttpClient();
            var res = await httpClient.GetStringAsync("https://localhost:7191/BarberShop/customers");
            #pragma warning disable CS8601 // Possible null reference assignment.
            Customers = JsonConvert.DeserializeObject<List<Customer>>(res);
            #pragma warning restore CS8601 // Possible null reference assignment.
        }
        private async void GetAppointments()
        {
            HttpClient httpClient = new HttpClient();
            var res = await httpClient.GetStringAsync("https://localhost:7191/BarberShop/appointments");
            #pragma warning disable CS8601 // Possible null reference assignment.
            Appointments = JsonConvert.DeserializeObject<List<Appointment>>(res);
            #pragma warning restore CS8601 // Possible null reference assignment.
        }

        private void GetCustomerButton(object sender, RoutedEventArgs e)
        {

            dataGrid1.ItemsSource = Customers;
        }
        private void GetAppointmentsButton(object sender, RoutedEventArgs e)
        {
            dataGrid2.ItemsSource = Appointments;
        }
        private async void DeleteVetCardButton(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            var res = await httpClient.
                DeleteAsync($"https://localhost:7191/BarberShop/customers/{Customers[dataGrid1.SelectedIndex].Id}");
            GetCustomers();
        }

        private async void dataGrid1_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            var res = await httpClient.
                PostAsJsonAsync("https://localhost:7191/BarberShop/customers", Customers[dataGrid1.SelectedIndex]);
            GetCustomers();
        }
        private async void DeleteAppointmentButton(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            var res = await httpClient.
                DeleteAsync($"https://localhost:7191/BarberShop/appointments/{Appointments[dataGrid2.SelectedIndex].Id}");
            GetAppointments();
        }

        private async void dataGrid2_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            var res = await httpClient.
                PostAsJsonAsync("https://localhost:7191/BarberShop/appointments", Appointments[dataGrid2.SelectedIndex]);
            GetAppointments();
        }


    }
}

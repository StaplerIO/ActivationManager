using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.NetworkInformation;
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

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string registrationUrl = "http://39.106.211.14:32118/activaction/register";

        public MainWindow()
        {
            InitializeComponent();

            MachineIdentifierTextBox.Text = Guid.NewGuid().ToString("N");
        }

        private async void ActivateButton_Click(object sender, RoutedEventArgs e)
        {
            #region DisableTextBoxes
            MachineIdentifierTextBox.IsEnabled = false;
            SerialNumberTextBox.IsEnabled = false;
            #endregion

            var MACAddress = GetMacByNetworkInterface();
            var machineIdentifier = MachineIdentifierTextBox.Text;
            var serialNumber = SerialNumberTextBox.Text;

            var client = new HttpClient();
            var model = new ActivateViewModel
            {
                MACAddress = MACAddress,
                MachineIdentifier = machineIdentifier,
                SerialNumber = serialNumber
            };

            var content = JsonContent.Create(model);

            var response = await client.PostAsync(registrationUrl, content);

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                _ = MessageBox.Show(responseContent, "Activaction Result", MessageBoxButton.OK, MessageBoxImage.Information);

                await PostOperation.ExtractResourceAsync();

                _ = MessageBox.Show("Resource extracted successfully", "ActivationManager", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                _ = MessageBox.Show(responseContent, "Activaction Result", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static string GetMacByNetworkInterface()
        {
            try
            {
                var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface networkInterface in networkInterfaces)
                {
                    return BitConverter.ToString(networkInterface.GetPhysicalAddress().GetAddressBytes());
                }
            }
            catch (Exception)
            {
            }
            return "xx-xx-xx-xx-xx-xx";
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var model = new ActivateViewModel
            {
                MACAddress = GetMacByNetworkInterface(),
            };

            var content = JsonContent.Create(model);

            var client = new HttpClient();
            var response = await client.PostAsync(registrationUrl, content);

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                _ = MessageBox.Show(responseContent, "Activaction Result", MessageBoxButton.OK, MessageBoxImage.Information);
                await PostOperation.ExtractResourceAsync();
                _ = MessageBox.Show("Resource extracted successfully", "ActivationManager", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}

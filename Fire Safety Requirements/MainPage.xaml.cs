using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Devices;
using Plugin.MauiMTAdmob;
using System.Diagnostics;
namespace Fire_Safety_Requirements
{
    public partial class MainPage : ContentPage
    {
        public string programmer_message { get; set; }
        public string preface { get; set; }
        public string HtmlContent { get; set; }
        public MainPage()
        {
            InitializeComponent();
            programmer_message = "Good day, my fellow Fire Safety Inspectors (FSIs) and Building Plan Evaluators (BPEs)!\r\n\r\nI am Junrey B. Ongcol, the creator of this app. I developed this app to assist you, my fellow FSIs and BPEs, in performing our work with more guidance and ease.\r\n\r\nThis app is based entirely on our manual, Fire Safety Guidelines for Different Types of Occupancy, Vol. 2. I sincerely hope that this app proves to be a valuable tool in your work.";
            preface = "Welcome to the Fire Safety Guidelines App\r\n\r\n" +
                "This app is based on Fire Safety Guidelines on Different Types of Occupancy, Volume 2, " +
                "a comprehensive resource designed to help you understand and implement fire safety measures " +
                "across various occupancy types. Whether you're a building manager, safety officer, " +
                "or just interested in fire safety, this app provides essential guidelines to ensure the safety and security of occupants in diverse environments.\r\n\r\n" +
                "Explore detailed recommendations and guidelines tailored to each occupancy type, and stay informed with the best practices for fire safety.";
            SendToFirestore();
            BindingContext = this;
            ShowInterstitialAd();
        }
        private void ShowInterstitialAd()
        {
            // Load your interstitial
            CrossMauiMTAdmob.Current.LoadInterstitial("ca-app-pub-8158194714551266/6246925054");

            // Optional: handle events
            CrossMauiMTAdmob.Current.OnInterstitialLoaded += (s, e) =>
            {
                Console.WriteLine("Interstitial loaded; showing now...");
                CrossMauiMTAdmob.Current.ShowInterstitial();
            };

            CrossMauiMTAdmob.Current.OnInterstitialFailedToLoad += (s, e) =>
                Console.WriteLine($"Failed to load interstitial: {e.ErrorMessage}");

            // Or later in your logic:
            if (CrossMauiMTAdmob.Current.IsInterstitialLoaded())
                CrossMauiMTAdmob.Current.ShowInterstitial();
            else
                Console.WriteLine("Interstitial not ready yet.");

        }
        //-----------------fire store save device data-----------------//
        private async void SendToFirestore()
        {
            string deviceName = DeviceInfo.Model; 
            string currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm t"); 
            string period = DateTime.UtcNow.ToString("yyyy-MM"); 
            string timestamp = DateTime.UtcNow.ToString("o"); 
            var service = new FirestoreService();
            bool success = await service.PostDeviceDataAsync(deviceName, period);

        }

        private async void GoToOccupancyTypePage(object sender, EventArgs e)
        {
            // Using Shell Navigation to go to the page
             await Shell.Current.GoToAsync("//OccupancyTypePage");
            
        }
        private async void GoToSummaryPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("SummaryPage");
        }
        private async void GoToMeansOfEgressPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("MeansOfEgressPage");
        }
        private async void GoToInspectionFlowChartPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("InspectionFlowChartPage");
        }
        private async void GoToOtherFeesCalcPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("OtherFeesCalc");
        }
        private async void GoToLink(object sender, EventArgs e)
        {
            // Specify the URL you want to open
            string url = "https://www.linkedin.com/in/junreyongcol/";

            // Open the URL in the default browser
            await Launcher.OpenAsync(new Uri(url));
        }
    }

}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Networking; // for Connectivity
using System.Threading.Tasks;

namespace Fire_Safety_Requirements.ViewModel;

[QueryProperty("Text", "text")]
public partial class OccupancyDetailViewModel : ObservableObject
{
    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    bool isOffline; 

    [ObservableProperty]
    string text;

    // Observable Property for HtmlSource
    private WebViewSource _htmlSource;
    public WebViewSource HtmlSource
    {
        get => _htmlSource;
        set => SetProperty(ref _htmlSource, value);
    }

    //constructor
    public OccupancyDetailViewModel()
    {
        IsOffline = Preferences.Default.Get("IsOffline", false);
    }

    // Called whenever "Text" query parameter changes
    partial void OnTextChanged(string value)
    {
        UpdateHtmlSource(value);
    }

    private void UpdateHtmlSource(string occtype)
    {
        string selectedHtml = "";
        string localBase = "Resources/FireCodeRequirements/";
        string onlineBase = "https://codewithjunrey.web.app/FireCodeRequirements/";

        switch (occtype)
        {
            case "Places of Assembly": selectedHtml = "assembly.html"; break;
            case "Educational Occupancy": selectedHtml = "educational.html"; break;
            case "Day Care Occupancy": selectedHtml = "daycare.html"; break;
            case "Health Care Occupancy": selectedHtml = "healthcare.html"; break;
            case "Residential Board and Care": selectedHtml = "resboardcare.html"; break;
            case "Detention and Correctional Occupancy": selectedHtml = "detention.html"; break;
            case "Residential Occupancy": selectedHtml = "residential.html"; break;
            case "Mercantile Occupancy": selectedHtml = "mercantile.html"; break;
            case "Business Occupancy": selectedHtml = "business.html"; break;
            case "Industrial Occupancy": selectedHtml = "industrial.html"; break;
            case "Storage Occupancy": selectedHtml = "storage.html"; break;
            case "Special Structures": selectedHtml = "special.html"; break;
            case "High Rise Buildings": selectedHtml = "highrise.html"; break;
            case "Fire Exit Drill": selectedHtml = "firedrill.html"; break;
            default: selectedHtml = "default.html"; break;
        }

        if (IsOffline)
        {
            // Premium users → always load local
            HtmlSource = new UrlWebViewSource { Url = $"{localBase}{selectedHtml}" };
        }
        else
        {
            bool hasInternet = Connectivity.Current.NetworkAccess == NetworkAccess.Internet;

            if (hasInternet)
            {
                HtmlSource = new UrlWebViewSource { Url = $"{onlineBase}{selectedHtml}" };
            }
            else
            {
                HtmlSource = new HtmlWebViewSource
                {
                    Html = "<html><body style='font-family:sans-serif;text-align:center;padding:20px;'>" +
                           "<h2 style='color:#c0392b;'>You are offline</h2>" +
                           "<p>You need to connect to the internet,</p>" +
                           "<p>or switch to <b>offline mode (premium account)</b>.</p>" +
                           "</body></html>"
                };
            }
        }

    }

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}

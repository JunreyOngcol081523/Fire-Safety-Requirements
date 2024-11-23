using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace Fire_Safety_Requirements.ViewModel;

[QueryProperty("Text","text")]
public partial class OccupancyDetailViewModel : ObservableObject
{

    private string _htmlSource;
     public OccupancyDetailViewModel()
    {
   
    }
    [ObservableProperty]
    string text;

    // Observable Property for HtmlSource
    public string HtmlSource
    {
        get => _htmlSource;
        set => SetProperty(ref _htmlSource, value); // This ensures binding updates the UI
    }
    // Update HtmlSource when Text changes
    partial void OnTextChanged(string value)
    {
        UpdateHtmlSource(value); // Call UpdateHtmlSource whenever Text changes
    }
    // Method to update HtmlSource based on the Text value
    private void UpdateHtmlSource(string occtype)
    {
        string selectedHtml = "";
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

            default: selectedHtml = "default.html"; break; // Fallback option
        }

        HtmlSource = $"Resources/FireCodeRequirements/{selectedHtml}"; // Set the HtmlSource
    }

  
    [RelayCommand]
    async Task GoBack()
    {
        if (Shell.Current.Navigation.NavigationStack.Count > 1)
        {
            // If there's more than one page in the navigation stack, pop the current page
            await Shell.Current.Navigation.PopAsync();
        }
        else
        {
            // If this is the root page, use GoToAsync to navigate to a specific page or exit
            await Shell.Current.GoToAsync("//OccupancyTypePage"); // Adjust based on your app's navigation flow
        }
    }


}


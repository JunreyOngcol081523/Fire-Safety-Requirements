
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace Fire_Safety_Requirements.ViewModel;

public partial class SummaryViewModel:ObservableObject
{

    private string _htmlSource;

    public SummaryViewModel()
    {
        UpdateHtmlSource();
    }

    public string HtmlSource
    {
        get => _htmlSource;
        set => SetProperty(ref _htmlSource, value); // This ensures binding updates the UI
    
    }

    // Method to update HtmlSource based on the Text value
    private void UpdateHtmlSource()
    {
        //string selectedHtml = "";
        HtmlSource = $"Resources/FireCodeRequirements/summary.html"; // Set the HtmlSource
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
            await Shell.Current.GoToAsync("//MainPage"); // Adjust based on your app's navigation flow
        }
    }
}

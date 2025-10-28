using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Fire_Safety_Requirements.ViewModel;

public partial class OccupancyTypeViewModel : ObservableObject
{
    public OccupancyTypeViewModel()
    {
        items = new ObservableCollection<string>();
        items.Add("Places of Assembly");
        items.Add("Educational Occupancy");
        items.Add("Day Care Occupancy");
        items.Add("Health Care Occupancy");
        items.Add("Residential Board and Care");
        items.Add("Detention and Correctional Occupancy");
        items.Add("Residential Occupancy");
        items.Add("Mercantile Occupancy");
        items.Add("Business Occupancy");
        items.Add("Industrial Occupancy");
        items.Add("Storage Occupancy");
        items.Add("Special Structures");
        items.Add("High Rise Buildings");
        items.Add("Fire Exit Drill");

        // Load saved preference
        isOffline = Preferences.Default.Get("IsOffline", false);
    }

    [ObservableProperty]
    ObservableCollection<string> items;

    private bool isOffline;
    public bool IsOffline
    {
        get => isOffline;
        set
        {
            if (SetProperty(ref isOffline, value))
            {
                // Save to preferences whenever it changes
                Preferences.Default.Set("IsOffline", value);
                // Display dialog box
                string message = value ? "Offline Mode is now ON" : "Offline Mode is now OFF";
                Application.Current?.MainPage?.DisplayAlert(
                    "Offline Mode",
                    message,
                    "OK"
                );
            }
        }
    }

    [RelayCommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"OccupancyDetailPage?text={Uri.EscapeDataString(s)}");
    }

    [RelayCommand]
    async Task GoToMain()
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}
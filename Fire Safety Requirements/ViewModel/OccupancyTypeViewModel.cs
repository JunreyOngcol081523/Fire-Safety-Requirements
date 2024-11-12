

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Fire_Safety_Requirements.ViewModel;

public partial class OccupancyTypeViewModel:ObservableObject
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
        items.Add("Inspection Flow Chart");
    }

    [ObservableProperty]
    ObservableCollection<string> items;

    
    [RelayCommand]
    async Task Tap(string s)
    {
        //await Shell.Current.GoToAsync($"///OccupancyDetailPage?text={s}");
        await Shell.Current.GoToAsync($"OccupancyDetailPage?text={Uri.EscapeDataString(s)}");
    }

    [RelayCommand]
    void ShowDetail(string s)
    {
        //System.Diagnostics.Debug.WriteLine(s);
    }
}

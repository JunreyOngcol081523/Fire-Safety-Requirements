using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Fire_Safety_Requirements.ViewModel;

[QueryProperty("Text","text")]
public partial class OccupancyDetailViewModel : ObservableObject
{
    [ObservableProperty]
    string text;

    [RelayCommand]
    async Task GoBack()
    {
        //System.Diagnostics.Debug.WriteLine(text);
        //await Shell.Current.GoToAsync("..");
        //await Shell.Current.Navigation.PopAsync();
        await Shell.Current.GoToAsync("//OccupancyTypePage");
    }
}

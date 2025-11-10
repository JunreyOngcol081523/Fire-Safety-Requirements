using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Fire_Safety_Requirements.ViewModel
{
    [QueryProperty(nameof(HtmlSource), "Url")]
    public partial class WebViewViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isBusy;

        private string _htmlSource;
        public string HtmlSource
        {
            get => _htmlSource;
            set => SetProperty(ref _htmlSource, value);
        }

        public WebViewViewModel()
        {
            // Default URL (optional)
            HtmlSource = "https://bfp.gov.ph/";
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}


using Fire_Safety_Requirements.ViewModel;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Security.AccessControl;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Fire_Safety_Requirements;

public partial class OccupancyDetailPage : ContentPage
{
    public string htmlsource = "";
    OccupancyDetailViewModel viewmodel;
    public OccupancyDetailPage(OccupancyDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        viewmodel = vm;
        
    }
    private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
    {
        viewmodel.IsBusy = true;
    }

    private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
    {
        viewmodel.IsBusy = false;
    }
}


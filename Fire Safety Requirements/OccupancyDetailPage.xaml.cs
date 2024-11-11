
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
    public OccupancyDetailPage(OccupancyDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}


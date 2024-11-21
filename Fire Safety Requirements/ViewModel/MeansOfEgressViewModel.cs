

using CommunityToolkit.Mvvm.ComponentModel;

namespace Fire_Safety_Requirements.ViewModel;

public partial class MeansOfEgressViewModel:ObservableObject
{
    [ObservableProperty]
    string title;

    public MeansOfEgressViewModel()
    {
        title = "Means of Egress Calculator";
    }
}

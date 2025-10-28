

namespace Fire_Safety_Requirements;

public partial class InspectionFlowChartPage : ContentPage
{
    public InspectionFlowChartPage()
    {
        InitializeComponent();
    }

    private void OnPortraitClicked(object sender, EventArgs e)
    {
        // Set to portrait (vertical) - 0 degrees
        FlowchartImage.Rotation = 0;
    }

    private void OnLandscapeClicked(object sender, EventArgs e)
    {
        // Set to landscape (horizontal) - 90 degrees clockwise
        FlowchartImage.Rotation = 90;
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
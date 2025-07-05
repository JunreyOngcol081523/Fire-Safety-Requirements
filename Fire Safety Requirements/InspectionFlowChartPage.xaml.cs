namespace Fire_Safety_Requirements;

public partial class InspectionFlowChartPage : ContentPage
{
	public InspectionFlowChartPage()
	{
		InitializeComponent();
	}
    private double currentRotation = 0;

    private void OnRotateButtonClicked(object sender, EventArgs e)
    {
        currentRotation += 90;
        if (currentRotation >= 360)
            currentRotation = 0;

        FlowchartImage.Rotation = currentRotation;
    }
}
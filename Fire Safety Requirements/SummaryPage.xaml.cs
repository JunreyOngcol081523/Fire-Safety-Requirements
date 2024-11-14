using Fire_Safety_Requirements.ViewModel;

namespace Fire_Safety_Requirements;

public partial class SummaryPage : ContentPage
{
	public SummaryPage(SummaryViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
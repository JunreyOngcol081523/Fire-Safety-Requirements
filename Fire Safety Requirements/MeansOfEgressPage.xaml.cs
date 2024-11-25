using Fire_Safety_Requirements.ViewModel;

namespace Fire_Safety_Requirements;

public partial class MeansOfEgressPage : ContentPage
{
	public MeansOfEgressPage(MeansOfEgressViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
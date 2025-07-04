using Fire_Safety_Requirements.ViewModel;

namespace Fire_Safety_Requirements;

public partial class OtherFeesCalc : ContentPage
{
    public OtherFeesCalc(OtherFeesCalcViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
using Fire_Safety_Requirements.ViewModel;
using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace Fire_Safety_Requirements
{
    public partial class OccupancyTypePage : ContentPage
    {
        public OccupancyTypePage(OccupancyTypeViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;

        }
    }
}
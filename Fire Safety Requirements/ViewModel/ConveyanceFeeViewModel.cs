using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Fire_Safety_Requirements.ViewModel
{
    public partial class ConveyanceFeeViewModel: ObservableObject
    {
        public ObservableCollection<string> ConveyanceType { get; } = new()
        {
            "A. Flammable Liquids in Vehicles (Liters)",
            "B. Explosives or Hazardous Chemicals (Kilograms)",
            "C. Loading/Unloading at Terminals or Piers",
            "D. Transfer to Shore Tanks (Liters)",
            "E. Bulk Transfer via Lighters or Pipelines"
        };
    }
}



using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Fire_Safety_Requirements.ViewModel;

public partial class MeansOfEgressViewModel:ObservableObject
{
    [ObservableProperty]
    string title;

    [ObservableProperty]
    ObservableCollection<string> occupancytypes;

    [ObservableProperty]
    private string selectedOccupancyType;

    [ObservableProperty]
    public ObservableCollection<Item> items;

    [ObservableProperty]
    private string height;

    [ObservableProperty]
    private string width;

    [ObservableProperty]
    private string result = "0";

    [ObservableProperty]
    private string diagonal = "0";

    [ObservableProperty]
    private string remotenessSprinklered = "0";
    
    [ObservableProperty]
    private string remotenessNonSprinklered = "0";

    // These partial methods must exist in the same partial class
    partial void OnHeightChanged(string value)
    {
        UpdateResult();
        CalculateDiagonal();
    }

    partial void OnWidthChanged(string value)
    {
        UpdateResult();
        CalculateDiagonal();
    }

    private void UpdateResult()
    {
        // Logic to calculate or set the Result
        if (double.TryParse(Height, out double h) && double.TryParse(Width, out double w))
        {
            Result = (h * w).ToString();  // Example calculation
        }
        else
        {
            Result = "0";  // Handle invalid input
        }
        OnSelectedOccupancyTypeChanged(this.selectedOccupancyType);
    }
    private void CalculateDiagonal()
    {
        // Logic to calculate or set the Result
        if (double.TryParse(Height, out double h) && double.TryParse(Width, out double w))
        {
            double diagonaldbl = Math.Sqrt(Math.Pow(w, 2) + Math.Pow(h, 2));

            // Round the results to 2 decimal places
            Diagonal = Math.Round(diagonaldbl, 2).ToString();
            RemotenessNonSprinklered = Math.Round(diagonaldbl / 2, 2).ToString();
            RemotenessSprinklered = Math.Round(diagonaldbl / 3, 2).ToString();
        }
        else
        {
            Diagonal = "0";  // Handle invalid input
        }
    }

    public MeansOfEgressViewModel()
    {
        title = "Means of Egress Calculator";
        occupancytypes = new ObservableCollection<string>();
        occupancytypes.Add("Places of Assembly");
        occupancytypes.Add("Educational Occupancy");
        occupancytypes.Add("Day Care Occupancy");
        occupancytypes.Add("Health Care Occupancy");
        occupancytypes.Add("Residential Board and Care");
        occupancytypes.Add("Detention and Correctional Occupancy");
        occupancytypes.Add("Residential Occupancy");
        occupancytypes.Add("Mercantile Occupancy");
        occupancytypes.Add("Business Occupancy");
        occupancytypes.Add("Industrial Occupancy");
        occupancytypes.Add("Storage Occupancy");
        occupancytypes.Add("Special Structures");

        Items = new ObservableCollection<Item>
        {
            new Item
            {
                Title = "",
                OccupantLoad = "",
                RequiredNumberOfExits = "",
                StairSize = ""
            }
        };
    }
    // Partial method triggered when selected occupancy type changes
    partial void OnSelectedOccupancyTypeChanged(string value)
    {
        UpdateItemsBasedOnOccupancyType(value);
    }

    private void UpdateItemsBasedOnOccupancyType(string occupancyType)
    {
        double resValue = Double.Parse(this.result);
        // Logic to update the Items collection dynamically based on the selected occupancy type
        if (occupancyType == "Places of Assembly")
        {

            Items = new ObservableCollection<Item>
            {
                new Item { Title = "Concentrated use without fixed seats",    OccupantLoad = (resValue/0.65).ToString("0"), RequiredNumberOfExits =  GetNumberOfEgresses((resValue/0.65)), StairSize = GetStairWidth((resValue/0.65)) },
                new Item { Title = "Less concentrated use",                   OccupantLoad = (resValue/1.4).ToString("0"),  RequiredNumberOfExits =  GetNumberOfEgresses((resValue/1.4)),  StairSize = GetStairWidth((resValue/1.4)) },
                new Item { Title = "Waiting space area",                      OccupantLoad = (resValue/0.25).ToString("0"), RequiredNumberOfExits =  GetNumberOfEgresses((resValue/0.25)), StairSize = GetStairWidth((resValue/0.25)) },
                new Item { Title = "Areas not in excess of 930 square meter", OccupantLoad = (resValue/0.46).ToString("0"), RequiredNumberOfExits =  GetNumberOfEgresses((resValue/0.46)), StairSize = GetStairWidth((resValue/0.46)) },
                new Item { Title = "Areas in excess of 930 square meter",     OccupantLoad = (resValue/0.65).ToString("0"), RequiredNumberOfExits =  GetNumberOfEgresses((resValue/0.65)), StairSize = GetStairWidth((resValue/0.65)) }
            };
        }
        else if (occupancyType == "Educational Occupancy")
        {
            Items = new ObservableCollection<Item>
            {
                new Item { Title = "Classroom Area",                               OccupantLoad = (resValue/1.9).ToString("0"), RequiredNumberOfExits = "2 Exits", StairSize = ((resValue/1.9) < 2000) ? "1120mm in width" : "1420mm in width" },
                new Item { Title = "Shops, Laboratories, and other similar rooms", OccupantLoad = (resValue/4.6).ToString("0"), RequiredNumberOfExits = "2 Exits", StairSize = ((resValue/4.6) < 2000) ? "1120mm in width" : "1420mm in width" },
                new Item { Title = "Dry Nurseries/Sleeping facilities",            OccupantLoad = (resValue/3.3).ToString("0"), RequiredNumberOfExits = "2 Exits", StairSize = ((resValue/3.3) < 2000) ? "1120mm in width" : "1420mm in width" }
            };
        }
        else if (occupancyType == "Day Care Occupancy")
        {
            Items = new ObservableCollection<Item>
            {
                new Item { Title = "Day Care Occupancy", OccupantLoad = (resValue/3.3).ToString("0"), RequiredNumberOfExits = GetNumberOfEgresses((resValue/3.3)), StairSize = GetRequiredWidth("AO",(resValue/3.3),false).ToString("0")+"mm in Width" }
                
            };
        }
        // Add additional conditions for other occupancy types
    }
    public string GetStairWidth(double occupantLoad)
    {
        if (occupantLoad < 50)
        {
            return 915+"mm wide";  // in mm
        }
        else if (occupantLoad < 2000)
        {
            return 1120+"mm wide";  // in mm
        }
        else
        {
            return 1420+"mm wide";  // in mm
        }
    }
    public string GetNumberOfEgresses(double occupantLoad)
    {
        if (occupantLoad > 500 && occupantLoad <= 1000)
        {
            return 3+" Exits";  // 3 means of egress for 501 to 1000 occupants
        }
        else if (occupantLoad > 1000)
        {
            return 4 + " Exits";  // 4 means of egress for more than 1000 occupants
        }
        else
        {
            return 2 + " Exits";  // or any default value if the occupant load is less than or equal to 500
        }
    }
    public static double GetRequiredWidth(string occupancyType, double occupantLoad, bool isStairway)
    {
        // Define the capacity factors (width per person) based on occupancy type and component (stairway or ramp)
        double widthPerPerson = 0;

        switch (occupancyType)
        {
            case "BC": // Board and Care
                widthPerPerson = isStairway ? 10 : 5;
                break;
            case "HCS": // Health Care, Sprinklered
                widthPerPerson = isStairway ? 7.6 : 5;
                break;
            case "HCN": // Health Care, Non-Sprinklered
                widthPerPerson = isStairway ? 15 : 13;
                break;
            case "HH": // High Hazards
                widthPerPerson = isStairway ? 18 : 10;
                break;
            case "AO": // All Others
                widthPerPerson = isStairway ? 7.6 : 5;
                break;
            default:
                throw new ArgumentException("Invalid occupancy type");
        }

        // Calculate the nominal width in mm for stairways or ramps (using double for precision)
        double nominalWidth = widthPerPerson * occupantLoad;

        // If it's a stairway, check if nominal width is greater than 1120 mm
        if (isStairway)
        {
            return CalculateCapacity(nominalWidth);
        }

        // If it's not a stairway, just return the nominal width
        return nominalWidth;
    }
    public static double CalculateCapacity(double nominalWidth)
    {
        // Ensure the nominal width is greater than 1120 mm before applying the formula
        if (nominalWidth > 1120)
        {
            // Apply the formula for increased capacity
            double capacity = 146.7 + ((nominalWidth - 1120) / 5.45);

            // Return the capacity rounded to the nearest integer
            return Math.Round(capacity);
        }

        // If nominal width is not greater than 1120, return 0 (or any default value as per your need)
        return 0;
    }

}
public class Item
{
    public string Title { get; set; }
    public string OccupantLoad { get; set; }
    public string RequiredNumberOfExits { get; set; }
    public string StairSize { get; set; }
}


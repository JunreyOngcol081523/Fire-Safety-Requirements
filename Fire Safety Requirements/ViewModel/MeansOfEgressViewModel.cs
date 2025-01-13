

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Fire_Safety_Requirements.ViewModel;

public partial class MeansOfEgressViewModel:ObservableObject
{
    
    [ObservableProperty]
    string title;

    [ObservableProperty]
    ObservableCollection<string> occupancytypes;

    [ObservableProperty]
    private string selectedOccupancyType="";

    [ObservableProperty]
    public ObservableCollection<Item> items;

    [ObservableProperty]
    private string height;

    [ObservableProperty]
    private string width;

    [ObservableProperty]
    private string result = "";

    [ObservableProperty]
    private string diagonal = "0";

    [ObservableProperty]
    private string remotenessSprinklered = "0";
    
    [ObservableProperty]
    private string remotenessNonSprinklered = "0";

    [ObservableProperty]
    private string nominalWidth="0";

    [ObservableProperty]
    double capacityinStairway;

    [ObservableProperty]
    bool isSprinklered = false;

    [ObservableProperty]
    bool isSprinkleredEnable = false;

    [ObservableProperty]
    double capacityinLevelComponents;

    [ObservableProperty]
    bool isHighHazard = false;

    [ObservableProperty]
    string areaType = "AO";

    [ObservableProperty]
    bool resultIsReadOnlyValue = true;

    [ObservableProperty]
    bool haveSelectedOccupancyType = false;

    [ObservableProperty]
    string lowhazard;
    [ObservableProperty]
    string moderatedhazard;
    [ObservableProperty]
    string highhazard;

    partial void OnResultChanged(string value)
    {
        OnSelectedOccupancyTypeChanged(this.SelectedOccupancyType);
        //UpdateResult();
        CalculateDiagonal();
        CalculateNumberofFireEx();
    }
    partial void OnHeightChanged(string value)
    {
        //UpdateResult();
        CalculateDiagonal();
    }
    partial void OnWidthChanged(string value)
    {
        //UpdateResult();
        CalculateDiagonal();
    }
    partial void OnNominalWidthChanged(string value)
    {
        CalculateCapacity();
    }
    partial void OnIsHighHazardChanged(bool value)
    {
        CalculateCapacity();
    }
    partial void OnIsSprinkleredChanged(bool value)
    {
        
        CalculateCapacity();
    }
    // Partial method triggered when selected occupancy type changes
    partial void OnSelectedOccupancyTypeChanged(string value)
    {
        if (value == null)
        {
            this.HaveSelectedOccupancyType = false;
        }
        else
        {
            this.HaveSelectedOccupancyType = true;
            NominalWidth = "0";
            IsHighHazard = false;
            UpdateItemsBasedOnOccupancyType(value);
        }
        
    }
    private void CalculateDiagonal()
    {
        // Logic to calculate or set the Result
        if (double.TryParse(Height, out double h) && double.TryParse(Width, out double w))
        {
            double diagonaldbl = System.Math.Sqrt(Math.Pow(w, 2) + Math.Pow(h, 2));

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
    private void CalculateNumberofFireEx()
    {
        if(double.TryParse(Result, out double res))
        {
            this.Lowhazard = Math.Ceiling((res / 200)).ToString();
            this.Moderatedhazard = Math.Ceiling((res / 100)).ToString();
            this.Highhazard = Math.Ceiling((res / 75)).ToString();
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

        if (SelectedOccupancyType.Equals(""))
        {
            this.HaveSelectedOccupancyType = false;
        }
    }


    private void UpdateItemsBasedOnOccupancyType(string occupancyType)
    {
        IsSprinklered = false;
        IsSprinkleredEnable = false;
        double.TryParse(Result, out double resValue);
        
        // Logic to update the Items collection dynamically based on the selected occupancy type
        if (occupancyType == "Places of Assembly")
        {
            IsSprinkleredEnable = false;
            Items = new ObservableCollection<Item>
            {
                new Item { Title = "Concentrated use without fixed seats",    OccupantLoad = (resValue/0.65).ToString("0"), RequiredNumberOfExits =  GetNumberOfEgresses((resValue/0.65)), StairSize = GetStairWidth((resValue/0.65),false) },
                new Item { Title = "Less concentrated use",                   OccupantLoad = (resValue/1.4).ToString("0"),  RequiredNumberOfExits =  GetNumberOfEgresses((resValue/1.4)),  StairSize = GetStairWidth((resValue/1.4),false) },
                new Item { Title = "Waiting space area",                      OccupantLoad = (resValue/0.25).ToString("0"), RequiredNumberOfExits =  GetNumberOfEgresses((resValue/0.25)), StairSize = GetStairWidth((resValue/0.25), false) },
                new Item { Title = "Areas not in excess of 930 square meter", OccupantLoad = (resValue/0.46).ToString("0"), RequiredNumberOfExits =  GetNumberOfEgresses((resValue/0.46)), StairSize = GetStairWidth((resValue/0.46), false) },
                new Item { Title = "Areas in excess of 930 square meter",     OccupantLoad = (resValue/0.65).ToString("0"), RequiredNumberOfExits =  GetNumberOfEgresses((resValue/0.65)), StairSize = GetStairWidth((resValue/0.65), false) }
            };
        }
        else if (occupancyType == "Educational Occupancy")
        {
            IsSprinkleredEnable = false;
            Items = new ObservableCollection<Item>
            {
                new Item { Title = "Classroom Area",                               OccupantLoad = (resValue/1.9).ToString("0"), RequiredNumberOfExits = "not less than 2 Exits", StairSize = ((resValue/1.9) < 2000) ? "1120mm wide" : "1420mm wide" },
                new Item { Title = "Shops, Laboratories, and other similar rooms", OccupantLoad = (resValue/4.6).ToString("0"), RequiredNumberOfExits = "not less than 2 Exits", StairSize = ((resValue/4.6) < 2000) ? "1120mm wide" : "1420mm wide" },
                new Item { Title = "Dry Nurseries/Sleeping facilities",            OccupantLoad = (resValue/3.3).ToString("0"), RequiredNumberOfExits = "not less than 2 Exits", StairSize = ((resValue/3.3) < 2000) ? "1120mm wide" : "1420mm wide" }
            };
        }
        else if (occupancyType == "Day Care Occupancy")
        {
            IsSprinkleredEnable = false;
            Items = new ObservableCollection<Item>
            {
                new Item { Title = "Day Care Occupancy", OccupantLoad = (resValue/3.3).ToString("0"), RequiredNumberOfExits = GetNumberOfEgresses((resValue/3.3)), StairSize = GetStairWidth((resValue/3.3), true).ToString() }

            };
        }
        else if (occupancyType == "Health Care Occupancy")
        {
            IsSprinkleredEnable = true;
            Items = new ObservableCollection<Item>
            {
                new Item { Title = "Health care sleeping departments",             OccupantLoad = (resValue/11.1).ToString("0"), RequiredNumberOfExits = GetNumberOfEgresses((resValue/11.1)), StairSize = GetStairWidth((resValue/11.1),false).ToString() },
                new Item { Title = " Inpatient health care treatment departments", OccupantLoad = (resValue/22.3).ToString("0"), RequiredNumberOfExits = GetNumberOfEgresses((resValue/22.3)), StairSize = GetStairWidth((resValue/22.3),false).ToString() }

            };

        }
        else if (occupancyType == "Residential Board and Care")
        {
            IsSprinkleredEnable = false;
            Items = new ObservableCollection<Item>
            {
                new Item { Title = "Residential Board and Care", OccupantLoad = (resValue/18.6).ToString("0"), RequiredNumberOfExits = GetNumberOfEgresses((resValue/18.6)), StairSize = GetStairWidth((resValue/18.6), true).ToString() }
            };

        }
        else if (occupancyType == "Detention and Correctional Occupancy")
        {
            IsSprinkleredEnable = false;
            Items = new ObservableCollection<Item>
            {
                new Item { Title = "Every Detention and Correctional Occupancy", OccupantLoad = (resValue/11.1).ToString("0"), RequiredNumberOfExits = GetNumberOfEgresses((resValue/11.1)), StairSize = GetStairWidth((resValue/11.1),true).ToString() }
            };

        }
        else if (occupancyType == "Residential Occupancy")
        {
            IsSprinkleredEnable = false;
            Items = new ObservableCollection<Item>
            {
                new Item { Title = "Every Residential Occupancy", OccupantLoad = (resValue/18.6).ToString("0"), RequiredNumberOfExits = GetNumberOfEgresses((resValue/18.6)), StairSize = GetStairWidth((resValue/18.6),false).ToString() }
            };

        }
        else if (occupancyType == "Mercantile Occupancy")
        {
            IsSprinkleredEnable = false;
            Items = new ObservableCollection<Item>
            {
                new Item { Title = "Street floor and sales floor below the street floor", OccupantLoad = (resValue/2.8).ToString("0"), RequiredNumberOfExits = GetNumberOfEgresses((resValue/2.8)), StairSize = GetStairWidth((resValue/2.8),false).ToString() },
                new Item { Title = "Sales space of different grade of streets", OccupantLoad = (resValue/3.7).ToString("0"), RequiredNumberOfExits = GetNumberOfEgresses((resValue/3.7)), StairSize = GetStairWidth((resValue/3.7),false).ToString() },
                new Item { Title = "Upper floors used for sale", OccupantLoad = (resValue/5.6).ToString("0"), RequiredNumberOfExits = GetNumberOfEgresses((resValue/5.6)), StairSize = GetStairWidth((resValue/5.6),false).ToString() },
                new Item { Title = "Covered walls", OccupantLoad = (resValue/2.8).ToString("0"), RequiredNumberOfExits = GetNumberOfEgresses((resValue/2.8)), StairSize = GetStairWidth((resValue/2.8),false).ToString() },
                new Item { Title = "Floor used only for offices, storage, shipping and not open to general public", OccupantLoad = (resValue/9.3).ToString("0"), RequiredNumberOfExits = GetNumberOfEgresses((resValue/9.3)), StairSize = GetStairWidth((resValue/9.3),false).ToString() }
            };
        }
        else if (occupancyType == "Business Occupancy")
        {
            IsSprinkleredEnable = false;
            Items = new ObservableCollection<Item>
            {
                new Item { Title = "General use", OccupantLoad = (resValue/9.3).ToString("0"), RequiredNumberOfExits = GetNumberOfEgresses((resValue/9.3)), StairSize = GetStairWidth((resValue/9.3),false).ToString() },
                new Item { Title = "Call Centers, IT Centers, BPO’s and other similar occupancies", OccupantLoad = (resValue/4.6).ToString("0"), RequiredNumberOfExits = GetNumberOfEgresses((resValue/4.6)), StairSize = GetStairWidth((resValue/4.6),false).ToString() }
            };
        }
        else if (occupancyType == "Industrial Occupancy")
        {
            IsSprinkleredEnable = false;
            Items = new ObservableCollection<Item>
            {
                new Item { Title = "Every Industrial Occupancy", OccupantLoad = (resValue/9.3).ToString("0"), RequiredNumberOfExits = GetNumberOfEgresses((resValue/9.3)), StairSize = GetStairWidth((resValue/9.3),true).ToString() }
            };
        }
        else if (occupancyType == "Storage Occupancy")
        {
            IsSprinkleredEnable = false;
            Items = new ObservableCollection<Item>
            {
                new Item { Title = "Every Storage Occupancy", OccupantLoad = "Refer to SECTION 10.2.18.1 para A.", RequiredNumberOfExits = "At least two (2) separate means of egress, as remote from each other as practicable", StairSize = "<2000 persons - 1120mm\r\n>2000 persons - 1420mm" }
                };
        }
        else if (occupancyType == "Special Structures")
        {
            IsSprinkleredEnable = false;
            Items = new ObservableCollection<Item>
            {
                new Item { Title = " large airport terminal buildings: Concourse", OccupantLoad = (resValue/9.3).ToString("0"), RequiredNumberOfExits = "Refer to DIVISION 19. SPECIAL STRUCTURES", StairSize = "Refer to DIVISION 19. SPECIAL STRUCTURES" },
                new Item { Title = " large airport terminal buildings:  Waiting Areas ", OccupantLoad = (resValue/1.4).ToString("0"), RequiredNumberOfExits = "Refer to DIVISION 19. SPECIAL STRUCTURES", StairSize = "Refer to DIVISION 19. SPECIAL STRUCTURES" },
                new Item { Title = " large airport terminal buildings:  Baggage Claim ", OccupantLoad = (resValue/1.9).ToString("0"), RequiredNumberOfExits = "Refer to DIVISION 19. SPECIAL STRUCTURES", StairSize = "Refer to DIVISION 19. SPECIAL STRUCTURES" },
                new Item { Title = " large airport terminal buildings:   Baggage Handling ", OccupantLoad = (resValue/27.9).ToString("0"), RequiredNumberOfExits = "Refer to DIVISION 19. SPECIAL STRUCTURES", StairSize = "Refer to DIVISION 19. SPECIAL STRUCTURES" }
            };
        }
    }
    public string GetStairWidth(double occupantLoad, bool newStair)
    {
        if (newStair)
        {
            if (occupantLoad < 2000)
            {
                return 1120 + "mm wide";  // in mm
            }
            else
            {
                return 1420 + "mm wide";  // in mm
            }
        }
        else
        {
            if (occupantLoad < 50)
            {
                return 915 + "mm wide";  // in mm
            }
            else if (occupantLoad < 2000)
            {
                return 1120 + "mm wide";  // in mm
            }
            else
            {
                return 1420 + "mm wide";  // in mm
            }
        }
        
    }
    public string GetNumberOfEgresses(double occupantLoad)
    {
        if (occupantLoad < 500)
        {
            return "2 exits"; // At least 2 exits remote from each other for less than 500 persons
        }
        else if (occupantLoad >= 500 && occupantLoad < 1000)
        {
            return "3 exits"; // At least 3 exits remote from each other for 500 to 1000 persons
        }
        else
        {
            return "4 exits"; // At least 4 exits remote from each other for 1000 or more persons
        }
    }

    public double CalculateCapacityOfMeansEgress(double widthinmm, bool isStairway)
    {
        string areaTypeValue = this.AreaType;
        // Define the capacity factors (width per person) based on occupancy type and component (stairway or ramp)
        double capacityFactor = 0;
        double capacity = 0;
        Debug.WriteLine($"area type: {areaTypeValue}");
        if (string.IsNullOrEmpty(areaTypeValue) ||
            !(areaTypeValue == "BC" || areaTypeValue == "HCS" || areaTypeValue == "HCN" || areaTypeValue == "HH" || areaTypeValue == "AO"))
        {
            Debug.WriteLine("Invalid areaType");
        }
        else
        {
            switch (areaTypeValue)
            {
                case "BC": // Board and Care
                    capacityFactor = isStairway ? 10 : 5;
                    break;
                case "HCS": // Health Care, Sprinklered
                    capacityFactor = isStairway ? 7.6 : 5;
                    break;
                case "HCN": // Health Care, Non-Sprinklered
                    capacityFactor = isStairway ? 15 : 13;
                    break;
                case "HH": // High Hazards
                    capacityFactor = isStairway ? 18 : 10;
                    break;
                case "AO": // All Others
                    capacityFactor = isStairway ? 7.6 : 5;
                    break;
                default:
                    // This should never be reached
                    Debug.WriteLine("Invalid areaType");
                    break;
            }
        }

        if (isStairway && widthinmm > 1120)
        {
            capacity = 146.7 + ((widthinmm - 1120) / 5.45);
            Debug.WriteLine($"Capacity width>1120 & stairway: {capacity}");
        }
        else
        {
            capacity = widthinmm / capacityFactor;
            Debug.WriteLine($"Capacity : {capacity}");
        }
        
        return capacity;
    }
    public void CalculateCapacity()
    {
         this.AreaType = "AO";
        if (this.SelectedOccupancyType.Equals("Health Care Occupancy"))
        {
            AreaType = IsSprinklered ? "HCS" : "HCN";
        }
        else if(this.SelectedOccupancyType.Equals("Residential Board and Care"))
        {
            AreaType = "BC";
        }else
        {
            if (this.IsHighHazard == true)
            {
                AreaType = "HH";
                IsSprinklered = false;
                IsSprinkleredEnable = false;
            }
            else
            {
                AreaType = "AO";
            }
        }
        try
        {

            CapacityinStairway = (int)Math.Ceiling(CalculateCapacityOfMeansEgress(Double.Parse(NominalWidth), true));
            Debug.WriteLine($"Final capacity of Stairway: {CapacityinStairway}");
            CapacityinLevelComponents = (int)Math.Ceiling(CalculateCapacityOfMeansEgress(Double.Parse(NominalWidth), false));
            Debug.WriteLine($"Final capacity of level comp: {CapacityinLevelComponents}");
        }
        catch(Exception e)
        {
            Debug.WriteLine(e.Message);
        }
        Debug.WriteLine($"Area Type:{AreaType}");
    }

}
public class Item
{
    public string Title { get; set; }
    public string OccupantLoad { get; set; }
    public string RequiredNumberOfExits { get; set; }
    public string StairSize { get; set; }
}


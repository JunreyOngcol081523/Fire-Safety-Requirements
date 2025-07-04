using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Fire_Safety_Requirements.ViewModel
{
    public partial class OtherFeesCalcViewModel : ObservableObject
    {
        public ObservableCollection<string> StorageCategories { get; } = new()
        {
            "Flammable/Combustible Solids",
            "Flammable/Combustible Liquids",
            "Flammable Gases"
        };

        [ObservableProperty]
        string selectedStorageCategory;

        [ObservableProperty]
        string selectedMaterialType;

        [ObservableProperty]
        public ObservableCollection<string> materialTypes = new();

        [ObservableProperty]
        double basisOfComputation;

        [ObservableProperty]
        private string annualFees;

        public ObservableCollection<string> OtherFees { get; } = new()
        {
            "a. Appeal Fee mentioned under Rule 14 of this RIRR",
            "b. Certified true copy of Fire Safety Inspection Certificate, Building Fire Safety Clearance and Fire Clearance",
            "c. Electrical Installation",
            "d. Filing Fee for Fire Safety Evaluation Clearance (FSEC)",
            "e. Fire Drill",
            "f. Fire Incident Clearance",
            "g. Fire Prevention and Safety Seminar",
            "h. Fireworks Display",
            "i. Fumigation/Fogging",
            "j. Open Flame",
            "k. Protest Fee mentioned under Rule 14 of this RIRR",
            "l. Soundstage and Approved Production Facilities and Locations",
            "m. Welding, Cutting and Other Hotworks"
        };

        [ObservableProperty]
        private string selectedOtherFee;
        [ObservableProperty]
        private double otherFeesBasisOfComputation;
        [ObservableProperty]
        private string otherFeesAmount;
        [ObservableProperty]
        private string otherFeesButtonText = "View Amount";
        [ObservableProperty]
        private string otherFeesBasisText = "Not Applicable";
        [ObservableProperty]
        bool isReadOnly = true;
        public OtherFeesCalcViewModel()
        {
            selectedStorageCategory = StorageCategories.FirstOrDefault();
        }

        partial void OnSelectedStorageCategoryChanged(string value)
        {
            MaterialTypes.Clear();

            switch (value)
            {
                case "Flammable/Combustible Solids":
                    MaterialTypes.Add("a) Calcium carbide");//StorageFlammableCombustibleSolids_1
                    MaterialTypes.Add("b) Pyroxylin");//StorageFlammableCombustibleSolids_2
                    MaterialTypes.Add("c) Matches");//StorageFlammableCombustibleSolids_3
                    //StorageFlammableCombustibleSolids_4
                    MaterialTypes.Add("d) Nitrate, phosphorous, bromine, sodium, picric acid and other hazardous\r\nchemicals of similar flammable, explosive, oxidizing or lacrymatory properties:");
                    //StorageFlammableCombustibleSolids_5
                    MaterialTypes.Add("e) Shredded combustible materials, such as wood shaving/excelsior (kusot),\r\nsawdust, kapok, straw and hay; combustible loose fibers: cotton waste (estopa),\r\nsisal, oakum; and other similar combustible shavings and fine materials");
                    //StorageFlammableCombustibleSolids_6
                    MaterialTypes.Add("f) Tar, resin, waxes, copra, rubber, cork, bituminous coal and similar combustible\r\nmaterials:");
                    break;

                case "Flammable/Combustible Liquids":
                    //StorageFlammableCombustibleLiquids_1
                    MaterialTypes.Add("a) For flammable liquids having flashpoint of -6.67oC or below, such as gasoline,\r\nether, carbon bisolphide, naptha, benzol (benzene), collodion, aflodin and\r\nacetone");
                    //StorageFlammableCombustibleLiquids_2
                    MaterialTypes.Add("b) For flammable liquids having flashpoint of above -6.67oC and below 22.8 oC such\r\nas alcohol, amyl, toluol, ethyl, acetate and like");
                    //StorageFlammableCombustibleLiquids_3
                    MaterialTypes.Add("c) For liquids having flashpoint of 22.8 oC to 93.3 oC, such as kerosene, turpentine,\r\nthinner, prepared paints, varnish, diesel oil, fuel oil, kerosene, cleansing solvent,\r\npolishing liquids and similar");
                    //StorageFlammableCombustibleLiquids_4
                    MaterialTypes.Add("d) For combustible liquids having flash point greater than 93.3 oC that is subject to\r\nspontaneous ignition or is artificially heated to a temperature equal to or higher\r\nthan its flash point, such as crude oil, petroleum oil and others");
                    break;

                case "Flammable Gases":
                    //StorageFlammableGases_1a
                    MaterialTypes.Add("a) (Bulk Storage)Liquefied Petroleum Gas (LPG) in liter water capacity");
                    //StorageFlammableGases_1b
                    MaterialTypes.Add("b) For other than bulk storage LPG");
                    //StorageFlammableGases_2
                    MaterialTypes.Add("c) Other flammable gases in liter water capacity");
                    break;
            }

            SelectedMaterialType = null;
        }
        private StorageItems _storageItems = new StorageItems();

        


        [RelayCommand]
        private void CalculateStorageFees()
        {
             
            //Application.Current.MainPage.DisplayAlert("Info", "sample", "OK");
            if (SelectedStorageCategory.Equals("Flammable/Combustible Solids"))
            {
                if(string.IsNullOrEmpty(SelectedMaterialType) || SelectedMaterialType.Length < 2)
                {
                    // Handle the case where no material type is selected or the selection is invalid
                    return;
                }
                switch (SelectedMaterialType[0])
                {
                    case 'a':
                        _storageItems.StorageFlammableCombustibleSolids_1(); // Example value for Calcium carbide
                        var fee1 = _storageItems.getAmount(BasisOfComputation);
                        AnnualFees = fee1.ToString("N2");
                        break;
                    case 'b':
                        _storageItems.StorageFlammableCombustibleSolids_2();// Example value for Pyroxylin
                        var fee2 = _storageItems.getAmount(BasisOfComputation);
                        AnnualFees = fee2.ToString("N2");
                        break;
                    case 'c':
                        _storageItems.StorageFlammableCombustibleSolids_3();// Example value for Matches
                        var fee3 = _storageItems.getAmount(BasisOfComputation);
                        AnnualFees = fee3.ToString("N2");
                        break;
                    case 'd':
                        _storageItems.StorageFlammableCombustibleSolids_4();// Example value for hazardous chemicals
                        var fee4 = _storageItems.getAmount(BasisOfComputation);
                        AnnualFees = fee4.ToString("N2");
                        break;
                    case 'e':
                        _storageItems.StorageFlammableCombustibleSolids_5();// Example value for shredded combustible materials
                        var fee5 = _storageItems.getAmount(BasisOfComputation);
                        AnnualFees = fee5.ToString("N2");
                        break;
                    case 'f':
                        _storageItems.StorageFlammableCombustibleSolids_6();// Example value for tar, resin, waxes, etc.
                        var fee6= _storageItems.getAmount(BasisOfComputation);
                        AnnualFees = fee6.ToString("N2");
                        break;
                }

            }
            else if (SelectedStorageCategory.Equals("Flammable/Combustible Liquids"))
            {
                if (string.IsNullOrEmpty(SelectedMaterialType) || SelectedMaterialType.Length < 2)
                {
                    // Handle the case where no material type is selected or the selection is invalid
                    return;
                }
                switch (SelectedMaterialType[0])
                {
                    case 'a':
                        _storageItems.StorageFlammableCombustibleLiquids_1();
                        var feeLiq1 = _storageItems.getAmountwithExcess(BasisOfComputation);
                        AnnualFees = feeLiq1.ToString("N2");
                        break;
                    case 'b':
                        _storageItems.StorageFlammableCombustibleLiquids_2();
                        var feeLiq2 = _storageItems.getAmount(BasisOfComputation);
                        AnnualFees = feeLiq2.ToString("N2");
                        break;
                    case 'c':
                        _storageItems.StorageFlammableCombustibleLiquids_3();
                        var feeLiq3 = _storageItems.getAmount(BasisOfComputation);
                        AnnualFees = feeLiq3.ToString("N2");
                        break;
                    case 'd':
                        _storageItems.StorageFlammableCombustibleLiquids_4();
                        var feeLiq4 = _storageItems.getAmount(BasisOfComputation);
                        AnnualFees = feeLiq4.ToString("N2");
                        break;

                }
            }
            else if (SelectedStorageCategory.Equals("Flammable Gases"))
            {
                if (string.IsNullOrEmpty(SelectedMaterialType) || SelectedMaterialType.Length < 2)
                {
                    // Handle the case where no material type is selected or the selection is invalid
                    return;
                }
                switch (SelectedMaterialType[0])
                {
                    case 'a':
                        _storageItems.StorageFlammableGases_1a();
                        var fee1a = _storageItems.getAmountwithExcess(BasisOfComputation);
                        AnnualFees = fee1a.ToString("N2");
                        break;
                    case 'b':
                        _storageItems.StorageFlammableGases_1b();
                        var fee1b = _storageItems.getAmountwithExcess(BasisOfComputation);
                        AnnualFees = fee1b.ToString("N2");
                        break;
                    case 'c':
                        _storageItems.StorageFlammableGases_2();
                        var fee2b = _storageItems.getAmount(BasisOfComputation);
                        AnnualFees = fee2b.ToString("N2");
                        break;
                }
            }

        }

        [RelayCommand]
        private void OnSelectedOtherFeeChanged()
        {
            if (string.IsNullOrEmpty(SelectedOtherFee) || SelectedOtherFee.Length < 2)
            {
                // Handle the case where no other fee is selected or the selection is invalid
                return;
            }
            switch (SelectedOtherFee[0])
            {
                case 'a':
                    OtherFeesButtonText = "View Amount";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    
                    break;
                case 'b':
                    OtherFeesButtonText = "View Amount";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    
                    break;
                case 'c':
                    OtherFeesButtonText = "Calculate";
                    OtherFeesBasisText = "Basis of Computation (kVA):";
                    IsReadOnly = false;
                    break;
                case 'd':
                    OtherFeesButtonText = "View Amount";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    
                    break;
                case 'e':
                    OtherFeesButtonText = "View Amount";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    
                    break;
                case 'f':
                    OtherFeesButtonText = "View Amount";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    
                    break;
                case 'g':
                    OtherFeesButtonText = "View Amount";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    
                    break;
                case 'h':
                    OtherFeesButtonText = "View Amount";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    
                    break;
                case 'i':
                    OtherFeesButtonText = "View Amount";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    
                    break;
                case 'j':
                    OtherFeesButtonText = "View Amount";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    
                    break;
                case 'k':
                    OtherFeesButtonText = "View Amount";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    
                    break;
                case 'l':
                    OtherFeesButtonText = "View Amount";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    
                    break;
                case 'm':
                    OtherFeesButtonText = "Calculate";
                    OtherFeesBasisText = "Basis of Computation (Qty of Welding/oxy-acytylene/cutting machine):";
                    IsReadOnly = false;
                    
                    break;

            }
        }
        [RelayCommand]
        private void CalculateOtherFees()
        {
            ElectricalItems electricalItems = new ElectricalItems();
            if (string.IsNullOrEmpty(SelectedOtherFee) || SelectedOtherFee.Length < 2)
            {
                // Handle the case where no other fee is selected or the selection is invalid
                return;
            }
            switch (SelectedOtherFee[0])
            {
                case 'a':
                    
                    OtherFeesAmount = "1000.00";
                    break;
                case 'b':
                    
                    OtherFeesAmount = "350.00";
                    break;
                case 'c':
                    
                    OtherFeesAmount = electricalItems.GetElectricalAmount(OtherFeesBasisOfComputation).ToString("N2");
                    break;
                case 'd':
                    
                    OtherFeesAmount = "200.00";
                    break;
                case 'e':
                    
                    OtherFeesAmount = "1000.00";
                    break;
                case 'f':

                    OtherFeesAmount = "350.00";
                    break;
                case 'g':
                    
                    OtherFeesAmount = "2000.00";
                    break;
                case 'h':
                    
                    OtherFeesAmount = "1049.00";
                    break;
                case 'i':
                    
                    OtherFeesAmount = "350.00";
                    break;
                case 'j':
                    
                    OtherFeesAmount = "525.00";
                    break;
                case 'k':
                    
                    OtherFeesAmount = "500.00";
                    break;
                case 'l':
                    
                    OtherFeesAmount = "2000.00";
                    break;
                case 'm':
                    
                    OtherFeesAmount = GetHotworksAmount((int)OtherFeesBasisOfComputation).ToString("N2");
                    break;

            }
        }
        public double GetHotworksAmount(int qty)
        {
            if (qty <= 0)
                return 0;

            if (qty <= 5)
                return 500.0;
            else if (qty <= 10)
                return 1000.0;
            else
                return 1500.0;
        }


    }
}

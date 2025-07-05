using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;

namespace Fire_Safety_Requirements.ViewModel
{
    public partial class OtherFeesCalcViewModel_1 : ObservableObject
    {
        public OtherFeesCalcViewModel_1()
        {
            selectedStorageCategory = StorageCategories.FirstOrDefault();
            selectedOtherFee = OtherFees.FirstOrDefault();
        }

        //------------------Storage Fees-------------------//
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

        partial void OnSelectedStorageCategoryChanged(string value)
        {
            MaterialTypes.Clear();
            SelectedMaterialType = null;

            switch (value)
            {
                case "Flammable/Combustible Solids":
                    MaterialTypes.Add("a) Calcium carbide");
                    MaterialTypes.Add("b) Pyroxylin");
                    MaterialTypes.Add("c) Matches");
                    MaterialTypes.Add("d) Nitrate, phosphorous, bromine, sodium, picric acid and other hazardous\r\nchemicals of similar flammable, explosive, oxidizing or lacrymatory properties:");
                    MaterialTypes.Add("e) Shredded combustible materials...");
                    MaterialTypes.Add("f) Tar, resin, waxes...");
                    break;

                case "Flammable/Combustible Liquids":
                    MaterialTypes.Add("a) For flammable liquids having flashpoint of -6.67oC or below...");
                    MaterialTypes.Add("b) For flammable liquids having flashpoint above -6.67oC and below 22.8 oC...");
                    MaterialTypes.Add("c) For liquids having flashpoint of 22.8 oC to 93.3 oC...");
                    MaterialTypes.Add("d) For combustible liquids having flash point greater than 93.3 oC...");
                    break;

                case "Flammable Gases":
                    MaterialTypes.Add("a) (Bulk Storage)Liquefied Petroleum Gas (LPG) in liter water capacity");
                    MaterialTypes.Add("b) For other than bulk storage LPG");
                    MaterialTypes.Add("c) Other flammable gases in liter water capacity");
                    break;
            }
        }

        private StorageItems _storageItems = new StorageItems();

        [RelayCommand]
        private void CalculateStorageFees()
        {
            if (string.IsNullOrEmpty(SelectedMaterialType) || SelectedMaterialType.Length < 1)
                return;

            char materialKey = SelectedMaterialType[0];

            if (SelectedStorageCategory == "Flammable/Combustible Solids")
            {
                switch (materialKey)
                {
                    case 'a':
                        _storageItems.StorageFlammableCombustibleSolids_1();
                        break;
                    case 'b':
                        _storageItems.StorageFlammableCombustibleSolids_2();
                        break;
                    case 'c':
                        _storageItems.StorageFlammableCombustibleSolids_3();
                        break;
                    case 'd':
                        _storageItems.StorageFlammableCombustibleSolids_4();
                        break;
                    case 'e':
                        _storageItems.StorageFlammableCombustibleSolids_5();
                        break;
                    case 'f':
                        _storageItems.StorageFlammableCombustibleSolids_6();
                        break;
                }

                AnnualFees = _storageItems.getAmount(BasisOfComputation).ToString("N2");
            }
            else if (SelectedStorageCategory == "Flammable/Combustible Liquids")
            {
                switch (materialKey)
                {
                    case 'a':
                        _storageItems.StorageFlammableCombustibleLiquids_1();
                        AnnualFees = _storageItems.getAmountwithExcess(BasisOfComputation).ToString("N2");
                        break;
                    case 'b':
                        _storageItems.StorageFlammableCombustibleLiquids_2();
                        break;
                    case 'c':
                        _storageItems.StorageFlammableCombustibleLiquids_3();
                        break;
                    case 'd':
                        _storageItems.StorageFlammableCombustibleLiquids_4();
                        break;
                }

                if (materialKey != 'a')
                    AnnualFees = _storageItems.getAmount(BasisOfComputation).ToString("N2");
            }
            else if (SelectedStorageCategory == "Flammable Gases")
            {
                switch (materialKey)
                {
                    case 'a':
                        _storageItems.StorageFlammableGases_1a();
                        AnnualFees = _storageItems.getAmountwithExcess(BasisOfComputation).ToString("N2");
                        break;
                    case 'b':
                        _storageItems.StorageFlammableGases_1b();
                        AnnualFees = _storageItems.getAmountwithExcess(BasisOfComputation).ToString("N2");
                        break;
                    case 'c':
                        _storageItems.StorageFlammableGases_2();
                        AnnualFees = _storageItems.getAmount(BasisOfComputation).ToString("N2");
                        break;
                }
            }
        }

        partial void OnSelectedOtherFeeChanged(object value)
        {
            OnSelectedOtherFeeChanged();
        }

        [RelayCommand]
        private void OnSelectedOtherFeeChanged()
        {
            string _selected = SelectedOtherFee as string;

            if (string.IsNullOrEmpty(_selected) || _selected.Length < 1)
                return;

            OtherFeesBasisOfComputation = 0;
            OtherFeesAmount = "";
            IsReadOnly = true;
            OtherFeesButtonText = "View Clearance Fee";
            OtherFeesBasisText = "Not Applicable";

            switch (_selected[0])
            {
                case 'c':
                    OtherFeesButtonText = "Calculate";
                    OtherFeesBasisText = "Basis of Computation (kVA):";
                    IsReadOnly = false;
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
            string _selectedOtherFee = SelectedOtherFee as string;
            if (string.IsNullOrEmpty(_selectedOtherFee))
                return;

            ElectricalItems electricalItems = new ElectricalItems();

            switch (_selectedOtherFee[0])
            {
                case 'a': OtherFeesAmount = "1000.00"; break;
                case 'b': OtherFeesAmount = "350.00"; break;
                case 'c':
                    OtherFeesAmount = electricalItems.GetElectricalAmount(OtherFeesBasisOfComputation).ToString("N2");
                    break;
                case 'd': OtherFeesAmount = "200.00"; break;
                case 'e': OtherFeesAmount = "1000.00"; break;
                case 'f': OtherFeesAmount = "350.00"; break;
                case 'g': OtherFeesAmount = "2000.00"; break;
                case 'h': OtherFeesAmount = "1049.00"; break;
                case 'i': OtherFeesAmount = "350.00"; break;
                case 'j': OtherFeesAmount = "525.00"; break;
                case 'k': OtherFeesAmount = "500.00"; break;
                case 'l': OtherFeesAmount = "2000.00"; break;
                case 'm':
                    OtherFeesAmount = GetHotworksAmount((int)OtherFeesBasisOfComputation).ToString("N2");
                    break;
            }
        }

        public double GetHotworksAmount(int qty)
        {
            if (qty <= 0) return 0;
            if (qty <= 5) return 500.0;
            if (qty <= 10) return 1000.0;
            return 1500.0;
        }

        //------------------Conveyance Fees-------------------//
        public ObservableCollection<string> ConveyanceType { get; } = new()
        {
            "A. Flammable Liquids in Vehicles (Liters)",
            "B. Explosives or Hazardous Chemicals (Kilograms)",
            "C. Loading/Unloading at Terminals or Piers",
            "D. Transfer to Shore Tanks (Liters)",
            "E. Bulk Transfer via Lighters or Pipelines"
        };

        [ObservableProperty]
        private string selectedConveyanceType;

        [ObservableProperty]
        private double conveyanceFeesBasisOfComputation;

        [ObservableProperty]
        private string conveyanceFeesAmount;

        [RelayCommand]
        private void CalculateConveyanceFees()
        {
            ConveyanceFeeCalculator con = new ConveyanceFeeCalculator();
            ConveyanceFeesAmount = SelectedConveyanceType switch
            {
                "A. Flammable Liquids in Vehicles (Liters)" => con.ComputeFee_CaseA(ConveyanceFeesBasisOfComputation).ToString("N2"),
                "B. Explosives or Hazardous Chemicals (Kilograms)" => con.ComputeFee_CaseB(ConveyanceFeesBasisOfComputation).ToString("N2"),
                "C. Loading/Unloading at Terminals or Piers" => con.ComputeFee_CaseC(ConveyanceFeesBasisOfComputation).ToString("N2"),
                "D. Transfer to Shore Tanks (Liters)" => con.ComputeFee_CaseD(ConveyanceFeesBasisOfComputation).ToString("N2"),
                "E. Bulk Transfer via Lighters or Pipelines" => con.ComputeFee_CaseE(ConveyanceFeesBasisOfComputation).ToString("N2"),
                _ => "0.00"
            };
        }

        //------------------Other Fees (UI Binding)-------------------//
        public ObservableCollection<string> OtherFees { get; } = new()
        {
            "a. Appeal Fee mentioned under Rule 14 of this RIRR",
            "b. Certified true copy...",
            "c. Electrical Installation",
            "d. Filing Fee for Fire Safety Evaluation Clearance (FSEC)",
            "e. Fire Drill",
            "f. Fire Incident Clearance",
            "g. Fire Prevention and Safety Seminar",
            "h. Fireworks Display",
            "i. Fumigation/Fogging",
            "j. Open Flame",
            "k. Protest Fee...",
            "l. Soundstage...",
            "m. Welding, Cutting and Other Hotworks"
        };

        [ObservableProperty]
        private object selectedOtherFee;

        [ObservableProperty]
        private double otherFeesBasisOfComputation;

        [ObservableProperty]
        private string otherFeesAmount;

        [ObservableProperty]
        private string otherFeesButtonText = "View Clearance Fee";

        [ObservableProperty]
        private string otherFeesBasisText = "Not Applicable";

        [ObservableProperty]
        bool isReadOnly = true;

        //------------------Installation Fees-------------------//
        public ObservableCollection<string> InstallationType { get; } = new()
        {
            "a. Compressed Gases (LPG, CNG) – Over 454L",
            "b. Flammable/Combustible Liquids in Tanks",
            "c. Equipment & Fire Protection Systems (per RIRR)"
        };

        [ObservableProperty]
        private string selectedInstallationType;

        [ObservableProperty]
        private double installationFeesBasisOfComputation;

        [ObservableProperty]
        private string installationFeesAmount;

        [ObservableProperty]
        private bool textFieldInstallationBasis = false;

        [RelayCommand]
        private void CalculateInstallationFees()
        {
            InstallationFeeCalculator calc = new InstallationFeeCalculator();
            switch (SelectedInstallationType)
            {
                case "a. Compressed Gases (LPG, CNG) – Over 454L":
                    InstallationFeesAmount = calc.ComputeFee_CaseA_Gases(InstallationFeesBasisOfComputation).ToString("N2");
                    break;
                case "b. Flammable/Combustible Liquids in Tanks":
                    InstallationFeesAmount = calc.ComputeFee_CaseB_Tanks().ToString("N2");
                    break;
                case "c. Equipment & Fire Protection Systems (per RIRR)":
                    InstallationFeesAmount = calc.ComputeFee_CaseC_Equipment(InstallationFeesBasisOfComputation).ToString("N2");
                    break;
                default:
                    InstallationFeesAmount = "0.00";
                    break;
            }
        }

        partial void OnSelectedInstallationTypeChanged(string value)
        {
            TextFieldInstallationBasis = !value.Equals("b. Flammable/Combustible Liquids in Tanks");
        }
    }
}

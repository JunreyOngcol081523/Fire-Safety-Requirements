using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Fire_Safety_Requirements.ViewModel
{
    public partial class OtherFeesCalcViewModel : ObservableObject
    {
        // Constructor
        public OtherFeesCalcViewModel()
        {
            //selectedStorageCategory = StorageCategories.FirstOrDefault();
            //selectedConveyanceType = ConveyanceType.FirstOrDefault();
            //selectedInstallationType = InstallationType.FirstOrDefault();
            //selectedOtherFee = OtherFees.FirstOrDefault();
        }
        //-----------------fire code revenue 01-06-------------------//
        [ObservableProperty]
        string selectedRevenueCategory;
        [ObservableProperty]
        double revenueBasisOfComputation;
        [ObservableProperty]
        string revenueFees;
        public ObservableCollection<string> RevenueCategories { get; } = new()
        {
            "01 - Fire Code Construction Tax",
            "02 - Fire Code Realty Tax",
            "03 - Fire Code Premium Tax",
            "04 - Fire Code Sales Tax",
            "05 - Fire Code Proceeds Tax",
            "06 - Fire Safety Inspection Fee"
        };
        //calculate revenue fees
        [RelayCommand]
        private void CalculateRevenue()
        {
            double percentage = 0;
            switch (SelectedRevenueCategory)
            {
                case "01 - Fire Code Construction Tax":
                    percentage = 0.001; // 0.10% (one-tenth of one per centum)
                    break;
                case "02 - Fire Code Realty Tax":
                    percentage = 0.0001; // 0.01% (one-hundredth of one per centum)
                    break;
                case "03 - Fire Code Premium Tax":
                    percentage = 0.02; // 2% (two per centum)
                    break;
                case "04 - Fire Code Sales Tax":
                    percentage = 0.02; // 2% (two per centum)
                    break;
                case "05 - Fire Code Proceeds Tax":
                    percentage = 0.02; // 2% (two per centum)
                    break;
                case "06 - Fire Safety Inspection Fee":
                    percentage = 0.15; // 15% (fifteen percent)
                    break;
                default:
                    percentage = 0;
                    break;
            }
            double calculatedFee = RevenueBasisOfComputation * percentage;
            if (SelectedRevenueCategory == "06 - Fire Safety Inspection Fee")
            {
                if (calculatedFee < 500.00)
                {
                    calculatedFee = 500.00; // Minimum fee of PhP500.00
                }
            }
            //construction tax cannot be more than 50,000
            if (SelectedRevenueCategory == "01 - Fire Code Construction Tax" && calculatedFee > 50000.00)
            {
                calculatedFee = 50000.00; // Maximum fee of PhP50,000.00
            }
            // Format as Philippine Peso with thousand separators and 2 decimal places
            RevenueFees = calculatedFee.ToString("C2", new CultureInfo("en-PH"));
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
            if (string.IsNullOrEmpty(SelectedMaterialType) || SelectedMaterialType.Length < 1)
                return;
            //Application.Current.MainPage.DisplayAlert("Info", "sample", "OK");
            if (SelectedStorageCategory.Equals("Flammable/Combustible Solids"))
            {
                if (string.IsNullOrEmpty(SelectedMaterialType) || SelectedMaterialType.Length < 2)
                {
                    // Handle the case where no material type is selected or the selection is invalid
                    return;
                }
                switch (SelectedMaterialType[0])
                {
                    case 'a':
                        _storageItems.StorageFlammableCombustibleSolids_1(); // Example value for Calcium carbide
                        var fee1 = _storageItems.getAmount(BasisOfComputation);
                        AnnualFees = fee1.ToString("C2", new CultureInfo("en-PH"));
                        break;
                    case 'b':
                        _storageItems.StorageFlammableCombustibleSolids_2();// Example value for Pyroxylin
                        var fee2 = _storageItems.getAmount(BasisOfComputation);
                        AnnualFees = fee2.ToString("C2", new CultureInfo("en-PH"));
                        break;
                    case 'c':
                        _storageItems.StorageFlammableCombustibleSolids_3();// Example value for Matches
                        var fee3 = _storageItems.getAmount(BasisOfComputation);
                        AnnualFees = fee3.ToString("C2", new CultureInfo("en-PH"));
                        break;
                    case 'd':
                        _storageItems.StorageFlammableCombustibleSolids_4();// Example value for hazardous chemicals
                        var fee4 = _storageItems.getAmount(BasisOfComputation);
                        AnnualFees = fee4.ToString("C2", new CultureInfo("en-PH"));
                        break;
                    case 'e':
                        _storageItems.StorageFlammableCombustibleSolids_5();// Example value for shredded combustible materials
                        var fee5 = _storageItems.getAmount(BasisOfComputation);
                        AnnualFees = fee5.ToString("C2", new CultureInfo("en-PH"));
                        break;
                    case 'f':
                        _storageItems.StorageFlammableCombustibleSolids_6();// Example value for tar, resin, waxes, etc.
                        var fee6 = _storageItems.getAmount(BasisOfComputation);
                        AnnualFees = fee6.ToString("C2", new CultureInfo("en-PH"));
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
                        AnnualFees = feeLiq1.ToString("C2", new CultureInfo("en-PH"));
                        break;
                    case 'b':
                        _storageItems.StorageFlammableCombustibleLiquids_2();
                        var feeLiq2 = _storageItems.getAmount(BasisOfComputation);
                        AnnualFees = feeLiq2.ToString("C2", new CultureInfo("en-PH"));
                        break;
                    case 'c':
                        _storageItems.StorageFlammableCombustibleLiquids_3();
                        var feeLiq3 = _storageItems.getAmount(BasisOfComputation);
                        AnnualFees = feeLiq3.ToString("C2", new CultureInfo("en-PH"));
                        break;
                    case 'd':
                        _storageItems.StorageFlammableCombustibleLiquids_4();
                        var feeLiq4 = _storageItems.getAmount(BasisOfComputation);
                        AnnualFees = feeLiq4.ToString("C2", new CultureInfo("en-PH"));
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
                        AnnualFees = fee1a.ToString("C2", new CultureInfo("en-PH"));
                        break;
                    case 'b':
                        _storageItems.StorageFlammableGases_1b();
                        var fee1b = _storageItems.getAmountwithExcess(BasisOfComputation);
                        AnnualFees = fee1b.ToString("C2", new CultureInfo("en-PH"));
                        break;
                    case 'c':
                        _storageItems.StorageFlammableGases_2();
                        var fee2b = _storageItems.getAmount(BasisOfComputation);
                        AnnualFees = fee2b.ToString("C2", new CultureInfo("en-PH"));
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
            if (string.IsNullOrEmpty(_selected) || _selected.Length < 2)
            {
                // Handle the case where no other fee is selected or the selection is invalid
                return;
            }
            OtherFeesBasisOfComputation = 0;
            OtherFeesAmount = "";
            switch (_selected[0])
            {
                case 'a':
                    OtherFeesButtonText = "View Clearance Fee";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    break;
                case 'b':
                    OtherFeesButtonText = "View Clearance Fee";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    break;
                case 'c':
                    OtherFeesButtonText = "Calculate";
                    OtherFeesBasisText = "Basis of Computation (kVA):";
                    IsReadOnly = false;
                    break;
                case 'd':
                    OtherFeesButtonText = "View Clearance Fee";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    break;
                case 'e':
                    OtherFeesButtonText = "View Clearance Fee";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    break;
                case 'f':
                    OtherFeesButtonText = "View Clearance Fee";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    break;
                case 'g':
                    OtherFeesButtonText = "View Clearance Fee";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    break;
                case 'h':
                    OtherFeesButtonText = "View Clearance Fee";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    break;
                case 'i':
                    OtherFeesButtonText = "View Clearance Fee";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    break;
                case 'j':
                    OtherFeesButtonText = "View Clearance Fee";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    break;
                case 'k':
                    OtherFeesButtonText = "View Clearance Fee";
                    OtherFeesBasisText = "Not Applicable";
                    IsReadOnly = true;
                    break;
                case 'l':
                    OtherFeesButtonText = "View Clearance Fee";
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
            string _selectedOtherFee = SelectedOtherFee as string;
            if (string.IsNullOrEmpty(_selectedOtherFee))
                return;
            ElectricalItems electricalItems = new ElectricalItems();
            if (string.IsNullOrEmpty(_selectedOtherFee) || _selectedOtherFee.Length < 2)
            {
                // Handle the case where no other fee is selected or the selection is invalid
                return;
            }
            switch (_selectedOtherFee[0])
            {
                case 'a':

                    OtherFeesAmount = "1000.00";
                    break;
                case 'b':

                    OtherFeesAmount = "350.00";
                    break;
                case 'c':

                    OtherFeesAmount = electricalItems.GetElectricalAmount(OtherFeesBasisOfComputation).ToString("C2", new CultureInfo("en-PH"));
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

                    OtherFeesAmount = GetHotworksAmount((int)OtherFeesBasisOfComputation).ToString("C2", new CultureInfo("en-PH"));
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
        //--------------------end of Other Fees-------------------//

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
                "A. Flammable Liquids in Vehicles (Liters)" => con.ComputeFee_CaseA(ConveyanceFeesBasisOfComputation).ToString("C2", new CultureInfo("en-PH")),
                "B. Explosives or Hazardous Chemicals (Kilograms)" => con.ComputeFee_CaseB(ConveyanceFeesBasisOfComputation).ToString("C2", new CultureInfo("en-PH")),
                "C. Loading/Unloading at Terminals or Piers" => con.ComputeFee_CaseC(ConveyanceFeesBasisOfComputation).ToString("C2", new CultureInfo("en-PH")),
                "D. Transfer to Shore Tanks (Liters)" => con.ComputeFee_CaseD(ConveyanceFeesBasisOfComputation).ToString("C2", new CultureInfo("en-PH")),
                "E. Bulk Transfer via Lighters or Pipelines" => con.ComputeFee_CaseE(ConveyanceFeesBasisOfComputation).ToString("C2", new CultureInfo("en-PH")),
                _ => "0.00"
            };
        }
        //--------------------------end of Conveyance Fees-------------------//

        //------------------Other Fees-------------------//
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
        //------------------end of Other Fees-------------------//


        //---------------installation fees-------------------//
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
            InstallationFeeCalculator installationFeeCalculator = new InstallationFeeCalculator();
            switch (SelectedInstallationType)
            {
                case "a. Compressed Gases (LPG, CNG) – Over 454L":
                    InstallationFeesAmount = installationFeeCalculator.ComputeFee_CaseA_Gases(InstallationFeesBasisOfComputation).ToString("C2", new CultureInfo("en-PH"));
                    break;
                case "b. Flammable/Combustible Liquids in Tanks":
                    InstallationFeesAmount = installationFeeCalculator.ComputeFee_CaseB_Tanks().ToString("C2", new CultureInfo("en-PH"));
                    break;
                case "c. Equipment & Fire Protection Systems (per RIRR)":
                    InstallationFeesAmount = installationFeeCalculator.ComputeFee_CaseC_Equipment(InstallationFeesBasisOfComputation).ToString("C2", new CultureInfo("en-PH"));
                    break;
                default:
                    InstallationFeesAmount = "0.00";
                    break;
            }
        }

        partial void OnSelectedInstallationTypeChanged(string value)
        {
            if (string.IsNullOrEmpty(value) || string.Equals(value, "b. Flammable/Combustible Liquids in Tanks"))
            {
                TextFieldInstallationBasis = false;
            }
            else
            {
                TextFieldInstallationBasis = true;
            }
            InstallationFeesBasisOfComputation = 0;
        }

        //----------------end of installation fees-------------------//

        //-----------------admin fines-------------------//
        public ObservableCollection<string> AdminFineType { get; } = new()
        {
            "a. Cellulose nitrate plastic of any kind",
            "b. Combustible fibers",
            "c. Cellular materials such as foam rubber",
            "d. Flammable and combustible liquids or gases",
            "e. Flammable paints, varnishes, stains and organic coatings",
            "f. High piled or widely spread combustible stock",
            "g. Metallic magnesium in any form",
            "h. Corrosive liquids, oxidizing materials, etc.",
            "i. Blasting agents, explosives, etc.",
            "j. Liquid nitro-glycerine and TNT",
            "k. Firework materials of any kind",
            "l. Matches in commercial quantities",
            "m. Hot ashes, live coals and embers",
            "n. Mineral, vegetable or animal oils (above 25L)",
            "o. Combustible waste materials for resale",
            "p. Explosive dusts and vapors",
            "q. Agriculture, forest, marine or mineral products"
        };

        [ObservableProperty]
        private string selectedAdminFineType;

        [ObservableProperty]
        private double adminFineBasisOfComputation;

        [ObservableProperty]
        private string adminFineAmount;
        [ObservableProperty]
        private string unitMeasurement = "Basis of Computation";
        [RelayCommand]
        private void CalculateAdminFine()
        {
            double basis = AdminFineBasisOfComputation;
            double fine = 0;

            switch (SelectedAdminFineType)
            {
                case "a. Cellulose nitrate plastic of any kind":
                    fine = Math.Min(basis * 2843.20, 8885);
                    break;

                case "b. Combustible fibers":
                case "c. Cellular materials such as foam rubber":
                case "q. Agriculture, forest, marine or mineral products":
                    fine = Math.Min(basis * 2843.20, 28432);
                    break;

                case "d. Flammable and combustible liquids or gases":
                    fine = Math.Min(basis * 2843.20, 50000);
                    break;

                case "e. Flammable paints, varnishes, stains and organic coatings":
                    fine = Math.Min(basis * 2843.20, 17770);
                    break;

                case "f. High piled or widely spread combustible stock":
                    fine = Math.Min(basis * 568.64, 50000);
                    break;

                case "g. Metallic magnesium in any form":
                case "h. Corrosive liquids, oxidizing materials, etc.":
                    fine = Math.Min(basis * 2843.20, 50000);
                    break;

                case "i. Blasting agents, explosives, etc.":
                    fine = Math.Min(basis * 14216.00, 50000);
                    break;

                case "j. Liquid nitro-glycerine and TNT":
                    fine = Math.Min(basis * 28432.00, 50000);
                    break;

                case "k. Firework materials of any kind":
                    fine = Math.Min(basis * 14216.00, 50000);
                    break;

                case "l. Matches in commercial quantities":
                    fine = Math.Min(basis * 2843.20, 50000);
                    break;

                case "m. Hot ashes, live coals and embers":
                    fine = Math.Min(basis * 1421.60, 28432);
                    break;

                case "n. Mineral, vegetable or animal oils (above 25L)":
                    fine = Math.Min(basis * 284.30, 28432);
                    break;

                case "o. Combustible waste materials for resale":
                    fine = Math.Min(basis * 284.30, 28432);
                    break;

                case "p. Explosive dusts and vapors":
                    // Special case: Fixed range fine (no computation needed)
                    fine = Math.Max(28432, Math.Min(50000, basis <= 0 ? 28432 : basis));
                    break;

                default:
                    fine = 0;
                    break;
            }

            AdminFineAmount = fine.ToString("C2", new CultureInfo("en-PH"));
        }

        partial void OnSelectedAdminFineTypeChanged(string value)
        {
            switch (value)
            {
                case "a. Cellulose nitrate plastic of any kind":
                case "g. Metallic magnesium in any form":
                case "i. Blasting agents, explosives, etc.":
                case "k. Firework materials of any kind":
                    UnitMeasurement = "Basis of Computation: kilogram";
                    break;

                case "b. Combustible fibers":
                case "c. Cellular materials such as foam rubber":
                case "f. High piled or widely spread combustible stock":
                case "m. Hot ashes, live coals and embers":
                case "o. Combustible waste materials for resale":
                case "q. Agriculture, forest, marine or mineral products":
                    UnitMeasurement = "Basis of Computation: m³";
                    break;

                case "d. Flammable and combustible liquids or gases":
                case "e. Flammable paints, varnishes, stains and organic coatings":
                case "h. Corrosive liquids, oxidizing materials, etc.":
                case "j. Liquid nitro-glycerine and TNT":
                case "n. Mineral, vegetable or animal oils (above 25L)":
                    UnitMeasurement = "Basis of Computation: liter";
                    break;

                case "l. Matches in commercial quantities":
                    UnitMeasurement = "Basis of Computation: matchman gross";
                    break;

                case "p. Explosive dusts and vapors":
                    UnitMeasurement = "Basis of Computation: per violation";
                    break;

                default:
                    UnitMeasurement = string.Empty;
                    break;
            }
        }


        //-------------------end of admin fines-------------------//
    }
}

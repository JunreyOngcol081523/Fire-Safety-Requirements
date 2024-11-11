using Fire_Safety_Requirements.ViewModel;
using System.Text.Json;

namespace Fire_Safety_Requirements;

public partial class OccupancyDetailPage : ContentPage
{
    public OccupancyDetailPage(OccupancyDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        LoadDataFromJson();
    }
    private async void LoadDataFromJson()
    {
        try
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("data.json");
            using var reader = new StreamReader(stream);
            string assetPath = "Fire Safety Requirements.Resources.Json.data.json";
            // Sample path to JSON file in app data directory
            string jsonFilePath = assetPath;


            var jsonData = File.ReadAllText(jsonFilePath);
            var rows = JsonSerializer.Deserialize<List<RowData>>(jsonData);

            int rowIndex = 1;  // Start from row 1 (row 0 is the header)

            foreach (var row in rows)
            {
                // Column 1
                var column1Label = new Label
                {
                    Text = row.Column1
                };
                // Correctly calling Grid.SetRow and Grid.SetColumn as methods
                Grid.SetRow(column1Label, rowIndex);
                Grid.SetColumn(column1Label, 0);

                // Column 2
                var column2Label = new Label
                {
                    Text = row.Column2
                };
                // Correctly calling Grid.SetRow and Grid.SetColumn as methods
                Grid.SetRow(column2Label, rowIndex);
                Grid.SetColumn(column2Label, 1);

                // Add the labels to the Grid
                tableGrid.Children.Add(column1Label);
                tableGrid.Children.Add(column2Label);

                rowIndex++; // Increment to next row
            }
            
        }
        catch (Exception ex)
        {
            
        }
        
        
    }
    public class RowData
    {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
    }

}
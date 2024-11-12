namespace Fire_Safety_Requirements
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(OccupancyTypePage), typeof(OccupancyTypePage));
            Routing.RegisterRoute("OccupancyDetailPage", typeof(OccupancyDetailPage));
            
        }
    }
}

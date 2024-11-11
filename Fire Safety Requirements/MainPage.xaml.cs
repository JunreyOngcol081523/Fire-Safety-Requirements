namespace Fire_Safety_Requirements
{
    public partial class MainPage : ContentPage
    {
        public string programmer_message { get; set; }
        public string preface { get; set; }
        public MainPage()
        {
            InitializeComponent();
            programmer_message = "Good day, my fellow Fire Safety Inspectors (FSIs) and Building Plan Evaluators (BPEs)!\r\n\r\nI am Junrey B. Ongcol, the creator of this app. I developed this app to assist you, my fellow FSIs and BPEs, in performing our work with more guidance and ease.\r\n\r\nThis app is based entirely on our manual, Fire Safety Guidelines for Different Types of Occupancy, Vol. 2. I sincerely hope that this app proves to be a valuable tool in your work.";
            preface = "Fire is extremely dangerous, and we must all be cautious of it to save our lives and the lives of our loved ones. Depending on the existing conditions, fire may start as a slow-growth scenario or it may grow rapidly in a building. In either case, fire is considered a disaster that, when not suppressed, can lead to a total loss of property and ultimately the loss of lives.\n\n Nowadays and in future generations, it is important to have a basic understanding of fire safety and prevention. The Bureau of Fire Protection is the sole agency mandated to enforce the Fire Code of the Philippines. As such, public safety is its highest obligation, and the prevention of destructive fires is among its utmost responsibilities.";
            BindingContext = this;
        }

    }

}

using Fire_Safety_Requirements.ViewModel;

namespace Fire_Safety_Requirements;

public partial class WebViewPage : ContentPage
{
    public string htmlsource = "";
    WebViewViewModel viewmodel;
    public WebViewPage(WebViewViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
        viewmodel = vm;
    }
    private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
    {
        viewmodel.IsBusy = true;
    }

    private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
    {
        viewmodel.IsBusy = false;
    }
}
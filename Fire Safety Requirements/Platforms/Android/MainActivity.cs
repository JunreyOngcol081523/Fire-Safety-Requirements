using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.MauiMTAdmob;

namespace Fire_Safety_Requirements
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            string appId = "ca-app-pub-8158194714551266~1214454213";

            string license = "ZIrXQSue3vFYNfMSzKXkStXSLUgy6vEfkwHfvSnC1lBKifhqgmAOL6QzX3YZdz6q/9yWdo1LWRxQy3pBHuapiubn7tcVNE8Z8A=="; //<-- Your license key here
            string deviceId = "9cdc0cea-dfce-49cd-ab2a-beec9ad74057"; //<--- Your test device id here
            string OPENADS_AD_UNIT_ID = "ca-app-pub-8158194714551266~5887832408";
            string NATIVEADS_AD_UNIT_ID = "ca-app-pub-3940256099942544/2247696110";
            bool enableOpenAds = false;
            bool initialiseConsentAtStartup = true;
            //If you have a license code:

            //CrossMauiMTAdmob.Current.SkipConsent = true;

            //CrossMauiMTAdmob.Current.Init(this, appId, license, NATIVEADS_AD_UNIT_ID, OPENADS_AD_UNIT_ID, enableOpenAds, false, deviceId, true, Plugin.MauiMTAdmob.Extra.DebugGeography.DEBUG_GEOGRAPHY_EEA, initialiseConsentAtStartup);

            //If you don't have a license code, you can use the following line instead:
            CrossMauiMTAdmob.Current.Init(this, appId);
        }

        // Add the following code to the MainActivity class to handle the lifecycle events:
        // CrossMauiMTAdmob.Current.OnResume() allows to load and show the app open ad when the app is resumed.
        // You need to add your logic to decide if and when show the app open ad.
        // You can use CrossMauiMTAdmob.Current.AreOpenAdsEnabled to enable or disable the app open ads.
        protected override void OnResume()
        {
            base.OnResume();
            CrossMauiMTAdmob.Current.OnResume();
        }
    }
}

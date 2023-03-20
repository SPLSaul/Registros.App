using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Registros;

[Activity(Label = "IconoYSplash",Icon = "@drawable/splash", Theme = "@style/Maui.MySplash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
}

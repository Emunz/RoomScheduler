using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RoomScheduler.Services;
using RoomScheduler.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.Identity.Client;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace RoomScheduler
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        public static string AzureBackendUrl = "http://localhost:5000";
        public static bool UseMockDataStore = true;

        public static PublicClientApplication PCA = null;
        public static string AuthClientID = ResSched.Config.MSALClientId; //replace this id if you use your own azure tenant, also need to replace the id in the android manifest file and the info.plist file in ios
        public static string[] AuthScopes = ResSched.Config.MSALAuthScopes;
        public static string AuthUserName = string.Empty;
        public static string AuthUserEmail = string.Empty;

        public static UIParent UiParent { get; set; }

        public App()
        {
            InitializeComponent();

            PCA = new PublicClientApplication(AuthClientID)
            {
                RedirectUri = ResSched.Config.MSALRedirectUri
            };

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<AzureDataStore>();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            AppCenter.Start($"uwp={ResSched.Config.AppCenterUWP};" +
                  $"android={ResSched.Config.AppCenterAndroid};" +
                  $"ios={ResSched.Config.AppCenteriOS};",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RoomScheduler.Services;
using RoomScheduler.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace RoomScheduler
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        public static string AzureBackendUrl = "http://localhost:5000";
        public static bool UseMockDataStore = true;

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<AzureDataStore>();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            AppCenter.Start("uwp=db62a449-64c8-4063-8039-cf60499c9e55;" +
                  "android=07e5dacc-4b03-49ac-99fe-571332935014" +
                  "ios=af531830-d6c2-4165-bf39-8c07dd6f1895",
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

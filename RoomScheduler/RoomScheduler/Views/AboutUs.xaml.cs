using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RoomScheduler.Models;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;

namespace RoomScheduler.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutUs : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        public AboutUs()
        {
            InitializeComponent();
        }

        private void FacebookGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://facebook.com/foxbuildshop/"));
        }

        private void TwitterGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://twitter.com/fox_build/"));
        }

        private void SlackGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage.DisplayAlert("Wait!", "You must be a member to join our Slack Channel!", "OK");
        }

        private void PhoneGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open("16303449385");
                Analytics.TrackEvent("Phone Call Attempted", new Dictionary<string, string>
                {
                    {"Where", "AboutUsPage - Phone Number - Tap" }
                });
            }
            catch (FeatureNotEnabledException ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Sorry, the phone dialer is not supported", "OK");
                Analytics.TrackEvent("Phone Call Attempted", new Dictionary<string, string>
                {
                    {"Where", "AboutUsPage - Phone Number - Tap" },
                    {"Error", "Phone dialer was not supported on the device" }
                });
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    {"Where", "AboutUsPage - Phone Number - Tap" },
                    {"Error", ex.Message }
                });
            }
        }

        private void BackButton_Tapped(object sender, EventArgs e)
        {
            (RootPage.Master as MenuPage).TakeMeHere(MenuItemType.Browse);
        }

        private void TestCrashButton_Clicked()
        {
            Crashes.GenerateTestCrash();
        }
    }
}
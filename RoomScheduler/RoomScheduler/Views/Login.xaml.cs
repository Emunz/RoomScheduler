using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomScheduler.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoomScheduler.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        public Login ()
		{
			InitializeComponent ();
		}
        private void BackButton_Tapped(object sender, EventArgs e)
        {
            (RootPage.Master as MenuPage).TakeMeHere(MenuItemType.Browse);
        }
    }
}
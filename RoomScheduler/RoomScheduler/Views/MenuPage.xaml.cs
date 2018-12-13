﻿using RoomScheduler.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoomScheduler.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            //TODO: Remove My Reservations if the user is not logged in
            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse" },
                new HomeMenuItem {Id = MenuItemType.MyReservations, Title="My Reservations" },
                new HomeMenuItem {Id = MenuItemType.AboutUs, Title="About Us" },
                new HomeMenuItem {Id = MenuItemType.Login, Title="Login" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += OnMenuItemSelected;
        }

        private async void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var id = (int)((HomeMenuItem)e.SelectedItem).Id;
            await RootPage.NavigateFromMenu(id);
        }

        public void TakeMeHere(MenuItemType page)
        {
            int id = (int)page;
            ListViewMenu.SelectedItem = menuItems[id];
        }
    }
}
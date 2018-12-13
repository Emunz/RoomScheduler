using System;
using System.Collections.Generic;
using System.Text;

namespace RoomScheduler.Models
{
    public enum MenuItemType
    {
        Browse,
        MyReservations,
        Login,
        AboutUs
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}

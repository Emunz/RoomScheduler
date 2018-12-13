using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomScheduler.Services
{
    interface ISQLite
    {
        void CloseConnection();
        SQLiteConnection GetConnection();
        SQLiteAsyncConnection GetAsyncConnection();
        void DeleteDatabase();

    }
}

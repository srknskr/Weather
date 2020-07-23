using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Connection
{
    public interface IDatabase
    {
        SQLiteConnection GetConnection();
    }
}

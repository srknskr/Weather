using System;
using Android.OS;
using SQLite;
using Weather.Droid.Connection;
using Xamarin.Forms;
using System.IO;
using Weather.Connection;

[assembly: Dependency(typeof(Weather.Droid.Connection.SQLiteConnection))]
namespace Weather.Droid.Connection
{
    class SQLiteConnection : IDatabase
    {
        public SQLite.SQLiteConnection GetConnection()
        {
            var filename = "Places.db";
            var documentspath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, filename);
            var connection = new SQLite.SQLiteConnection(path);
            return connection;
        }
    }
}
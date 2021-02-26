using SQLite;
using System.Collections.Generic;
using System.Linq;
using Weather.Model;
using Xamarin.Forms;

namespace Weather.Connection
{
public class Database
{
    static object locker = new object();

    SQLiteConnection _sqlconnection;

    public Database()
    {
        _sqlconnection = DependencyService.Get<IDatabase>().GetConnection();
        _sqlconnection.CreateTable<Places>();
    }
    public int Insert(Places place)
    {
        lock (locker)
        {
            return _sqlconnection.Insert(place);
        }
    }
    public int Update(Places place)
    {
        lock (locker)
        {
            return _sqlconnection.Update(place);
        }
    }
    public int Delete(int id)
    {
        lock (locker)
        {
            return _sqlconnection.Delete<Places>(id);
        }
    }
    public IEnumerable<Places> GetAll()
    {
        lock (locker)
        {
            return (from i in _sqlconnection.Table<Places>() select i).ToList();
        }
    } 
    public int FullDelete()
    {
        lock (locker)
        {
            return _sqlconnection.DeleteAll<Places>();
        }
    }
    public Places Get(int id)
    {
        lock (locker)
        {
            return _sqlconnection.Table<Places>().FirstOrDefault(t => t.Id == id);
        }
    }
    public List<Places> GetFirst()
    {
        lock (locker)
        {
            return _sqlconnection.Query<Places>("SELECT * FROM Places LIMIT 1");
        }
    }
    public void Dispose()
    {
        _sqlconnection.Dispose();
    }
}
}

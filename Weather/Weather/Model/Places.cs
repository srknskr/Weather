using SQLite;
using System;
using System.Collections.Generic;
using System.Text;


namespace Weather.Model
{
    public class Places
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string CityName { get; set; }
        public double CityLat { get; set; }
        public double CityLon { get; set; }
        public string CityKey { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public string FirstCharacter
        {
            get
            {
                if (!String.IsNullOrEmpty(CityName))
                {
                    return CityName.Substring(0, 1).ToUpper();
                }
                else
                {
                    return "";
                }
            }
        }

    }
}

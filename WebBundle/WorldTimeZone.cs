using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBundle
{
    public class WorldTimeZone
    {        
        /// <summary>
        /// Inner class for timezone information.
        /// </summary>
        public class TimezoneInfo
        {
            public string value;
            public string info;
        }

        /// <summary>
        /// Timezone info list
        /// </summary>
        private static List<TimezoneInfo> timezoneInfoList = new List<TimezoneInfo> {
        new TimezoneInfo() { value="Morocco Standard Time", info="(GMT) Casablanca" },
        new TimezoneInfo() { value="GMT Standard Time", info="(GMT) Greenwich Mean Time : Dublin, Edinburgh, Lisbon, London" },
        new TimezoneInfo() { value="Greenwich Standard Time", info="(GMT) Monrovia, Reykjavik" },
        new TimezoneInfo() { value="W. Europe Standard Time", info="(GMT+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna" },
        new TimezoneInfo() { value="Central Europe Standard Time", info="(GMT+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague" },
        new TimezoneInfo() { value="Romance Standard Time", info="(GMT+01:00) Brussels, Copenhagen, Madrid, Paris" },
        new TimezoneInfo() { value="Central European Standard Time", info="(GMT+01:00) Sarajevo, Skopje, Warsaw, Zagreb" },
        new TimezoneInfo() { value="W. Central Africa Standard Time", info="(GMT+01:00) West Central Africa" },
        new TimezoneInfo() { value="Jordan Standard Time", info="(GMT+02:00) Amman" },
        new TimezoneInfo() { value="GTB Standard Time", info="(GMT+02:00) Athens, Bucharest, Istanbul" },
        new TimezoneInfo() { value="Middle East Standard Time", info="(GMT+02:00) Beirut" },
        new TimezoneInfo() { value="Egypt Standard Time", info="(GMT+02:00) Cairo" },
        new TimezoneInfo() { value="South Africa Standard Time", info="(GMT+02:00) Harare, Pretoria" },
        new TimezoneInfo() { value="FLE Standard Time", info="(GMT+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius" },
        new TimezoneInfo() { value="Israel Standard Time", info="(GMT+02:00) Jerusalem" },
        new TimezoneInfo() { value="E. Europe Standard Time", info="(GMT+02:00) Minsk" },
        new TimezoneInfo() { value="Namibia Standard Time", info="(GMT+02:00) Windhoek" },
        new TimezoneInfo() { value="Arabic Standard Time", info="(GMT+03:00) Baghdad" },
        new TimezoneInfo() { value="Arab Standard Time", info="(GMT+03:00) Kuwait, Riyadh" },
        new TimezoneInfo() { value="Russian Standard Time", info="(GMT+03:00) Moscow, St. Petersburg, Volgograd" },
        new TimezoneInfo() { value="E. Africa Standard Time", info="(GMT+03:00) Nairobi" },
        new TimezoneInfo() { value="Georgian Standard Time", info="(GMT+03:00) Tbilisi" },
        new TimezoneInfo() { value="Iran Standard Time", info="(GMT+03:30) Tehran" },
        new TimezoneInfo() { value="Arabian Standard Time", info="(GMT+04:00) Abu Dhabi, Muscat" },
        new TimezoneInfo() { value="Azerbaijan Standard Time", info="(GMT+04:00) Baku" },
        new TimezoneInfo() { value="Mauritius Standard Time", info="(GMT+04:00) Port Louis" },
        new TimezoneInfo() { value="Caucasus Standard Time", info="(GMT+04:00) Yerevan" },
        new TimezoneInfo() { value="Afghanistan Standard Time", info="(GMT+04:30) Kabul" },
        new TimezoneInfo() { value="Ekaterinburg Standard Time", info="(GMT+05:00) Ekaterinburg" },
        new TimezoneInfo() { value="Pakistan Standard Time", info="(GMT+05:00) Islamabad, Karachi" },
        new TimezoneInfo() { value="West Asia Standard Time", info="(GMT+05:00) Tashkent" },
        new TimezoneInfo() { value="India Standard Time", info="(GMT+05:30) Chennai, Kolkata, Mumbai, New Delhi" },
        new TimezoneInfo() { value="Sri Lanka Standard Time", info="(GMT+05:30) Sri Jayawardenepura" },
        new TimezoneInfo() { value="Nepal Standard Time", info="(GMT+05:45) Kathmandu" },
        new TimezoneInfo() { value="N. Central Asia Standard Time", info="(GMT+06:00) Almaty, Novosibirsk" },
        new TimezoneInfo() { value="Central Asia Standard Time", info="(GMT+06:00) Astana, Dhaka" },
        new TimezoneInfo() { value="Myanmar Standard Time", info="(GMT+06:30) Yangon (Rangoon)" },
        new TimezoneInfo() { value="SE Asia Standard Time", info="(GMT+07:00) Bangkok, Hanoi, Jakarta" },
        new TimezoneInfo() { value="North Asia Standard Time", info="(GMT+07:00) Krasnoyarsk" },
        new TimezoneInfo() { value="China Standard Time", info="(GMT+08:00) Beijing, Chongqing, Hong Kong, Urumqi" },
        new TimezoneInfo() { value="North Asia East Standard Time", info="(GMT+08:00) Irkutsk, Ulaan Bataar" },
        new TimezoneInfo() { value="Singapore Standard Time", info="(GMT+08:00) Kuala Lumpur, Singapore" },
        new TimezoneInfo() { value="W. Australia Standard Time", info="(GMT+08:00) Perth" },
        new TimezoneInfo() { value="Taipei Standard Time", info="(GMT+08:00) Taipei" },
        new TimezoneInfo() { value="Tokyo Standard Time", info="(GMT+09:00) Osaka, Sapporo, Tokyo" },
        new TimezoneInfo() { value="Korea Standard Time", info="(GMT+09:00) Seoul" },
        new TimezoneInfo() { value="Yakutsk Standard Time", info="(GMT+09:00) Yakutsk" },
        new TimezoneInfo() { value="Cen. Australia Standard Time", info="(GMT+09:30) Adelaide" },
        new TimezoneInfo() { value="AUS Central Standard Time", info="(GMT+09:30) Darwin" },
        new TimezoneInfo() { value="E. Australia Standard Time", info="(GMT+10:00) Brisbane" },
        new TimezoneInfo() { value="AUS Eastern Standard Time", info="(GMT+10:00) Canberra, Melbourne, Sydney" },
        new TimezoneInfo() { value="West Pacific Standard Time", info="(GMT+10:00) Guam, Port Moresby" },
        new TimezoneInfo() { value="Tasmania Standard Time", info="(GMT+10:00) Hobart" },
        new TimezoneInfo() { value="Vladivostok Standard Time", info="(GMT+10:00) Vladivostok" },
        new TimezoneInfo() { value="Central Pacific Standard Time", info="(GMT+11:00) Magadan, Solomon Is., New Caledonia" },
        new TimezoneInfo() { value="New Zealand Standard Time", info="(GMT+12:00) Auckland, Wellington" },
        new TimezoneInfo() { value="Fiji Standard Time", info="(GMT+12:00) Fiji, Kamchatka, Marshall Is." },
        new TimezoneInfo() { value="Tonga Standard Time", info="(GMT+13:00) Nuku'alofa" },
        new TimezoneInfo() { value="Azores Standard Time", info="(GMT-01:00) Azores" },
        new TimezoneInfo() { value="Cape Verde Standard Time", info="(GMT-01:00) Cape Verde Is." },
        new TimezoneInfo() { value="Mid-Atlantic Standard Time", info="(GMT-02:00) Mid-Atlantic" },
        new TimezoneInfo() { value="E. South America Standard Time", info="(GMT-03:00) Brasilia" },
        new TimezoneInfo() { value="Argentina Standard Time", info="(GMT-03:00) Buenos Aires" },
        new TimezoneInfo() { value="SA Eastern Standard Time", info="(GMT-03:00) Georgetown" },
        new TimezoneInfo() { value="Greenland Standard Time", info="(GMT-03:00) Greenland" },
        new TimezoneInfo() { value="Montevideo Standard Time", info="(GMT-03:00) Montevideo" },
        new TimezoneInfo() { value="Newfoundland Standard Time", info="(GMT-03:30) Newfoundland" },
        new TimezoneInfo() { value="Atlantic Standard Time", info="(GMT-04:00) Atlantic Time (Canada)" },
        new TimezoneInfo() { value="SA Western Standard Time", info="(GMT-04:00) La Paz" },
        new TimezoneInfo() { value="Central Brazilian Standard Time", info="(GMT-04:00) Manaus" },
        new TimezoneInfo() { value="Pacific SA Standard Time", info="(GMT-04:00) Santiago" },
        new TimezoneInfo() { value="Venezuela Standard Time", info="(GMT-04:30) Caracas" },
        new TimezoneInfo() { value="SA Pacific Standard Time", info="(GMT-05:00) Bogota, Lima, Quito, Rio Branco" },
        new TimezoneInfo() { value="Eastern Standard Time", info="(GMT-05:00) Eastern Time (US & Canada)" },
        new TimezoneInfo() { value="US Eastern Standard Time", info="(GMT-05:00) Indiana (East)" },
        new TimezoneInfo() { value="Central America Standard Time", info="(GMT-06:00) Central America" },
        new TimezoneInfo() { value="Central Standard Time", info="(GMT-06:00) Central Time (US & Canada)" },
        new TimezoneInfo() { value="Central Standard Time (Mexico)", info="(GMT-06:00) Guadalajara, Mexico City, Monterrey" },
        new TimezoneInfo() { value="Canada Central Standard Time", info="(GMT-06:00) Saskatchewan" },
        new TimezoneInfo() { value="US Mountain Standard Time", info="(GMT-07:00) Arizona" },
        new TimezoneInfo() { value="Mountain Standard Time (Mexico)", info="(GMT-07:00) Chihuahua, La Paz, Mazatlan" },
        new TimezoneInfo() { value="Mountain Standard Time", info="(GMT-07:00) Mountain Time (US & Canada)" },
        new TimezoneInfo() { value="Pacific Standard Time", info="(GMT-08:00) Pacific Time (US & Canada)" },
        new TimezoneInfo() { value="Pacific Standard Time (Mexico)", info="(GMT-08:00) Tijuana, Baja California" },
        new TimezoneInfo() { value="Alaskan Standard Time", info="(GMT-09:00) Alaska" },
        new TimezoneInfo() { value="Hawaiian Standard Time", info="(GMT-10:00) Hawaii" },
        new TimezoneInfo() { value="Samoa Standard Time", info="(GMT-11:00) Midway Island, Samoa" },
        new TimezoneInfo() { value="Dateline Standard Time", info="(GMT-12:00) International Date Line West" }
        };

        /// <summary>
        /// This method return list of timezon info
        /// </summary>
        /// <returns>List&#60;TimezoneInfo&#62;</returns>
        public static List<TimezoneInfo> getTimezoneInfoList()
        {
            return timezoneInfoList;            
        }

        /// <summary>
        /// This method return the timezone and current datetime of that timezone as cictionary
        /// </summary>
        /// <returns>Dictionary&#60;string, DateTime&#62;</returns>
        public Dictionary<string, DateTime> getTimeZoneList()
        {
            Dictionary<string, DateTime> timezoneTimeDict = null;
            try
            {
                timezoneTimeDict = new Dictionary<string, DateTime>();
                foreach (var item in WorldTimeZone.timezoneInfoList)
                {
                    string timeZoneID = item.value;
                    var timeUtc = DateTime.UtcNow;
                    TimeZoneInfo timeInfoZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneID);
                    DateTime time = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, timeInfoZone);
                    timezoneTimeDict.Add(timeZoneID, time);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine($"Exception {exp.StackTrace}");
            }
            return timezoneTimeDict;
        }
    }
}

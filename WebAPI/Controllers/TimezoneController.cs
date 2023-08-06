using Microsoft.AspNetCore.Mvc;
using WebBundle;
using WebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TimezoneController : ControllerBase
    {
        /// <summary>
        /// This will return list of all timezone name and current datetime
        /// </summary>
        /// <returns>List&#60;TimezoneModel&#62;</returns>
        [Route("GetList")]
        [HttpGet(Name = "GetTimezoneInfoList")]
        public List<TimezoneModel> Get()
        {
            Dictionary<string, string> myList = new Dictionary<string, string>();

            var dict = new WorldTimeZone().getTimeZoneList();

            dict = dict.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            List<TimezoneModel> lstZoneInfo= new List<TimezoneModel>();
            foreach (var item in dict)
            {
                var ob = new TimezoneModel() { zonename= item.Key, datetime= item.Value.ToString() };
                lstZoneInfo.Add(ob);
            }
            return lstZoneInfo;
        }

        /// <summary>
        /// This will take zonename as argument of string type and returns current datetime 
        /// </summary>
        /// <param name="zonename">Pass zonename as argument as string. It should be correct match as listed.</param>
        /// <returns>TimezoneModel</returns>
        [Route("GetZonetime/{zonename}")]
        [HttpGet(Name ="GetTimezoneInfo")]
        public TimezoneModel Get([FromRoute]string zonename) 
        {
            TimezoneModel timezone = null;
            var dict = new WorldTimeZone().getTimeZoneList();
            if (dict.ContainsKey(zonename))
            {
                timezone = new TimezoneModel() { zonename = zonename, datetime= dict[zonename].ToString() };
            }

            return timezone;
        }
    }
}

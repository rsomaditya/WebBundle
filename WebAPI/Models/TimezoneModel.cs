using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class TimezoneModel
    {
        [JsonPropertyName("zonename")]
        public string zonename { get; set; }

        [JsonPropertyName("datetime")]
        public string datetime { get; set; }
    }
}

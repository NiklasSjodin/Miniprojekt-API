using System.Text.Json.Serialization;

namespace Miniprojekt_API.Models.ViewModels
{
    public class PersonViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

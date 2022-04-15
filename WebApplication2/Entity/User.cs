using System.Text.Json.Serialization;
using WebApplication2.Vendors.Entity;

namespace WebApplication2.Entity
{
    public class User:EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        [JsonIgnore] public string Password { get; set; }
    }
}
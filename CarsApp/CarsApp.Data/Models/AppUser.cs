namespace CarsApp.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    using System.Collections.Generic;

    public class AppUser : IdentityUser
    {
        public AppUser()
            : base() => this.Cars = new HashSet<Car>();

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<Car> Cars { get; set; }
    }
}

namespace CarsApp.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Car
    {
        public Car() => this.Images = new HashSet<Image>();

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int ModelId { get; set; }

        public Model Model { get; set; }

        public Guid AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public IEnumerable<Image> Images { get; set; }
    }
}

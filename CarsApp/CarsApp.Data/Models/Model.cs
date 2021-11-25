namespace CarsApp.Data.Models
{
    using System.Collections.Generic;

    public class Model
    {
        public Model() => this.Cars = new HashSet<Car>();

        public int Id { get; set; }

        public string Title { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public IEnumerable<Car> Cars { get; set; }
    }
}

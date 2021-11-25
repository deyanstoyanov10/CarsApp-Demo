namespace CarsApp.Data.Models
{
    using System.Collections.Generic;

    public class Brand
    {
        public Brand() => this.Models = new HashSet<Model>();

        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<Model> Models { get; set; }
    }
}

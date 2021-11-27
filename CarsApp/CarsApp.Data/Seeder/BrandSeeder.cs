namespace CarsApp.Data.Seeder
{
    using Models;

    using System.Linq;
    using System.Collections.Generic;

    public class BrandSeeder : ISeeder
    {
        private readonly CarsDbContext _data;
        private IEnumerable<string> brands;

        public BrandSeeder(CarsDbContext data) =>_data = data;

        public void Seed()
        {
            if (_data.Brands.Any())
            {
                return;
            }

            this.FillBrands();
            this.SeedData();
        }

        private void SeedData()
        {
            var brands = new List<Brand>();

            foreach (var brandTitle in this.brands)
            {
                var brand = new Brand()
                {
                    Title = brandTitle
                };

                brands.Add(brand);
            }

            _data.Brands.AddRange(brands);
            _data.SaveChanges();
        }

        private void FillBrands()
        {
            this.brands = new List<string>
            {
                "Volkswagen",
                "Mercedes-Benz",
                "BMW",
                "Audi",
                "Opel",
                "Peugeot",
                "Renault",
                "Ford",
                "Toyota",
                "Citroen",
                "Fiat",
                "Mazda",
                "Honda",
                "Nissan",
                "Seat",
                "Skoda",
                "Mitsubishi",
                "Hyundai",
                "Kia",
                "Volvo",
                "Subaru",
                "Suzuki",
                "Alfa Romeo",
                "Chevrolet",
                "Land Rover",
                "Dacia",
                "Jeep",
                "Mini",
                "Lancia",
                "Chrysler",
                "Daihatsu",
                "Smart",
                "Ssangyong",
                "Jaguar",
                "Daewoo",
                "Rover",
                "Porsche",
                "Lexus",
                "Saab",
                "Dodge",
                "Infiniti",
                "Isuzu",
                "Tesla",
                "Range Rover",
                "Cadillac",
                "Lincoln",
                "Hummer",
                "Maserati",
                "MG",
                "Bentley",
                "Pontiac",
                "Pagani",
                "Koenigsegg",
                "Ferrari",
                "Rolls Royce",
                "Datsun",
                "Austin",
                "Acura",
                "Lamborghini",
                "Maybach",
                "Haval",
                "Oldsmobile",
                "GMC",
                "Aston Martin"
            };
        }
    }
}

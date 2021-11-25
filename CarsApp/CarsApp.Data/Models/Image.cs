namespace CarsApp.Data.Models
{
    public class Image
    {
        public long Id { get; set; }

        public string Folder { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }
    }
}

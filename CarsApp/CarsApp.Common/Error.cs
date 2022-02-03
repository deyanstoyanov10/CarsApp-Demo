namespace CarsApp.Common
{
    public class Error
    {
        public Error() => this.Message = string.Empty;

        public Error(string message) => this.Message = message;

        public string Message { get; set; }
    }
}

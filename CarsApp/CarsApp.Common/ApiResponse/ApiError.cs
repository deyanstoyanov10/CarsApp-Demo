namespace CarsApp.Common.ApiResponse
{
    public class ApiError
    {
        private const string DefaultSourceContext = "Server";
        private const string DefaultErrorMessage = "Server Error";

        public ApiError() 
        {
            this.SourceContext = DefaultSourceContext;
            this.Error = DefaultErrorMessage;
        }

        public ApiError(string sourceContext, string error)
        {
            this.SourceContext = sourceContext;
            this.Error = error;
        }

        public string SourceContext { get; set; }

        public string Error { get; set; }
    }
}

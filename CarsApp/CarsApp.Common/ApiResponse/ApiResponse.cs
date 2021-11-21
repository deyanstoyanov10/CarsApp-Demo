namespace CarsApp.Common.ApiResponse
{
    using System.Linq;
    using System.Collections.Generic;

    public class ApiResponse<T>
    {
        public ApiResponse() { }

        public ApiResponse(T data) => this.Data = data;

        public ApiResponse(IEnumerable<ApiError> errors)
        {
            if (errors.Any())
            {
                this.Errors = errors;
            }
            else
            {
                this.Errors = new List<ApiError>()
                {
                    new ApiError()
                };
            }
        }

        public T Data { get; set; }

        public IEnumerable<ApiError> Errors { get; set; }

        public bool Succeeded => !this.Errors.Any();

        public bool Failure => !this.Succeeded;
    }
}

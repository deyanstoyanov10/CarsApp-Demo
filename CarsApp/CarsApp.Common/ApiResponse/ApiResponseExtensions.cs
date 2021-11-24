namespace CarsApp.API.Infrastructure.Extensions
{
    using Common.ApiResponse;
    using Common.ServiceResult;

    using System.Collections.Generic;

    public static class ApiResponseExtensions
    {
        public static ApiResponse<T> ToApiResponse<T>(this T data)
            => new ApiResponse<T>(data);

        public static ApiResponse<T> ToErrorApiResponse<T>(this Result<T> result, string sourceContext)
            => new ApiResponse<T>(new List<ApiError>()
               {
                   new ApiError(sourceContext, result.Error)
               });
    }
}

namespace CarsApp.Common
{
    using System.Linq;
    using System.Collections.Generic;

    public class Result<TData>
    {
        public Result(TData data)
        {
            this.Data = data;
            this.Errors = new List<Error>();
        }

        public Result(string error)
        {
            this.Errors = new List<Error>() { new Error(error) };
        }

        public bool Succeeded => this.Errors.Any();

        public bool Failure => !this.Succeeded;

        public TData Data { get; set; }

        public List<Error> Errors { get; set; }

        public static implicit operator Result<TData>(TData data)
            => new Result<TData>(data);

        public static implicit operator Result<TData>(string error)
            => new Result<TData>(error);
    }
}

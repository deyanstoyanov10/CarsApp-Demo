namespace CarsApp.Handlers
{
    using Common;

    public interface IHandler<TObject, TObjectResult>
        where TObject : class
    {
        Task<Result<TObjectResult>> Execute(TObject model);

        IHandler<TObject, TObjectResult> SetNext(IHandler<TObject, TObjectResult> handler);
    }
}
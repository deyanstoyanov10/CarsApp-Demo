namespace CarsApp.Handlers
{
    using Common;

    public abstract class Handler<TObject, TObjectResult> : IHandler<TObject, TObjectResult> 
        where TObject : class
    {
        private const string INTERNAL_VALIDATION_ERROR = "Internal validation error.";

        protected IHandler<TObject, TObjectResult> _next;

        public virtual async Task<Result<TObjectResult>> Execute(TObject model)
        {
            if (_next is not null)
            {
                await _next.Execute(model);
            }

            return INTERNAL_VALIDATION_ERROR;
        }

        public IHandler<TObject, TObjectResult> SetNext(IHandler<TObject, TObjectResult> handler)
        {
            _next = handler;

            return _next;
        }
    }
}

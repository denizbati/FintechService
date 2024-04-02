namespace FintechService.ApiContract
{
    public class ResponseBase<T> : ResponseBaseModel
    {
        public T Result { get; set; }

        public ResponseBase()
        {
        }

        public ResponseBase<T> SetResult(T t)
        {
            Result = t;

            return this;
        }
    }
}
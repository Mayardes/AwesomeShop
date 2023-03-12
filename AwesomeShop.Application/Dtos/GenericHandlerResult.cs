namespace AwesomeShop.Application.Dtos
{
    public class GenericHandlerResult<T> where T : class
    {
        public string Message { get; private set;}
        public T Data { get; private set; }
        public bool Success { get; private set; }
        public List<ValidationObject> Validation { get; private set; }

        public GenericHandlerResult(string message, T data, bool success, List<ValidationObject> validation)
        {
            Message = message;
            Data = data;
            Success = success;
            Validation = validation;
        }
    }
    public class ValidationObject
    {
        public string Property { get; private set;}
        public string Message { get; private set;}

        public ValidationObject(string property, string message)
        {
            Property = property;
            Message = message;
        }
    }
}

namespace EconomyTips.Domain
{
    public class Result<T>
    {
        public T? Value { get; set; }

        public String ErrorMessage { get; set; } = "";

        public bool Sucess => string.IsNullOrEmpty(ErrorMessage);

        public Result<T> OK(T value)
        {
            Value = value;
            ErrorMessage = "";
            return this;
        }

        public Result<T> BadRequest(string ErrorMessage)
        {
            this.ErrorMessage = ErrorMessage;
            return this;
        }
    }
}

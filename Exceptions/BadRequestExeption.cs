namespace onlatn_tv_project.Exceptions
{
    public class BadRequestExeption :Exception
    {

        public BadRequestExeption()
        {
        }

        public BadRequestExeption(string message)
            : base(message)
        {
        }

        public BadRequestExeption(string message, Exception inner)
            : base(message, inner)
        {

        }

    }
}

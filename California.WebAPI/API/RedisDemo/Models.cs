namespace API.RedisDemo
{
    public class Request
    {

    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {

        }
    }

    public class Response
    {
        public string Message { get; set; }
    }
}
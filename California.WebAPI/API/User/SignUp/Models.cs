using California.WebAPI.Entities;

namespace API.User.SignUp
{
    public class Request : AccountEntity
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
        public bool Message { get; set; }
    }
}
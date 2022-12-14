using California.WebAPI.Entities;
using Newtonsoft.Json.Linq;

namespace API.User.Login
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
        public string AccountEmail { get; set; }
        public IEnumerable<string> AccountPermissions { get; set; }
        public string TokenValue { get; set; }
        public DateTime TokenExpiryDate { get; set; }
    }
}
using California.WebAPI.Entities;

namespace API.Blog.Query
{
    public class Request
    {
        public string? BlogId { get; set; } // 博客id
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {

        }
    }

    public class Response : BlogEntity
    {
        
    }
}
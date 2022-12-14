using California.WebAPI.Entities;

namespace API.Blog.Add
{
    public class Mapper : Mapper<Request, Response, BlogEntity>
    {
        public override async Task<BlogEntity> ToEntityAsync(Request r)
        {
            return new BlogEntity()
            {
                BlogTitle = r.BlogTitle,
                BlogContext = r.BlogContext,
            };
        }
    }
}
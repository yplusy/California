using California.WebAPI.Entities;

namespace API.Blog.Query
{
    public class Mapper : Mapper<Request, Response, BlogEntity>
    {
        public override async Task<BlogEntity> ToEntityAsync(Request r)
        {
            return new BlogEntity()
            {
                BlogId = r.BlogId
            };
        }
        public override async Task<Response> FromEntityAsync(BlogEntity entity)
        {
            return new Response()
            {
                BlogId = entity.BlogId,
                BlogTitle = entity.BlogTitle,
                BlogContext = entity.BlogContext,
                CreateTime = entity.CreateTime,
            };
        }
    }
}
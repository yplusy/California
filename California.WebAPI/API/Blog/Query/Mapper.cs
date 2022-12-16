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
        public async Task<List<Response>> ToResponseAsync(List<BlogEntity> entities)
        {
            List<Response> responses = new List<Response>();
            try
            {
                Response response = new Response();
                foreach (var item in entities)
                {
                    response.BlogId = item.BlogId;
                    response.BlogTitle = item.BlogTitle;
                    response.BlogContext = item.BlogContext;
                    response.CreateTime = item.CreateTime;
                    responses.Add(response);
                }
                return responses;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
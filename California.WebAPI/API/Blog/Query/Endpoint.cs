using California.WebAPI.Entities;

namespace API.Blog.Query
{
    public class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public readonly CaliforniaContext _context;
        public Endpoint(CaliforniaContext context)
        {
            _context = context;
        }

        public override void Configure()
        {
            Get("/api/blog");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var entity = await Map.ToEntityAsync(r);
            var data = Data.GetBlog(_context, entity);

            Response = await Map.FromEntityAsync(data);
            await SendAsync(Response);
        }
    }
}
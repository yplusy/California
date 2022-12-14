using California.WebAPI.Entities;

namespace API.Blog.Add
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
            Post("/api/blog/add");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var entity = await Map.ToEntityAsync(r);
            var data = Data.PostBlog(_context, entity);

            if (data)
            {
                Response.Message = data.ToString();
            }
            else
            {
                Response.Message = (!data).ToString();
            }
            await SendAsync(Response);
        }
    }
}
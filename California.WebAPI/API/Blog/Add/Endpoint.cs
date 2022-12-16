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
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var entity = await Map.ToEntityAsync(r);
            var data = Data.PostBlog(_context, entity);

            if (data)
            {
                Response.Msg = data.ToString();
            }
            else
            {
                Response.Msg = (!data).ToString();
            }
            await SendAsync(Response);
        }
    }
}
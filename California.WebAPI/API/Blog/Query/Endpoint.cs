using California.WebAPI.Entities;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Text.Json;
using California.WebAPI;

namespace API.Blog.Query
{
    public class Endpoint : Endpoint<Request, List<Response>, Mapper>
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
            var data = await Data.GetBlog(_context, entity);

            Response = await Map.ToResponseAsync(data);
            //await SendStringAsync(data.ToJson());
        }
    }
}
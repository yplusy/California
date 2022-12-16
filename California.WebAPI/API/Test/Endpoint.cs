using California.WebAPI.Entities;

namespace API.Test
{
    public class Endpoint : EndpointWithoutRequest<List<BlogEntity>>
    {
        public readonly CaliforniaContext _context;
        public Endpoint(CaliforniaContext context)
        {
            _context = context;
        }

        public override void Configure()
        {
            Get("/api/test");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            Response = await Data.GetPendingArticles(_context);
        }
    }
}
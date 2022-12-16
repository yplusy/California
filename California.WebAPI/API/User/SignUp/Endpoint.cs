using California.WebAPI.Entities;

namespace API.User.SignUp
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
            Post("/api/signup");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var entity = await Map.ToEntityAsync(r);
            var data = Data.Zc(_context, entity, r.CAPTCHA);

            Response.Msg = data;
            await SendAsync(Response);
        }
    }
}
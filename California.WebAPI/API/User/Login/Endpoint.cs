using California.WebAPI.Entities;
using System.Security.Claims;

namespace API.User.Login
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
            Post("/api/login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var entity = await Map.ToEntityAsync(r);
            var data = Data.Account(_context, entity);

            if (data != null)
            {
                Response = await Map.FromEntityAsync(data);
            }
            else
            {
                Response.Msg = "登录失败";
            }

            await SendAsync(Response);
        }
    }
}
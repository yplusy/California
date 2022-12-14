using California.WebAPI.Entities;

namespace API.User.SignUp
{
    public class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public readonly CaliforniaContext _dbContext;
        public Endpoint(CaliforniaContext context)
        {
            _dbContext = context;
        }

        public override void Configure()
        {
            Post("/api/signup");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var entity = await Map.ToEntityAsync(r);
            var data = Data.Zc(_dbContext, entity, r.CAPTCHA);

            Response.Message = data;
            await SendAsync(Response);
        }
    }
}
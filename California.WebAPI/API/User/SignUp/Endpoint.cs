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

        public override Task HandleAsync(Request r, CancellationToken c)
        {

            if (Data.Zc(_dbContext, "qq@qq.com", "sa@123", null))
            {
                Response.Message = true;
            }
            else
            {
                Response.Message = false;
            }
            return SendAsync(Response);
        }
    }
}
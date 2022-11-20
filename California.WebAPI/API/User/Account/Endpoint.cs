namespace California.WebAPI.API.User.Account
{
    public class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public override void Configure()
        {
            Post("/account");
        }

        public override Task HandleAsync(Request r, CancellationToken c)
        {
            return SendAsync(Response);
        }
    }
}
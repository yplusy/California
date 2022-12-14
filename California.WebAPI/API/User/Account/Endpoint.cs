namespace API.User.Account
{
    public class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public override void Configure()
        {
            Get("/api/account");
            AllowAnonymous();
        }

        public override Task HandleAsync(Request r, CancellationToken c)
        {
            return SendAsync(Response);
        }
    }
}
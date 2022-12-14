namespace API.Email
{
    public class Endpoint : Endpoint<Request, Response, Mapper>
    {
        public override void Configure()
        {
            Post("/api/email");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            Data.SendEmail("321968991@qq.com");
            await SendAsync(Response);
        }
    }
}
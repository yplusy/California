namespace API.Email
{
    public class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Post("/api/email");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var data = Data.SendEmail(r.email);
            Response.Msg = data;
            await SendAsync(Response);
        }
    }
}
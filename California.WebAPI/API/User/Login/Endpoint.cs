using California.WebAPI.Entities;
using System.Security.Claims;

namespace API.User.Login
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
            Get("/api/login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var entity = await Map.ToEntityAsync(r);
            var data = _dbContext.Account.Where(p => p.AccountEmail == entity.AccountEmail && p.PasswordHash == entity.PasswordHash).FirstOrDefault();

            Response.TokenValue = JWTBearer.CreateToken(
                signingKey: Config["JwtSigningKey"],
                expireAt: DateTime.UtcNow.AddHours(1),
                claims: new[] { ("AccountEmail", entity.AccountEmail), ("AccountId", entity.AccountId) },
                roles: null,
                permissions: null);
            Response.TokenExpiryDate = DateTime.UtcNow.AddHours(4);
            Response.AccountEmail = entity.AccountEmail;
            await SendAsync(Response);
        }
    }
}
using California.WebAPI;
using California.WebAPI.Entities;

namespace API.User.Login
{
    public class Mapper : Mapper<Request, Response, AccountEntity>
    {
        public override async Task<AccountEntity> ToEntityAsync(Request r)
        {
            return new AccountEntity()
            {
                AccountId = r.AccountId,
                AccountEmail = r.AccountEmail,
                PasswordHash = r.PasswordHash,
            };
        }
        public override async Task<Response> FromEntityAsync(AccountEntity entity)
        {
            return new Response()
            {
                AccountEmail = entity.AccountEmail,
                TokenValue = JWTBearer.CreateToken(
                    signingKey: AppSettings.Configuration.GetSection("JwtSigningKey").Value, // Config["JwtSigningKey"]
                    expireAt: DateTime.Now.AddHours(1),
                    claims: new[] { ("AccountEmail", entity.AccountEmail), ("AccountId", entity.AccountId) },
                    roles: null,
                    permissions: null),
                TokenExpiryDate = DateTime.Now.AddHours(4),
                Msg = "登录成功",
            };
        }
    }
}
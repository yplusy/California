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
    }
}
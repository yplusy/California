using California.WebAPI.Entities;

namespace API.User.SignUp
{
    public class Mapper : Mapper<Request, Response, AccountEntity>
    {
        public override async Task<AccountEntity> ToEntityAsync(Request r)
        {
            return new AccountEntity()
            {
                AccountEmail = r.AccountEmail,
                PasswordHash = r.PasswordHash,
            };
        }
    }
}
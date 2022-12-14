using California.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace API.User.SignUp
{
    public static class Data
    {
        public static bool Zc(CaliforniaContext context, string Email, string PasswordHash, string yzm)
        {
            //using (var context = new CaliforniaContext())
            //{
            var Account = new AccountEntity
            {
                AccountId = Guid.NewGuid().ToString(),
                AccountEmail = Email,
                PasswordHash = PasswordHash,
            };
            context.Account.Add(Account);
            context.SaveChanges();
            //}

            //AccountEntity entity = new();
            //entity.AccountId = Guid.NewGuid().ToString();
            //entity.AccountEmail = Email;
            //AppSettings.dbContext.Account.Add(entity);
            //AppSettings.dbContext.SaveChangesAsync();
            return true;
        }
    }
}
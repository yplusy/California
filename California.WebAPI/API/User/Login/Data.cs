using California.WebAPI.Entities;

namespace API.User.Login
{
    public static class Data
    {
        public static AccountEntity Account(CaliforniaContext db, AccountEntity entity)
        {
            var data = db.Account.Where(p => p.AccountEmail == entity.AccountEmail && p.PasswordHash == entity.PasswordHash).FirstOrDefault();
            return data;
        }
    }
}
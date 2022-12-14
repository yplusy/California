using California.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace API.User.SignUp
{
    public static class Data
    {
        public static string Zc(CaliforniaContext db, AccountEntity entity, string CAPTCHA)
        {
            if (CAPTCHA == "123")
            {
                entity.AccountId = Guid.NewGuid().ToString();
                db.Account.Add(entity);
                try
                {
                    db.SaveChanges();
                    return "true";
                }
                catch (Exception)
                {
                    return "错误";
                    throw;
                }
            }
            else
            {
                return "验证码错误";
            }
        }
    }
}
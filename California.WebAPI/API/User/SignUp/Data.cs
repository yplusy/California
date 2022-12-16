using California.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace API.User.SignUp
{
    public static class Data
    {
        public static string Zc(CaliforniaContext db, AccountEntity entity, string CAPTCHA)
        {
            if (CAPTCHA == "string")
            {
                entity.AccountId = Guid.NewGuid().ToString();
                db.Account.Add(entity);
                try
                {
                    db.SaveChanges();
                    return "注册成功";
                }
                catch (Exception)
                {
                    return "注册出错";
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
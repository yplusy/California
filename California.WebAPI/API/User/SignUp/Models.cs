using California.WebAPI.Entities;

namespace API.User.SignUp
{
    public class Request : AccountEntity
    {
        public string AccountEmail { get; set; } // 账号
        public string PasswordHash { get; set; } // 密码
        public string CAPTCHA { get; set; } // 验证码
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {

        }
    }

    public class Response
    {
        public string Msg { get; set; }
    }
}
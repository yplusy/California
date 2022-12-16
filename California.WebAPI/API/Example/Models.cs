using FluentValidation;

namespace API.Example
{
    /// <summary>
    /// 请求体
    /// </summary>
    public class Request
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }

    /// <summary>
    /// 请求体验证
    /// </summary>
    public class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("用户名为空！");

            RuleFor(x => x.PasswordHash)
                .NotEmpty().WithMessage("密码为空！");
        }
    }

    /// <summary>
    /// 响应体
    /// </summary>
    public class Response
    {
        public string UserName { get; set; }
        public IEnumerable<string> UserPermissions { get; set; }
        public string TokenValue { get; set; }
        public DateTime TokenExpiryDate { get; set; }
    }
}
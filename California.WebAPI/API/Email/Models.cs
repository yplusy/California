using FluentValidation;

namespace API.Email
{
    public class Request
    {
        public string email { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(r => r.email)
            .NotEmpty().WithMessage("邮箱不能为空！")
            .EmailAddress().WithMessage("邮箱格式错误！");
        }
    }

    public class Response
    {
        public bool Message { get; set; }
    }
}
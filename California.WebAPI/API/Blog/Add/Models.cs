using FluentValidation;

namespace API.Blog.Add
{
    public class Request
    {
        public string? BlogTitle { get; set; } // 标题
        public string? BlogContext { get; set; } // 内容
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(r => r.BlogTitle)
            .NotEmpty().WithMessage("标题不能为空！");

            RuleFor(r => r.BlogContext)
                .NotEmpty().WithMessage("内容不能为空！");
        }
    }

    public class Response
    {
        public string Message { get; set; } // 消息
    }
}
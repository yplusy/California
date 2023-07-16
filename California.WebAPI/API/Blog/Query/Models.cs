using California.WebAPI.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Blog.Query
{
    public class Request
    {
        public string? BlogId { get; set; } // 博客id
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
        }
    }

    public class Response
    {
        public string BlogId { get; set; } // 博客id
        public string? BlogTitle { get; set; } // 标题
        public string? BlogContext { get; set; } // 内容
        public DateTime? CreateTime { get; set; } // 添加时间
    }
}
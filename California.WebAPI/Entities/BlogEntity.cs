using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace California.WebAPI.Entities
{
    [Table("Blog")]
    public class BlogEntity // 博客
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string BlogId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? BlogTitle { get; set; } // 标题

        [Column(TypeName = "varchar(max)")]
        public string? BlogContext { get; set; } // 内容

        [Column(TypeName = "datetime")]
        public DateTime? CreateTime { get; set; } // 添加时间
    }
}

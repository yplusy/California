using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace California.WebAPI.Entities
{
    [Table("Example")] //数据库表名
    public class ExampleEntity
    {
        [Key] //主键
        [Column(TypeName = "varchar(50)")] //数据库数据类型
        public string UserId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? UserName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? PasswordHash { get; set; }
    }
}

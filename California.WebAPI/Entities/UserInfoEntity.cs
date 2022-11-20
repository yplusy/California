using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace California.WebAPI.Entities
{
    [Table("Sys_User")]//数据库表名
    public class UserInfoEntity
    {
        [Key]//主键
        [Column(TypeName = "varchar(50)")]//数据库数据类型
        public string UserId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string UserName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Pwd { get; set; }
    }
}

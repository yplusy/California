using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace California.WebAPI.Entities
{
    [Table("Account")]
    public class AccountEntity
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string AccountId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? AccountEmail { get; set; } // 账号

        [Column(TypeName = "varchar(50)")]
        public string? PasswordHash { get; set; } // 密码
    }
}

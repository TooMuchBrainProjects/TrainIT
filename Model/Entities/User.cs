using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Model.Entities;

[Table("USERS")]
public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("USER_ID")]
    public int UserId { get; set; }
    
    [Required, StringLength(100)]
    [Column("NAME")]
    public string Name { get; set; }
    
    [Required, StringLength(100)]
    [Column("EMAIL")]
    public string Email { get; set; }
    
    [Required, StringLength(128)]
    [Column("PASSWORD")]
    public string Password { get; set; }
}
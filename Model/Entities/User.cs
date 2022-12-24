using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BC = BCrypt.Net.BCrypt;

namespace Model.Entities;

[Table("USERS")]
public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("USER_ID")]
    public int Id { get; set; }
    
    [Required, StringLength(100)]
    [Column("NAME")]
    public string Name { get; set; }
    
    [Required, StringLength(100)]
    [Column("EMAIL")]
    public string Email { get; set; }
    
    [Required]
    [NotMapped]
    [MinLength(8)]
    public string Password { get; set; }
    
    [Required]
    [Column("PASSWORD_HASHED", TypeName = "TEXT")]
    [MinLength(8)]
    public string PasswordHashed { get; set; }
    
    public User ClearSensitiveData() {
        //PasswordHash = null!;
        return this;
    }

    public static string HashPassword(string plainPassword) {
        var salt = BC.GenerateSalt(8);
        return BC.HashPassword(plainPassword, salt);
    }

    public static bool VerifyPassword(string plainPassword, string hashedPassword) {
        return BC.Verify(plainPassword, hashedPassword);
    }
}
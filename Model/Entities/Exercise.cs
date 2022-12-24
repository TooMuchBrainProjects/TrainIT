using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("EXERCISES")]
public class Exercise
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("EXERCISE_ID")]
    public int Id { get; set; }
    
    [Required, StringLength(100)]
    [Column("NAME")]
    public string Name { get; set; }
    
    [StringLength(100)]
    [Column("MACHINE")]
    public string Machine { get; set; }
    
    [DataType(DataType.Text)]
    [Column("DESCRIPTION")]
    public string Description { get; set; }

    [Required]
    [Column("USER_ID")]
    public int UserId { get; set; }
    public User User { get; set; }
    
    [NotMapped]
    public bool IsSelected { get; set; }
    
}
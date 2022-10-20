using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("EXCERSISES")]
public class Excercise
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("EXERCISE_ID")]
    public int Id { get; set; }
    
    [Required, StringLength(100)]
    [Column("NAME")]
    public string Name { get; set; }
    
    [Required, StringLength(100)]
    [Column("MACHINE")]
    public string Machine { get; set; }
    
    [Column("DESCRIPTION",TypeName = "LONGTEXT")]
    public string Description { get; set; }
    
    [Required]
    [Column("REPETITION")]
    public int Repetition { get; set; }
    
    [Required]
    [Column("SET")]
    public int Set { get; set; }
    
    //must be defined in fluent API
    [Required]
    [Column("USER_ID")]
    public int UserId { get; set; }
    
    public User User { get; set; }
    
}
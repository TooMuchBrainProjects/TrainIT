using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("DATES")]
public class Date
{
    [Key]
    [Column("VALUE")]
    public DateOnly DateValue { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("PRESETS")]
public class Preset
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("PRESET_ID")]
    public int PresetId { get; set; }
    
    [Required, StringLength(100)]
    [Column("NAME")] 
    public string Name { get; set; }
}
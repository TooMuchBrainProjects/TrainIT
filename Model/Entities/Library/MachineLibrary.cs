﻿namespace Model.Entities.Library;

public class MachineLibrary
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("MACHINE_LIBRARY_ID")]
    public int Id { get; set; }
    
    [Required, StringLength(100)]
    [Column("NAME")]
    public string Name { get; set; }
}
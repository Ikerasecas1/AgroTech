using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("sectors", Schema = "agronomy")]
public partial class Sector
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("greenhouse_id")]
    public int GreenhouseId { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("area")]
    [Precision(8, 2)]
    public decimal Area { get; set; }

    [Column("irrigation_type")]
    [StringLength(50)]
    public string IrrigationType { get; set; } = null!;

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("Sector")]
    public virtual ICollection<Crop> Crops { get; set; } = new List<Crop>();
}

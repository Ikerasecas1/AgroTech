using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("crops", Schema = "agronomy")]
public partial class Crop
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("sector_id")]
    public int SectorId { get; set; }

    [Column("crop_type")]
    [StringLength(50)]
    public string CropType { get; set; } = null!;

    [Column("variety")]
    [StringLength(100)]
    public string Variety { get; set; } = null!;

    [Column("planting_date")]
    public DateOnly PlantingDate { get; set; }

    [Column("status")]
    [StringLength(30)]
    public string Status { get; set; } = null!;

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("Crop")]
    public virtual ICollection<Incident> Incidents { get; set; } = new List<Incident>();

    [ForeignKey("SectorId")]
    [InverseProperty("Crops")]
    public virtual Sector Sector { get; set; } = null!;

    [InverseProperty("Crop")]
    public virtual ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
}

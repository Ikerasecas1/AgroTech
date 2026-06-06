using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("incidents", Schema = "agronomy")]
public partial class Incident
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("crop_id")]
    public int CropId { get; set; }

    [Column("description")]
    public string Description { get; set; } = null!;

    [Column("severity")]
    [StringLength(20)]
    public string Severity { get; set; } = null!;

    [Column("ai_diagnosis")]
    public string? AiDiagnosis { get; set; }

    [Column("detected_at")]
    public DateTime DetectedAt { get; set; }

    [Column("status")]
    [StringLength(30)]
    public string Status { get; set; } = null!;

    [ForeignKey("CropId")]
    [InverseProperty("Incidents")]
    public virtual Crop Crop { get; set; } = null!;

    [InverseProperty("Incident")]
    public virtual ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
}

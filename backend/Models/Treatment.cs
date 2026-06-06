using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("treatments", Schema = "agronomy")]
public partial class Treatment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("crop_id")]
    public int CropId { get; set; }

    [Column("incident_id")]
    public int? IncidentId { get; set; }

    [Column("treatment_name")]
    [StringLength(150)]
    public string TreatmentName { get; set; } = null!;

    [Column("product_type")]
    [StringLength(50)]
    public string ProductType { get; set; } = null!;

    [Column("dosage")]
    [StringLength(100)]
    public string Dosage { get; set; } = null!;

    [Column("safety_period_days")]
    public int SafetyPeriodDays { get; set; }

    [Column("application_date")]
    public DateTime ApplicationDate { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [ForeignKey("CropId")]
    [InverseProperty("Treatments")]
    public virtual Crop Crop { get; set; } = null!;

    [ForeignKey("IncidentId")]
    [InverseProperty("Treatments")]
    public virtual Incident? Incident { get; set; }
}

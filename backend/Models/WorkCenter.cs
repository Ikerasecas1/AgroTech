using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("work_centers", Schema = "operations")]
[Index("StaticQrIdentifier", Name = "uq_work_centers_qr", IsUnique = true)]
public partial class WorkCenter
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(150)]
    public string Name { get; set; } = null!;

    [Column("latitude")]
    [Precision(9, 6)]
    public decimal Latitude { get; set; }

    [Column("longitude")]
    [Precision(9, 6)]
    public decimal Longitude { get; set; }

    [Column("allowed_radius_meters")]
    public int AllowedRadiusMeters { get; set; }

    [Column("static_qr_identifier")]
    [StringLength(100)]
    public string StaticQrIdentifier { get; set; } = null!;

    [Column("is_active")]
    public bool IsActive { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("WorkCenter")]
    public virtual ICollection<QrToken> QrTokens { get; set; } = new List<QrToken>();

    [InverseProperty("WorkCenter")]
    public virtual ICollection<TimeRecord> TimeRecords { get; set; } = new List<TimeRecord>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("box_deliveries", Schema = "operations")]
public partial class BoxDelivery
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("worker_id")]
    public int WorkerId { get; set; }

    [Column("crew_id")]
    public int CrewId { get; set; }

    [Column("crop_id")]
    public int? CropId { get; set; }

    [Column("box_count")]
    public int BoxCount { get; set; }

    [Column("weight_kg")]
    [Precision(8, 2)]
    public decimal? WeightKg { get; set; }

    [Column("delivered_at")]
    public DateTime DeliveredAt { get; set; }

    [Column("aisle_location")]
    [StringLength(50)]
    public string? AisleLocation { get; set; }

    [Column("is_synced")]
    public bool IsSynced { get; set; }

    [Column("device_uuid")]
    [StringLength(100)]
    public string DeviceUuid { get; set; } = null!;

    [ForeignKey("CrewId")]
    [InverseProperty("BoxDeliveries")]
    public virtual Crew Crew { get; set; } = null!;

    [ForeignKey("CropId")]
    [InverseProperty("BoxDeliveries")]
    public virtual Crop? Crop { get; set; }

    [ForeignKey("WorkerId")]
    [InverseProperty("BoxDeliveries")]
    public virtual Worker Worker { get; set; } = null!;
}

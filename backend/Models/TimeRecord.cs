using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("time_records", Schema = "operations")]
public partial class TimeRecord
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("worker_id")]
    public int WorkerId { get; set; }

    [Column("crew_id")]
    public int CrewId { get; set; }

    [Column("work_center_id")]
    public int? WorkCenterId { get; set; }

    [Column("check_in")]
    public DateTime CheckIn { get; set; }

    [Column("check_out")]
    public DateTime? CheckOut { get; set; }

    [Column("record_date")]
    public DateOnly RecordDate { get; set; }

    [Column("latitude")]
    [Precision(9, 6)]
    public decimal? Latitude { get; set; }

    [Column("longitude")]
    [Precision(9, 6)]
    public decimal? Longitude { get; set; }

    [Column("qr_type")]
    [StringLength(20)]
    public string QrType { get; set; } = null!;

    [Column("validation_status")]
    [StringLength(20)]
    public string ValidationStatus { get; set; } = null!;

    [Column("is_synced")]
    public bool IsSynced { get; set; }

    [Column("synced_at")]
    public DateTime? SyncedAt { get; set; }

    [Column("device_uuid")]
    [StringLength(100)]
    public string DeviceUuid { get; set; } = null!;

    [ForeignKey("CrewId")]
    [InverseProperty("TimeRecords")]
    public virtual Crew Crew { get; set; } = null!;

    [ForeignKey("WorkCenterId")]
    [InverseProperty("TimeRecords")]
    public virtual WorkCenter? WorkCenter { get; set; }

    [ForeignKey("WorkerId")]
    [InverseProperty("TimeRecords")]
    public virtual Worker Worker { get; set; } = null!;
}

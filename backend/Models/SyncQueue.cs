using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("sync_queue", Schema = "system")]
public partial class SyncQueue
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("entity_type")]
    [StringLength(50)]
    public string EntityType { get; set; } = null!;

    [Column("entity_id")]
    public int EntityId { get; set; }

    [Column("payload", TypeName = "jsonb")]
    public string Payload { get; set; } = null!;

    [Column("status")]
    [StringLength(20)]
    public string Status { get; set; } = null!;

    [Column("attempts")]
    public int Attempts { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("last_attempt_at")]
    public DateTime? LastAttemptAt { get; set; }

    [Column("device_uuid")]
    [StringLength(100)]
    public string DeviceUuid { get; set; } = null!;
}

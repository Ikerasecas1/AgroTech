using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("qr_tokens", Schema = "operations")]
public partial class QrToken
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("work_center_id")]
    public int WorkCenterId { get; set; }

    [Column("generated_by_user_id")]
    public int GeneratedByUserId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("expires_at")]
    public DateTime ExpiresAt { get; set; }

    [ForeignKey("GeneratedByUserId")]
    [InverseProperty("QrTokens")]
    public virtual User GeneratedByUser { get; set; } = null!;

    [ForeignKey("WorkCenterId")]
    [InverseProperty("QrTokens")]
    public virtual WorkCenter WorkCenter { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("workers", Schema = "personnel")]
[Index("DocumentId", Name = "uq_workers_document", IsUnique = true)]
[Index("QrCode", Name = "uq_workers_qr", IsUnique = true)]
[Index("UserId", Name = "uq_workers_user", IsUnique = true)]
public partial class Worker
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("first_name")]
    [StringLength(100)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(100)]
    public string LastName { get; set; } = null!;

    [Column("document_id")]
    [StringLength(20)]
    public string DocumentId { get; set; } = null!;

    [Column("qr_code")]
    [StringLength(255)]
    public string QrCode { get; set; } = null!;

    [Column("phone")]
    [StringLength(20)]
    public string? Phone { get; set; }

    [Column("status")]
    [StringLength(20)]
    public string Status { get; set; } = null!;

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("Worker")]
    public virtual ICollection<CrewMember> CrewMembers { get; set; } = new List<CrewMember>();

    [InverseProperty("ForemanWorker")]
    public virtual ICollection<Crew> Crews { get; set; } = new List<Crew>();

    [InverseProperty("Worker")]
    public virtual ICollection<TimeRecord> TimeRecords { get; set; } = new List<TimeRecord>();

    [ForeignKey("UserId")]
    [InverseProperty("Worker")]
    public virtual User? User { get; set; }
}

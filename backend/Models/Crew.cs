using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("crews", Schema = "personnel")]
public partial class Crew
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("greenhouse_id")]
    public int GreenhouseId { get; set; }

    [Column("foreman_worker_id")]
    public int ForemanWorkerId { get; set; }

    [Column("status")]
    [StringLength(20)]
    public string Status { get; set; } = null!;

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("Crew")]
    public virtual ICollection<CrewMember> CrewMembers { get; set; } = new List<CrewMember>();

    [ForeignKey("ForemanWorkerId")]
    [InverseProperty("Crews")]
    public virtual Worker ForemanWorker { get; set; } = null!;

    [InverseProperty("Crew")]
    public virtual ICollection<TimeRecord> TimeRecords { get; set; } = new List<TimeRecord>();
}

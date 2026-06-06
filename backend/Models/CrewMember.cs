using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("crew_members", Schema = "personnel")]
[Index("CrewId", "WorkerId", Name = "uq_crew_worker", IsUnique = true)]
public partial class CrewMember
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("crew_id")]
    public int CrewId { get; set; }

    [Column("worker_id")]
    public int WorkerId { get; set; }

    [Column("assigned_at")]
    public DateTime? AssignedAt { get; set; }

    [ForeignKey("CrewId")]
    [InverseProperty("CrewMembers")]
    public virtual Crew Crew { get; set; } = null!;

    [ForeignKey("WorkerId")]
    [InverseProperty("CrewMembers")]
    public virtual Worker Worker { get; set; } = null!;
}

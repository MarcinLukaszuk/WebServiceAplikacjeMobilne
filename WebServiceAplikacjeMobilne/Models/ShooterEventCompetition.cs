using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServiceAplikacjeMobilne.Models
{


    public class ShooterEventCompetition
    {
        [Key]
        public int Id { get; set; }
        public int EventCompetitionId { get; set; }
        public int ShooterId { get; set; }

        [ForeignKey("ShooterId")]
        public virtual Shooter Shooter { get; set; }
        [ForeignKey("EventCompetitionId")]
        public virtual EventCompetition EventCompetition { get; set; }
    }
}
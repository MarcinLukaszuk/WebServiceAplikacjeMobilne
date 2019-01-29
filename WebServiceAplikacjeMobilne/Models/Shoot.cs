using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServiceAplikacjeMobilne.Models
{

    public class Shoot
    {
        [Key]
        public int Id { get; set; }
        public int ShooterEventCompetitionId { get; set; }
        public decimal Value { get; set; }
        [ForeignKey("ShooterEventCompetitionId")]
        public virtual ShooterEventCompetition ShooterEventCompetition { get; set; }
    }
}
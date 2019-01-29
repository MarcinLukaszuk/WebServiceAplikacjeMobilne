using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServiceAplikacjeMobilne.Models
{
    [Serializable]

    public class EventCompetition
    {
        [Key]
        public int Id { get; set; }       
        public int EventId { get; set; }
        public int CompetitionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }
        [ForeignKey("CompetitionId")]
        public virtual Competition Competition { get; set; }
    }
}
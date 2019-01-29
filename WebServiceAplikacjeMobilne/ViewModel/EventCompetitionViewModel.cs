using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServiceAplikacjeMobilne.Models
{
   

    public class EventCompetitionViewModel
    { 
        public int Id { get; set; }       
        public int EventId { get; set; }
        public string CompetitionName { get; set; }
        public int CompetitionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
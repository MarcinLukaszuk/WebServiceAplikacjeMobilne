using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServiceAplikacjeMobilne.Models
{
    

    public class ShooterEventCompetitionViewModel
    {
        public ShooterEventCompetitionViewModel()
        {
            Shoots = new List<Shoot>();
        }
        public int Id { get; set; }
        public int EventCompetitionId { get; set; }
        public int ShooterId { get; set; }

        public List<Shoot> Shoots { get; set; }
    }
}
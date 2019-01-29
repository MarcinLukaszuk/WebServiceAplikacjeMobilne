using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServiceAplikacjeMobilne.Models
{

    public class ShootViewModel
    { 
        public int Id { get; set; }
        public int ShooterEventCompetitionId { get; set; }
        public decimal Value { get; set; }  
    }
}
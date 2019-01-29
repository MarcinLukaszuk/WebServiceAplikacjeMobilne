using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebServiceAplikacjeMobilne.Models
{

    public class ShooterViewModel
    {
        public ShooterViewModel()
        {
            Shoots = new List<ShootViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public int? ShooterEventCompetitionId { get; set; }

        public List<ShootViewModel> Shoots { get; set; }
    }
}
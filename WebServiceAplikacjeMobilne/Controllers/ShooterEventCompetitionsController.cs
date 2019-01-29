using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebServiceAplikacjeMobilne.Models;

namespace WebServiceAplikacjeMobilne.Controllers
{
    public class ShooterEventCompetitionsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/ShooterEventCompetitions
        public List<ShooterEventCompetitionViewModel> GetShootersEventCompetition()
        {
            var tmpArray = AutoMapper.Mapper.Map<List<ShooterEventCompetitionViewModel>>(db.ShootersEventCompetition);



            return tmpArray;
        }

        // GET: api/ShooterEventCompetitions/5

        public IHttpActionResult GetShootersEventCompetition(int id)
        {
            var tmpArray =
                db.ShootersEventCompetition.Where(x => x.EventCompetitionId == id).Join(db.Shooters,
                shtmp => shtmp.ShooterId,
                shooter => shooter.Id,
                (shtmp, shooter) => new { shtmp = shtmp, shooter = shooter }).ToList();


            List<ShooterViewModel> shootersVM = new List<ShooterViewModel>();

            foreach (var item in tmpArray)
            {
                var shooterVMTmp = AutoMapper.Mapper.Map<ShooterViewModel>(item.shooter);
                shooterVMTmp.ShooterEventCompetitionId = item.shtmp.Id;
                shootersVM.Add(shooterVMTmp);
                shootersVM.FirstOrDefault(x => x.Id == item.shooter.Id).Shoots = AutoMapper.Mapper.Map<List<ShootViewModel>>(db.Shoots.Where(x => x.ShooterEventCompetitionId == item.shtmp.Id).ToList());
            }
            return Ok(new { shooters = shootersVM });
        }
        // PUT: api/ShooterEventCompetitions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShooterEventCompetition(int id, ShooterEventCompetition shooterEventCompetition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shooterEventCompetition.Id)
            {
                return BadRequest();
            }

            db.Entry(shooterEventCompetition).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShooterEventCompetitionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ShooterEventCompetitions
        [ResponseType(typeof(ShooterEventCompetition))]
        public IHttpActionResult PostShooterEventCompetition(ShooterEventCompetition shooterEventCompetition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ShootersEventCompetition.Add(shooterEventCompetition);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = shooterEventCompetition.Id }, shooterEventCompetition);
        }

        // DELETE: api/ShooterEventCompetitions/5
        [ResponseType(typeof(ShooterEventCompetition))]
        public IHttpActionResult DeleteShooterEventCompetition(int id)
        {
            ShooterEventCompetition shooterEventCompetition = db.ShootersEventCompetition.Find(id);
            if (shooterEventCompetition == null)
            {
                return NotFound();
            }

            db.ShootersEventCompetition.Remove(shooterEventCompetition);
            db.SaveChanges();

            return Ok(shooterEventCompetition);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShooterEventCompetitionExists(int id)
        {
            return db.ShootersEventCompetition.Count(e => e.Id == id) > 0;
        }
    }
}
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
    public class ShootersController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/Shooters
        public IQueryable<Shooter> GetShooters()
        {
            return db.Shooters;
        }

        // GET: api/Shooters/5
        [ResponseType(typeof(Shooter))]
        public IHttpActionResult GetShooter(int id)
        {
            Shooter shooter = db.Shooters.Find(id);
            if (shooter == null)
            {
                return NotFound();
            }

            return Ok(shooter);
        }

        // PUT: api/Shooters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShooter(int id, Shooter shooter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shooter.Id)
            {
                return BadRequest();
            }

            db.Entry(shooter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShooterExists(id))
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

        // POST: api/Shooters
        [ResponseType(typeof(Shooter))]
        public IHttpActionResult PostShooter(Shooter shooter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Shooters.Add(shooter);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = shooter.Id }, shooter);
        }

        // DELETE: api/Shooters/5
        [ResponseType(typeof(Shooter))]
        public IHttpActionResult DeleteShooter(int id)
        {
            Shooter shooter = db.Shooters.Find(id);
            if (shooter == null)
            {
                return NotFound();
            }

            db.Shooters.Remove(shooter);
            db.SaveChanges();

            return Ok(shooter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShooterExists(int id)
        {
            return db.Shooters.Count(e => e.Id == id) > 0;
        }
    }
}
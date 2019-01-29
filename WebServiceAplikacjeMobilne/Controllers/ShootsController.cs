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
    public class ShootsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/Shoots
        public IQueryable<Shoot> GetShoots()
        {
            return db.Shoots;
        }

        // GET: api/Shoots/5
        [ResponseType(typeof(List<ShootViewModel>))]
        public IHttpActionResult GetShoot(int id)
        {
            var shoots = db.Shoots.Where(x => x.ShooterEventCompetitionId == id).ToList();

            return Ok(new { shoots = AutoMapper.Mapper.Map<List<ShootViewModel>>(shoots) });
        }

        // PUT: api/Shoots/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShoot(int id, Shoot shoot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shoot.Id)
            {
                return BadRequest();
            }

            db.Entry(shoot).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShootExists(id))
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

        // POST: api/Shoots
        [ResponseType(typeof(Shoot))]
        public IHttpActionResult PostShoot(Shoot shoot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Shoots.Add(shoot);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = shoot.Id }, shoot);
        }

        // DELETE: api/Shoots/5
        [ResponseType(typeof(Shoot))]
        public IHttpActionResult DeleteShoot(int id)
        {
            Shoot shoot = db.Shoots.Find(id);
            if (shoot == null)
            {
                return NotFound();
            }

            db.Shoots.Remove(shoot);
            db.SaveChanges();

            return Ok(shoot);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShootExists(int id)
        {
            return db.Shoots.Count(e => e.Id == id) > 0;
        }
    }
}
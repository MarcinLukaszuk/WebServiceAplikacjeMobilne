using AutoMapper;
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
    public class EventCompetitionsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/EventCompetitions
        public List<EventCompetitionViewModel> GetEventsCompetition()
        {
            var tmp = Mapper.Map<List<EventCompetitionViewModel>>(db.EventsCompetition.ToList());
            return tmp;
        }

        // GET: api/EventCompetitions/5 
        public IHttpActionResult GetEventCompetition(int id)
        {
            List<EventCompetitionViewModel> eventCompetition = Mapper.Map<List<EventCompetitionViewModel>>(db.EventsCompetition.Where(x => x.EventId == id));
            var competitionNames = db.Competitions.ToList();

            foreach (var eventComp in eventCompetition)
            {
                eventComp.CompetitionName = competitionNames.First(x => x.Id == eventComp.CompetitionId)?.Name;
            }

            if (!eventCompetition.Any())
            {
                return null;
            }
            return Ok(new { competitions = eventCompetition }  );
        } 

        // PUT: api/EventCompetitions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventCompetition(int id, EventCompetition eventCompetition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventCompetition.Id)
            {
                return BadRequest();
            }

            db.Entry(eventCompetition).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventCompetitionExists(id))
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

        // POST: api/EventCompetitions
        [ResponseType(typeof(EventCompetition))]
        public IHttpActionResult PostEventCompetition(EventCompetition eventCompetition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventsCompetition.Add(eventCompetition);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eventCompetition.Id }, eventCompetition);
        }

        // DELETE: api/EventCompetitions/5
        [ResponseType(typeof(EventCompetition))]
        public IHttpActionResult DeleteEventCompetition(int id)
        {
            EventCompetition eventCompetition = db.EventsCompetition.Find(id);
            if (eventCompetition == null)
            {
                return NotFound();
            }

            db.EventsCompetition.Remove(eventCompetition);
            db.SaveChanges();

            return Ok(eventCompetition);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventCompetitionExists(int id)
        {
            return db.EventsCompetition.Count(e => e.Id == id) > 0;
        }
    }
}
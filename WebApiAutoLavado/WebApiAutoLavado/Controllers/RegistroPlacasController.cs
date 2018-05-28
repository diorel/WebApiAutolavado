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
using WebApiAutoLavado.Models;

namespace WebApiAutoLavado.Controllers
{
    public class RegistroPlacasController : ApiController
    {
        private AutoLavadoEntities db = new AutoLavadoEntities();

        // GET: api/RegistroPlacas
        public IQueryable<RegistroPlacas> GetRegistroPlacas()
        {
            return db.RegistroPlacas;
        }

        // GET: api/RegistroPlacas/5
        [ResponseType(typeof(RegistroPlacas))]
        public IHttpActionResult GetRegistroPlacas(int id)
        {
            RegistroPlacas registroPlacas = db.RegistroPlacas.Find(id);
            if (registroPlacas == null)
            {
                return NotFound();
            }

            return Ok(registroPlacas);
        }

        // PUT: api/RegistroPlacas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegistroPlacas(int id, RegistroPlacas registroPlacas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registroPlacas.IdRegistro)
            {
                return BadRequest();
            }

            db.Entry(registroPlacas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroPlacasExists(id))
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

        // POST: api/RegistroPlacas
        [ResponseType(typeof(RegistroPlacas))]
        public IHttpActionResult PostRegistroPlacas(RegistroPlacas registroPlacas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RegistroPlacas.Add(registroPlacas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = registroPlacas.IdRegistro }, registroPlacas);
        }

        // DELETE: api/RegistroPlacas/5
        [ResponseType(typeof(RegistroPlacas))]
        public IHttpActionResult DeleteRegistroPlacas(int id)
        {
            RegistroPlacas registroPlacas = db.RegistroPlacas.Find(id);
            if (registroPlacas == null)
            {
                return NotFound();
            }

            db.RegistroPlacas.Remove(registroPlacas);
            db.SaveChanges();

            return Ok(registroPlacas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegistroPlacasExists(int id)
        {
            return db.RegistroPlacas.Count(e => e.IdRegistro == id) > 0;
        }
    }
}
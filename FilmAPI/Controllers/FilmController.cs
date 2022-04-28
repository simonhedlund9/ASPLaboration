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
using System.Web.UI.WebControls;
using FilmAPI;

namespace FilmAPI.Controllers
{
    public class FilmController : ApiController
    {
        private FilmModell db = new FilmModell();

        
        public IQueryable<Film> GetFilms()
        {
            try
            {
                return db.Films;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        
        [ResponseType(typeof(Film))]
        public IHttpActionResult GetFilm(int id)
        {
            try
            {
                Film film = db.Films.Find(id);
                if (film == null)
                {
                    return NotFound();
                }

                return Ok(film);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFilm(int id, Film film)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != film.Id)
                {
                    return BadRequest();
                }

                db.Entry(film).State = EntityState.Modified;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
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

        
        [ResponseType(typeof(Film))]
        public IHttpActionResult PostFilm(Film film)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.Films.Add(film);
                db.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = film.Id }, film);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        
        [ResponseType(typeof(Film))]
        public IHttpActionResult DeleteFilm(int id)
        {
            try
            {
                Film film = db.Films.Find(id);
                if (film == null)
                {
                    return NotFound();
                }

                db.Films.Remove(film);
                db.SaveChanges();

                return Ok(film);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
        }

        private bool FilmExists(int id)
        {
          return db.Films.Count(e => e.Id == id) > 0; 
        }
    }
}
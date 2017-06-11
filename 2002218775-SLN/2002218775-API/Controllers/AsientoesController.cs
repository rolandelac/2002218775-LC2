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
using _2002218775_API.DTO;
using _2002218775_ENT;
using _2002218775_ENT.IRepositories;
using _2002218775_PER;
using AutoMapper;

namespace _2002218775_API.Controllers
{
    public class AsientoesController : ApiController
    {
        //private _2002218775DbContext db = new _2002218775DbContext();

        private readonly IUnityOfWork _UnityOfWork;

        public AsientoesController()
        {

        }

        public AsientoesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }


        // GET: api/Asientoes
        //public IQueryable<Asiento> GetAsientos()
        //{
        //    return db.Asientos;
        //}


        [HttpGet]
        public IHttpActionResult Get()
        {
            //La capa de persistencia no debe ser modificada, porque es única para todo canal de atencion de la aplicacion
            //por lo tanto, a nivel de controlador se debe de hacer las modificaciones.
            var Asientos = _UnityOfWork.Asientos.GetAll();

            if (Asientos == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var AsientoDto = new List<AsientosDto>();

            foreach (var asiento in Asientos)
                AsientoDto.Add(Mapper.Map<Asiento, AsientosDto>(asiento));

            return Ok(AsientoDto);
        }


        // GET: api/Asientoes/5
        //[ResponseType(typeof(Asiento))]
        //public IHttpActionResult GetAsiento(int id)
        //{
        //    Asiento asiento = db.Asientos.Find(id);
        //    if (asiento == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(asiento);
        //}


        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var asiento = _UnityOfWork.Asientos.Get(id);

            if (asiento == null)
                return NotFound();

            return Ok(Mapper.Map<Asiento, AsientosDto>(asiento));
        }


        // PUT: api/Asientoes/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutAsiento(int id, Asiento asiento)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != asiento.AsientoId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(asiento).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AsientoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}



        [HttpPut]
        public IHttpActionResult Update(int id, AsientosDto asientoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var asientoInPersistence = _UnityOfWork.Asientos.Get(id);
            if (asientoInPersistence == null)
                return NotFound();

            Mapper.Map<AsientosDto, Asiento>(asientoDto, asientoInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(asientoDto);
        }
        // POST: api/Asientoes
        //[ResponseType(typeof(Asiento))]
        //public IHttpActionResult PostAsiento(Asiento asiento)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Asientos.Add(asiento);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = asiento.AsientoId }, asiento);
        //}

        [HttpPost]
        public IHttpActionResult Create(AsientosDto asientoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var asiento = Mapper.Map<AsientosDto, Asiento>(asientoDto);

            _UnityOfWork.Asientos.Add(asiento);
            _UnityOfWork.SaveChanges();

            asientoDto.AsientoId = asiento.AsientoId;

            return Created(new Uri(Request.RequestUri + "/" + asiento.AsientoId), asientoDto);
        }

        // DELETE: api/Asientoes/5
        //[ResponseType(typeof(Asiento))]
        //public IHttpActionResult DeleteAsiento(int id)
        //{
        //    Asiento asiento = db.Asientos.Find(id);
        //    if (asiento == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Asientos.Remove(asiento);
        //    db.SaveChanges();

        //    return Ok(asiento);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var asientoInDataBase = _UnityOfWork.Asientos.Get(id);
            if (asientoInDataBase == null)
                return NotFound();

            _UnityOfWork.Asientos.Delete(asientoInDataBase);
            _UnityOfWork.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool AsientoExists(int id)
        //{
        //    return db.Asientos.Count(e => e.AsientoId == id) > 0;
        //}
    }
}
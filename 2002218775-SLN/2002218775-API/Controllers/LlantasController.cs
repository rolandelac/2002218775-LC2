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
    public class LlantasController : ApiController
    {
        //private _2002218775DbContext db = new _2002218775DbContext();

        private readonly IUnityOfWork _UnityOfWork;

        public LlantasController()
        {

        }

        public LlantasController(IUnityOfWork unityOfWork)
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
            var Llantas = _UnityOfWork.Llantas.GetAll();

            if (Llantas == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var LlantaDto = new List<LlantasDto>();

            foreach (var llanta in Llantas)
                LlantaDto.Add(Mapper.Map<Llanta, LlantasDto>(llanta));

            return Ok(LlantaDto);
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
            var llanta = _UnityOfWork.Llantas.Get(id);

            if (llanta == null)
                return NotFound();

            return Ok(Mapper.Map<Llanta, LlantasDto>(llanta));
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
        public IHttpActionResult Update(int id, LlantasDto llantaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var llantaInPersistence = _UnityOfWork.Llantas.Get(id);
            if (llantaInPersistence == null)
                return NotFound();

            Mapper.Map<LlantasDto, Llanta>(llantaDto, llantaInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(llantaDto);
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
        public IHttpActionResult Create(LlantasDto llantaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var llanta = Mapper.Map<LlantasDto, Llanta>(llantaDto);

            _UnityOfWork.Llantas.Add(llanta);
            _UnityOfWork.SaveChanges();

            llantaDto.LlantaId = llanta.LlantaId;

            return Created(new Uri(Request.RequestUri + "/" + llanta.LlantaId), llantaDto);
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

            var llantaInDataBase = _UnityOfWork.Llantas.Get(id);
            if (llantaInDataBase == null)
                return NotFound();

            _UnityOfWork.Llantas.Delete(llantaInDataBase);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiAnimales.context;
using apiAnimales.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiAnimales.Controllers
{
    [Route("api/[controller]")]
    public class AnimalesController : Controller
    {

        // Se llama el context. Debe usarase el paquete apiAnimales.context;
        private readonly AppDbContext context;

        // Se define el constructor
        public AnimalesController(AppDbContext context)
        {
            this.context = context;
        }
    

        // Se crean los metodos de la API -> las peticiones HTTP

        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()    // Para obtener todo el listado
        {
            try
            {
                return Ok(context.animales.ToList());
            }catch(Exception ex)
            {
                return (BadRequest(ex.Message));   // Mensaje de error para cuando no es exitosa la peticion
            }
        }

        // GET api/<controller>/5        // Peticion para obtener id
        [HttpGet("{id}", Name = "GetAnimal")] // Se definio un nombre para este get, ya que sera reutilizado
        public ActionResult Get(int id)
        {
            try 
            {
                var animal = context.animales.FirstOrDefault(f => f.id == id);
                return Ok(animal);
            }catch (Exception ex)
            {
                return (BadRequest(ex.Message));
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Animales animal) // Del modelo 
        {
            try
            {
                context.animales.Add(animal);
                context.SaveChanges();
                return CreatedAtRoute("GetAnimal", new { id = animal.id}, animal);
            }
            catch (Exception ex)
            {
                return (BadRequest(ex.Message));
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Animales animal)
        {
            try
            {
                if (animal.id == id)
                {
                    context.Entry(animal).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetAnimal", new { id = animal.id }, animal);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return (BadRequest(ex.Message));

            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var animal = context.animales.FirstOrDefault(f => f.id == id);
                if (animal != null)
                {
                    context.animales.Remove(animal);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return (BadRequest(ex.Message));

            }
        }
    }
}

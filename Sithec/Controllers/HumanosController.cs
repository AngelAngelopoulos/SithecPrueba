/**
* @file HumanosController.cs
* @brief Controlador de la API de Humanos
*/
using System.Collections.Generic;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sithec.Data;
using Sithec.Models;
using Sithec.Services;

/**
* @class HumanosController
* @brief Controlador de la API de Humanos
*/
namespace Sithec.Controllers
{
    [ApiController]
    [Route("humanos/")]
    public class HumanosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly OperationService _operationService = new OperationService();


        /**
         * @brief Constructor de HumanosController
         * @param context Contexto de la aplicación
         */
        public HumanosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/humanos/mocked/
        /**
        * @brief Devuelve una lista de humanos mockeados
        * @return Lista de objetos de la clase Humano
        */
        [HttpGet("mocked/")]
        public ActionResult<IEnumerable<Humano>> GetMockedHumanos()
        {
            return DatosMock.GetHumanos();
        }

        // GET: api/humanos/
        /**
        * @brief Devuelve una lista con todos los humanos
        * @return Lista de objetos de la clase Humano
        */
        [HttpGet]
        public async Task<ActionResult<IList<Humano>>> GetAllHumanos()
        {
            try
            {
                List<Humano> humanos = await this._context.Humanos.ToListAsync();

                return Ok(humanos);
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return StatusCode(500);
            }
        }

        // GET: api/humanos/1/
        /**
        * @brief Devuelve un objeto Humano por su ID
        * @param id ID del objeto Humano a devolver
        * @return Objeto de la clase Humano correspondiente al ID dado
        */
        [HttpGet("{id}")]
        public async Task<ActionResult<Humano>> GetHumanoById(int id)
        {
            try {
                var humano = await _context.Humanos.FindAsync(id);

                if (humano == null)
                {
                    return NotFound();
                }

                return Ok(humano);
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return StatusCode(500);
            }
        }

        // POST: api/humanos/create
        /**
        * @brief Crea un objeto Humano
        * @param humano Objeto Humano a crear
        * @return Objeto de la clase Humano creado
        */
        [HttpPost("create/")]
        public async Task<ActionResult<Humano>> CreateHumano([FromBody] Humano humano)
        {
            try
            {
                var createdHumano = await _context.Humanos.AddAsync(humano);

                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetHumanoById), new { id = humano.Id }, humano);
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return StatusCode(500);
            }

        }

        // PUT: api/humanos/edit/1/
        /**
        * @brief Actualiza un objeto Humano por su ID
        * @param id ID del objeto Humano a actualizar
        * @param humano Objeto Humano actualizado
        * @return Objeto de la clase Humano actualizado
        */
        [HttpPut("edit/{id}")]
        public async Task<ActionResult<Humano>> UpdateHumanoById(int id, [FromBody] Humano humano)
        {
            try
            {
                if (humano != null && id == humano.Id)
                {
                    var humanoExists = await _context.Humanos.FindAsync(id);

                    if (humanoExists == null)
                    {
                        return NotFound();
                    }

                    _context.Entry(humanoExists).CurrentValues.SetValues(humanoExists);
                    await _context.SaveChangesAsync();

                    return Ok(new { success = true });
                }
                return BadRequest();
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
                return StatusCode(500);
            }
        }
    } 
}
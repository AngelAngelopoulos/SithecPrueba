using System;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Sithec.Data;
using Sithec.Services;

namespace Sithec.Controllers
{
    [ApiController]
    [Route("operacion/")]
    public class OperationsController : ControllerBase
	{
        private readonly OperationService _operationService;

        public OperationsController()
		{
            this._operationService = new OperationService();
        }

        // POST: api/operacion/
        /**
        * @brief Crea una nueva operacion
        * @param Operacion Objeto Operacion a crear
        * @return Resultado de la operacion
        */
        [HttpPost]
        public IActionResult MakeOperation([FromBody] Operacion operacion)
        {
            try
            {
                double result = _operationService.SolveOperation(operacion);
                return Ok(new { result });
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return BadRequest(new { message = error.Message });
                //return StatusCode(500);
            }
        }

       // GET: api/Humanos/operacion? operando1 = 2 & operando2 = 3 & tipo = suma
        public IActionResult RealizarOperacionConHeaders([FromHeader(Name = "operando1")] double operando1, [FromHeader(Name = "operando2")] double operando2, [FromHeader(Name = "tipo")] string tipo)
        {
            try
            {
                Operacion operacion = new Operacion
                {
                    Tipo = tipo,
                    Operando1 = operando1,
                    Operando2 = operando2
                };
                double result = _operationService.SolveOperation(operacion);
                return Ok(new { result });
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return BadRequest(new { message = error.Message });
                //return StatusCode(500);
            }
        }
    }
}


using Localiza.Diogo.Modelo;
using Localiza.Diogo.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Localiza.Diogo.ApiGat
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NumeroController : ControllerBase
    {
        IFatorar fatService;
        public NumeroController(IFatorar _fatService)
        {
            fatService = _fatService;
        }

        // POST api/<NumeroController>
        [HttpPost]
        [Route("fatorar")]
        public IActionResult Post([FromBody] int numeroEntrada)
        {
            var resultado = fatService.fatorar(numeroEntrada);
            return Ok(resultado);
        }


    }
}

﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIAutores.Entidades;

namespace WebAPIAutores.Controllers
{
 
    /* Heredamos de Controller Base y tbn importamos */
    [ApiController] /* Con este atributo indicamos que la clase es un controlador de API y habilita su comportamiento especifico. */
    [Route("api/autores")] /* Este atributo establece la ruta base para las acciones dentro del controlador. Los [] en autores indica que es una variable que se va a reemplazar con un valor real.*/
    public class AutoresController: ControllerBase /* Hereda de ControllBase para poder usar sus funcionalidades y metodos GET. */
    {
        private readonly ApplicationDbContext context;
        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet] /* Se define el método */
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await context.Autores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}

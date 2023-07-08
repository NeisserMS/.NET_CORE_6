using Biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    /* Heredamos de Controller Base y tbn importamos */
    [ApiController] /* Con este atributo indicamos que la clase es un controlador de API y habilita su comportamiento especifico. */
    [Route("api/[autores]")] /* Este atributo establece la ruta base para las acciones dentro del controlador. Los [] en autores indica que es una variable que se va a reemplazar con un valor real.*/
    public class AutoresController: ControllerBase /* Hereda de ControllBase para poder usar sus funcionalidades y metodos GET. */
    {
        [HttpGet] /* Se define el método */
        public ActionResult <List<Autor>> Get()
        {
            return new List<Autor>()
            {
                new Autor() { id = 1, nombre = "Jair" },
                new Autor() { id = 2, nombre = "Neisser" },
            };
        }
    }
}

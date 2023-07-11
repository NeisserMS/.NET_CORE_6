using System.Collections.Generic;

namespace WebAPIAutores.Entidades
{
    public class Autor
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public List<Libro> libros { get; set; } // Permite cargar los libros del autor.
    }
}

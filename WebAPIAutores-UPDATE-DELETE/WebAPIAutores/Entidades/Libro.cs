namespace WebAPIAutores.Entidades
{
    public class Libro
    {
        public int id { get; set; }
        public string titulo {  get; set; } 
        public int autorId { get; set; }
        public Autor Autor { get; set; } // Es una propiedad de navegación para poder obtener la data, es decir, obtener que autor ha escrito dicho libro (se relaciona).
    }
}

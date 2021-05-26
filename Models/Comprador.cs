namespace Practica3.Models
{
    public class Comprador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Celular { get; set; }
        public string Lugar { get; set; }

        public string Foto { get; set; }
        public string Precio { get; set; }


        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}
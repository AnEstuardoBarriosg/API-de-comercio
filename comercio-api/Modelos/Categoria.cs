namespace comercio_api.Modelos;


public class Categoria
{
    // Creamos las propiedades
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty; // Cuando sale del constructor, el nombre es una cadena vacía
    public bool Activo { get; set; }
    public string DatoPrivado { get; set; } = string.Empty; // Este dato no se mostrará en la respuesta de la API


}

namespace comercio_api.DTOs.Categorías;
// ESTO ES LO QUE EL CLIENTE PUEDE VER, es decir, lo que se le va a enviar al cliente cuando se le solicite la información de una categoría. Este DTO (Data Transfer Object) se utiliza para definir la estructura de los datos que se enviarán al cliente, y puede contener solo las propiedades necesarias para esa operación específica, en este caso, el nombre y el estado activo de la categoría.
public class CrearCategoriaDto
{
    public string Nombre { get; set; } = string.Empty;
    public bool Activo { get; set; }
}
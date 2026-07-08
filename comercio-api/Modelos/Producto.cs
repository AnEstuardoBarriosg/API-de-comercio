namespace comercio_api.Modelos;

// ENTIDADES QUE CORRESPONDERN A LA BASE DE DATOS Y QUE SE USARAN PARA LAS OPERACIONES DE LA API van en MODELOS, estas entidades se mapearan a las tablas de la base de datos y se usaran para las operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en la API. Estas entidades pueden tener propiedades adicionales que no necesariamente se mapean a la base de datos, como propiedades calculadas o propiedades de navegación para relaciones entre entidades.
public class Producto
{
    // PROPIEDADES CREADAS 
    public int Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public decimal PrecioUnitario { get; set; }
    public decimal CostoProducto { get; set; }
    public int Stock { get; set; }
    public bool Activo { get; set; } = true;
    public int CategoriaId { get; set; }
    public int ProveedorId { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
}

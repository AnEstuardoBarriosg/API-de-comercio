namespace comercio_api.DTOs.Productos;

public class ActualizarProductoDto
{
    public string Nombre { get; set; } = string.Empty;
    public decimal PrecioUnitario { get; set; }
    public decimal CostoProducto { get; set; }
    public int Stock { get; set; }
    public bool Activo { get; set; }
}
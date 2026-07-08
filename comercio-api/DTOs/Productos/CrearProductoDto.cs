namespace comercio_api.DTOs.Productos;

public class CrearProductoDto
{
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public decimal PrecioUnitario { get; set; }
    public decimal CostoProducto { get; set; }
    public int Stock { get; set; }
    public int CategoriaId { get; set; }
    public int ProveedorId { get; set; }
}
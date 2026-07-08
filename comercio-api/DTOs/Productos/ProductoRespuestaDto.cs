namespace comercio_api.DTOs.Productos;

public class ProductoRespuestaDto
{
    public int Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public decimal PrecioUnitario { get; set; }
    public int Stock { get; set; }
    public bool Activo { get; set; }
    public int CategoriaId { get; set; }
}
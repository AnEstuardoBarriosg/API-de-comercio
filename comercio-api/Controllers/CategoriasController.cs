using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using comercio_api.Controllers;
using comercio_api.DTOs.Categorías;
using comercio_api.Modelos;
using System.Data.Common;
using System.Runtime.CompilerServices;


namespace comercio_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriasController : ControllerBase
    {
        private static List<Categoria> _categorias = new()
        {
            new Categoria { Id = 1, Nombre = "Electronica", Activo = true , DatoPrivado = "Mi dato privado 1" },
            new Categoria { Id = 2, Nombre = "Ropa", Activo = true , DatoPrivado = "Mi dato privado 2" },
            new Categoria { Id = 3, Nombre = "Hogar", Activo = true , DatoPrivado = "Mi dato privado 3" }
        };

        // COMENZAMOS A DEFINIR NUESTROS METODOS = ENDPOINTS

        [HttpGet]
        [ProducesResponseType(typeof(List<CategoriaRespuestaDto>), StatusCodes.Status200OK)]
        public IActionResult ObtenerTodos()
        {
            var resultado = _categorias.Select(item => new CategoriaRespuestaDto
            {
                Id = item.Id,
                Nombre = item.Nombre,
                Activo = item.Activo,
            }).ToList();
            return Ok(resultado);
        }


    // GET /api/Categoria
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(CategoriaRespuestaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CategoriaRespuestaDto), StatusCodes.Status404NotFound)]
        public IActionResult ObtenerPorId(int id)
        {
            var categoria = _categorias.FirstOrDefault(item => item.Id == id);

            if (categoria == null)
            {
                // definimos un objeto anonimo usando "new"
                return NotFound(new
                {
                    Error = $"Categoria #{id} no encontrado"
                });
            }

            var resultado = new CategoriaRespuestaDto
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                Activo = categoria.Activo
            };

            return Ok(resultado);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CategoriaRespuestaDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Crear([FromBody] CrearCategoriaDto crearCategoriaDto)
        {
            if (crearCategoriaDto == null)
            {
                return BadRequest(new
                {
                    mensaje = "Los datos de la categoría son obligatorios."
                });
            }

            if (string.IsNullOrWhiteSpace(crearCategoriaDto.Nombre))
            {
                return BadRequest(new
                {
                    mensaje = "El nombre de la categoría es obligatorio."
                });
            }

            var nombreNormalizado = crearCategoriaDto.Nombre.Trim();

            var existe = _categorias.Any(item =>
                item.Nombre.Equals(nombreNormalizado, StringComparison.OrdinalIgnoreCase)
            );

            if (existe)
            {
                return Conflict(new
                {
                    mensaje = $"Ya existe una categoría con el nombre '{nombreNormalizado}'."
                });
            }

            var nuevoId = _categorias.Any()
                ? _categorias.Max(item => item.Id) + 1
                : 1;

            var nuevaCategoria = new Categoria
            {
                Id = nuevoId,
                Nombre = nombreNormalizado,
                Activo = crearCategoriaDto.Activo,
                DatoPrivado = "Dato privado generado"
            };

            _categorias.Add(nuevaCategoria);

            var respuesta = new CategoriaRespuestaDto
            {
                Id = nuevaCategoria.Id,
                Nombre = nuevaCategoria.Nombre,
                Activo = nuevaCategoria.Activo
            };

            return CreatedAtAction(nameof(ObtenerPorId), new { id = respuesta.Id }, respuesta);
        }

        // Ejemplo del ingeniero
        /*
        [HttpPost]
        public IActionResult Crear{[FromBody] CrearCategoriaDto dto}
        {
            bool existe = _categoria.Any(item => item.Nombre.Equals{dto.Nombre, StringComparasion.OrdinalIgnoreCase})
        );

        if (existe)
        {
            return Conflict(new
            {
                Error = $"Ya existe unac ategoría con el nombre '{dto.Nombre}'"
            });
        }

        var nuevaCategoria = new Categoria
        {
            Id = _categoria.Count +1,
            Nombre = dto.Nombre,
            Activo = true
        };

        _categoria.Add(nuevaCategoria);

        var respuesta = new CategoriaRespuestaDto
        {
            Id = nuevaCategoria.Id,
            Nombre = nuevaCategoria.Nombre
            Activo = nuevaCategoria.Activo
        };

        return CreatedAtAction(nameof(ObtenerPorId), new{Id = nuevaCategoria.Id}, respuesta);

        }
    }

        */

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Actualizar(int id, [FromBody] ActualizarCategoriaDto actualizarCategoriaDto)
        {
            if (string.IsNullOrWhiteSpace(actualizarCategoriaDto.Nombre))
            {
                return BadRequest(new
                {
                    mensaje = "El nombre de la categoría es obligatorio."
                });
            }

            var categoria = _categorias.FirstOrDefault(item => item.Id == id);

            if (categoria == null)
            {
                return NotFound(new
                {
                    mensaje = "La categoría no fue encontrada."
                });
            }

            categoria.Nombre = actualizarCategoriaDto.Nombre;
            categoria.Activo = actualizarCategoriaDto.Activo;

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Eliminar(int id)
        {
            var categoria = _categorias.FirstOrDefault(item => item.Id == id);

            if (categoria == null)
            {
                return NotFound(new
                {
                    mensaje = "La categoría no fue encontrada."
                });
            }

            _categorias.Remove(categoria);

            return NoContent();
        }
    }
}
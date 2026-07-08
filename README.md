# Comercio API

API REST desarrollada con ASP.NET Core para la gestión básica de categorías y productos dentro de un sistema de comercio.

Este proyecto fue creado como práctica para reforzar conceptos de desarrollo backend, estructura de controladores, uso de DTOs, validaciones básicas y documentación de endpoints mediante Swagger.

## Tecnologías utilizadas

- C#
- ASP.NET Core Web API
- Swagger / OpenAPI
- .NET
- Visual Studio Code
- Git y GitHub

## Funcionalidades actuales

### Categorías

Actualmente el módulo de categorías permite:

- Consultar todas las categorías
- Consultar una categoría por ID
- Crear una nueva categoría
- Actualizar una categoría existente
- Eliminar o desactivar una categoría
- Validar campos obligatorios
- Evitar registros duplicados

### Productos

El módulo de productos se encuentra en desarrollo.  
Actualmente el proyecto ya cuenta con los modelos y DTOs base para productos.

## Estructura del proyecto

```txt
comercio-api/
├── Controllers/
│   └── CategoriasController.cs
│
├── DTOs/
│   ├── Categorías/
│   │   ├── CrearCategoriaDto.cs
│   │   ├── ActualizarCategoriaDto.cs
│   │   └── CategoriaRespuestaDto.cs
│   │
│   └── Productos/
│       ├── CrearProductoDto.cs
│       ├── ActualizarProductoDto.cs
│       └── ProductoRespuestaDto.cs
│
├── Modelos/
│   ├── Categoria.cs
│   └── Producto.cs
│
├── Program.cs
├── appsettings.json
└── appsettings.Development.json

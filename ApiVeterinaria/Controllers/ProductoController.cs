using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiFarmacia.Helpers;
using ApiVeterinaria.Helpers;

namespace ApiVeterinaria.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class ProductoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public ProductoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<Producto>>> Get0([FromQuery]Params productoParams)
    {
        var producto = await unitofwork.Productos.GetAllAsync(productoParams.PageIndex,productoParams.PageSize, productoParams.Search);
        var listaProductos = mapper.Map<List<Producto>>(producto.registros);
        return new Pager<Producto>(listaProductos, producto.totalRegistros,productoParams.PageIndex,productoParams.PageSize,productoParams.Search);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<Producto>>> Get([FromQuery]Params productoParams)
    {
        var producto = await unitofwork.Productos.GetAllAsync(productoParams.PageIndex,productoParams.PageSize, productoParams.Search);
        var listaProductos = mapper.Map<List<Producto>>(producto.registros);
        return new Pager<Producto>(listaProductos, producto.totalRegistros,productoParams.PageIndex,productoParams.PageSize,productoParams.Search);
    }

    [HttpGet("{id}")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Producto>> Get(int id)
    {
        var producto = await unitofwork.Productos.GetByIdAsync(id);
        return mapper.Map<Producto>(producto);
    }

    [HttpPost]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Producto>> Post(Producto productoDto)
    {
        var roducto = this.mapper.Map<Producto>(productoDto);
        this.unitofwork.Productos.Add(roducto);
        await unitofwork.SaveAsync();
        if (roducto == null){
            return BadRequest();
        }
        productoDto.Id = roducto.Id;
        return CreatedAtAction(nameof(Post), new { id = productoDto.Id }, productoDto);
    }

    [HttpPut]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Producto>> Put (int id, [FromBody]Producto productoDto)
    {
        if(productoDto == null)
            return NotFound();

        var producto = this.mapper.Map<Producto>(productoDto);
        unitofwork.Productos.Update(producto);
        await unitofwork.SaveAsync();
        return productoDto;     
    }

    [HttpDelete("{id}")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var producto = await unitofwork.Productos.GetByIdAsync(id);

        if (producto == null)
        {
            return Notfound();
        }

        unitofwork.Productos.Remove(producto);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
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
[Authorize (Roles= "Administrador")]    

public class MovimientoProductoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public MovimientoProductoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<MovimientoProducto>>> Get0([FromQuery]Params movimientoProductoParams)
    {
        var movimientoProducto = await unitofwork.MovimientosProductos.GetAllAsync(movimientoProductoParams.PageIndex,movimientoProductoParams.PageSize, movimientoProductoParams.Search);
        var listaMovimientosProductos = mapper.Map<List<MovimientoProducto>>(movimientoProducto.registros);
        return new Pager<MovimientoProducto>(listaMovimientosProductos, movimientoProducto.totalRegistros,movimientoProductoParams.PageIndex,movimientoProductoParams.PageSize,movimientoProductoParams.Search);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<MovimientoProducto>>> Get([FromQuery]Params movimientoProductoParams)
    {
        var movimientoProducto = await unitofwork.MovimientosProductos.GetAllAsync(movimientoProductoParams.PageIndex,movimientoProductoParams.PageSize, movimientoProductoParams.Search);
        var listaMovimientosProductos = mapper.Map<List<MovimientoProducto>>(movimientoProducto.registros);
        return new Pager<MovimientoProducto>(listaMovimientosProductos, movimientoProducto.totalRegistros,movimientoProductoParams.PageIndex,movimientoProductoParams.PageSize,movimientoProductoParams.Search);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MovimientoProducto>> Get(int id)
    {
        var movimientoProducto = await unitofwork.MovimientosProductos.GetByIdAsync(id);
        return mapper.Map<MovimientoProducto>(movimientoProducto);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MovimientoProducto>> Post(MovimientoProducto movimientoProductoDto)
    {
        var movimientoProducto = this.mapper.Map<MovimientoProducto>(movimientoProductoDto);
        this.unitofwork.MovimientosProductos.Add(movimientoProducto);
        await unitofwork.SaveAsync();
        if (movimientoProducto == null){
            return BadRequest();
        }
        movimientoProductoDto.Id = movimientoProducto.Id;
        return CreatedAtAction(nameof(Post), new { id = movimientoProductoDto.Id }, movimientoProductoDto);
    }

    [HttpPut]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<MovimientoProducto>> Put (int id, [FromBody]MovimientoProducto movimientoProductoDto)
    {
        if(movimientoProductoDto == null)
            return NotFound();

        var movimientoProducto = this.mapper.Map<MovimientoProducto>(movimientoProductoDto);
        unitofwork.MovimientosProductos.Update(movimientoProducto);
        await unitofwork.SaveAsync();
        return movimientoProductoDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var movimientoProducto = await unitofwork.MovimientosProductos.GetByIdAsync(id);

        if (movimientoProducto == null)
        {
            return Notfound();
        }

        unitofwork.MovimientosProductos.Remove(movimientoProducto);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
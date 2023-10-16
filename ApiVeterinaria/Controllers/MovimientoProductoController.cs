using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiVeterinaria.Controllers;

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
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MovimientoProducto>>> Get()
    {
        var movimientoProducto = await unitofwork.MovimientosProductos.GetAllAsync();
        return mapper.Map<List<MovimientoProducto>>(movimientoProducto);
    }

    [HttpGet("{id}")]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MovimientoProducto>> Get(int id)
    {
        var movimientoProducto = await unitofwork.MovimientosProductos.GetByIdAsync(id);
        return mapper.Map<MovimientoProducto>(movimientoProducto);
    }

    [HttpPost]
    [Authorize]    
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
    [Authorize]    
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
    [Authorize]    
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
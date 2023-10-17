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

public class TipoMovimientoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public TipoMovimientoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<TipoMovimiento>>> Get0([FromQuery]Params tipoMovimientoParams)
    {
        var tipoMovimiento = await unitofwork.TiposMovimientos.GetAllAsync(tipoMovimientoParams.PageIndex,tipoMovimientoParams.PageSize, tipoMovimientoParams.Search);
        var listaTiposMovimientos = mapper.Map<List<TipoMovimiento>>(tipoMovimiento.registros);
        return new Pager<TipoMovimiento>(listaTiposMovimientos, tipoMovimiento.totalRegistros,tipoMovimientoParams.PageIndex,tipoMovimientoParams.PageSize,tipoMovimientoParams.Search);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<TipoMovimiento>>> Get([FromQuery]Params tipoMovimientoParams)
    {
        var tipoMovimiento = await unitofwork.TiposMovimientos.GetAllAsync(tipoMovimientoParams.PageIndex,tipoMovimientoParams.PageSize, tipoMovimientoParams.Search);
        var listaTiposMovimientos = mapper.Map<List<TipoMovimiento>>(tipoMovimiento.registros);
        return new Pager<TipoMovimiento>(listaTiposMovimientos, tipoMovimiento.totalRegistros,tipoMovimientoParams.PageIndex,tipoMovimientoParams.PageSize,tipoMovimientoParams.Search);
    }

    [HttpGet("{id}")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoMovimiento>> Get(int id)
    {
        var tipoMovimiento = await unitofwork.TiposMovimientos.GetByIdAsync(id);
        return mapper.Map<TipoMovimiento>(tipoMovimiento);
    }

    [HttpPost]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoMovimiento>> Post(TipoMovimiento tipoMovimientoDto)
    {
        var tipoMovimiento = this.mapper.Map<TipoMovimiento>(tipoMovimientoDto);
        this.unitofwork.TiposMovimientos.Add(tipoMovimiento);
        await unitofwork.SaveAsync();
        if (tipoMovimiento == null){
            return BadRequest();
        }
        tipoMovimientoDto.Id = tipoMovimiento.Id;
        return CreatedAtAction(nameof(Post), new { id = tipoMovimientoDto.Id }, tipoMovimientoDto);
    }

    [HttpPut]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoMovimiento>> Put (int id, [FromBody]TipoMovimiento tipoMovimientoDto)
    {
        if(tipoMovimientoDto == null)
            return NotFound();

        var tipoMovimiento = this.mapper.Map<TipoMovimiento>(tipoMovimientoDto);
        unitofwork.TiposMovimientos.Update(tipoMovimiento);
        await unitofwork.SaveAsync();
        return tipoMovimientoDto;     
    }

    [HttpDelete("{id}")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var tipoMovimiento = await unitofwork.TiposMovimientos.GetByIdAsync(id);

        if (tipoMovimiento == null)
        {
            return Notfound();
        }

        unitofwork.TiposMovimientos.Remove(tipoMovimiento);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
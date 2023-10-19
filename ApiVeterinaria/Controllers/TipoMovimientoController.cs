using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiVeterinaria.Helpers;

namespace ApiVeterinaria.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
[Authorize (Roles= "Administrador")]    

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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<TipoMovimiento>>> Get()
    {
        var tipoMovimiento = await unitofwork.TiposMovimientos.GetAllAsync();
        return mapper.Map<List<TipoMovimiento>>(tipoMovimiento);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<TipoMovimiento>>> Get([FromQuery]Params tipoMovimientoParams)
    {
        var tipoMovimiento = await unitofwork.TiposMovimientos.GetAllAsync(tipoMovimientoParams.PageIndex,tipoMovimientoParams.PageSize, tipoMovimientoParams.Search);
        var listaTiposMovimientos = mapper.Map<List<TipoMovimiento>>(tipoMovimiento.registros);
        return new Pager<TipoMovimiento>(listaTiposMovimientos, tipoMovimiento.totalRegistros,tipoMovimientoParams.PageIndex,tipoMovimientoParams.PageSize,tipoMovimientoParams.Search);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoMovimiento>> Get(int id)
    {
        var tipoMovimiento = await unitofwork.TiposMovimientos.GetByIdAsync(id);
        return mapper.Map<TipoMovimiento>(tipoMovimiento);
    }

    [HttpPost]    
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
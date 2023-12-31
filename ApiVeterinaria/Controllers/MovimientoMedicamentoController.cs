using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiVeterinaria.Helpers;
using ApiVeterinaria.Dtos;

namespace ApiVeterinaria.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class MovimientoMedicamentoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public MovimientoMedicamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MovimientoMedicamentoGetDto>>> Get()
    {
        var movimientoMedicamento = await unitofwork.MovimientosMedicamentos.GetAllAsync();
        return mapper.Map<List<MovimientoMedicamentoGetDto>>(movimientoMedicamento);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<MovimientoMedicamentoGetDto>>> Get([FromQuery]Params movimientoMedicamentoParams)
    {
        var movimientoMedicamento = await unitofwork.MovimientosMedicamentos.GetAllAsync(movimientoMedicamentoParams.PageIndex,movimientoMedicamentoParams.PageSize, movimientoMedicamentoParams.Search);
        var listaMovimientosMedicamentos = mapper.Map<List<MovimientoMedicamentoGetDto>>(movimientoMedicamento.registros);
        return new Pager<MovimientoMedicamentoGetDto>(listaMovimientosMedicamentos, movimientoMedicamento.totalRegistros,movimientoMedicamentoParams.PageIndex,movimientoMedicamentoParams.PageSize,movimientoMedicamentoParams.Search);
    }

    [HttpGet("{id}")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MovimientoMedicamento>> Get(int id)
    {
        var movimientoMedicamento = await unitofwork.MovimientosMedicamentos.GetByIdAsync(id);
        return mapper.Map<MovimientoMedicamento>(movimientoMedicamento);
    }

    [HttpPost]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MovimientoMedicamento>> Post(MovimientoMedicamento movimientoMedicamentoDto)
    {
        var movimientoMedicamento = this.mapper.Map<MovimientoMedicamento>(movimientoMedicamentoDto);
        this.unitofwork.MovimientosMedicamentos.Add(movimientoMedicamento);
        await unitofwork.SaveAsync();
        if (movimientoMedicamento == null){
            return BadRequest();
        }
        movimientoMedicamentoDto.Id = movimientoMedicamento.Id;
        return CreatedAtAction(nameof(Post), new { id = movimientoMedicamentoDto.Id }, movimientoMedicamentoDto);
    }

    [HttpPut]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<MovimientoMedicamento>> Put (int id, [FromBody]MovimientoMedicamento movimientoMedicamentoDto)
    {
        if(movimientoMedicamentoDto == null)
            return NotFound();

        var movimientoMedicamento = this.mapper.Map<MovimientoMedicamento>(movimientoMedicamentoDto);
        unitofwork.MovimientosMedicamentos.Update(movimientoMedicamento);
        await unitofwork.SaveAsync();
        return movimientoMedicamentoDto;     
    }

    [HttpDelete("{id}")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var movimientoMedicamento = await unitofwork.MovimientosMedicamentos.GetByIdAsync(id);

        if (movimientoMedicamento == null)
        {
            return Notfound();
        }

        unitofwork.MovimientosMedicamentos.Remove(movimientoMedicamento);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    [HttpGet("movimientosMedicamentos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MovimientoMedicamentoDto>>> GetMovimientosMedic()
    {
        var movimientosMedi = await unitofwork.Medicamentos.movimientoMedicamentos();
        return mapper.Map<List<MovimientoMedicamentoDto>>(movimientosMedi);
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
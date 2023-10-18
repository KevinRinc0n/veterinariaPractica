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

public class TratamientoMedicoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public TratamientoMedicoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]  
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<TratamientoMedico>>> Get0([FromQuery]Params tratamientoMedicoParams)
    {
        var tratamientoMedico = await unitofwork.TratamientosMedicos.GetAllAsync(tratamientoMedicoParams.PageIndex,tratamientoMedicoParams.PageSize, tratamientoMedicoParams.Search);
        var listaTratamientosMedicos = mapper.Map<List<TratamientoMedico>>(tratamientoMedico.registros);
        return new Pager<TratamientoMedico>(listaTratamientosMedicos, tratamientoMedico.totalRegistros,tratamientoMedicoParams.PageIndex,tratamientoMedicoParams.PageSize,tratamientoMedicoParams.Search);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]   
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<TratamientoMedico>>> Get([FromQuery]Params tratamientoMedicoParams)
    {
        var tratamientoMedico = await unitofwork.TratamientosMedicos.GetAllAsync(tratamientoMedicoParams.PageIndex,tratamientoMedicoParams.PageSize, tratamientoMedicoParams.Search);
        var listaTratamientosMedicos = mapper.Map<List<TratamientoMedico>>(tratamientoMedico.registros);
        return new Pager<TratamientoMedico>(listaTratamientosMedicos, tratamientoMedico.totalRegistros,tratamientoMedicoParams.PageIndex,tratamientoMedicoParams.PageSize,tratamientoMedicoParams.Search);
    }

    [HttpGet("{id}")]   
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TratamientoMedico>> Get(int id)
    {
        var tipoMovimiento = await unitofwork.TratamientosMedicos.GetByIdAsync(id);
        return mapper.Map<TratamientoMedico>(tipoMovimiento);
    }

    [HttpPost]   
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TratamientoMedico>> Post(TratamientoMedico tratamientoMedicoDto)
    {
        var tratamientoMedico = this.mapper.Map<TratamientoMedico>(tratamientoMedicoDto);
        this.unitofwork.TratamientosMedicos.Add(tratamientoMedico);
        await unitofwork.SaveAsync();
        if (tratamientoMedico == null){
            return BadRequest();
        }
        tratamientoMedicoDto.Id = tratamientoMedico.Id;
        return CreatedAtAction(nameof(Post), new { id = tratamientoMedicoDto.Id }, tratamientoMedicoDto);
    }

    [HttpPut]   
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TratamientoMedico>> Put (int id, [FromBody]TratamientoMedico tratamientoMedicoDto)
    {
        if(tratamientoMedicoDto == null)
            return NotFound();

        var tratamientoMedico = this.mapper.Map<TratamientoMedico>(tratamientoMedicoDto);
        unitofwork.TratamientosMedicos.Update(tratamientoMedico);
        await unitofwork.SaveAsync();
        return tratamientoMedicoDto;     
    }

    [HttpDelete("{id}")]   
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var tratamientoMedico = await unitofwork.TratamientosMedicos.GetByIdAsync(id);

        if (tratamientoMedico == null)
        {
            return Notfound();
        }

        unitofwork.TratamientosMedicos.Remove(tratamientoMedico);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
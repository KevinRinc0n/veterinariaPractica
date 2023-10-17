using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiFarmacia.Helpers;
using ApiVeterinaria.Helpers;
using ApiVeterinaria.Dtos;

namespace ApiVeterinaria.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class VeterinarioController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public VeterinarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    // [Authorize]    
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
    // [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<TratamientoMedico>>> Get([FromQuery]Params tratamientoMedicoParams)
    {
        var tratamientoMedico = await unitofwork.TratamientosMedicos.GetAllAsync(tratamientoMedicoParams.PageIndex,tratamientoMedicoParams.PageSize, tratamientoMedicoParams.Search);
        var listaTratamientosMedicos = mapper.Map<List<TratamientoMedico>>(tratamientoMedico.registros);
        return new Pager<TratamientoMedico>(listaTratamientosMedicos, tratamientoMedico.totalRegistros,tratamientoMedicoParams.PageIndex,tratamientoMedicoParams.PageSize,tratamientoMedicoParams.Search);
    }

    [HttpGet("{id}")]
    // [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Veterinario>> Get(int id)
    {
        var veterinario = await unitofwork.Veterinarios.GetByIdAsync(id);
        return mapper.Map<Veterinario>(veterinario);
    }

    [HttpPost]
    // [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Veterinario>> Post(Veterinario veterinarioDto)
    {
        var veterinario = this.mapper.Map<Veterinario>(veterinarioDto);
        this.unitofwork.Veterinarios.Add(veterinario);
        await unitofwork.SaveAsync();
        if (veterinario == null){
            return BadRequest();
        }
        veterinarioDto.Id = veterinario.Id;
        return CreatedAtAction(nameof(Post), new { id = veterinarioDto.Id }, veterinarioDto);
    }

    [HttpPut]
    // [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Veterinario>> Put (int id, [FromBody]Veterinario veterinarioDto)
    {
        if(veterinarioDto == null)
            return NotFound();

        var veterinario = this.mapper.Map<Veterinario>(veterinarioDto);
        unitofwork.Veterinarios.Update(veterinario);
        await unitofwork.SaveAsync();
        return veterinarioDto;     
    }

    [HttpDelete("{id}")]
    // [Authorize]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var veterinario = await unitofwork.Veterinarios.GetByIdAsync(id);

        if (veterinario == null)
        {
            return Notfound();
        }

        unitofwork.Veterinarios.Remove(veterinario);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    [HttpGet("especialidad")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<VeterinarioDto>>> GetEspecialidad()
    {
        var veterinario = await unitofwork.Veterinarios.veterinarioCirujanoVascular();
        return mapper.Map<List<VeterinarioDto>>(veterinario);
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
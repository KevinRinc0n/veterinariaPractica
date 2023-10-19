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
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<VeterinarioGetDto>>> Get()
    {
        var veterinario = await unitofwork.Veterinarios.GetAllAsync();
        return mapper.Map<List<VeterinarioGetDto>>(veterinario);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<VeterinarioGetDto>>> Get([FromQuery]Params veterinarioParams)
    {
        var veterinario = await unitofwork.Veterinarios.GetAllAsync(veterinarioParams.PageIndex,veterinarioParams.PageSize, veterinarioParams.Search);
        var listaVeteriarios = mapper.Map<List<VeterinarioGetDto>>(veterinario.registros);
        return new Pager<VeterinarioGetDto>(listaVeteriarios, veterinario.totalRegistros,veterinarioParams.PageIndex,veterinarioParams.PageSize,veterinarioParams.Search);
    }

    [HttpGet("{id}")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Veterinario>> Get(int id)
    {
        var veterinario = await unitofwork.Veterinarios.GetByIdAsync(id);
        return mapper.Map<Veterinario>(veterinario);
    }

    [HttpPost]
    [Authorize (Roles= "Administrador")]    
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
    [Authorize (Roles= "Administrador")]    
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
    [Authorize (Roles= "Administrador")]    
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
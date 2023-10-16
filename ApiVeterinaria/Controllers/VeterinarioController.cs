using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiVeterinaria.Controllers;

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
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Veterinario>>> Get()
    {
        var veterinario = await unitofwork.Veterinarios.GetAllAsync();
        return mapper.Map<List<Veterinario>>(veterinario);
    }

    [HttpGet("{id}")]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Veterinario>> Get(int id)
    {
        var veterinario = await unitofwork.Veterinarios.GetByIdAsync(id);
        return mapper.Map<Veterinario>(veterinario);
    }

    [HttpPost]
    [Authorize]    
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
    [Authorize]    
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
    [Authorize]    
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

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
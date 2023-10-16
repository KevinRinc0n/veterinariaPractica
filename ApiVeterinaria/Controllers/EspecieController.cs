using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiVeterinaria.Controllers;

public class EspecieController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public EspecieController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Especie>>> Get()
    {
        var especie = await unitofwork.Especies.GetAllAsync();
        return mapper.Map<List<Especie>>(especie);
    }

    [HttpGet("{id}")]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Especie>> Get(int id)
    {
        var especies = await unitofwork.Especies.GetByIdAsync(id);
        return mapper.Map<Especie>(especies);
    }

    [HttpPost]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Especie>> Post(Especie especieDto)
    {
        var especie = this.mapper.Map<Especie>(especieDto);
        this.unitofwork.Especies.Add(especie);
        await unitofwork.SaveAsync();
        if (especie == null){
            return BadRequest();
        }
        especieDto.Id = especie.Id;
        return CreatedAtAction(nameof(Post), new { id = especieDto.Id }, especieDto);
    }

    [HttpPut]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Especie>> Put (int id, [FromBody]Especie especieDto)
    {
        if(especieDto == null)
            return NotFound();

        var especie = this.mapper.Map<Especie>(especieDto);
        unitofwork.Especies.Update(especie);
        await unitofwork.SaveAsync();
        return especieDto;     
    }

    [HttpDelete("{id}")]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var especie = await unitofwork.Especies.GetByIdAsync(id);

        if (especie == null)
        {
            return Notfound();
        }

        unitofwork.Especies.Remove(especie);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
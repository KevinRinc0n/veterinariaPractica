using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiVeterinaria.Controllers;

public class RazaController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public RazaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Raza>>> Get()
    {
        var raza = await unitofwork.Razas.GetAllAsync();
        return mapper.Map<List<Raza>>(raza);
    }

    [HttpGet("{id}")]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Raza>> Get(int id)
    {
        var raza = await unitofwork.Razas.GetByIdAsync(id);
        return mapper.Map<Raza>(raza);
    }

    [HttpPost]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Raza>> Post(Raza razaDto)
    {
        var raza = this.mapper.Map<Raza>(razaDto);
        this.unitofwork.Razas.Add(raza);
        await unitofwork.SaveAsync();
        if (raza == null){
            return BadRequest();
        }
        razaDto.Id = raza.Id;
        return CreatedAtAction(nameof(Post), new { id = razaDto.Id }, razaDto);
    }

    [HttpPut]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Raza>> Put (int id, [FromBody]Raza razaDto)
    {
        if(razaDto == null)
            return NotFound();

        var raza = this.mapper.Map<Raza>(razaDto);
        unitofwork.Razas.Update(raza);
        await unitofwork.SaveAsync();
        return razaDto;     
    }

    [HttpDelete("{id}")]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var raza = await unitofwork.Razas.GetByIdAsync(id);

        if (raza == null)
        {
            return Notfound();
        }

        unitofwork.Razas.Remove(raza);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
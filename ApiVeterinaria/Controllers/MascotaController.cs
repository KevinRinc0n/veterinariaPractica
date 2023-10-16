using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiVeterinaria.Controllers;

public class MascotaController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public MascotaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Mascota>>> Get()
    {
        var mascota = await unitofwork.Mascotas.GetAllAsync();
        return mapper.Map<List<Mascota>>(mascota);
    }

    [HttpGet("{id}")]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Mascota>> Get(int id)
    {
        var mascota = await unitofwork.Mascotas.GetByIdAsync(id);
        return mapper.Map<Mascota>(mascota);
    }

    [HttpPost]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Mascota>> Post(Mascota mascotaDto)
    {
        var mascota = this.mapper.Map<Mascota>(mascotaDto);
        this.unitofwork.Mascotas.Add(mascota);
        await unitofwork.SaveAsync();
        if (mascota == null){
            return BadRequest();
        }
        mascotaDto.Id = mascota.Id;
        return CreatedAtAction(nameof(Post), new { id = mascotaDto.Id }, mascotaDto);
    }

    [HttpPut]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Mascota>> Put (int id, [FromBody]Mascota mascotaDto)
    {
        if(mascotaDto == null)
            return NotFound();

        var mascota = this.mapper.Map<Mascota>(mascotaDto);
        unitofwork.Mascotas.Update(mascota);
        await unitofwork.SaveAsync();
        return mascotaDto;     
    }

    [HttpDelete("{id}")]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var mascota = await unitofwork.Mascotas.GetByIdAsync(id);

        if (mascota == null)
        {
            return Notfound();
        }

        unitofwork.Mascotas.Remove(mascota);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
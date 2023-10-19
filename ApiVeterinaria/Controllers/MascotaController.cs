using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiVeterinaria.Helpers;
using ApiVeterinaria.Dtos;
using API.Dtos;

namespace ApiVeterinaria.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

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
    [MapToApiVersion("1.0")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MascotaGetDto>>> Get()
    {
        var mascota = await unitofwork.Mascotas.GetAllAsync();
        return mapper.Map<List<MascotaGetDto>>(mascota);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<MascotaGetDto>>> Get([FromQuery]Params mascotaParams)
    {
        var mascota = await unitofwork.Mascotas.GetAllAsync(mascotaParams.PageIndex,mascotaParams.PageSize, mascotaParams.Search);
        var listaMascotas = mapper.Map<List<MascotaGetDto>>(mascota.registros);
        return new Pager<MascotaGetDto>(listaMascotas, mascota.totalRegistros,mascotaParams.PageIndex,mascotaParams.PageSize,mascotaParams.Search);
    }

    [HttpGet("{id}")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Mascota>> Get(int id)
    {
        var mascota = await unitofwork.Mascotas.GetByIdAsync(id);
        return mapper.Map<Mascota>(mascota);
    }

    [HttpPost]
    [Authorize (Roles= "Administrador")]    
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
    [Authorize (Roles= "Administrador")]    
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
    [Authorize (Roles= "Administrador")]    
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

    [HttpGet("felino")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MascotaDto>>> GetFelino()
    {
        var mascota = await unitofwork.Mascotas.ObtenerMascotasFelinas();
        return mapper.Map<List<MascotaDto>>(mascota);
    }

    [HttpGet("vacunados")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MascotaVacunadaDto>>> GetVacuna()
    {
        var mascota = await unitofwork.Mascotas.mascotaVacunacion();
        return mapper.Map<List<MascotaVacunadaDto>>(mascota);
    }

    [HttpGet("determinadoVeterinario")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MascotaAtendidaVeteDto>>> GetVeterinarioDeterminado(string nombre)
    {
        var mascotaVeterinario = await unitofwork.Mascotas.mascotasAtendidasDetermiVeterinario(nombre);
        return mapper.Map<List<MascotaAtendidaVeteDto>>(mascotaVeterinario);
    }

    [HttpGet("goldenRetriever")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MascotaPropietarioDto>>> GetRetriever()
    {
        var mascotaVeterinario = await unitofwork.Mascotas.mascotaGolden();
        return mapper.Map<List<MascotaPropietarioDto>>(mascotaVeterinario);
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
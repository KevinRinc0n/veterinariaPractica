using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiVeterinaria.Helpers;
using ApiFarmacia.Helpers;

namespace ApiVeterinaria.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class CitaController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public CitaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<Cita>>> Get([FromQuery]Params citaParams)
    {
        var cita = await unitofwork.Citas.GetAllAsync(citaParams.PageIndex,citaParams.PageSize, citaParams.Search);
        var listaCitas = mapper.Map<List<Cita>>(cita.registros);
        return new Pager<Cita>(listaCitas, cita.totalRegistros,citaParams.PageIndex,citaParams.PageSize,citaParams.Search);
    }

    [HttpGet("{id}")]
    // [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Cita>> Get(int id)
    {
        var citas = await unitofwork.Citas.GetByIdAsync(id);
        return mapper.Map<Cita>(citas);
    }

    [HttpPost]
    // [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cita>> Post(Cita citaDto)
    {
        var cita = this.mapper.Map<Cita>(citaDto);
        this.unitofwork.Citas.Add(cita);
        await unitofwork.SaveAsync();
        if (cita == null){
            return BadRequest();
        }
        citaDto.Id = cita.Id;
        return CreatedAtAction(nameof(Post), new { id = citaDto.Id }, citaDto);
    }

    [HttpPut]
    // [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Cita>> Put (int id, [FromBody]Cita citaDto)
    {
        if(citaDto == null)
            return NotFound();

        var cita = this.mapper.Map<Cita>(citaDto);
        unitofwork.Citas.Update(cita);
        await unitofwork.SaveAsync();
        return citaDto;     
    }

    [HttpDelete("{id}")]
    // [Authorize]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var cita = await unitofwork.Citas.GetByIdAsync(id);

        if (cita == null)
        {
            return Notfound();
        }

        unitofwork.Citas.Remove(cita);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
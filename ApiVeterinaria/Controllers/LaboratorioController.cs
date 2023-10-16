using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiVeterinaria.Controllers;

public class LaboratorioController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public LaboratorioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Laboratorio>>> Get()
    {
        var laboratorio = await unitofwork.Laboratorios.GetAllAsync();
        return mapper.Map<List<Laboratorio>>(laboratorio);
    }

    [HttpGet("{id}")]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Laboratorio>> Get(int id)
    {
        var laboratorio = await unitofwork.Laboratorios.GetByIdAsync(id);
        return mapper.Map<Laboratorio>(laboratorio);
    }

    [HttpPost]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Laboratorio>> Post(Laboratorio laboratorioDto)
    {
        var laboratorio = this.mapper.Map<Laboratorio>(laboratorioDto);
        this.unitofwork.Laboratorios.Add(laboratorio);
        await unitofwork.SaveAsync();
        if (laboratorio == null){
            return BadRequest();
        }
        laboratorioDto.Id = laboratorio.Id;
        return CreatedAtAction(nameof(Post), new { id = laboratorioDto.Id }, laboratorioDto);
    }

    [HttpPut]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Laboratorio>> Put (int id, [FromBody]Laboratorio laboratorioDto)
    {
        if(laboratorioDto == null)
            return NotFound();

        var laboratorio = this.mapper.Map<Laboratorio>(laboratorioDto);
        unitofwork.Laboratorios.Update(laboratorio);
        await unitofwork.SaveAsync();
        return laboratorioDto;     
    }

    [HttpDelete("{id}")]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var laboratorio = await unitofwork.Laboratorios.GetByIdAsync(id);

        if (laboratorio == null)
        {
            return Notfound();
        }

        unitofwork.Laboratorios.Remove(laboratorio);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
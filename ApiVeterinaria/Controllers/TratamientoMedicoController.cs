using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiVeterinaria.Controllers;

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
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<TratamientoMedico>>> Get()
    {
        var tratamientoMedico = await unitofwork.TratamientosMedicos.GetAllAsync();
        return mapper.Map<List<TratamientoMedico>>(tratamientoMedico);
    }

    [HttpGet("{id}")]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TratamientoMedico>> Get(int id)
    {
        var tipoMovimiento = await unitofwork.TratamientosMedicos.GetByIdAsync(id);
        return mapper.Map<TratamientoMedico>(tipoMovimiento);
    }

    [HttpPost]
    [Authorize]    
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
    [Authorize]    
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
    [Authorize]    
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
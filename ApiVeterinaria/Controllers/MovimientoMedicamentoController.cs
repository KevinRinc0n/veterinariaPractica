using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiVeterinaria.Controllers;

public class MovimientoMedicamentoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public MovimientoMedicamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MovimientoMedicamento>>> Get()
    {
        var movimientoMedicamento = await unitofwork.MovimientosMedicamentos.GetAllAsync();
        return mapper.Map<List<MovimientoMedicamento>>(movimientoMedicamento);
    }

    [HttpGet("{id}")]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MovimientoMedicamento>> Get(int id)
    {
        var movimientoMedicamento = await unitofwork.MovimientosMedicamentos.GetByIdAsync(id);
        return mapper.Map<MovimientoMedicamento>(movimientoMedicamento);
    }

    [HttpPost]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MovimientoMedicamento>> Post(MovimientoMedicamento movimientoMedicamentoDto)
    {
        var movimientoMedicamento = this.mapper.Map<MovimientoMedicamento>(movimientoMedicamentoDto);
        this.unitofwork.MovimientosMedicamentos.Add(movimientoMedicamento);
        await unitofwork.SaveAsync();
        if (movimientoMedicamento == null){
            return BadRequest();
        }
        movimientoMedicamentoDto.Id = movimientoMedicamento.Id;
        return CreatedAtAction(nameof(Post), new { id = movimientoMedicamentoDto.Id }, movimientoMedicamentoDto);
    }

    [HttpPut]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<MovimientoMedicamento>> Put (int id, [FromBody]MovimientoMedicamento movimientoMedicamentoDto)
    {
        if(movimientoMedicamentoDto == null)
            return NotFound();

        var movimientoMedicamento = this.mapper.Map<MovimientoMedicamento>(movimientoMedicamentoDto);
        unitofwork.MovimientosMedicamentos.Update(movimientoMedicamento);
        await unitofwork.SaveAsync();
        return movimientoMedicamentoDto;     
    }

    [HttpDelete("{id}")]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var movimientoMedicamento = await unitofwork.MovimientosMedicamentos.GetByIdAsync(id);

        if (movimientoMedicamento == null)
        {
            return Notfound();
        }

        unitofwork.MovimientosMedicamentos.Remove(movimientoMedicamento);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
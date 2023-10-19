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

public class MedicamentoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public MedicamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MedicamentoGetDto>>> Get()
    {
        var medicamento = await unitofwork.Medicamentos.GetAllAsync();
        return mapper.Map<List<MedicamentoGetDto>>(medicamento);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<MedicamentoGetDto>>> Get([FromQuery]Params medicamentoParams)
    {
        var medicamento = await unitofwork.Medicamentos.GetAllAsync(medicamentoParams.PageIndex,medicamentoParams.PageSize, medicamentoParams.Search);
        var listaMedicamentos = mapper.Map<List<MedicamentoGetDto>>(medicamento.registros);
        return new Pager<MedicamentoGetDto>(listaMedicamentos, medicamento.totalRegistros,medicamentoParams.PageIndex,medicamentoParams.PageSize,medicamentoParams.Search);
    }

    [HttpGet("{id}")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Medicamento>> Get(int id)
    {
        var medicamento = await unitofwork.Medicamentos.GetByIdAsync(id);
        return mapper.Map<Medicamento>(medicamento);
    }

    [HttpPost]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Medicamento>> Post(Medicamento medicamentoDto)
    {
        var medicamento = this.mapper.Map<Medicamento>(medicamentoDto);
        this.unitofwork.Medicamentos.Add(medicamento);
        await unitofwork.SaveAsync();
        if (medicamento == null){
            return BadRequest();
        }
        medicamentoDto.Id = medicamento.Id;
        return CreatedAtAction(nameof(Post), new { id = medicamentoDto.Id }, medicamentoDto);
    }

    [HttpPut]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Medicamento>> Put (int id, [FromBody]Medicamento medicamentoDto)
    {
        if(medicamentoDto == null)
            return NotFound();

        var mascota = this.mapper.Map<Medicamento>(medicamentoDto);
        unitofwork.Medicamentos.Update(mascota);
        await unitofwork.SaveAsync();
        return medicamentoDto;     
    }

    [HttpDelete("{id}")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var medicamento = await unitofwork.Medicamentos.GetByIdAsync(id);

        if (medicamento == null)
        {
            return Notfound();
        }

        unitofwork.Medicamentos.Remove(medicamento);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    [HttpGet("mayor50000")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Medicamento5000Dto>>> GetCaro()
    {
        var medicamento = await unitofwork.Medicamentos.medicamentos50000();
        return mapper.Map<List<Medicamento5000Dto>>(medicamento);
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
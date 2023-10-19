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
    [MapToApiVersion("1.0")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<LaboratorioGetDto>>> Get()
    {
        var laboratorio = await unitofwork.Laboratorios.GetAllAsync();
        return mapper.Map<List<LaboratorioGetDto>>(laboratorio);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<LaboratorioGetDto>>> Get([FromQuery]Params laboratorioParams)
    {
        var laboratorio = await unitofwork.Laboratorios.GetAllAsync(laboratorioParams.PageIndex,laboratorioParams.PageSize, laboratorioParams.Search);
        var listaLaboratorios = mapper.Map<List<LaboratorioGetDto>>(laboratorio.registros);
        return new Pager<LaboratorioGetDto>(listaLaboratorios, laboratorio.totalRegistros,laboratorioParams.PageIndex,laboratorioParams.PageSize,laboratorioParams.Search);
    }

    [HttpGet("{id}")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Laboratorio>> Get(int id)
    {
        var laboratorio = await unitofwork.Laboratorios.GetByIdAsync(id);
        return mapper.Map<Laboratorio>(laboratorio);
    }

    [HttpPost]
    [Authorize (Roles= "Administrador")]    
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
    [Authorize (Roles= "Administrador")]    
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
    [Authorize (Roles= "Administrador")]    
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

    [HttpGet("genfar")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoLaboDto>>> GetLabosGenfar()
    {
        var laboratorio = await unitofwork.Laboratorios.medicamentosGenfar();
        return mapper.Map<List<MedicamentoLaboDto>>(laboratorio);
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
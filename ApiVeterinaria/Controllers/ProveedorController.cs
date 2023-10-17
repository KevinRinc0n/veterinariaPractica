using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiFarmacia.Helpers;
using ApiVeterinaria.Helpers;
using System.Text.Json;
using System.Text.Json.Serialization;
using ApiVeterinaria.Dtos;

namespace ApiVeterinaria.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class ProveedorController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public ProveedorController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<Proveedor>>> Get0([FromQuery]Params proveedorParams)
    {
        var proveedor = await unitofwork.Proveedores.GetAllAsync(proveedorParams.PageIndex,proveedorParams.PageSize, proveedorParams.Search);
        var listaProveedores = mapper.Map<List<Proveedor>>(proveedor.registros);
        return new Pager<Proveedor>(listaProveedores, proveedor.totalRegistros,proveedorParams.PageIndex,proveedorParams.PageSize,proveedorParams.Search);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<Proveedor>>> Get([FromQuery]Params proveedorParams)
    {
        var proveedor = await unitofwork.Proveedores.GetAllAsync(proveedorParams.PageIndex,proveedorParams.PageSize, proveedorParams.Search);
        var listaProveedores = mapper.Map<List<Proveedor>>(proveedor.registros);
        return new Pager<Proveedor>(listaProveedores, proveedor.totalRegistros,proveedorParams.PageIndex,proveedorParams.PageSize,proveedorParams.Search);
    }

    [HttpGet("{id}")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Proveedor>> Get(int id)
    {
        var proveedor = await unitofwork.Proveedores.GetByIdAsync(id);
        return mapper.Map<Proveedor>(proveedor);
    }

    [HttpPost]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Proveedor>> Post(Proveedor proveedorDto)
    {
        var proveedor = this.mapper.Map<Proveedor>(proveedorDto);
        this.unitofwork.Proveedores.Add(proveedor);
        await unitofwork.SaveAsync();
        if (proveedor == null){
            return BadRequest();
        }
        proveedorDto.Id = proveedor.Id;
        return CreatedAtAction(nameof(Post), new { id = proveedorDto.Id }, proveedorDto);
    }

    [HttpPut]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Proveedor>> Put (int id, [FromBody]Proveedor proveedorDto)
    {
        if(proveedorDto == null)
            return NotFound();

        var proveedor = this.mapper.Map<Proveedor>(proveedorDto);
        unitofwork.Proveedores.Update(proveedor);
        await unitofwork.SaveAsync();
        return proveedorDto;     
    }

    [HttpDelete("{id}")]
    [Authorize (Roles= "Administrador")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var proveedor = await unitofwork.Proveedores.GetByIdAsync(id);

        if (proveedor == null)
        {
            return Notfound();
        }

        unitofwork.Proveedores.Remove(proveedor);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    [HttpGet("medicamentoDeterminado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<LaboratorioDeterMedicDto>>> GetVeterinario(string nombre)
    {
        var deterMedicamento = await unitofwork.Proveedores.proveedorMedicaDeterminado(nombre);
        return mapper.Map<List<LaboratorioDeterMedicDto>>(deterMedicamento);
    }


    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
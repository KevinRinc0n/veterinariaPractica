using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiVeterinaria.Controllers;

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
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Proveedor>>> Get()
    {
        var proveedor = await unitofwork.Proveedores.GetAllAsync();
        return mapper.Map<List<Proveedor>>(proveedor);
    }

    [HttpGet("{id}")]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Proveedor>> Get(int id)
    {
        var proveedor = await unitofwork.Proveedores.GetByIdAsync(id);
        return mapper.Map<Proveedor>(proveedor);
    }

    [HttpPost]
    [Authorize]    
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
    [Authorize]    
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
    [Authorize]    
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

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
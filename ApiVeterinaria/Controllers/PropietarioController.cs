using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiFarmacia.Helpers;
using ApiVeterinaria.Helpers;

namespace ApiVeterinaria.Controllers;

public class PropietarioController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public PropietarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<Propietario>>> Get([FromQuery]Params propietarioParams)
    {
        var propietario = await unitofwork.Propietarios.GetAllAsync(propietarioParams.PageIndex,propietarioParams.PageSize, propietarioParams.Search);
        var listaPropietarios = mapper.Map<List<Propietario>>(propietario.registros);
        return new Pager<Propietario>(listaPropietarios, propietario.totalRegistros,propietarioParams.PageIndex,propietarioParams.PageSize,propietarioParams.Search);
    }

    [HttpGet("{id}")]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Propietario>> Get(int id)
    {
        var propietario = await unitofwork.Propietarios.GetByIdAsync(id);
        return mapper.Map<Propietario>(propietario);
    }

    [HttpPost]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Propietario>> Post(Propietario propietarioDto)
    {
        var propietario = this.mapper.Map<Propietario>(propietarioDto);
        this.unitofwork.Propietarios.Add(propietario);
        await unitofwork.SaveAsync();
        if (propietario == null){
            return BadRequest();
        }
        propietarioDto.Id = propietario.Id;
        return CreatedAtAction(nameof(Post), new { id = propietarioDto.Id }, propietarioDto);
    }

    [HttpPut]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Propietario>> Put (int id, [FromBody]Propietario propietarioDto)
    {
        if(propietarioDto == null)
            return NotFound();

        var propietario = this.mapper.Map<Propietario>(propietarioDto);
        unitofwork.Propietarios.Update(propietario);
        await unitofwork.SaveAsync();
        return propietarioDto;     
    }

    [HttpDelete("{id}")]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var propietario = await unitofwork.Propietarios.GetByIdAsync(id);

        if (propietario == null)
        {
            return Notfound();
        }

        unitofwork.Propietarios.Remove(propietario);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
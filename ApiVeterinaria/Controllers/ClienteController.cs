using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiFarmacia.Helpers;
using ApiVeterinaria.Helpers;

namespace ApiVeterinaria.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class ClienteController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [Authorize (Roles= "Administrador")]        
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<Cliente>>> Get0([FromQuery]Params clienteParams)
    {
        var cliente = await unitofwork.Clientes.GetAllAsync(clienteParams.PageIndex,clienteParams.PageSize, clienteParams.Search);
        var listaClientes = mapper.Map<List<Cliente>>(cliente.registros);
        return new Pager<Cliente>(listaClientes, cliente.totalRegistros,clienteParams.PageIndex,clienteParams.PageSize,clienteParams.Search);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [Authorize (Roles= "Administrador")]        
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<Cliente>>> Get([FromQuery]Params clienteParams)
    {
        var cliente = await unitofwork.Clientes.GetAllAsync(clienteParams.PageIndex,clienteParams.PageSize, clienteParams.Search);
        var listaClientes = mapper.Map<List<Cliente>>(cliente.registros);
        return new Pager<Cliente>(listaClientes, cliente.totalRegistros,clienteParams.PageIndex,clienteParams.PageSize,clienteParams.Search);
    }

    [HttpGet("{id}")]
    [Authorize (Roles= "Administrador")]        
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Cliente>> Get(int id)
    {
        var clientes = await unitofwork.Clientes.GetByIdAsync(id);
        return mapper.Map<Cliente>(clientes);
    }

    [HttpPost]
    [Authorize (Roles= "Administrador")]        
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cliente>> Post(Cliente clienteDto)
    {
        var cliente = this.mapper.Map<Cliente>(clienteDto);
        this.unitofwork.Clientes.Add(cliente);
        await unitofwork.SaveAsync();
        if (cliente == null){
            return BadRequest();
        }
        clienteDto.Id = cliente.Id;
        return CreatedAtAction(nameof(Post), new { id = clienteDto.Id }, clienteDto);
    }

    [HttpPut]
    [Authorize (Roles= "Administrador")]        
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Cliente>> Put (int id, [FromBody]Cliente clienteDto)
    {
        if(clienteDto == null)
            return NotFound();

        var cliente = this.mapper.Map<Cliente>(clienteDto);
        unitofwork.Clientes.Update(cliente);
        await unitofwork.SaveAsync();
        return clienteDto;     
    }

    [HttpDelete("{id}")]
    [Authorize (Roles= "Administrador")]        
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var cliente = await unitofwork.Clientes.GetByIdAsync(id);

        if (cliente == null)
        {
            return Notfound();
        }

        unitofwork.Clientes.Remove(cliente);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
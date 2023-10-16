using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiVeterinaria.Controllers;

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
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Cliente>>> Get()
    {
        var cliente = await unitofwork.Clientes.GetAllAsync();
        return mapper.Map<List<Cliente>>(cliente);
    }

    [HttpGet("{id}")]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Cliente>> Get(int id)
    {
        var clientes = await unitofwork.Clientes.GetByIdAsync(id);
        return mapper.Map<Cliente>(clientes);
    }

    [HttpPost]
    [Authorize]    
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
    [Authorize]    
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
    [Authorize]    
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
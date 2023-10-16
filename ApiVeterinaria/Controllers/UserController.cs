using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiVeterinaria.Controllers;

public class UserController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public UserController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        var usuario = await unitofwork.Usuarios.GetAllAsync();
        return mapper.Map<List<User>>(usuario);
    }

    [HttpGet("{id}")]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<User>> Get(int id)
    {
        var usuario = await unitofwork.Usuarios.GetByIdAsync(id);
        return mapper.Map<User>(usuario);
    }

    [HttpPost]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<User>> Post(User usuarioDto)
    {
        var usuario = this.mapper.Map<User>(usuarioDto);
        this.unitofwork.Usuarios.Add(usuario);
        await unitofwork.SaveAsync();
        if (usuario == null){
            return BadRequest();
        }
        usuarioDto.Id = usuario.Id;
        return CreatedAtAction(nameof(Post), new { id = usuarioDto.Id }, usuarioDto);
    }

    [HttpPut]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<User>> Put (int id, [FromBody]User usuarioDto)
    {
        if(usuarioDto == null)
            return NotFound();

        var usuario = this.mapper.Map<User>(usuarioDto);
        unitofwork.Usuarios.Update(usuario);
        await unitofwork.SaveAsync();
        return usuarioDto;     
    }

    [HttpDelete("{id}")]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var usuario = await unitofwork.Usuarios.GetByIdAsync(id);

        if (usuario == null)
        {
            return Notfound();
        }

        unitofwork.Usuarios.Remove(usuario);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
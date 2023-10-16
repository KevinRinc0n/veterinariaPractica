using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiVeterinaria.Dtos;
using ApiVeterinaria.Services;
using ApiFarmacia.Helpers;
using ApiVeterinaria.Helpers;

namespace ApiVeterinaria.Controllers;

public class UserController : BaseApiController
{
    private IUserService _userService;
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public UserController(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
        _userService = userService;
    } 

    [HttpGet]
    [Authorize]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<User>>> Get([FromQuery]Params usuarioParams)
    {
        var usuario = await unitofwork.Usuarios.GetAllAsync(usuarioParams.PageIndex,usuarioParams.PageSize, usuarioParams.Search);
        var listaUsuarios = mapper.Map<List<User>>(usuario.registros);
        return new Pager<User>(listaUsuarios, usuario.totalRegistros,usuarioParams.PageIndex,usuarioParams.PageSize,usuarioParams.Search);
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

    [HttpPost("register")]
    public async Task<ActionResult> RegisterAsync(RegisterDto model)
    {
        var result = await _userService.RegisterAsync(model);
        return Ok(result);
    }

    [HttpPost("token")] 
    public async Task<IActionResult> GetTokenAsync(LoginDto model)
    {
        var result = await _userService.GetTokenAsync(model);
        SetRefreshTokenInCookie(result.RefreshToken);
        return Ok(result);
    }

    [HttpPost("addrole")]
    public async Task<IActionResult> AddRoleAsync(AddRolDto model)
    {
        var result = await _userService.AddRoleAsync(model);
        return Ok(result);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = Request.Cookies["refreshToken"];
        var response = await _userService.RefreshTokenAsync(refreshToken);
        if (!string.IsNullOrEmpty(response.RefreshToken))
            SetRefreshTokenInCookie(response.RefreshToken);
        return Ok(response);
    }

    private void SetRefreshTokenInCookie(string refreshToken)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(10),
        };
        Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
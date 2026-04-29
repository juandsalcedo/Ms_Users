using Microsoft.AspNetCore.Mvc;
using Ms_Users.Adapter.Restful.v1.Dtos;
using Ms_Users.Adapter.Restful.v1.Mappers;
using Ms_Users.Application.Service;
using Ms_Users.Domain.Entity;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        
        if (user == null) return NotFound(new { message = "Usuario no encontrado" });
        
        return Ok(user);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userDto)
    {
        if (userDto == null) return BadRequest(new { message = "Datos inválidos" });

        // Convertimos el DTO que viene de la calle a una Entidad de Dominio
        var userEntity = userDto.ToEntity();

        // Pasamos la Entidad al servicio Capa de Aplicación
        await _userService.CreateUserAsync(userEntity);

        //  Respondemos con éxito
        return Ok(new { message = "Usuario creado exitosamente" });
    }
}



// Agregar un DTO que pase por application para que la informacion del dominio no pase directo a los controladores y un mapper que 
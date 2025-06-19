using Microsoft.AspNetCore.Mvc;
using PrimeiraApi.Dtos.Request;
using PrimeiraApi.Service;

namespace PrimeiraApi.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _service;

    public UsuarioController(IUsuarioService service)
    {
        _service = service;
    }

    [HttpGet("GetUsuarios")]
    public async Task<IActionResult> GetUsuarios()
    {
        return Ok(await _service.GetUsuariosAsync());
    }

    [HttpGet("GetUsuarioPorId")]
    public async Task<IActionResult> GetUsuariosPorId(Guid id)
    {
        return Ok(await _service.GetUsuarioPorIdAsync(id));
    }

    [HttpPut("UpdateUsuario")]
    public async Task UpdateUsuario([FromBody] UsuarioInputRequest request)
    {
        await _service.UpdateUsuarioAsync(request);
    }

    [HttpPost("CreateUsuario")]
    public async Task CreateUsuario([FromBody]UsuarioCreateRequest request)
    {
        await _service.CreateUsuarioAsync(request);
    }

    [HttpDelete("DeleteUsuario")]
    public async Task DeleteUsuario(Guid id)
    {
        await _service.DeleteUsuarioAsync(id);
    }
}

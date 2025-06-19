using PrimeiraApi.Dtos;
using PrimeiraApi.Dtos.Request;
using PrimeiraApi.Dtos.Response;

namespace PrimeiraApi.Service;

public interface IUsuarioService
{
    Task<UsuarioResponse<List<UsuarioOutputDto>>> GetUsuariosAsync();
    Task<UsuarioResponse<UsuarioOutputDto>> GetUsuarioPorIdAsync(Guid id);
    Task UpdateUsuarioAsync(UsuarioInputRequest change);
    Task CreateUsuarioAsync(UsuarioCreateRequest request);
    Task DeleteUsuarioAsync(Guid id);
}

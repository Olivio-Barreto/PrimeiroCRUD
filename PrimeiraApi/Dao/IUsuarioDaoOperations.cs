using System.Collections;
using PrimeiraApi.Dtos.Request;
using PrimeiraApi.Entities;

namespace PrimeiraApi.Dao;

internal interface IUsuarioDaoOperations
{
    Task<List<Usuario>> GetUsuariosAsync();
    Task<Usuario> GetUsuarioPorIdAsync(Guid id);
    Task UpdateUsuarioAsync(UsuarioInputRequest request);
    Task CreateUsuarioAsync(UsuarioCreateRequest request);
    Task RemoveUsuarioAsync(Guid id);
}

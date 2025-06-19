using PrimeiraApi.Dao;
using PrimeiraApi.Dtos;
using PrimeiraApi.Dtos.Enums;
using PrimeiraApi.Dtos.Request;
using PrimeiraApi.Dtos.Response;

namespace PrimeiraApi.Service;

internal class UsuarioService : IUsuarioService
{
    private readonly IUsuarioDaoOperations _operation;

    public UsuarioService(IUsuarioDaoOperations operation)
    {
        _operation = operation;
    }
    public async Task<UsuarioResponse<List<UsuarioOutputDto>>> GetUsuariosAsync()
    {
        UsuarioResponse<List<UsuarioOutputDto>> response = new();
        List<UsuarioOutputDto> listOut = [];
        try
        {
            var listSource = await _operation.GetUsuariosAsync();

            listOut.AddRange(listSource
                .Select(usuario => new UsuarioOutputDto
                {
                    Id = usuario.Id,
                    PrimeiroNome = usuario.PrimeiroNome,
                    SegundoNome = usuario.SegundoNome,
                    Email = usuario.Email
                })
            );

            response.Message = "Usuários coletados.";
            response.Status = StatusResponse.Sucess;
            response.Value = listOut;

            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = StatusResponse.Failed;
            response.Value = null;

            return response;
        }
    }

    public async Task<UsuarioResponse<UsuarioOutputDto>> GetUsuarioPorIdAsync(Guid id)
    {
        UsuarioResponse<UsuarioOutputDto> response = new();
        try
        {
            var source = await _operation.GetUsuarioPorIdAsync(id);
            var novoUsuarioOut = new UsuarioOutputDto()
            {
                Id = source.Id,
                PrimeiroNome = source.PrimeiroNome,
                SegundoNome = source.SegundoNome,
                Email = source.Email,
            };
            response.Message = "Usuário coletado.";
            response.Status = StatusResponse.Sucess;
            response.Value = novoUsuarioOut;

            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = StatusResponse.Failed;
            response.Value = null;

            return response;
        }
    }

    public async Task UpdateUsuarioAsync(UsuarioInputRequest change) => await _operation
        .UpdateUsuarioAsync(change);

    public async Task CreateUsuarioAsync(UsuarioCreateRequest request) => await _operation
        .CreateUsuarioAsync(request);

    public async Task DeleteUsuarioAsync(Guid id) => await _operation
        .RemoveUsuarioAsync(id);
}

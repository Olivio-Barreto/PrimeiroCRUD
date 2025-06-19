using PrimeiraApi.Dtos.Enums;

namespace PrimeiraApi.Dtos.Response;

public class UsuarioResponse<T>
{
    public T? Value { get; set; }
    public string? Message { get; set; }
    public StatusResponse Status { get; set; }
}

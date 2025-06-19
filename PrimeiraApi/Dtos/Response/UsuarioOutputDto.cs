namespace PrimeiraApi.Dtos;

public record UsuarioOutputDto
{
    public Guid Id { get; set; }
    public string PrimeiroNome { get; set; } = string.Empty;
    public string SegundoNome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

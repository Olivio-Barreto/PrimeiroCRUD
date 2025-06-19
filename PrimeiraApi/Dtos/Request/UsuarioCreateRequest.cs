using System.ComponentModel.DataAnnotations;

namespace PrimeiraApi.Dtos.Request;

public record UsuarioCreateRequest
{
    [Required(ErrorMessage = "O primeiro nome é obrigatório.")]
    [StringLength(20, MinimumLength = 3)]
    public string PrimeiroNome { get; set; }

    [Required(ErrorMessage = "O segundo nome é obrigatório.")]
    [StringLength(20)]
    public string SegundoNome { get; set; }

    [Required(ErrorMessage = "O email é obrigatório")]
    [EmailAddress(ErrorMessage = "Este email é inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória.")]
    [DataType(DataType.Password)]
    public string Senha { get; set; }
}

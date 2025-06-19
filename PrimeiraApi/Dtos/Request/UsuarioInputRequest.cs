using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace PrimeiraApi.Dtos.Request;

public class UsuarioInputRequest
{
    [Required(ErrorMessage = "O ID é obrigatório.")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O primeiro nome é obrigatório.")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Min = 8, Max = 20")]
    public string PrimeiroNome { get; set; }

    [Required(ErrorMessage = "O segundo nome é obrigatório.")]
    [StringLength(20, ErrorMessage = "Min = 8, Max = 20")]
    public string SegundoNome { get; set; }

    [Required(ErrorMessage = "O email é obrigatório.")]
    [EmailAddress(ErrorMessage = "Este email é inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória")]
    [DataType(DataType.Password, ErrorMessage = "Esta senha é inválida.")]
    public string Senha { get; set; }
}

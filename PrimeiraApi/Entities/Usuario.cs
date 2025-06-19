using System.ComponentModel.DataAnnotations;

namespace PrimeiraApi.Entities;

public class Usuario
{
    public Guid Id { get; private init; }
    [StringLength(50)] public string PrimeiroNome { get; private set; } = string.Empty;
    [StringLength(50)] public string SegundoNome { get; private set; } = string.Empty;
    [StringLength(100)] public string Email { get; private set; } = string.Empty;
    [StringLength(50)] public string Senha { get; private set; } = string.Empty;

    public Usuario()
    {
        Id = Guid.NewGuid();
    }

    public Usuario(string primeiroNome, string segundoNome, string email, string senha) : this()
    {
        PrimeiroNome = primeiroNome;
        SegundoNome = segundoNome;
        Email = email;
        Senha = senha;
    }

    public void SetNome(string first, string second)
    {
        PrimeiroNome = first;
        SegundoNome = second;
    }

    public void SetMail(string email, string senha)
    {
        Email = email;
        Senha = senha;
    }
}

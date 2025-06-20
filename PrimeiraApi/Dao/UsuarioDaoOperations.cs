using System.Runtime.ExceptionServices;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using PrimeiraApi.Data;
using PrimeiraApi.Dtos.Request;
using PrimeiraApi.Entities;

namespace PrimeiraApi.Dao;

internal class UsuarioDaoOperations : IUsuarioDaoOperations
{
    private readonly AppDbContext _context;

    public UsuarioDaoOperations(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Usuario>> GetUsuariosAsync()
    {
        try
        {
            var list = await _context.Usuarios
                .OrderBy(u => u.Id)
                .ThenBy(u => u.PrimeiroNome)
                .ToListAsync();
            return list;
        }
        catch (MySqlException ex) when (ex.InnerException != null)
        {
            ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
            throw; // nunca será executado, mas necessário.
        }
        catch (MySqlException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Usuario> GetUsuarioPorIdAsync(Guid id)
    {
        try
        {
            var source = await _context.Usuarios.FirstAsync(u => u.Id.Equals(id));

            return source;
        }
        catch (MySqlException ex) when (ex.InnerException != null)
        {
            ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
            throw; // nunca será executado, mas necessário.
        }
        catch (MySqlException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task UpdateUsuarioAsync(UsuarioInputRequest request)
    {
        try
        {
            var source = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == request.Id) ??
                         throw new ArgumentNullException(nameof(request));
            source.SetNome(request.PrimeiroNome, request.SegundoNome);
            source.SetMail(request.Email, request.Senha);

            _context.Usuarios.Update(source);
            await _context.SaveChangesAsync();
        }
        catch (MySqlException ex) when (ex.InnerException != null)
        {
            ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
        }
        catch (MySqlException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task CreateUsuarioAsync(UsuarioCreateRequest request)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(request);

            await _context.Usuarios.AddAsync(new Usuario(
                request.PrimeiroNome,
                request.SegundoNome,
                request.Email,
                request.Senha));

            await _context.SaveChangesAsync();
        }
        catch (MySqlException ex) when (ex.InnerException != null)
        {
            ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
        }
        catch (MySqlException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task RemoveUsuarioAsync(Guid id)
    {
        try
        {
            var source = await _context.Usuarios.FirstAsync(u => u.Id == id);

            _context.Usuarios.Remove(source);
            await _context.SaveChangesAsync();
        }
        catch (MySqlException ex) when (ex.InnerException != null)
        {
            ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
        }
        catch (MySqlException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }
}


using Microsoft.EntityFrameworkCore;
using systemquchooch.Models;
using systemquchooch.Servicios.Contrato;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace systemquchooch.Servicios.Implementacion;


public class UsuarioService : IUsuarioService
{
    private readonly QuchoochContext _dbContext;
    public UsuarioService(QuchoochContext dbContext) 
    {
    _dbContext = dbContext;
    }


    public async Task<Usuario> GetUsuarios(string correo, string clave)
    {
        Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.Email == correo && u.Contrasena == clave)
            .FirstOrDefaultAsync();
        
        return usuario_encontrado;
    }

    public async Task<Usuario> SaveUsuario(Usuario modelo)
    {
        _dbContext.Usuarios.Add(modelo);
        await _dbContext.SaveChangesAsync();
        return modelo;
    }
}

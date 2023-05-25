using Microsoft.EntityFrameworkCore;
using systemquchooch.Models;
using systemquchooch.Servicios.Contrato;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace systemquchooch.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly QuchoochContext _dbContext;
        public UsuarioService(QuchoochContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Usuario Usuario_encontrado => throw new NotImplementedException();


        public async Task<Usuario?> GetUsuario(string email, string contrasena, Usuario usuario_encontrado)
        {
            Usuario? usuario = await _dbContext.Usuario.Where(u => u.Email == email && u.Contrasena == contrasena)
                             .FirstOrDefaultAsync();
            return usuario_encontrado;
        }

        public Task<Usuario?> GetUsuario(string email, string contrasena, Usuario? usuarioEncontrado, Usuario? usuario_encontrado)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario?> GetUsuario(string email, string contrasena)
        {
           Usuario? usuario_encontrado = await _dbContext.Usuario.Where(u => u.Email == email && u.Contrasena == contrasena)
                .FirstOrDefaultAsync();
            return usuario_encontrado;
            //Console.WriteLine(usuario_encontrado);
            

        }
        public async Task<Usuario?> SaveUsuario(Usuario modelo)
            {
            _dbContext.Usuario.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}



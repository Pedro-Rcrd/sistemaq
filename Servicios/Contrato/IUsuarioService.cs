using Microsoft.EntityFrameworkCore;
using systemquchooch.Models;


namespace systemquchooch.Servicios.Contrato
    {

        public interface IUsuarioService
        {
            Task<Usuario?> GetUsuario(string email, string contrasena);
            Task<Usuario?> GetUsuario(string email, string contrasena, Usuario? usuarioEncontrado, Usuario? usuario_encontrado);
            Task<Usuario?> GetUsuario(string email, string v, Usuario usuario_encontrado);
            Task<Usuario?> SaveUsuario(Usuario modelo);
        }
}

using Microsoft.EntityFrameworkCore;
using systemquchooch.Models;

namespace systemquchooch.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuarios(string correo, string clave);

        Task<Usuario> SaveUsuario(Usuario modelo);
    }
}

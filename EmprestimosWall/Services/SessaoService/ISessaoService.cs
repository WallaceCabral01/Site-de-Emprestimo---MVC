using EmprestimosWall.Models;

namespace EmprestimosWall.Services.SessaoService
{
    public interface ISessaoService
    {
        UsuarioModel BuscarSessao();
        void CriarSessao(UsuarioModel usuarioModel);
        void RemoverSessao();
    }
}

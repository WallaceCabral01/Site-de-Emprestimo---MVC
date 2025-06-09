using EmprestimosWall.Dto;
using EmprestimosWall.Models;

namespace EmprestimosWall.Services.LoginService
{
    public interface ILoginService
    {
        Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegisterDto usuarioRegisterDto);
    }
}

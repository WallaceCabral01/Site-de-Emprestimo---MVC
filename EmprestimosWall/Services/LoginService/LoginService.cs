using DocumentFormat.OpenXml.Bibliography;
using EmprestimosWall.Data;
using EmprestimosWall.Dto;
using EmprestimosWall.Models;
using EmprestimosWall.Services.SenhaService;

namespace EmprestimosWall.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly ApplicationDbContext _context;
        public readonly ISenhaService _iSenhaService;

        public LoginService(ApplicationDbContext context,ISenhaService iSenhaService)
        {
            _context = context;
            _iSenhaService = iSenhaService;
        }

        public async Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegisterDto usuarioRegisterDto)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

            try
            {
                if (VerificarEmailExistente(usuarioRegisterDto))
                {
                    response.Mensagem = "Desculpe,já existe um usuário cadastrado com o email informado!";
                    response.status = false;
                    return response;
                }
                _iSenhaService.CriarSenhaHash(usuarioRegisterDto.Senha, out byte[] senhaHAsh, out byte[] senhaSalt);

                var usuario = new UsuarioModel()
                {
                    Nome = usuarioRegisterDto.Nome,
                    Sobrenome = usuarioRegisterDto.Sobrenome,
                    Email = usuarioRegisterDto.Email,
                    SenhaHash = senhaHAsh,
                    SenhaSalt = senhaSalt
                };
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                response.Mensagem = "Usuario cadastrado com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.status = false;
                return response;

            }


        }
        public bool VerificarEmailExistente(UsuarioRegisterDto usuarioRegisterDto)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Email == usuarioRegisterDto.Email);
            if (usuario == null)
            {
                return false;
            }
            return true;
        }

    }
}

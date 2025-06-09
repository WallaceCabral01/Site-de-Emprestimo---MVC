using EmprestimosWall.Dto;
using EmprestimosWall.Services.LoginService;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimosWall.Controllers
{
    public class LoginController : Controller
    {
        public readonly ILoginService _LoginService;

        public LoginController(ILoginService loginService)
        {
            _LoginService = loginService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioRegisterDto usuarioRegisterDto)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _LoginService.RegistrarUsuario(usuarioRegisterDto);

                if (usuario.status)
                {
                    TempData["MenssagemSucesso"] = usuario.Mensagem;
                }
                else
                {
                    TempData["ErroMenssagem"] = usuario.Mensagem;
                    return View(usuarioRegisterDto);
                }
                return RedirectToAction("index");
            }
            else {
                return View(usuarioRegisterDto);
            }
        }
    }
}

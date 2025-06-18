using EmprestimosWall.Dto;
using EmprestimosWall.Services.LoginService;
using EmprestimosWall.Services.SessaoService;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimosWall.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _LoginService;
        private readonly ISessaoService _SessaoService;

        public LoginController(ILoginService loginService, ISessaoService sessaoService)
        {
            _LoginService = loginService;
            _SessaoService = sessaoService;
        }
       
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View("Login");
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            _SessaoService.RemoverSessao();
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
                return RedirectToAction("Login");
            }
            else
            {
                return View(usuarioRegisterDto);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Login(UsuarioLoginDto usuarioLoginDto)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _LoginService.Login(usuarioLoginDto);

                if (usuario.status)
                {
                    TempData["MenssagemSucesso"] = usuario.Mensagem;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["ErroMenssagem"] = usuario.Mensagem;
                    return View(usuarioLoginDto);
                }

            }
            else
            {
                return View(usuarioLoginDto);
            }
        }
    }
}

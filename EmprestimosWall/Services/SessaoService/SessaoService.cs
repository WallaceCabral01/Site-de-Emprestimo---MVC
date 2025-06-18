using EmprestimosWall.Models;
using Newtonsoft.Json;

namespace EmprestimosWall.Services.SessaoService
{
    public class SessaoService : ISessaoService
    {
        private readonly IHttpContextAccessor _ContextAccessor;

        public SessaoService(IHttpContextAccessor contextAccessor)
        {
            _ContextAccessor = contextAccessor;
        }

        public UsuarioModel BuscarSessao()
        {
            var sessaoUsuario = _ContextAccessor.HttpContext.Session.GetString("sessaoUsuario");
            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return null;
            }
                
            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessao(UsuarioModel usuarioModel)
        {
            var usuarioJson = JsonConvert.SerializeObject(usuarioModel);
            _ContextAccessor.HttpContext.Session.SetString("sessaoUsuario", usuarioJson);
        }

        public void RemoverSessao()
        {
            _ContextAccessor.HttpContext.Session.Remove("sessaoUsuario");
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EmprestimosWall.Dto
{
    public class UsuarioRegisterDto
    {
        [Required(ErrorMessage ="Digite o nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Digite o sobrenome. ")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage ="Digite o emai. ")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Digite a senha.")]
        public string Senha { get; set; }

        [Required(ErrorMessage ="Confirme a senha: "),
        Compare("Senha", ErrorMessage = "As senhas não estão iguais!")]
        public string ConfirmarSenha { get; set; }
    }
}

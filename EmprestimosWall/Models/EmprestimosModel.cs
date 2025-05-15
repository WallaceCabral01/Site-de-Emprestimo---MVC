using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmprestimosWall.Models
{
    public class EmprestimosModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Por favor, informe o nome do recebedor!")]
        public string Recebedor { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do fornecedor!")]
        public string Fornecedor { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do Livro!")]
        public string LivroEmprestado { get; set; }
        public DateTime DataUltimaAtuazacao { get; set; } = DateTime.Now;

    }

 }

using EmprestimosWall.Data;
using EmprestimosWall.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimosWall.Controllers 
{
    
    public class EmprestimoController : Controller
    {

        readonly private ApplicationDbContext _context;

        public EmprestimoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<EmprestimosModel> emprestimos = _context.Emprestimos; 
            return View(emprestimos);
        }
        public IActionResult Cadastrar()
        {
            
            return View();
        }
    }
}

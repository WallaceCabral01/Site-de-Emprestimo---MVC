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

        [HttpGet]
        public IActionResult Cadastrar()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _context.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _context.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModel emprestimos)
        {
            if (ModelState.IsValid)
            {
                _context.Emprestimos.Add(emprestimos);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpPost]

        public IActionResult Editar(EmprestimosModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                _context.Emprestimos.Update(emprestimo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emprestimo);
        }

        [HttpPost]

        public IActionResult Excluir(EmprestimosModel emprestimo)
        {
            if (emprestimo == null)
            {
                return NotFound();
            }

            _context.Emprestimos.Remove(emprestimo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

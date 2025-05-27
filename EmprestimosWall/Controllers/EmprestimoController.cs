using ClosedXML.Excel;
using EmprestimosWall.Data;
using EmprestimosWall.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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

        [HttpGet]
        public IActionResult Exportar()
        { 
            var dados = GetDados();

            using (XLWorkbook workbook = new XLWorkbook())
            {
                workbook.AddWorksheet(dados, "Dados Emprestimo");

                using MemoryStream ms = new MemoryStream();
                {
                    workbook.SaveAs(ms);
                    return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Emprestimo.Xls");
                       
                }
            }
            return Ok(); 
        }
            
        private DataTable GetDados()
        {
            
            DataTable dataTable = new DataTable();

            dataTable.TableName = "Dados emprestimo";

            dataTable.Columns.Add("Recebedor", typeof(string));
            dataTable.Columns.Add("Fornecedor", typeof(string));
            dataTable.Columns.Add("Livro", typeof(string));
            dataTable.Columns.Add("Data Emprestimo", typeof(DateTime));

            var dados = _context.Emprestimos.ToList();

            if(dados.Count > 0)
            {
                dados.ForEach(empretimo =>
                { dataTable.Rows.Add(empretimo.Recebedor, empretimo.Fornecedor, empretimo.LivroEmprestado, empretimo.DataEmprestimo); });

            }
            return dataTable;
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModel emprestimos)
        {
            if (ModelState.IsValid)
            {
                _context.Emprestimos.Add(emprestimos);
                _context.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpPost]

        public IActionResult Editar(EmprestimosModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                var emprestimoDb = _context.Emprestimos.Find(emprestimo.Id);

                emprestimoDb.Fornecedor = emprestimo.Fornecedor;
                emprestimoDb.Recebedor = emprestimo.Recebedor;
                emprestimo.LivroEmprestado = emprestimo.LivroEmprestado;


                _context.Emprestimos.Update(emprestimoDb);
                _context.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizado com sucesso!";

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

            TempData["MensagemSucesso"] = "Remoção realizada com sucesso!";

            return RedirectToAction("Index");
        }
    }
}

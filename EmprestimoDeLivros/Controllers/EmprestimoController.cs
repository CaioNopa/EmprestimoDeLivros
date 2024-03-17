using EmprestimoDeLivros.Data;
using EmprestimoDeLivros.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EmprestimoDeLivros.Controllers
{


    public class EmprestimoController : Controller
    {
        //private readonly AppDbContext _db;

        //basicamente permite esse controller usar o bd
        //public EmprestimoController(AppDbContext context)
        //{
        //    _db = context;
        //}


        public IActionResult Index([FromServices] AppDbContext context)
        {
            IEnumerable<EmprestimoModel> emprestismos = context.Emprestimos.ToList();

            return View(emprestismos);
        }


        [HttpGet]
        public IActionResult Editar([FromRoute] int? id, [FromServices] AppDbContext context)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var emprestimo = context.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
                return NotFound(new { message = "Empréstimo não existe" });

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Editar([FromServices] AppDbContext context, EmprestimoModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                context.Emprestimos.Update(emprestimo);
                context.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizada com sucesso";


                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Algum erro ocorreu ao realizar a edição";

            return View(emprestimo);

        }


        [HttpGet]
        public IActionResult Excluir([FromRoute] int? id, [FromServices] AppDbContext context)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var emprestimo = context.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
                return NotFound(new { message = "Empréstimo não existe" });

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Excluir([FromServices] AppDbContext context, EmprestimoModel emprestimos)
        {
            if (emprestimos == null)
            {

                return NotFound();

            }


            context.Emprestimos.Remove(emprestimos);
            context.SaveChanges();

            TempData["MensagemSucesso"] = "Exclusão realizada com sucesso";


            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult CadastroEmprestimo()
        {


            return View();
        }


        [HttpPost]
        public IActionResult CadastroEmprestimo([FromServices] AppDbContext context, EmprestimoModel emprestimos)
        {
            if (ModelState.IsValid)
            {
                context.Emprestimos.Add(emprestimos);
                context.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Algum erro ocorreu ao realizar o cadastro";


            return View();
        }






        //[HttpPost("emprestimos")]
        //public async Task<IActionResult> PostAsync(
        //     [FromServices] AppDbContext context,
        //     [FromBody] EmprestimoCreateViewModels model)
        //{
        //    try
        //    {
        //        var emprestimo = new EmprestimoModel
        //        {
        //            Fornecedor = model.Fornecedor,
        //            Recebedor = model.Recebedor,
        //            LivroEmprestado = model.LivroEmprestado

        //        };

        //        await context.Emprestimos.AddAsync(emprestimo);
        //        await context.SaveChangesAsync();

        //        return Ok(emprestimo);
        //    }
        //    catch
        //    {
        //        return StatusCode(500, new { message = "Erro no servidor" });
        //    }

        //}

        [HttpGet("emprestimos")]
        public async Task<IActionResult> GetAsync(
         [FromServices] AppDbContext context)
        {
            try
            {
                var artistas = await context.Emprestimos.ToListAsync();

                return Ok(artistas);
            }
            catch
            {
                return StatusCode(500, new { message = "Erro no servidor" });
            }
        }
    }
}
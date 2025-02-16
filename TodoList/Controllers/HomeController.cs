using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            var tarefa = _context.Tarefas.ToList();

            return View(tarefa);
        }

        // CREATE GET / View
        public IActionResult Create()
        {
            ViewData["Title"] = "Adicionar Nova Tarefa";
            return View("Form");
        }

        // CREATE POST
        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Retorna a mesma view se algo der errado
            var tarefas = _context.Tarefas.ToList();
            return View("Index", tarefa);
        }

        // EDIT GET / View
        public IActionResult Edit(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            return View("Form", tarefa);
        }

        // EDIT POST
        [HttpPost]
        public IActionResult Edit(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Tarefas.Update(tarefa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Retorna a mesma view se algo der errado
            var tarefas = _context.Tarefas.ToList();
            return View("Form", tarefa);
        }

        // DELETE GET / View
        public IActionResult Delete(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        // DELETE POST
        [HttpPost]
        public IActionResult Delete(Tarefa tarefa)
        { 
            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
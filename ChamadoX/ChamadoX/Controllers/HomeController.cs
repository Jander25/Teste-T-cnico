using ChamadoX.Data;
using ChamadoX.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Diagnostics;

namespace ChamadoX.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context) 
        {
            _context = context; 
        }

        
        public IActionResult Index(String id)
        {
            var filtros = new Filtros(id);

            ViewBag.Filtros = filtros;
            ViewBag.Categorias = _context.Categoria.ToList();
            ViewBag.Status = _context.Statuses.ToList();
            ViewBag.Vencimentovalores = Filtros.VencimentoValoresFiltro;

            IQueryable<TiketModel> consulta = _context.Tiket
                .Include(c => c.CategoriaModel)
                .Include(s => s.StatusModel);

            if(filtros.TemCategoria)
            {
                consulta = consulta.Where(t => t.CategoriaId == filtros.CategoriaId);
            }

            if (filtros.TemStatus)
            {
                consulta = consulta.Where(t => t.StatusId == filtros.StatusId);
            }

            if (filtros.TemVencimento)
            {
                var hoje = DateTime.Today;

                if (filtros.EPassado)
                {
                    consulta = consulta.Where(t => t.DataDeVencimento < hoje);
                }
                if(filtros.EFuturo)
                {
                    consulta = consulta.Where(t => t.DataDeVencimento > hoje);
                }

                if (filtros.EHoje)
                {
                    consulta = consulta.Where(t => t.DataDeVencimento == hoje);
                }
            }

            var tarefas = consulta.OrderBy(t => t.DataDeVencimento).ToList();



            return View(tarefas);
        }

        [HttpPost]

        public IActionResult Filtrar(string[] filtro)
        {
            string id = string.Join('-', filtro);
            return RedirectToAction("Index", new {ID =id});   
        }

        public IActionResult Adcionar()
        {
            ViewBag.Categorias = _context.Categoria.ToList();
            ViewBag.Status = _context.Statuses.ToList();

            var tiket = new TiketModel { StatusId = "aberto" };

            return View(tiket);
        }

        [HttpPost]

        public IActionResult MarcarCompleto([FromRoute]string id, TiketModel tiketselecionado) { 
        
            tiketselecionado= _context.Tiket.Find(tiketselecionado.Id);
            
            if(tiketselecionado != null)
            {
                tiketselecionado.StatusId = "Finalizado";
                _context.SaveChanges();

            }
            return RedirectToAction("Index", new {ID =  id});
        }

        [HttpPost]

    
        public IActionResult Adcionar(TiketModel tiket)
        {
            if (ModelState.IsValid)
            {
                _context.Tiket.Add(tiket);
                _context.SaveChanges();

                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.Categorias = _context.Categoria.ToList();
                ViewBag.Status = _context.Statuses.ToList();

                return View(tiket);
            }
        }


        [HttpPost]

        public IActionResult DeletarFinalizados(string id)
        {
            var paraDeletar = _context.Tiket.Where(s => s.StatusId == "Finalizado").ToList();

            foreach (var tiket in paraDeletar)
            {
                _context.Tiket.Remove(tiket);
            }

            _context.SaveChanges();
            return RedirectToAction("index", new {ID = id});

        }

    }
}

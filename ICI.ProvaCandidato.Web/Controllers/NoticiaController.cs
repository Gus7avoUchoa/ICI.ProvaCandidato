using ICI.ProvaCandidato.Negocio.DTOs;
using ICI.ProvaCandidato.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Web.Controllers
{
    public class NoticiaController : Controller
    {
        private readonly INoticiaService _noticiaService;

        public NoticiaController(INoticiaService noticiaService)
        {
            _noticiaService = noticiaService;
        }

        public async Task<IActionResult> Index(string searchTerm = null)
        {
            ViewData["Title"] = "Lista de Notícias";
            var noticias = await _noticiaService.GetAllAsync(searchTerm);
            ViewData["CurrentFilter"] = searchTerm;
            return View(noticias);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Nova Notícia";
            return View("Form");
        }

        [HttpPost]
        public async Task<IActionResult> Create(NoticiaDto noticiaDto)
        {
            if (ModelState.IsValid)
            {
                await _noticiaService.CreateAsync(noticiaDto);
                return RedirectToAction(nameof(Index));
            }
            return View("Form", noticiaDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Editar Notícia";
            var noticia = await _noticiaService.GetByIdAsync(id);
            if (noticia is null) return NotFound();
            return View("Form", noticia);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NoticiaDto noticiaDto)
        {
            if (ModelState.IsValid)
            {
                await _noticiaService.UpdateAsync(noticiaDto);
                return RedirectToAction(nameof(Index));
            }
            return View("Form", noticiaDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Excluir Notícia";
            var noticia = await _noticiaService.GetByIdAsync(id);
            if (noticia is null) return NotFound();
            return View(noticia);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(NoticiaDto noticiaDto)
        {
            await _noticiaService.DeleteAsync(noticiaDto.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}

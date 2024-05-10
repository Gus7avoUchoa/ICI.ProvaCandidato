using ICI.ProvaCandidato.Dados.Entities;
using ICI.ProvaCandidato.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Web.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Lista de Tags";
            var tags = await _tagService.GetAllAsync();
            return View(tags);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Nova Tag";
            return View("Form");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tag tag)
        {
            if (ModelState.IsValid)
            {
                await _tagService.CreateAsync(tag);
                return RedirectToAction(nameof(Index));
            }
            return View("Form", tag);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Editar Tag";
            var tag = await _tagService.GetByIdAsync(id);
            if (tag is null) return NotFound();
            return View("Form", tag);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Tag tag)
        {
            if (ModelState.IsValid)
            {
                await _tagService.UpdateAsync(tag);
                return RedirectToAction(nameof(Index));
            }
            return View("Form", tag);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Excluir Tag";
            var tag = await _tagService.GetByIdAsync(id);
            if (tag is null) return NotFound();
            return View(tag);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Tag tag)
        {
            await _tagService.DeleteAsync(tag.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}

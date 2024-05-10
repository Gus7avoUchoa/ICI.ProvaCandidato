using ICI.ProvaCandidato.Negocio.DTOs;
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

        public async Task<IActionResult> Index(string searchTerm = null)
        {
            ViewData["Title"] = "Lista de Tags";
            var tags = await _tagService.GetAllAsync(searchTerm);
            ViewData["CurrentFilter"] = searchTerm;
            return View(tags);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Nova Tag";
            return View("Form");
        }

        [HttpPost]
        public async Task<IActionResult> Create(TagDto tagDto)
        {
            if (ModelState.IsValid)
            {
                await _tagService.CreateAsync(tagDto);
                return RedirectToAction(nameof(Index));
            }
            return View("Form", tagDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Editar Tag";
            var tag = await _tagService.GetByIdAsync(id);
            if (tag is null) return NotFound();
            return View("Form", tag);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TagDto tagDto)
        {
            if (ModelState.IsValid)
            {
                await _tagService.UpdateAsync(tagDto);
                return RedirectToAction(nameof(Index));
            }
            return View("Form", tagDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Excluir Tag";
            var tag = await _tagService.GetByIdAsync(id);
            if (tag is null) return NotFound();
            return View(tag);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TagDto tagDto)
        {
            await _tagService.DeleteAsync(tagDto.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}

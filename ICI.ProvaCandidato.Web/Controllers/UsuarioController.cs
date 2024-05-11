using ICI.ProvaCandidato.Negocio.DTOs;
using ICI.ProvaCandidato.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index(string searchTerm = null)
        {
            ViewData["Title"] = "Lista de Usuários";
            var usuarios = await _usuarioService.GetAllAsync(searchTerm);
            ViewData["CurrentFilter"] = searchTerm;
            return View(usuarios);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Novo Usuário";
            return View("Form");
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioDto usuarioDto)
        {
            if (ModelState.IsValid)
            {
                await _usuarioService.CreateAsync(usuarioDto);
                return RedirectToAction(nameof(Index));
            }
            return View("Form", usuarioDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Title"] = "Editar Usuário";
            var usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario is null) return NotFound();
            return View("Form", usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UsuarioDto usuarioDto)
        {
            if (ModelState.IsValid)
            {
                await _usuarioService.UpdateAsync(usuarioDto);
                return RedirectToAction(nameof(Index));
            }
            return View("Form", usuarioDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Title"] = "Excluir Usuário";
            var usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario is null) return NotFound();
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UsuarioDto usuarioDto)
        {
            await _usuarioService.DeleteAsync(usuarioDto.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}

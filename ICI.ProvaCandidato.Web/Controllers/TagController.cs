using ICI.ProvaCandidato.Dados.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ICI.ProvaCandidato.Web.Controllers
{
    public class TagController : Controller
    {
        private readonly NoticiasContext _context;

        public TagController(NoticiasContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Lista de Tags";
            var tags = _context.Tags.ToList();
            return View(tags);
        }
    }
}

using Jeu7Differences.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jeu7Differences.Pages
{
    public class JeuModel : PageModel
    {
        private readonly ILogger<JeuModel> _logger;
        private readonly ApplicationContext _context;

        public JeuModel(ILogger<JeuModel> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (!Request.Cookies.TryGetValue("Jeu7Differences", out var id))
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public IActionResult OnPostSaveScore(int duree)
        {
            if (Request.Cookies.TryGetValue("Jeu7Differences", out var id))
            {
                if (Guid.TryParse(id, out var guid))
                {
                    Joueur? joueur = _context.Joueurs.Find(guid);

                    if (joueur != null)
                    {
                        joueur.Duree = duree;

                        _context.SaveChanges();
                    }
                }
            }

            return new OkResult();
        }
    }
}

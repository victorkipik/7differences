using Jeu7Differences.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Jeu7Differences.Pages
{
    public class IndexModel : PageModel
    {
        [StringLength(50, MinimumLength = 2)]
        [Required]
        [BindProperty]
        public string NomJoueur { get; set; } = null!;

        [Required]
        [BindProperty]
        public bool Accepte { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (Request.Cookies.TryGetValue("Jeu7Differences", out var id))
            {
                return RedirectToPage("./Jeu");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Joueur? joueur = null;

                if (Request.Cookies.TryGetValue("Jeu7Differences", out var id))
                {
                    joueur = _context.Joueurs.Find(id);
                }

                if (joueur == null)
                {
                    joueur = new Joueur() { Id = Guid.NewGuid(), Creation = DateTime.Now, Nom = NomJoueur };

                    _context.Joueurs.Add(joueur);

                    _context.SaveChanges();
                }

                Response.Cookies.Append("Jeu7Differences", joueur.Id.ToString("N"), new CookieOptions() { Expires = DateTimeOffset.Now.AddDays(1) });

                return RedirectToPage("./Jeu");
            }

            return Page();
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jeu7Differences.Data;

[Table("Joueurs")]
public class Joueur
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public DateTime Creation { get; set; }

    [Required]
    [StringLength(50)]
    public string Nom { get; set; } = null!;

    public int? Duree { get; set; }
}
namespace Jeu7Differences.Data;

public static class DbInitializer
{
    public static void Initialize(ApplicationContext context)
    {
        context.Database.EnsureCreated();

        //if (context.Joueurs.Any())
        //{
        //    return;
        //}

        //var joueur = new Joueur();
        //joueur.Nom = "Test";
        //joueur.Creation = DateTime.Now;

        //context.Joueurs.Add(joueur);

        //context.SaveChanges();
    }
}
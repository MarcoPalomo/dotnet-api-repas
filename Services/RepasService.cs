using mornaloRepas.Models;

namespace mornaloRepas.Services;

public static class RepasService
{
    static List<Repas> Repas { get; }
    static int nextId = 3;
    static RepasService()
    {
        Repas = new List<Repas>
        //premiers repas
        {
            new Repas { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
            new Repas { Id = 2, Name = "Veggie", IsGlutenFree = true }
        };
    }
    // CRUD commence ici

    public static List<Repas> GetAll() => Repas;

    public static Repas? Get(int id) => Repas.FirstOrDefault(p => p.Id == id);

    public static void Add(Repas repas)
    {
        repas.Id = nextId++;
        Repas.Add(repas);
    }

    public static void Delete(int id)
    {
        var repas = Get(id);
        if(repas is null)
            return;

        Repas.Remove(repas);
    }

    public static void Update(Repas repas)
    {
        var index = Repas.FindIndex(p => p.Id == repas.Id);
        if(index == -1)
            return;

        Repas[index] = repas;
    }
}

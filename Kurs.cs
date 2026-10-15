using System.Text.Json;

namespace WestcoastEducation;

public enum Kurstyp
{
    Klassrum,
    Distans
}

public interface IJsonSparare
{
    void Spara(string filnamn);
}

public class Kurs : IJsonSparare
{
    public string Kursnummer { get; set; }= "";
    public string Namn { get; set; }= "";
    public int Dagar { get; set; }
    public DateTime StartDatum { get; set; }
    public DateTime SlutDatum { get; set; }
    public Kurstyp Typ { get; set; }
    public Larare? Larare { get; set; }
    public List<Elev> Elever { get; set; } = new();

    public bool RegistreraElev(Elev nyElev)
    {
        foreach (var elev in Elever)
        {
            if (elev.Personnummer == nyElev.Personnummer)
            {
                return false;
            }
        }
        Elever.Add(nyElev);
        return true;
    }

    public string VisaInfo()
    {
        string larareNamn = Larare != null ? $"{Larare.Fornamn} {Larare.Efternamn}" : "Saknas";

        return $"{Kursnummer}: {Namn} ({Typ})\n" +
               $"Tid: {StartDatum:yyyy-MM-dd} till {SlutDatum:yyyy-MM-dd} ({Dagar} dagar)\n" +
               $"Ansvarig: {larareNamn}\n" +
               $"Antal elever: {Elever.Count}";
    }

    public void Spara(string filnamn)
    {
        var jsonAlternativ = new JsonSerializerOptions { WriteIndented = true };
        string data = JsonSerializer.Serialize(this, jsonAlternativ);
        File.WriteAllText(filnamn, data);
        Console.WriteLine($"Kursen sparades till {filnamn}");
    }

    public static Kurs? Ladda(string filnamn)
    {
        if (!File.Exists(filnamn))
        {
            return null;
        }

        string text = File.ReadAllText(filnamn);
        return JsonSerializer.Deserialize<Kurs>(text);
    }
}
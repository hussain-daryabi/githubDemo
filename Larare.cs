namespace WestcoastEducation;

public class Larare : Person
{
    public List<string> Omraden { get; set; } = new();

    public override string SkrivUt()
    {
        string amnen = Omraden.Count > 0 ? string.Join(", ", Omraden) : "Inga valda";
        return $"Lärare: {base.SkrivUt()} - Kompetens: {amnen}";
    }
}
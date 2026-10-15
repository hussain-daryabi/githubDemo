namespace WestcoastEducation;

public abstract class Person
{
    public string Fornamn { get; set; } = "";
    public string Efternamn { get; set; } = "";
    public string Personnummer { get; set; } = "";
    public string Telefon { get; set; } = "";
    public string Adress { get; set; } = "";
    public string Postnummer { get; set; } = "";
    public string Ort { get; set; } = "";

    public virtual string SkrivUt()
    {
        return $"{Fornamn} {Efternamn}, Pnr: {Personnummer}, Adress: {Adress} {Postnummer} {Ort}, Tel: {Telefon}";
    }
}
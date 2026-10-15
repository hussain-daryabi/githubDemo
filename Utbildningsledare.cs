namespace WestcoastEducation;

public class Utbildningsledare : Larare
{
    public DateTime StartJobb { get; set; }

    public override string SkrivUt()
    {
        return $"Utbildningsledare: {base.SkrivUt()} - Anställd: {StartJobb:yyyy-MM-dd}";
    }
}
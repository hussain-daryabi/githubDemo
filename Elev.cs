namespace WestcoastEducation;

public class Elev : Person
{
    public override string SkrivUt()
    {
        return $"Studerande: {base.SkrivUt()}";
    }
}
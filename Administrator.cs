namespace WestcoastEducation;

public class Administrator : Utbildningsledare
{
    public override string SkrivUt()
    {
        return $"Admin: {base.SkrivUt()}";
    }
}
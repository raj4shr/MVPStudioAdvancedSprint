

namespace MVPAdvancedTask;

public class DescriptionTestData:IEnumerable
{
    private string moreThan600Chars;
    private string lessThan600Chars;

    public DescriptionTestData()
    {
        moreThan600Chars = "";
        lessThan600Chars = "";
        BuildStringForDescritionMoreThan600Chars();
        BuildStringForDescritionLessThan600Chars();
    }

    public void BuildStringForDescritionMoreThan600Chars()
    {
        for (int i = 0; i < 700; i++)
            moreThan600Chars += "a";
    }

    public void BuildStringForDescritionLessThan600Chars()
    {
        for (int i = 0; i < 600; i++)
            lessThan600Chars += "b";
    }

    public IEnumerator  GetEnumerator()
    {
        yield return new object[] {moreThan600Chars,false};
        yield return new object[] {lessThan600Chars,true};
        yield return new object[] {"Test",true};
        yield return new object[] {"",false};
    }
}


namespace MVPCompetitionSprint;

public class ProfileChangePasswordTestData:IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object[] { "santamonica", "santamonica","santamonica2",false};
        yield return new object[] { "santamonica", "santamonica1", "santamonica1", true};
        yield return new object[] { "santamonica", "", "santamonica1",false };
        yield return new object[] { "santamonica", "santamonica1", "",false };
        yield return new object[] { "santamonica", "sant", "sant",false };
        yield return new object[] { "invalid", "santamonica", "santamonica",false};
        yield return new object[] { "santamonica", "santa monica1", "santamonica1", false };
        yield return new object[] { "santamonica", "santa monica", "santa monica", false };
        yield return new object[] { "santamonica", "       ", "       ", false };
        yield return new object[] { "santamonica", "santa monica", "SANTA MONICA", false };
        yield return new object[] { "santamonica", "", "", false };
    }
}

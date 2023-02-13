
namespace MVPCompetitionSprint;

public class UserSignInTestData : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object[] { "GOWgow@GOW.com", "santamonica", true };
        yield return new object[] { "gowgow@gow.com", "santamonica", true };
        yield return new object[] { "GOWgowGOW.com", "santamonica", false };
        yield return new object[] { "GOWgowGOW", "santamonica", false };
        yield return new object[] { "", "santamonica", false };
        yield return new object[] { "GOWgow@GOW.com", "santa monica", false };
        yield return new object[] { "GOWgow@GOW.com", "", false };
        yield return new object[] { "   @   .com", "santamonica", false };
        yield return new object[] { "", "", false };
    }
}

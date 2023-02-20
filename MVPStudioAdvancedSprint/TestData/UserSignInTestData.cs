
namespace MVPAdvancedTask;

public class UserSignInTestData : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object[] { "LAStoFus@LOS.com", "naughtydog", true };
        yield return new object[] { "LAStOFUs@LOS.com", "naughtydog", true };
        yield return new object[] { "LAStOFUsLOS.com", "naughtydog", false };
        yield return new object[] { "LAStOFUs@LOS", "naughtydog", false };
        yield return new object[] { "LAStOFUs@LOS.com", "naughty dog", false };
        yield return new object[] { "", "naughtydog", false };
        yield return new object[] { "LAStOFUs@LOS.com", "", false };
        yield return new object[] { "", "", false };
        yield return new object[] { " @.com", "naughtydog", false };
    }
}

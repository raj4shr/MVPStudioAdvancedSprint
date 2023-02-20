
namespace MVPAdvancedTask;

public class ChangePasswordTestData:IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object[] { "naughtydog", "santamonica","santamonica2",false};
        yield return new object[] { "naughtydog", "naughtydog1", "naughtydog1", true};
        yield return new object[] { "naughtydog", "", "santamonica1",false };
        yield return new object[] { "naughtydog", "santamonica1", "",false };
        yield return new object[] { "naughtydog", "sant", "sant",false };
        yield return new object[] { "invalid", "santamonica", "santamonica",false};
        yield return new object[] { "naughtydog", "santa monica1", "santamonica1", false };
        yield return new object[] { "naughtydog", "santa monica", "santa monica", false };
        yield return new object[] { "naughtydog", "       ", "       ", false };
        yield return new object[] { "naughtydog", "santa monica", "SANTA MONICA", false };
        yield return new object[] { "naughtydog", "", "", false };
    }
}

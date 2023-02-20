

namespace MVPAdvancedTask;

public class EarnTargetTestData : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object[] { "Less than $500 per month", true };
        yield return new object[] { "Between $500 and $1000 per month", true };
        yield return new object[] { "More than $1000 per month", true };
        yield return new object[] { "Not Valid", false };
    }
}

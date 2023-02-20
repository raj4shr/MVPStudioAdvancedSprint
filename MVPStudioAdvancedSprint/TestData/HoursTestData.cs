

namespace MVPAdvancedTask;

public class HoursTestData : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object[] { "Less than 30hours a week", true };
        yield return new object[] { "More than 30hours a week", true };
        yield return new object[] { "As needed", true };
        yield return new object[] { "Select type", false };
    }
}

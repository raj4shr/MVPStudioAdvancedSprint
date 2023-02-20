

namespace MVPAdvancedTask;

public class AvailabilityTestData : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object[] { "Part Time", true };
        yield return new object[] { "Full Time",true };
        yield return new object[] { " ",false };
    }
}

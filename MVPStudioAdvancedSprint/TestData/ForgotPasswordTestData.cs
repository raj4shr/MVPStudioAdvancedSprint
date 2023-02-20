
namespace MVPAdvancedTask;

public class ForgotPasswordTestData : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object[]{ "Kratos@GOW.com", true};
        yield return new object[] { "Kratos.com", false };
        yield return new object[] { "", false };
        yield return new object[] { "Kratos@com", false };
        yield return new object[] { "Kratos @gow.com", false };
        yield return new object[] { "Kratos@gow.com.com", false };
    }
}

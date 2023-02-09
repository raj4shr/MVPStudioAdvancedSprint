
using System.Collections;

namespace MVPCompetitionTask;

//option 1
public class NewUserSignUpTestData
{
    public static IEnumerable<TestCaseData> NewUserSignUpData()
    {
        yield return new TestCaseData("Kratos", "GOW", "KratosGOWR@GOW.com", "santamonica", "santamonica").SetName("New user sign up with valid info");
        yield return new TestCaseData("Kratos", "GOW", "GOWGOW.com", "santamonica", "santamonica").SetName("New user data with invalid email -- No @");
        yield return new TestCaseData("Kratos", "GOW", "GOW@GOW", "santamonica", "santamonica").SetName("New user data with invalid email -- No dot com");
        yield return new TestCaseData("", "GOW", "GOW@GOW.com", "santamonica", "santamonica").SetName("New user data with blank first name");
        yield return new TestCaseData("Kratos", "GOW", "GOW@GOW1.com", "santa  monica", "santa  monica").SetName("New user data with spaces in password");
        yield return new TestCaseData("", "", "GOW@GOW1.com", "santamonica", "santamonica").SetName("New user data with blank first and last name");
        yield return new TestCaseData("Kratos", "GOW", "GOW@GOW.com", "", "santamonica").SetName("New user data with blank password");
        yield return new TestCaseData("Kratos", "GOW", "GO@GOW.com", "santamonica", "santamonica1").SetName("New user data with password confirmpassword mismatch");
    }
}

//option 2
public class UserSignUpInfo : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new string[] { "Kratos", "GOW", "KratosGOWR@GOW.com", "santamonica", "santamonica" };
        yield return new string[] { "Kratos", "GOW", "GOWGOW.com", "santamonica", "santamonica" };
        yield return new string[] { "Kratos", "GOW", "GOW@GOW", "santamonica", "santamonica" };
        yield return new string[] { "", "GOW", "GOW@GOW.com", "santamonica", "santamonica" };
        yield return new string[] { "Kratos", "GOW", "GOW@GOW1.com", "santa  monica", "santa  monica" };
        yield return new string[] { "", "", "GOW@GOW1.com", "santamonica", "santamonica" };
        yield return new string[] { "Kratos", "GOW", "GOW@GOW.com", "", "santamonica" };
        yield return new string[] { "Kratos", "GOW", "GOWgow@GOW.com", "santa monica", "santa monica" };
    }
}

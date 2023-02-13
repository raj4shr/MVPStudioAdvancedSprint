
using System.Collections;

namespace MVPCompetitionSprint;

//option 1
public class NewUserSignUpTestData
{
    public static IEnumerable<TestCaseData> NewUserSignUpData()
    {
        yield return new TestCaseData("Kratos", "GOW", "KraTosGOwR@GOW.com", "santamonica", "santamonica").SetName("New user sign up with valid info");
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
        yield return new object[] { "Kratos", "GOW", "LastOFUs@LOS.com", "naughtydog", "naughtydog", true };
        yield return new object[] { "Kratos", "GOW", "GOWGOW.com", "santamonica", "santamonica",false };
        yield return new object[] { "Kratos", "GOW", "GOW@GOW", "santamonica", "santamonica",false };
        yield return new object[] { "", "GOW", "GOW@GOW.com", "santamonica", "santamonica",false };
        yield return new object[] { "Kratos", "GOW", "GOW@GOW1.com", "santa  monica", "santa  monica",false };
        yield return new object[] { "", "", "GOW@GOW1.com", "santamonica", "santamonica",false };
        yield return new object[] { "Kratos", "GOW", "GOW@GOW.com", "", "santamonica",false };
        yield return new object[] { "Kratos", "GOW", "GOWgow@GOW.com", "santa monica", "santa monica" , false };
        //same as the first object array but email is written in mixed case---should be false because it's already registered
        yield return new object[] { "Kratos", "GOW", "LaStofUS@los.com", "naughtydog", "naughtydog", false };
    }
}



using System.Security.Cryptography;

namespace MVPAdvancedTask;

[TestFixture]
public class ForgotPasswordTest
{
    private ForgotPasswordPage forgotPasswordPage;
    private CommonDriver commonDriver;

    [SetUp]
    public void SetUp()
    {
        commonDriver = new CommonDriver();
        commonDriver.InitDriver();
        forgotPasswordPage = new ForgotPasswordPage();
    }


    [TestCaseSource(typeof(ForgotPasswordTestData))]
    public void ForgotPassword(string email,bool valid)
    {
        forgotPasswordPage.UserForgotPassword(email);
        if(valid)
            forgotPasswordPage.emailVerificationSent.Should().BeTrue();
        else
            forgotPasswordPage.emailVerificationSent.Should().BeFalse();    
    }

    [Test]
    public void RememberPwd()
    {
        forgotPasswordPage.RememberPassword();
        forgotPasswordPage.loginWindowVisible.Should().BeTrue();
    }

    [TearDown]
    public void TearDown()
    {
        forgotPasswordPage.Close();
    }
}


namespace MVPCompetitionSprint;

[TestFixture]
public class SignInTest
{
    private UserSignInPage userSignInPage;
    private CommonDriver commonDriver;

    [SetUp]
    public void SetUp()
    {
        commonDriver = new CommonDriver();
        commonDriver.InitDriver();
        userSignInPage = new UserSignInPage();
    }

    [TestCaseSource(typeof(UserSignInTestData))]
    public void SignIn(string email, string password, bool valid)
    {
        userSignInPage.UserSignInToPortal(email, password);
        if (valid)
            userSignInPage.successfulLogin.Should().BeTrue();
        else
            userSignInPage.successfulLogin.Should().BeFalse();
    }

    [Test]
    public void CheckJoinLink()
    {
        userSignInPage.ClickOnJoinLink();
        userSignInPage.joinLinkSuccess.Should().BeTrue();
    }

    [Test]
    public void CheckForgotPasswordLink()
    {
        userSignInPage.ClickOnForgotPasswordLink();
        userSignInPage.forgotPasswordLinkSuccess.Should().BeTrue();
    }

    [TearDown]
    public void Close()
    {
        userSignInPage.Close();
    }

}

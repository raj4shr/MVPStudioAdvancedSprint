
namespace MVPAdvancedTask;

[TestFixture]
public class DescriptionTest
{
    LoginToPortalPage loginToPortalPage;
    UserDescriptionPage userDescriptionPage;
    
    [SetUp]
    public void SetUp()
    {
        loginToPortalPage = new LoginToPortalPage();
        loginToPortalPage.LogintoPortal();
        userDescriptionPage = new UserDescriptionPage();
    }

    [TestCaseSource(typeof(DescriptionTestData))]
    public void EnterDescription(string description, bool valid)
    {
        userDescriptionPage.EnterUserDescription(description);
        if (valid)
            userDescriptionPage.isDecriptionUpdated.Should().BeTrue();
        else
            userDescriptionPage.isDecriptionUpdated.Should().BeFalse();
    }

    [TearDown]
    public void CloseDriver()
    {
        userDescriptionPage.CloseDriver();
    }
}

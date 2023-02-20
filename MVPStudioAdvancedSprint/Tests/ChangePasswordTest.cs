
namespace MVPAdvancedTask;

[TestFixture]
public class ChangePasswordTest
{
	private ChangePasswordPage changePasswordPage;
	
	private LoginToPortalPage loginToPortalPage;

	[SetUp]
	public void PortalLogin()
	{
		loginToPortalPage = new LoginToPortalPage();
		loginToPortalPage.LogintoPortal();
        changePasswordPage = new ChangePasswordPage();
    }

	[TestCaseSource(typeof(ChangePasswordTestData))]
	public void ChangePassword(string oldPassword,string newPassword,string confirmPassword,bool valid)
	{
		changePasswordPage.ChangeUserPwd(oldPassword, newPassword, confirmPassword);
		if(valid)
			changePasswordPage.pwdChanged.Should().BeTrue();
		else
			changePasswordPage.pwdChanged.Should().BeFalse();
    }

	[TearDown]
	public void Close()
	{
		//changePasswordPage.WriteNewPasswordToExcelFile();
        changePasswordPage.Close();
	}
}

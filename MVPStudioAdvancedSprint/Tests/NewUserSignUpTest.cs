
namespace MVPAdvancedTask;

[TestFixture]
public class NewUserSignUpTest : NewUserSignUpTestData
{
    private CommonDriver commonDriver;
    private NewUserRegistrationPage newUserRegistrationPage;

    [SetUp]
    public void SetUp()
    {
        commonDriver = new CommonDriver();
        commonDriver.InitDriver();
        newUserRegistrationPage = new NewUserRegistrationPage();
    }

    //option 1
    //[TestCaseSource(nameof(NewUserSignUpData))]
    //option 2 
    [TestCaseSource(typeof(UserSignUpInfo))]
    public void NewUserSignUp(string firstName,string lastName,string email,string password,string confirmPassword,bool valid)
    {
        newUserRegistrationPage.NewUserSignUp(firstName,lastName,email,password,confirmPassword);
        if (valid)
            newUserRegistrationPage.newUserCreated.Should().BeTrue();
        else
            newUserRegistrationPage.newUserCreated.Should().BeFalse();  
    }

    [TearDown]
    public void TearDown()
    {
        newUserRegistrationPage.Close();
    }
}
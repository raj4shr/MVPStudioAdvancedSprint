
namespace MVPCompetitionTask;

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
    public void NewUserSignUp(string firstName,string lastName,string email,string password,string confirmPassword)
    {
        newUserRegistrationPage.NewUserSignUp(firstName,lastName,email,password,confirmPassword);
        if(newUserRegistrationPage.createdNewUser==true || newUserRegistrationPage.alertForInvalidDetails==true)
            Assert.That(true);
        else
            Assert.That(false,"User alert is not displayed for invalid details"); 
    }

    [TearDown]
    public void TearDown()
    {
        newUserRegistrationPage.Close();
    }
}
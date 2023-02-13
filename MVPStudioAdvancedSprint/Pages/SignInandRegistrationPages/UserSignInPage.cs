

namespace MVPCompetitionSprint;

public class UserSignInPage:IExtentRpt
{
    //Element repository for sign in page
    private readonly By signInBtn = By.XPath("//a[text()='Sign In']");
    private readonly By emailInputBox = By.Name("email");
    private readonly By passwordInputBox = By.Name("password");
    private readonly By loginBtn = By.XPath("//button[text()='Login']");
    private readonly By forgotPasswordLink = By.XPath("//a[text()='Forgot your password?']");
    private readonly By joinLink = By.XPath("//a[text()=' Join']");
    private readonly By signOutBtn = By.XPath("//button[text()='Sign Out']");
    private readonly By joinBtnInJoinWindow = By.Id("submit-btn");
    private readonly By sendVerificationEmailBtn = By.XPath("//div[text()='SEND VERIFICATION EMAIL']");


    private readonly ExtentTest testLog;
    private readonly CommonSendKeysAndClickElements elementInteractions;
    public bool successfulLogin { get; set; }
    public bool joinLinkSuccess { get; set; }
    public bool forgotPasswordLinkSuccess { get; set; }

    public UserSignInPage()
    {
        successfulLogin = false;
        elementInteractions=new CommonSendKeysAndClickElements();
        testLog = IExtentRpt.testReport.CreateTest("Test_Sign In Test : " + DateTime.Now.ToString("_hhmmss")).Info("User is signing in to portal");
    }

    //Clicking on sign in button
    public void ClickOnSignIn()
    {
        elementInteractions.ClickElement(signInBtn);
    }

    //Clicking on join link
    public void ClickOnJoinLink()
    {
        ClickOnSignIn();
        elementInteractions.ClickElement(joinLink);
        AlertWait();
        if (elementInteractions.ReturnElementCollection(joinBtnInJoinWindow).Count > 0)
            joinLinkSuccess = true;
    }

    //Clicking on forgot password link
    public void ClickOnForgotPasswordLink()
    {
        ClickOnSignIn();
        elementInteractions.ClickElement(forgotPasswordLink);
        AlertWait();
        if(elementInteractions.ReturnElementCollection(sendVerificationEmailBtn).Count > 0)
            forgotPasswordLinkSuccess = true;
    }

    //Enter user email
    public void EnterEmailAddress(string email)
    {
        elementInteractions.SendKeysToElement(emailInputBox, email);
    }

    //Enter user password
    public void EnterPassword(string password)
    {
        elementInteractions.SendKeysToElement(passwordInputBox,password);
    }

    //Click on login button
    public void ClickOnLogin()
    {
        elementInteractions.ClickElement(loginBtn);
    }

    //Click on signout button when the user is successfully signed in
    public void ClickOnSignOut()
    {
        elementInteractions.ClickElement(signOutBtn);
    }

    //Custom wait
    public void AlertWait()
    {
        for (long i = 0; i < 300000000; i++) ;
    }

    //Checking to see if the user is signed in by checking if the signout button is visible
    public void CheckUserLoggedIn()
    {
        if(elementInteractions.ReturnElementCollection(signOutBtn).Count > 0)
            successfulLogin=true;  
    }

    public void Close()
    {
        elementInteractions.Close();
    }
   
    //Method for user sign in
    public void UserSignInToPortal(string email,string password)
    {
        ClickOnSignIn();
        EnterEmailAddress(email);
        EnterPassword(password);
        ClickOnLogin();
        AlertWait();
        CheckUserLoggedIn();
        if (successfulLogin)
            ClickOnSignOut();
    }
}

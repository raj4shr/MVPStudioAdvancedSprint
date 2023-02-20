
namespace MVPAdvancedTask;

public class ForgotPasswordPage
{
    //Element repository for forgot password window
    private readonly By emailInputBox = By.Name("email");
    private readonly By sendVerificationBtn = By.XPath("//div[text()='SEND VERIFICATION EMAIL']");
    private readonly By rememberPwdBtn = By.XPath("//a[text()='Remember your password?']");
    private readonly By signInBtn = By.XPath("//a[text()='Sign In']");
    private readonly By verificationEmailSentMsg = By.XPath("//div[text()='A recovery link has been sent to your inbox. ']");
    private readonly By loginBtn = By.XPath("//button[text()='Login']");
    private readonly By forgotPwdBtn = By.XPath("//a[text()='Forgot your password?']");

    private readonly CommonSendKeysAndClickElements elementInteractions;
    public bool emailVerificationSent { get; set; }
    public bool loginWindowVisible { get; set; }

    public ForgotPasswordPage()
    {
        elementInteractions = new CommonSendKeysAndClickElements();
        emailVerificationSent = false;
    }

    public void ClickOnSignIn()
    {
        elementInteractions.ClickElement(signInBtn);
    }

    public void EnterUserEmail(string email)
    {
        elementInteractions.SendKeysToElement(emailInputBox, email);
    }

    public void ClickOnSendVerificationEmail()
    {
        elementInteractions.ClickElement(sendVerificationBtn);
    }

    public void ClickOnRememberPwdButton()
    {
        elementInteractions.ClickElement(rememberPwdBtn);
    }

    public void ClickOnForgotPwdButton()
    {
        elementInteractions.ClickElement(forgotPwdBtn);
    }

    public void AlertWait()
    {
        for (long i = 0; i < 2000000000; i++) ;
    }

    public void CheckVerificationSent()
    {
        if (elementInteractions.ReturnElementCollection(verificationEmailSentMsg).Count > 0)
            emailVerificationSent = true;
    }

    public void Close()
    {
        elementInteractions.Close();
    }

    public void UserForgotPassword(string email)
    {
        ClickOnSignIn();
        ClickOnForgotPwdButton();
        EnterUserEmail(email);
        ClickOnSendVerificationEmail();
        AlertWait();
        CheckVerificationSent();
    }

    public void RememberPassword()
    {
        ClickOnSignIn();
        ClickOnForgotPwdButton();
        AlertWait();
        ClickOnRememberPwdButton();
        if (elementInteractions.ReturnElementCollection(loginBtn).Count > 0)
            loginWindowVisible = true;
    }
}

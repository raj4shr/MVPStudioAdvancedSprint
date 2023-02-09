﻿

using Gherkin;

namespace MVPCompetitionTask;

public class NewUserRegistrationPage : IExtentRpt
{
    private readonly By joinBtn = By.XPath("//button[text()='Join']");
    private readonly By firstNameInputBx = By.Name("firstName");
    private readonly By lastNameInputBx = By.Name("lastName");
    private readonly By emailInputBx = By.Name("email");
    private readonly By passwordInputBx=By.Name("password");
    private readonly By confirmPasswordInputBx = By.Name("confirmPassword");
    private readonly By termsInputBx = By.XPath("//input[@name='terms']");
    private readonly By joinBtnDiv = By.XPath("//div[text()='Join']");
    private readonly By LoginBtn = By.XPath("//a[text()=' Login']");
    private readonly By joinButtonEnabled = By.XPath("//div[@class='fluid ui teal button']");
    private readonly By invalidDetailsAlert = By.XPath("//div[@class='ui basic red pointing prompt label transition visible']");

    private readonly CommonSendKeysAndClickElements elementInteractions;
    private readonly ExtentTest extentTest;
    private readonly ExtentReports extentReport;

    public bool createdNewUser { get; set; }

    public bool alertForInvalidDetails { get; set; }    
    
    public NewUserRegistrationPage()
    {
        createdNewUser = false;
        alertForInvalidDetails = false;
        elementInteractions=new CommonSendKeysAndClickElements();
        extentReport=IExtentRpt.testReport;
        extentTest=extentReport.CreateTest("Test_New User Sign Up Test" + DateTime.Now.ToString("_hhmmss"));
    }

    public void ClickOnJoinBtn()
    {
        elementInteractions.ClickElement(joinBtn);
        extentTest.Log(Status.Info, "New user join button clicked");
    }

    public void SendFirstName(string firstName)
    {
        elementInteractions.SendKeysToElement(firstNameInputBx, firstName);
        extentTest.Log(Status.Info,firstName+ " firstname entered");
    }

    public void SendLastName(string lastName)
    {
        elementInteractions.SendKeysToElement(lastNameInputBx, lastName);
        extentTest.Log(Status.Info, lastName+" lastname entered");
    }

    public void SendEmail(string email)
    {
        elementInteractions.SendKeysToElement(emailInputBx, email);
        extentTest.Log(Status.Info, email+ " email entered");
    }

    public void SendPassword(string password)
    {
        elementInteractions.SendKeysToElement(passwordInputBx, password);
        extentTest.Log(Status.Info, password+ " password entered");
    }

    public void SendConfirmPassword(string confirmPassword)
    {
        elementInteractions.SendKeysToElement(confirmPasswordInputBx, confirmPassword);
        extentTest.Log(Status.Info, confirmPassword+ " confirmpassword entered");
    }

    public void AgreeToTerms()
    {
        elementInteractions.ClickOnCheckBox(termsInputBx);
        extentTest.Log(Status.Info, "Terms agreed");
    }

    public void ClickOnJoinBtnAfterInfo()
    {
        elementInteractions.TakeScreenShot();
        elementInteractions.ClickElement(joinBtnDiv);
        extentTest.Log(Status.Info, "Join button clicked after all the info entered");
    }

    public void ClickOnLoginBtn()
    {
        elementInteractions.ClickElement(LoginBtn);
        extentTest.Log(Status.Info, "Login button clicked and user is redirected to login window");
    }

    public static void AlertWait()
    {
        for (long i = 0; i < 300000000; i++) ;
    }

    public void NewUserCreated()
    {
        if (elementInteractions.ReturnElementCollection(joinButtonEnabled).Count == 1 && elementInteractions.ReturnElementCollection(invalidDetailsAlert).Count ==0)
            createdNewUser = true;
        else
            alertForInvalidDetails = elementInteractions.ReturnElementCollection(invalidDetailsAlert).Count > 0;
    }

    public void Close()
    {
        elementInteractions.Close();
    }
    public void NewUserSignUp(string firstName,string lastName,string email,string password,string confirmPassword)
    {
        ClickOnJoinBtn();
        SendFirstName(firstName);
        SendLastName(lastName);
        SendEmail(email);
        SendPassword(password);
        SendConfirmPassword(confirmPassword);
        AgreeToTerms();
        ClickOnJoinBtnAfterInfo();
        if(elementInteractions.ReturnElementCollection(joinButtonEnabled).Count == 1)
            AlertWait();
        NewUserCreated();
        if (createdNewUser==true && alertForInvalidDetails==false)
            extentTest.Log(Status.Pass, "New user created successfully");
        else
            extentTest.Log(Status.Fail, "New user creation failed because of invalid input");
    }


}

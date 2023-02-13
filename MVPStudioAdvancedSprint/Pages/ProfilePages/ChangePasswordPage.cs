namespace MVPCompetitionSprint;
public class ChangePasswordPage : IExtentRpt
{
    //Element repository for change password page
    private readonly By userAccountName = By.XPath("//span[contains(text(),'Hi')]");
    private readonly By changePasswordBtn = By.XPath("//a[text()='Change Password']");
    private readonly By oldPasswordInputBox = By.Name("oldPassword");
    private readonly By newPasswordInputBox = By.Name("newPassword");
    private readonly By confirmPasswordInputBox = By.Name("confirmPassword");
    private readonly By saveBtn = By.XPath("//button[text()='Save']");
    private readonly CommonSendKeysAndClickElements elementInteractions;
    public bool? pwdChanged { get; set; }
    private readonly ExtentTest testLog;

    public ChangePasswordPage()
    {
        testLog=IExtentRpt.testReport.CreateTest("Test_Change User Password" + DateTime.Now.ToString("_hhmmss"));
        elementInteractions=new CommonSendKeysAndClickElements();
        pwdChanged=false;
    }

    //Clicking on user account
    public void ClickOnUserAccount()
    {
        elementInteractions.ClickElement(userAccountName);
    }

    //Clicking on change password button
    public void ClickOnChangePasswordBtn()
    {
        elementInteractions.ClickElement(changePasswordBtn);
    }

    //Entering old password
    public void EnterOldPassword(string oldPassword)
    {
        elementInteractions.SendKeysToElement(oldPasswordInputBox,oldPassword);
        testLog.Log(Status.Info,"Old password entered-->" + oldPassword);
    }

    //Entering new password
    public void EnterNewPassword(string newPassword)
    {
        elementInteractions.SendKeysToElement(newPasswordInputBox,newPassword);
        testLog.Log(Status.Info, "New password entered-->" + newPassword);
    }

    //Entering confirm password
    public void EnterConfirmPassword(string confirmPassword)
    {
        elementInteractions.SendKeysToElement(confirmPasswordInputBox,confirmPassword);
        testLog.Log(Status.Info, "Confirm password entered-->" + confirmPassword);
    }

    //Clicking on save button
    public void ClickOnSaveBtn()
    {
        elementInteractions.ReturnElementCollectionByPresenceOfAllElements(saveBtn)[1].Click();
        testLog.Log(Status.Info, "Save button clicked...");
    }

    //Custom wait for overlapping element to disappear(Password changed successfully alert)
    public static void AlertWait()
    {
        for (long i = 0; i < 900000000; i++) ;
    }

    //Checking to see if password has been changed by checking if the save button from the change password is still present
    public void CheckPasswordChanged()
    {
        AlertWait();
        if (elementInteractions.ReturnElementCollectionByPresenceOfAllElements(saveBtn).Count == 1)
        {
            pwdChanged = true;
            testLog.Log(Status.Pass, "User password has been changed...");
        }
        else
            testLog.Log(Status.Fail, "User password has not been changed...");
    }

    //Closing the browser
    public void Close()
    {
        elementInteractions.Close();
    }
     
    //Change password method
    public void ChangeUserPwd(string oldPwd,string newPwd,string confirmPwd)
    {
        ClickOnUserAccount();
        ClickOnChangePasswordBtn();
        EnterOldPassword(oldPwd);
        EnterNewPassword(newPwd);
        EnterConfirmPassword(confirmPwd);
        ClickOnSaveBtn();
        CheckPasswordChanged();

        //if password has been sucessfully changed, resetting the password back to original again
        if (pwdChanged==true)
        {
            for(int i=0;i<9;i++)
                AlertWait();
            ClickOnUserAccount();
            ClickOnChangePasswordBtn();
            EnterOldPassword(newPwd);
            EnterNewPassword(oldPwd);
            EnterConfirmPassword(oldPwd);
            ClickOnSaveBtn();
        }
    }
}

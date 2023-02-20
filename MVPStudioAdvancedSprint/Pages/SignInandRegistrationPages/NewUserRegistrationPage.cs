using System.Runtime.InteropServices;

namespace MVPAdvancedTask;

public class NewUserRegistrationPage : IExtentRpt
{
    //Variables to open excel sheet and write new user credentials into it
    private string filename;
    private Excel.Application application;
    private Excel.Workbook workbook;
    private Excel.Worksheet worksheet;
    private Excel.Range range;
    private int newRowNumInExcel;
    private string newUserEmailToWriteToExcel, newUserPasswordToWriyeToExcel;

    //Element repository for the page
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



    public bool newUserCreated { get; set; }
    
    public NewUserRegistrationPage()
    {
        elementInteractions=new CommonSendKeysAndClickElements();
        extentReport=IExtentRpt.testReport;
        extentTest=extentReport.CreateTest("Test_New User Sign Up Test" + DateTime.Now.ToString("_hhmmss"));
    }

    //Click on join btn
    public void ClickOnJoinBtn()
    {
        elementInteractions.ClickElement(joinBtn);
        extentTest.Log(Status.Info, "New user join button clicked");
    }

    //Enter first name
    public void SendFirstName(string firstName)
    {
        elementInteractions.SendKeysToElement(firstNameInputBx, firstName);
        extentTest.Log(Status.Info,firstName+ " firstname entered");
    }

    //Enter last name
    public void SendLastName(string lastName)
    {
        elementInteractions.SendKeysToElement(lastNameInputBx, lastName);
        extentTest.Log(Status.Info, lastName+" lastname entered");
    }

    //Enter email
    public void SendEmail(string email)
    {
        elementInteractions.SendKeysToElement(emailInputBx, email);
        extentTest.Log(Status.Info, email+ " email entered");
    }

    //Enter password
    public void SendPassword(string password)
    {
        elementInteractions.SendKeysToElement(passwordInputBx, password);
        extentTest.Log(Status.Info, password+ " password entered");
    }

    //Enter confirm password
    public void SendConfirmPassword(string confirmPassword)
    {
        elementInteractions.SendKeysToElement(confirmPasswordInputBx, confirmPassword);
        extentTest.Log(Status.Info, confirmPassword+ " confirmpassword entered");
    }

    //Click on agree to terms check box
    public void AgreeToTerms()
    {
        elementInteractions.ClickOnCheckBox(termsInputBx);
        extentTest.Log(Status.Info, "Terms agreed");
    }

    //Click on join btn after the details are entered
    public void ClickOnJoinBtnAfterInfo()
    {
        elementInteractions.TakeScreenShot();
        elementInteractions.ClickElement(joinBtnDiv);
        extentTest.Log(Status.Info, "Join button clicked after all the info entered");
    }

    //Click on login btn
    public void ClickOnLoginBtn()
    {
        elementInteractions.ClickElement(LoginBtn);
        extentTest.Log(Status.Info, "Login button clicked and user is redirected to login window");
    }

    //Custom wait for me to check for any alerts
    public static void AlertWait()
    {
        for (long i = 0; i < 300000000; i++) ;
    }

    //Checking if the join btn is enabled and no alerts present
    public void NewUserCreated()
    {
        if (elementInteractions.ReturnElementCollection(joinButtonEnabled).Count == 1 && elementInteractions.ReturnElementCollection(invalidDetailsAlert).Count == 0)
        {
            newUserCreated = true;
            WriteNewUserCredeantialsToExcelFile();
        }
    }

    public void Close()
    {
        elementInteractions.Close();
    }

    #region Writing new user credentials to the excel file

    //Method to write new user credentials to LoginCred.xlsx excel file
    public void WriteNewUserCredeantialsToExcelFile()
    {
        if (newUserCreated)
        {
            InitExcel();
            WriteData();
            CloseExcelObjects();
        }
    }

    //Initialising excel file object
    public void InitExcel()
    {
        filename = @"C:\MVPStudioAdvacedSprint\MVPStudioAdvancedSprint\MVPStudioAdvancedSprint\LoginCred.xlsx";
        application = new Excel.Application();
        workbook = application.Workbooks.Open(filename);
        worksheet = workbook.Worksheets[1];
        range = worksheet.UsedRange;
    }

    //Method to get the next row to write new details on
    public void GetNextExcelRowToWrite()
    {
        int i = worksheet.Rows.Count;
        int j = worksheet.UsedRange.Count;
        newRowNumInExcel = j / 3;
    }

    //Method to write the user email and poassword to the excel file
    public void WriteData()
    {
        GetNextExcelRowToWrite();
        worksheet.Rows[newRowNumInExcel + 1].Cells[1].Value = newUserEmailToWriteToExcel;
        worksheet.Rows[newRowNumInExcel + 1].Cells[2].Value = newUserPasswordToWriyeToExcel;
        worksheet.Rows[newRowNumInExcel + 1].Cells[3].Value = newRowNumInExcel;
        workbook.Save();
    }

    //Method to garbage collect excel objects
    public void CloseExcelObjects()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Marshal.ReleaseComObject(range);
        Marshal.ReleaseComObject(worksheet);
        workbook.Close();
        Marshal.ReleaseComObject(workbook);
        application.Quit();
        Marshal.ReleaseComObject(application);
    }

    #endregion

    //Add new user method
    public void NewUserSignUp(string firstName,string lastName,string email,string password,string confirmPassword)
    {
        newUserEmailToWriteToExcel = email;
        newUserPasswordToWriyeToExcel = password;
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
        if (newUserCreated)
            extentTest.Log(Status.Pass, "New user created successfully");
        else
            extentTest.Log(Status.Fail, "New user creation failed because of invalid input");
    }


}

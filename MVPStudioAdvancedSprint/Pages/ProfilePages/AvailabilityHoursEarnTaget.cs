namespace MVPAdvancedTask;

public class AvailabilityHoursEarnTaget
{
   
    //Element repository
    private readonly By availabilityHoursAndEarnTargetBtn = By.XPath("//i[@class='right floated outline small write icon']");
    private readonly By availabilityDropDown = By.Name("availabiltyType");
    private readonly By hoursDropDown = By.Name("availabiltyHour");
    private readonly By earnTargetDropDown = By.Name("availabiltyTarget");
    private readonly By closeDropDownSelection = By.XPath("//i[@class='remove icon']");
    private readonly By isPartTimeSelected = By.XPath("//span[text()='Part Time']");
    private readonly By isFullTimeSelected = By.XPath("//span[text()='Full Time']");
    private readonly By isLessThan30HoursaWeekSelected = By.XPath("//span[text()='Less than 30hours a week']");
    private readonly By isMoreThan30HoursaWeekSelected = By.XPath("//span[text()='More than 30hours a week']");
    private readonly By isAsNeededSelected = By.XPath("//span[text()='As needed']");
    private readonly By isLessThan500PerMonthSelected = By.XPath("//span[text()='Less than $500 per month']");
    private readonly By isBetween500And1000PerMonthSelected = By.XPath("//span[text()='Between $500 and $1000 per month']");
    private readonly By isMoreThan1000PeMonthSelected = By.XPath("//span[text()='More than $1000 per month']");

    private SelectElement? availabilityDropDownElement;
    private SelectElement? hoursDropDownElement;
    private SelectElement? earnTargetDropDownElement;
    private readonly CommonSendKeysAndClickElements elementInteractions;
    public bool userInfoUpdatedSuccessfully { get; set; }
    public bool dropDownClosedSuccessfully { get; set; }

    //Constructor for the class
    public AvailabilityHoursEarnTaget()
    {
        elementInteractions = new CommonSendKeysAndClickElements();
        userInfoUpdatedSuccessfully = false;
        dropDownClosedSuccessfully = false;
    }

    //Check to see if cancel button works on the drop down box
    public void ClickOnCancelBtnDropDown()
    {
        elementInteractions.ReturnElementCollectionByPresenceOfAllElements(closeDropDownSelection)[0].Click();
    }

    //Click on availability drop down
    public void ClickAvailability()
    {
        elementInteractions.ReturnElementCollectionByPresenceOfAllElements(availabilityHoursAndEarnTargetBtn)[0].Click();
    }

    //Click on hours drop down
    public void ClickHours()
    {
        elementInteractions.ReturnElementCollectionByPresenceOfAllElements(availabilityHoursAndEarnTargetBtn)[1].Click();
    }

    //Custom wait for some operations
    public void AlertWait()
    {
        for (long i = 0; i < 2000000000; i++) ;
    }

    //Click on earn target
    public void ClickEarnTarget()
    {
        elementInteractions.ReturnElementCollectionByPresenceOfAllElements(availabilityHoursAndEarnTargetBtn)[2].Click();
    }

    //Checking to see if availability is updated
    public void CheckIsAvailabilityUpdated()
    {
        if(elementInteractions.ReturnElementCollection(isPartTimeSelected).Count>0 || elementInteractions.ReturnElementCollection(isFullTimeSelected).Count>0 )
            userInfoUpdatedSuccessfully=true;
    }

    //CHecking to see if hours is updated
    public void CheckIsHoursUpdated()
    {
        if(elementInteractions.ReturnElementCollection(isLessThan30HoursaWeekSelected).Count>0 || elementInteractions.ReturnElementCollection(isMoreThan30HoursaWeekSelected).Count>0 || elementInteractions.ReturnElementCollection(isAsNeededSelected).Count>0 )
            userInfoUpdatedSuccessfully=true;
    }

    //Checking to see if earnn target is updated
    public void CheckIsEarnTargetUpdated()
    {
        if(elementInteractions.ReturnElementCollection(isLessThan500PerMonthSelected).Count>0 || elementInteractions.ReturnElementCollection(isMoreThan1000PeMonthSelected).Count>0 || elementInteractions.ReturnElementCollection(isBetween500And1000PerMonthSelected).Count>0 )   
            userInfoUpdatedSuccessfully=true;
    }

    //Selecting availability
    public void SelectAvailability(string availability)
    {
        availabilityDropDownElement = new SelectElement(elementInteractions.ReturnElement(availabilityDropDown));

        //Checking to see if it accepts invalid data
        try
        {
            availabilityDropDownElement.SelectByText(availability);
        }
        catch
        {
            availabilityDropDownElement = null; 
        }
    }

    //Selcting hours
    public void SelectHours(string hours )
    {
        hoursDropDownElement=new SelectElement(elementInteractions.ReturnElement(hoursDropDown));
        //Checking to see if it accepts invalid data
        try
        {
            hoursDropDownElement.SelectByText(hours);
        }
        catch
        {
            hoursDropDownElement = null;
        }
    }
    
    //Selecting earn target
    public void SelectEarnTarget(string earnTarget )
    {
        earnTargetDropDownElement=new SelectElement(elementInteractions.ReturnElement(earnTargetDropDown));
        //Checking to see if it accepts invalid data
        try
        {
            earnTargetDropDownElement.SelectByText(earnTarget);
        }
        catch
        {
            earnTargetDropDownElement = null;
        }
    }

    //Closing the driver
    public void CloseDriver()
    {
        elementInteractions.Close();
    }

    //Checking to see if drop down list boxes are cancelled when cancel button is pressed
    public void CheckIfCancelDropdownSuccessful()
    {
        if(elementInteractions.ReturnElementCollection(closeDropDownSelection).Count==0)
            dropDownClosedSuccessfully = true;
    }

    //Adding availability method
    public void UserAvailability(string availability)
    {
        ClickAvailability();
        SelectAvailability(availability);
        AlertWait();
        CheckIsAvailabilityUpdated();
    }

    //Adding hours method
    public void UserHours(string hours)
    {
        ClickHours();
        SelectHours(hours);
        AlertWait();
        CheckIsHoursUpdated();
    }

    //Adding earn target method
    public void UserEarnTarget(string earnTarget)
    {
        ClickEarnTarget();
        SelectEarnTarget(earnTarget);
        AlertWait();
        CheckIsEarnTargetUpdated();
    }

    //Cancelling drop down method
    public void CancelSelection()
    {
        ClickAvailability();
        ClickOnCancelBtnDropDown();
        AlertWait();
        ClickHours();
        ClickOnCancelBtnDropDown();
        AlertWait();
        ClickEarnTarget();
        ClickOnCancelBtnDropDown();
        CheckIfCancelDropdownSuccessful();
    }
}

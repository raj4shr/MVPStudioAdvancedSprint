
namespace MVPAdvancedTask;

public class UserDescriptionPage
{
    //Element repository 
    private readonly By editDescriptionBtn = By.XPath("//i[@class='outline write icon']");
    private readonly By saveBtnForDescription = By.XPath("//button[text()='Save']");
    private readonly By descriptionTextArea = By.Name("value");
    private readonly By descriptionAfterSave = By.XPath("//span");
    private readonly By SaveBtnClickSuccessfullfterSave = By.XPath("//div[text()='Tell us more about yourself. Buyers are also interested in learning about you as a person.']");
    
    public bool isDecriptionUpdated { get; set; }

    private ReadOnlyCollection<IWebElement>? elements;

    public bool isDescriptionSavedSuccessfully { get; set; }

    private readonly CommonSendKeysAndClickElements elementInteractions;

    private string initialDescValue;

    public UserDescriptionPage()
    {
        isDecriptionUpdated = false;
        elementInteractions = new CommonSendKeysAndClickElements();
        initialDescValue = "";
    }

    //Clicking on edit description button
    public void ClickOnEditDescriptionBtn()
    {
        elementInteractions.ClickElement(editDescriptionBtn);
    }
    
    //Entering description
    public void EnterDescription(string description)
    {
        elementInteractions.SendKeysToElement(descriptionTextArea, description);
    }

    //Clicking on the save button
    public void ClickOnSaveButton()
    {
        elementInteractions.ReturnElementCollectionByPresenceOfAllElements(saveBtnForDescription)[1].Click();
    }

    public void CloseDriver()
    {
        elementInteractions.Close();
    }

    //Getting initial value from the text area when description is ""
    public void GetInitialDescValue()
    {
        initialDescValue=elementInteractions.ReturnElement(descriptionTextArea).Text;
    }

    //Checking to see if description has been updated in the text area
    public void CheckIfDescriptionIsUpdated(string description)
    {
        elements = elementInteractions.ReturnElementCollection(descriptionAfterSave);
        for (int i = 0; i < elements.Count; i++)
            if (elements[i].Text == description && description != "")
            {
                isDecriptionUpdated = true;
                break;
            }
            else if (elements[i].Text == initialDescValue && description == "")
            {
                isDecriptionUpdated = false;
                break;
            }
    }

    //Custom wait for some operations
    public void AlertWait()
    {
        for (long i = 0; i < 2000000000; i++) ;
    }

    //Checking to see if clicking save button was successful
    public void CheckIfSaveDescriptionSuccessful()
    {
        if(elementInteractions.ReturnElementCollection(SaveBtnClickSuccessfullfterSave).Count==0)
            isDescriptionSavedSuccessfully=true;
    }


    //Enter user description method
    public void EnterUserDescription(string description)
    {
        ClickOnEditDescriptionBtn();
        if (description == "")
            GetInitialDescValue();
        GetInitialDescValue();
        EnterDescription(description);
        ClickOnSaveButton();
        AlertWait();
        CheckIfSaveDescriptionSuccessful();
        if(isDescriptionSavedSuccessfully)
            CheckIfDescriptionIsUpdated(description);

    }

}

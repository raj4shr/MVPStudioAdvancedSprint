namespace MVPCompetitionTask;

public class CommonSendKeysAndClickElements : CommonDriver
{
    WebDriverWait wait;
    string path;


    public CommonSendKeysAndClickElements()
    {
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        path = "";
    }

    //Following are explicit waits for elements for different situations
    public void SendKeysToElement(By elementLocator, string elementValue)
    {
        wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
        driver.FindElement(elementLocator).Clear();
        driver.FindElement(elementLocator).SendKeys(elementValue);
    }

    public void ClickElement(By elementLocator)
    {
        wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
        driver.FindElement(elementLocator).Click();
    }

    public bool ElementIsDisplayed(By elementLocator)
    {
        wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(elementLocator));
        return driver.FindElement(elementLocator).Displayed;
    }

    public void ClickOnCheckBox(By elementLocator)
    {
        wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(elementLocator));
        driver.FindElement(elementLocator).Click();
    }

    public ReadOnlyCollection<IWebElement> ReturnElementCollectionByElementISVisible(By elementLocator)
    {
        wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
        return driver.FindElements(elementLocator);
    }

    public ReadOnlyCollection<IWebElement> ReturnElementCollectionByPresenceOfAllElements(By elementLocator)
    {
        wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(elementLocator));
        return driver.FindElements(elementLocator);
    }

    public ReadOnlyCollection<IWebElement> ReturnElementCollection(By elementLocator)
    {
        return driver.FindElements(elementLocator);
    }

    public IWebElement ReturnElement(By elementLocator)
    {
        wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
        return driver.FindElement(elementLocator);
    }

    public void Close()
    {
        driver.Quit();
    }

    //Method to take screenshot
    public void TakeScreenShot()
    {
        path = @"C:\ExtentReports\ScreenShots\" + DateTime.Now.ToString("_MMddyyyy_hhmmsstt") + @".png";
        ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(path, ScreenshotImageFormat.Png);
    }
}

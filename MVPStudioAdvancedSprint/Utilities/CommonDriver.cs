global using NUnit.Framework;
global using AventStack.ExtentReports;
global using ExcelDataReader;
global using System.Data;
global using FluentAssertions;
global using OpenQA.Selenium;
global using OpenQA.Selenium.Chrome;
global using System.Collections.ObjectModel;
global using OpenQA.Selenium.Support.UI;
global using SeleniumExtras.WaitHelpers;
global using AventStack.ExtentReports.Reporter.Configuration;
global using AventStack.ExtentReports.Reporter;
global using System.Collections;
global using Excel = Microsoft.Office.Interop.Excel;


namespace MVPCompetitionSprint;

public class CommonDriver
{
    //Common driver to be used for all the tests
    public static IWebDriver driver;
    public void InitDriver()
    {
        //Opening up MVP portal running on docker image
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("http://localhost:5000/");
    }


}

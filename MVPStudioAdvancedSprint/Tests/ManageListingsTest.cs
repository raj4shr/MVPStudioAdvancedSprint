namespace MVPCompetitionTask;

[TestFixture]
public class ManageListingsTest : CommonDriver
{
    private bool assert;
    public ManageListingsTest()
    {
        assert = false;
    }
    [SetUp]
    public void Setup()
    {
        LoginToPortalPage loginToPortalPage = new();
        loginToPortalPage.LogintoPortal();
    }
    //Delete a share skill if the share skill exists
    [TestCase("NUnit")]
    public void DeleteShareSkill(string title)
    {
        DeleteShareSkillPage deleteShareSkillPage = new();
        assert=deleteShareSkillPage.DeleteShareSkill(title);
        assert.Should().BeFalse();
    }

    //Trying to delete a share skill which doesn't exist
    [TestCase("Non Existent")]
    public void DeleteShareSkillNotExist(string title)
    {
        DeleteShareSkillPage deleteShareSkillPage = new();
        assert=deleteShareSkillPage.DeleteShareSkill(title);
        assert.Should().BeFalse();
    }


    //View an existing share skill
    [TestCase("SpecFlow")]
    public void ViewShareSkill(string title)
    {
        ViewShareSkillPage viewShareSkillPage = new();
        assert=viewShareSkillPage.ViewShareSkill(title);
        assert.Should().BeTrue();
    }

    //Trying to view a share skill which doesn't exist
    [TestCase("Share skill doesn't exist")]
    public void ViewShareSkillNotExist(string title)
    {
        ViewShareSkillPage viewShareSkillPage = new();
        assert = viewShareSkillPage.ViewShareSkill(title);
        assert.Should().BeFalse();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}

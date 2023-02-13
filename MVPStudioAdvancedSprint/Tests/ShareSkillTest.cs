
namespace MVPCompetitionSprint;

[TestFixture]
public class ShareSkillTest : AddNewShareSkillTestData
{
    private AddShareSkillPage addShareSkill;
    private LoginToPortalPage loginToPortalPage;
 
    [SetUp]
    public void Setup()
    {
        loginToPortalPage = new LoginToPortalPage();
        loginToPortalPage.LogintoPortal();
        addShareSkill = new AddShareSkillPage();
    }

    [TestCaseSource(typeof(NewShareSkillInfo))]
    public void AddNewShareSkill(string title,string description,string category,string subCategory,string Tags,string startDate,string endDate,string day,string startTime,string endTime,string skillExchange)
    {
        addShareSkill.AddNewShareSkill( title,  description,  category,  subCategory,  Tags,  startDate,  endDate,  day,startTime,endTime,  skillExchange);
    }

    [TearDown]
    public void TearDown()
    {
        addShareSkill.Close();
    }
}

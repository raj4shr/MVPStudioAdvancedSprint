
namespace MVPAdvancedTask;

//option 1
public class AddNewShareSkillTestData
{
    public static IEnumerable<TestCaseData> NewShareSkillTestData()
    {
        yield return new TestCaseData("SpecFlow", "BDD in CSharp", "Programming & Tech", "QA").SetName("Create new share skill with valid data");
        yield return new TestCaseData("", "BDD in java", "Programming & Tech", "QA").SetName("Create new share skill with blank title");
        yield return new TestCaseData("Java", "", "Programming & Tech", "QA").SetName("Create new share skill with blank description");
        yield return new TestCaseData("Cucumber", "BDD in java", "", "").SetName("Create new share skill with blank category and sub category");
    }
}

//option 2
public class NewShareSkillInfo : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new string[] { "SpecFlow", "BDD in Csharp", "Programming & Tech", "QA", "Programming", DateTime.Now.ToShortDateString(), DateTime.Now.AddDays(20).ToShortDateString(), "Thu", "07:00am","08:00pm", "Java"};
        yield return new string[] { "Cucumber", "", "Programming & Tech", "QA", "Programming", DateTime.Now.ToShortDateString(), DateTime.Now.AddDays(20).ToShortDateString(), "Tue", "07:00am", "3:30pm", "Java" };
        yield return new string[] { "Nunit", "BDD in CSharp", "","QA", "Programming", DateTime.Now.ToShortDateString(), DateTime.Now.AddDays(20).ToShortDateString(), "Wed", "07:00am", "3:30pm", "Java" };
        yield return new string[] { "Docker", "BDD in CSharp", "Programming & Tech", "", "Programming", DateTime.Now.ToShortDateString(), DateTime.Now.AddDays(20).ToShortDateString(), "Thu", "07:00am", "3:3 pm", "Java" };
        yield return new string[] { "Postman", "BDD in CSharp", "Programming & Tech", "QA", "", DateTime.Now.ToShortDateString(), DateTime.Now.AddDays(20).ToShortDateString(), "Fri", "07:00am", "3:30pm", "Java" };
        yield return new string[] { "Jmeter", "BDD in Csharp", "Programming & Tech", "QA", "Programming", DateTime.Now.ToShortDateString(), DateTime.Now.AddDays(20).ToShortDateString(), "Sat", "07:00am", "3:30pm", "Java" };
        yield return new string[] { "XUnit", "BDD in Csharp", "Programming & Tech", "QA", "Programming", DateTime.Now.ToShortDateString(), "", "Sun", "07:00am", "3:30pm", "Java" };
        yield return new string[] { "XUnit", "BDD in Csharp", "Programming & Tech", "QA", "Programming", "", DateTime.Now.AddDays(20).ToShortDateString(), "Sun", "07:00am", "3:30pm", "Java" };
        yield return new string[] { "Trello", "BDD in Csharp", "Programming & Tech", "QA", "Programming", DateTime.Now.ToShortDateString(), DateTime.Now.AddDays(20).ToShortDateString(), "", "07:00am", "3:30pm", "Java" };
        yield return new string[] { "Jira", "BDD in Csharp", "Programming & Tech", "QA", "Programming", DateTime.Now.ToShortDateString(), DateTime.Now.AddDays(20).ToShortDateString(), "Mon", "", "3:30pm", "Java" };
        yield return new string[] { "Newman", "BDD in Csharp", "Programming & Tech", "QA", "Programming", DateTime.Now.ToShortDateString(), DateTime.Now.AddDays(20).ToShortDateString(), "Mon", "07:00am", "", "Java" };
        yield return new string[] { "API", "BDD in Csharp", "Programming & Tech", "QA", "Programming", DateTime.Now.ToShortDateString(), DateTime.Now.AddDays(20).ToShortDateString(), "Mon", "07:00am", "3:30pm", "" };

    }
}



namespace MVPCompetitionTask;

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
        yield return new string[] { "SpecFlow", "BDD in Csharp", "Programming & Tech", "QA", "Programming", "10/02/2023", "10/03/2023", "Mon", "07:00 am", "3:30 pm", "Java"};
        yield return new string[] { "Cucumber", "", "Programming & Tech", "QA", "Programming", "10/02/2023", "10/03/2023", "Mon", "07:00 am", "3:30 pm", "Java" };
        yield return new string[] { "Nunit", "BDD in CSharp", "","QA", "Programming", "10/02/2023", "10/03/2023", "Mon", "07:00 am", "3:30 pm", "Java" };
        yield return new string[] { "Docker", "BDD in CSharp", "Programming & Tech", "", "Programming", "10/02/2023", "10/03/2023", "Mon", "07:00 am", "3:30 pm", "Java" };
        yield return new string[] { "Postman", "BDD in CSharp", "Programming & Tech", "QA", "", "10/02/2023", "10/03/2023", "Mon", "07:00 am", "3:30 pm", "Java" };
        yield return new string[] { "Jmeter", "BDD in Csharp", "Programming & Tech", "QA", "Programming", "", "10/03/2023", "Mon", "07:00 am", "3:30 pm", "Java" };
        yield return new string[] { "XUnit", "BDD in Csharp", "Programming & Tech", "QA", "Programming", "", "10/03/2023", "Mon", "07:00 am", "3:30 pm", "Java" };
        yield return new string[] { "Trello", "BDD in Csharp", "Programming & Tech", "QA", "Programming", "10/02/2023", "10/03/2023","", "07:00 am", "3:30 pm", "Java" };
        yield return new string[] { "Jira", "BDD in Csharp", "Programming & Tech", "QA", "Programming", "10/02/2023", "10/03/2023", "Mon", "", "3:30 pm", "Java" };
        yield return new string[] { "Newman", "BDD in Csharp", "Programming & Tech", "QA", "Programming", "10/02/2023", "10/03/2023", "Mon", "07:00 am", "", "Java" };
        yield return new string[] { "API", "BDD in Csharp", "Programming & Tech", "QA", "Programming", "10/02/2023", "10/03/2023", "Mon", "07:00 am", "3:30 pm", "" };

    }
}


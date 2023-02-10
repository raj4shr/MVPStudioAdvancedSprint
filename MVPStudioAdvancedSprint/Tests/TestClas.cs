using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPCompetitionSprint;

[TestFixture]
public class TestClas
{
    [Test]
    public void test()
    {
        Console.WriteLine(DateTime.Now.ToShortDateString());
        DateTime dt = DateTime.Now.AddDays(20);
        Console.WriteLine(dt.ToShortDateString());    
    }
}

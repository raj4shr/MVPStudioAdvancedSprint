namespace MVPCompetitionSprint;

[SetUpFixture]
class SetupandTeardown : IExtentRpt
{
    [OneTimeSetUp]
    public void oneTimeSetup()
    {
        IExtentRpt.InitReports();
    }

    [OneTimeTearDown]
    public void voidoneTimeTeardown()
    {
        IExtentRpt.flushReport();
    }

   
}

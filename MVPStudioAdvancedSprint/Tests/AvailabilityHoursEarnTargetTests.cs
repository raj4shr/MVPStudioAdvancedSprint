

using MVPAdvancedTask;

namespace MVPAdvancedTask;

[TestFixture]
public class AvailabilityHoursEarnTargetTests
{
    private LoginToPortalPage loginToPortal;
    private AvailabilityHoursEarnTaget availabilityHoursEarnTaget;

    [SetUp]
    public void SetUp()
    {
        loginToPortal = new LoginToPortalPage();
        loginToPortal.LogintoPortal();
        availabilityHoursEarnTaget = new AvailabilityHoursEarnTaget();
    }

    [TestCaseSource(typeof(AvailabilityTestData))]
    public void EnterUserAvailability(string availability, bool valid)
    {
        availabilityHoursEarnTaget.UserAvailability(availability);
        if (valid)
            availabilityHoursEarnTaget.userInfoUpdatedSuccessfully.Should().BeTrue();
        else
            availabilityHoursEarnTaget.userInfoUpdatedSuccessfully.Should().BeFalse();
    }

    [TestCaseSource(typeof(HoursTestData))]
    public void EnterUserHours(string hours, bool valid)
    {
        availabilityHoursEarnTaget.UserHours(hours);
        if (valid)
            availabilityHoursEarnTaget.userInfoUpdatedSuccessfully.Should().BeTrue();
        else
            availabilityHoursEarnTaget.userInfoUpdatedSuccessfully.Should().BeFalse();
    }

    [TestCaseSource(typeof(EarnTargetTestData))]
    public void EnterUserEarnTarget(string earnTarget, bool valid)
    {
        availabilityHoursEarnTaget.UserEarnTarget(earnTarget);
        if (valid)
            availabilityHoursEarnTaget.userInfoUpdatedSuccessfully.Should().BeTrue();
        else
            availabilityHoursEarnTaget.userInfoUpdatedSuccessfully.Should().BeFalse();
    }

    [Test]
    public void CancelDropDown()
    {
        availabilityHoursEarnTaget.CancelSelection();
        availabilityHoursEarnTaget.dropDownClosedSuccessfully.Should().BeTrue();
    }

    [TearDown]
    public void CloseDriver()
    {
        availabilityHoursEarnTaget.CloseDriver();
    }
}

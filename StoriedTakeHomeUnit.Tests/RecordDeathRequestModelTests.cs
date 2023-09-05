using PeopleCommandHandler.Models;

namespace StoriedTakeHomeUnit.Tests;
public class RecordDeathRequestModelTests
{
    [Theory]
    [MemberData(nameof(NoDateOrLocation))]
    public void NoDateOrLocationReturnFalse(RecordDeathRequestModel birth)
    {
        bool result = birth.Validate(out _);

        Assert.False(result);
    }

    [Theory]
    [MemberData(nameof(JustDate))]
    public void DateReturnTrue(RecordDeathRequestModel birth)
    {
        bool result = birth.Validate(out string error);

        Assert.True(result, error);
    }

    [Theory]
    [MemberData(nameof(JustLocation))]
    public void LocationReturnTrue(RecordDeathRequestModel birth)
    {
        bool result = birth.Validate(out string error);

        Assert.True(result, error);
    }

    [Theory]
    [MemberData(nameof(DateAndLocation))]
    public void DateAndLocationReturnTrue(RecordDeathRequestModel birth)
    {
        bool result = birth.Validate(out string error);

        Assert.True(result, error);
    }

    public static IEnumerable<object[]> NoDateOrLocation()
    {
        yield return new object[]
        {
            new RecordDeathRequestModel
            {
                DeathDate = null,
                DeathLocation = null
            }
        };
    }

    public static IEnumerable<object[]> JustDate()
    {
        yield return new object[]
        {
            new RecordDeathRequestModel
            {
                DeathDate = new DateTime(1980, 5, 23),
                DeathLocation = null
            }
        };
    }

    public static IEnumerable<object[]> JustLocation()
    {
        yield return new object[]
        {
            new RecordDeathRequestModel
            {
                DeathDate = null,
                DeathLocation = "Provo, Utah, United States"
            }
        };
    }

    public static IEnumerable<object[]> DateAndLocation()
    {
        yield return new object[]
        {
            new RecordDeathRequestModel
            {
                DeathDate = new DateTime(1980, 5, 23),
                DeathLocation = "Provo, Utah, United States"
            }
        };
    }
}

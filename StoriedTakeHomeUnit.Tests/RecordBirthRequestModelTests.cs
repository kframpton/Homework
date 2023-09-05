using StoriedTakeHomeWebApi.RequestModels;

namespace StoriedTakeHomeUnit.Tests;
public class RecordBirthRequestModelTests
{
    [Theory]
    [MemberData(nameof(NoDateOrLocation))]
    public void NoDateOrLocationReturnFalse(RecordBirthRequestModel birth)
    {
        bool result = birth.Validate(out _);

        Assert.False(result);
    }

    [Theory]
    [MemberData(nameof(JustDate))]
    public void DateReturnTrue(RecordBirthRequestModel birth)
    {
        bool result = birth.Validate(out string error);

        Assert.True(result, error);
    }

    [Theory]
    [MemberData(nameof(JustLocation))]
    public void LocationReturnTrue(RecordBirthRequestModel birth)
    {
        bool result = birth.Validate(out string error);

        Assert.True(result, error);
    }

    [Theory]
    [MemberData(nameof(DateAndLocation))]
    public void DateAndLocationReturnTrue(RecordBirthRequestModel birth)
    {
        bool result = birth.Validate(out string error);

        Assert.True(result, error);
    }

    public static IEnumerable<object[]> NoDateOrLocation()
    {
        yield return new object[]
        {
            new RecordBirthRequestModel
            {
                BirthDate = null,
                BirthLocation = null
            }
        };
    }

    public static IEnumerable<object[]> JustDate()
    {
        yield return new object[]
        {
            new RecordBirthRequestModel
            {
                BirthDate = new DateTime(1980, 5, 23),
                BirthLocation = null
            }
        };
    }

    public static IEnumerable<object[]> JustLocation()
    {
        yield return new object[]
        {
            new RecordBirthRequestModel
            {
                BirthDate = null,
                BirthLocation = "Provo, Utah, United States"
            }
        };
    }

    public static IEnumerable<object[]> DateAndLocation()
    {
        yield return new object[]
        {
            new RecordBirthRequestModel
            {
                BirthDate = new DateTime(1980, 5, 23),
                BirthLocation = "Provo, Utah, United States"
            }
        };
    }
}

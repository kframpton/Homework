using DataEntities.Entities.Tardis;
using StoriedTakeHomeWebApi.RequestModels;

namespace StoriedTakeHomeUnit.Tests;

public class AddPersonRequestModelTests
{
    [Theory]
    [MemberData(nameof(NameOrGenderNotBoth))]
    public void NameOrGenderRequiredReturnFalse(AddPersonRequestModel person)
    {
        bool result = person.Validate(out _);

        Assert.False(result);
    }

    [Theory]
    [MemberData(nameof(GivenNameAndGender))]
    public void GivenNameAndGenderReturnTrue(AddPersonRequestModel person)
    {
        bool result = person.Validate(out string error);

        Assert.True(result, error);
    }

    [Theory]
    [MemberData(nameof(SurnameAndGender))]
    public void SurnameAndGenderReturnTrue(AddPersonRequestModel person)
    {
        bool result = person.Validate(out string error);

        Assert.True(result, error);
    }

    [Theory]
    [MemberData(nameof(GivenNameAndSurnameAndGender))]
    public void GivenNameAndSurnameAndGenderReturnTrue(AddPersonRequestModel person)
    {
        bool result = person.Validate(out string error);

        Assert.True(result, error);
    }

    public static IEnumerable<object[]> NameOrGenderNotBoth()
    {
        yield return new object[]
        {
            new AddPersonRequestModel()
            {
                GivenName = null,
                Surname = null
            }
        };
        yield return new object[]
        {
            new AddPersonRequestModel()
            {
                GivenName = "Kevin",
                Surname = null,
                Gender = null
            }
        };
        yield return new object[]
        {
            new AddPersonRequestModel()
            {
                GivenName = "Elizabeth",
                Surname = "Frampton",
                Gender = null
            }
        };
        yield return new object[]
        {
            new AddPersonRequestModel()
            {
                GivenName = null,
                Surname = null,
                Gender = Gender.Female
            }
        };
    }

    public static IEnumerable<object[]> GivenNameAndGender()
    {
        yield return new object[]
        {
            new AddPersonRequestModel()
            {
                GivenName = "Kevin",
                Gender = Gender.Male
            }
        };
    }

    public static IEnumerable<object[]> SurnameAndGender()
    {
        yield return new object[]
        {
            new AddPersonRequestModel()
            {
                Surname = "Frampton",
                Gender = Gender.Male
            }
        };
    }

    public static IEnumerable<object[]> GivenNameAndSurnameAndGender()
    {
        yield return new object[]
        {
            new AddPersonRequestModel()
            {
                GivenName = "Elizabeth",
                Surname = "Frampton",
                Gender = Gender.Female
            }
        };
    }
}
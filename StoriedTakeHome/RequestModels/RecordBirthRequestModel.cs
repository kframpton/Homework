namespace StoriedTakeHomeWebApi.RequestModels;

public class RecordBirthRequestModel
{
    public Guid Id { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? BirthLocation { get; set; }

    public RecordBirthRequestModel()
    {
        
    }
    public RecordBirthRequestModel(Guid id, DateTime date, string? birthLocation = null)
    {
        Id = id;
        BirthDate = date;
        BirthLocation = birthLocation;

    }
    public RecordBirthRequestModel(Guid id, string date, string? birthLocation = null)
    {
        if (!DateTime.TryParse(date, out DateTime birthDate))
            throw new ArgumentException($"{nameof(date)} cannot be converted to a valid {typeof(DateTime).FullName}");
        Id = id;
        BirthDate = birthDate;
        BirthLocation = birthLocation;
    }
}

public static class RecordBirthRequestModelExtensions
{
    public static bool Validate(this RecordBirthRequestModel recordBirth, out string error)
    {
        if (recordBirth.BirthDate is null && recordBirth.BirthLocation is null)
        {
            error = "BirthDate, BirthLocation, or both MUST be provided";
            return false;
        }

        error = "";
        return true;
    }
}
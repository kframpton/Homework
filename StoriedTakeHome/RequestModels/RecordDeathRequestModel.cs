namespace StoriedTakeHomeWebApi.RequestModels;

public class RecordDeathRequestModel
{
    public Guid Id { get; set; }
    public DateTime? DeathDate { get; set; }
    public string? DeathLocation { get; set; }

    public RecordDeathRequestModel()
    {
        
    }
    public RecordDeathRequestModel(Guid id, DateTime date, string? deathLocation = null)
    {
        Id = id;
        DeathDate = date;
        DeathLocation = deathLocation;

    }
    public RecordDeathRequestModel(Guid id, string date, string? deathLocation = null)
    {
        if (!DateTime.TryParse(date, out DateTime deathDate))
            throw new ArgumentException($"{nameof(date)} cannot be converted to a valid {typeof(DateTime).FullName}");
        Id = id;
        DeathDate = deathDate;
        DeathLocation = deathLocation;
    }
}

public static class RecordDeathRequestModelExtensions
{
    public static bool Validate(this RecordDeathRequestModel recordDeath, out string error)
    {
        if (recordDeath.DeathDate is null && recordDeath.DeathLocation is null)
        {
            error = "DeathDate, DeathLocation, or both MUST be provided";
            return false;
        }

        error = "";
        return true;
    }
}

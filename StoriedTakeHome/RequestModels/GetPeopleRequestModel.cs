namespace StoriedTakeHomeWebApi.RequestModels;

public class GetPeopleRequestModel
{
    public IEnumerable<Guid> Ids { get; set; } = new List<Guid>();
    public string? GivenName { get; set; }
    public string? Surname { get; set; }

    public GetPeopleRequestModel() { }
    public GetPeopleRequestModel(IEnumerable<Guid> ids)
    {
        Ids = ids;
    }
    public GetPeopleRequestModel(string giveName, string surname)
    {
        GivenName = giveName;
        Surname = surname;
    }
}

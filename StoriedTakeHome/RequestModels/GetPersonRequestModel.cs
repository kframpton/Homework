namespace StoriedTakeHomeWebApi.RequestModels;

public class GetPersonRequestModel
{
    public Guid? Id { get; set; }
    public string? GivenName { get; set; }
    public string? Surname { get; set; }

    public GetPersonRequestModel() { }
    public GetPersonRequestModel(Guid id)
    {
        Id = id;
    }
    public GetPersonRequestModel(string givenName, string surname)
    {
        GivenName = givenName;
        Surname = surname;
    }
}

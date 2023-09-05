namespace StoriedTakeHomeWebApi;

public class PersonException : Exception
{
    public PersonException() : base("Person entity does not exist") { }
    public PersonException(string message) : base(message) { }
    public PersonException(Exception exception) : base("Person entity does not exist", exception) { }
    public PersonException(string message, Exception exception) : base(message, exception) { }
}

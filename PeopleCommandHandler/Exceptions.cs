namespace PeopleCommandHandler;

public class AddPersonException : Exception
{
    public AddPersonException() : base("Unable to add person entity") { }
    public AddPersonException(string message) : base(message) { }
    public AddPersonException(Exception exception) : base("Unable to add person entity", exception) { }
    public AddPersonException(string message, Exception exception) : base(message, exception) { }
}

public class RecordBirthException : Exception
{
    public RecordBirthException() : base("Unable to record birth") { }
    public RecordBirthException(string message) : base(message) { }
    public RecordBirthException(Exception exception) : base("Unable to record birth", exception) { }
    public RecordBirthException(string message, Exception exception) : base(message, exception) { }
}

public class PersonException : Exception
{
    public PersonException() : base("Person entity does not exist") { }
    public PersonException(string message) : base(message) { }
    public PersonException(Exception exception) : base("Person entity does not exist", exception) { }
    public PersonException(string message, Exception exception) : base(message, exception) { }
}
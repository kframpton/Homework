using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataEntities.Entities.Tardis;
public class PersonHistory
{
    [Key]
    public int Id { get; set; }
    public Guid PersonId { get; set; }
    public string? GivenName { get; set; }
    public string? Surname { get; set; }
    [Column(TypeName = "nvarchar(150)")]
    public Gender? Gender { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime? BirthDate { get; set; }
    public string? BirthLocation { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime? DeathDate { get; set; }
    public string? DeathLocation { get; set; }
    public DateTime ArchiveDate { get; set; } = DateTime.Now;

    //Relations
    public Person Person { get; set; }

    public PersonHistory()
    {
        
    }

    public PersonHistory(PersonHistory history)
    {
        Id = history.Id;
        PersonId = history.PersonId;
        GivenName = history.GivenName;
        Surname = history.Surname;
        Gender = history.Gender;
        BirthDate = history.BirthDate;
        BirthLocation = history.BirthLocation;
        DeathDate = history.DeathDate;
        DeathLocation = history.DeathLocation;
    }

    public PersonHistory(Person person)
    {
        PersonId = person.Id;
        GivenName = person.GivenName;
        Surname = person.Surname;
        Gender = person.Gender;
        BirthDate = person.BirthDate;
        BirthLocation = person.BirthLocation;
        DeathDate = person.DeathDate;
        DeathLocation = person.DeathLocation;
    }
}

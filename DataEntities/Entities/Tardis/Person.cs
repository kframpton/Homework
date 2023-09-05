using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataEntities.Entities.Tardis;
public class Person
{    
    [Key]
    public Guid Id { get; set; }
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

    [NotMapped]
    public string Fullname { get => $"{GivenName} {Surname}"; }

    public Person() { }
    public Person(Person person)
    {
        Id = person.Id;
        GivenName = person.GivenName;
        Surname = person.Surname;
        Gender = person.Gender;
        BirthDate = person.BirthDate;
        BirthLocation = person.BirthLocation;
        DeathDate = person.DeathDate;
        DeathLocation = person.DeathLocation;
    }
}

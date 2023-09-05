using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataEntities.Entities.Tardis;
public class Module
{
    [Key]
    [Column(TypeName = "nvarchar(1024)")]
    public string Name { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public ModuleType Type { get; set; }
    public double DefaultVersion { get; set; }
    public double MinimumVersion { get; set; }
        
    public bool Invalid(double version) => MinimumVersion <= 0.0 || MinimumVersion > version;
}

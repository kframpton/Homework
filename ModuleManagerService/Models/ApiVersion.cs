using ModuleSharedResources.Interfaces;

namespace ModuleManager.Models
{
    public class ApiVersion
	{
		public double Version { get; set; }
		public string Library { get; set; }
		public IManagedModule Console { get; set; }
		public ApiVersion(string library, double version, IManagedModule console)
		{
			Library = library;
			Version = version;
			Console = console;
		}
	}
}

namespace ModuleManager.Models
{
    public class ModuleManagerOptions
	{
		public int SlidingExpiration { get; set; } = 5;
		public int AbsoluteExpiration { get; set; } = 120;
	}
}

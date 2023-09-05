namespace ModuleManager.Models
{
    /// <summary>
    /// Object to house Major/Minor version info for a library request
    /// </summary>
    public class RequestVersion
	{
		/// <summary>
		/// Version number
		/// </summary>
		public int Major { get; set; }
		/// <summary>
		/// Revision number
		/// </summary>
		public int Minor { get; set; }
	}
}

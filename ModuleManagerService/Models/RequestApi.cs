namespace ModuleManager.Models
{
    /// <summary>
    /// Object to house a requested library including version
    /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class RequestApi
	{
        /// <summary>
        /// Name of requested library
        /// </summary>
        public string Library { get; set; }
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

namespace ModuleManager;
public class ModuleNameException : Exception
{
	public ModuleNameException() : base("unable to determine name of requested module") { }
}

/// <summary>
/// Exception signifying an outdated module
/// </summary>
/// <remarks>
/// Kevin Frampton, 2021-06-23
/// </remarks>
/// <seealso cref="T:System.Exception"/>
public class BadModuleException : Exception
{
    public string Library { get; set; }
    public double Version { get; set; }

    public BadModuleException(string message, string library, double version)
        : base(message)
    {
        Library = library;
        Version = version;
    }

    public BadModuleException(Exception ex, string message, string library, double version)
        : base(message, ex)
    {
        Library = library;
        Version = version;
    }

    public BadModuleException(Exception ex, string library, double version)
        : base("Module doesn't exist", ex)
    {
        Library = library;
        Version = version;
    }
}

public class BadModuleVersionException : Exception
{
    public string Library { get; set; }
    public double Version { get; set; }

    public BadModuleVersionException(string message, string library, double version)
        : base(message)
    {
        Library = library;
        Version = version;
    }

    public BadModuleVersionException(Exception ex, string message, string library, double version)
        : base(message, ex)
    {
        Library = library;
        Version = version;
    }

    public BadModuleVersionException(Exception ex, string library, double version)
        : base("Module doesn't exist", ex)
    {
        Library = library;
        Version = version;
    }
}

/// <summary>
/// Exception signifying an outdated module
/// </summary>
/// <remarks>
/// Kevin Frampton, 2021-06-23
/// </remarks>
/// <seealso cref="T:System.Exception"/>
public class OutdatedModuleException : Exception
{
    public double Version { get; set; }
    public string Library { get; set; }

    public OutdatedModuleException(string message, string library, double version)
        : base(message)
    {
        Version = version;
        Library = library;
    }
}
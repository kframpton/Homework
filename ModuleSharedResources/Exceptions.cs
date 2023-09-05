namespace ModuleSharedResources;

/// <summary>
/// Exception signifying method not available (and therefore gonna crap out) in version
/// </summary>
/// <remarks>
/// Kevin Frampton, 2022-09-06
/// </remarks>
/// <seealso cref="T:System.Exception"/>
public class NotInVersionException : Exception
{
    private static readonly string defaultMessage = "Method not available in version";

    public NotInVersionException() : base(defaultMessage) { }
    public NotInVersionException(string library) : base($"({library}) {defaultMessage}") { }
    public NotInVersionException(Exception ex) : base(defaultMessage, ex) { }
    public NotInVersionException(Exception ex, string library) : base($"({library}) {defaultMessage}", ex) { }
}

/// <summary>
/// Exception signifying method is deprecated (and therefore gonna crap out) in version
/// </summary>
/// <remarks>
/// Kevin Frampton, 2022-09-06
/// </remarks>
/// <seealso cref="T:System.Exception"/>
public class MethodDeprecatedException : Exception
{
    private static readonly string defaultMessage = "Method deprecated in version";

    public MethodDeprecatedException() : base(defaultMessage) { }
    public MethodDeprecatedException(string library) : base($"({library}) {defaultMessage}") { }
    public MethodDeprecatedException(Exception ex) : base(defaultMessage, ex) { }
    public MethodDeprecatedException(Exception ex, string library) : base($"({library}) {defaultMessage}", ex) { }
}

/// <summary>
/// Exception signifying method is deprecated (and therefore gonna crap out) in version
/// </summary>
/// <remarks>
/// Kevin Frampton, 2022-09-06
/// </remarks>
/// <seealso cref="T:System.Exception"/>
public class LoggerNotProvidedException : Exception
{
    private static readonly string defaultMessage = "Logger was not provided";

    public LoggerNotProvidedException() : base(defaultMessage) { }
    public LoggerNotProvidedException(string library) : base($"({library}) {defaultMessage}") { }
    public LoggerNotProvidedException(Exception ex) : base(defaultMessage, ex) { }
    public LoggerNotProvidedException(Exception ex, string library) : base($"({library}) {defaultMessage}", ex) { }
}
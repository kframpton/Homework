using System.Runtime.CompilerServices;

namespace ModuleSharedResources.Apis;
public abstract class ABaseConsole : IDisposable
{
    private readonly string defaultMessage = "library: NOT SPECIFIED, member: ";

    public virtual NotInVersionException NotInVersion<T>(T type, [CallerMemberName] string member = "")
    {
        try
        {
            return new($"library: {typeof(T).Assembly.GetName().Name ?? "how can the assembly name ever be null?"}, member: {member}");
        }
        catch
        {
            return new($"{defaultMessage}{member}");
        }
    }
    public virtual MethodDeprecatedException MethodDeprecated([CallerMemberName] string member = "") => new($"{defaultMessage}{member}");

    public void Dispose() => GC.SuppressFinalize(this);
}

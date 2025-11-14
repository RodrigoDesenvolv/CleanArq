using System.Reflection;

namespace Business.Strategy.ETO.Domain.Shared.Services.Entities
{
    public class AssemblyContext
    {
        internal static Func<string> GetAssemblyName = () => Assembly.GetEntryAssembly().GetName().Name;
    }
}

namespace Business.Strategy.ETO.Domain.Shared.Services.Entities
{
    public static class ResultContext
    {
        private static (string Layer, string ApplicationName) config = GetApplication();

        public static readonly string Layer = config.Layer;

        public static readonly string ApplicationName = config.ApplicationName;

        private static (string Layer, string ApplicationName) GetApplication()
        {
            string text = AssemblyContext.GetAssemblyName();
            return (Layer: text.Split('.').FirstOrDefault(), ApplicationName: text);
        }
    }
}

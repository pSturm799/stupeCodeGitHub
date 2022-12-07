namespace SerilogWithSeqForPlugins
{
    public class PluginXYZ
    {
        /// <summary>
        /// </summary>
        public void BuildCompositionRoot()
        {
            //ISettingsProvider settings = extendedServiceProvider.Settings;

            //IGetSerilogPluginExecutor executor = new GetSerilogPluginExecutor(settings);

            //ILogger logger = executor.Logger;

            // innerhalb des Plugins dann mit:
            // _logger.Debug("text");
        }
    }
}
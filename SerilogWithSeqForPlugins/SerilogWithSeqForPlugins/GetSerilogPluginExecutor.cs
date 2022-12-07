using System.Linq.Expressions;
using CRM.Core.Settings;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace SerilogWithSeqForPlugins
{
    /// <summary>
    ///     Get Serilog Azure Blob Storage Logger class
    /// </summary>
    public class GetSerilogPluginExecutor : IGetSerilogPluginExecutor
    {
        private const string SettingsPluginloglevelKey = "we_PluginLogLevel";

        //TODO aus Settings löschen
        //private const string SETTINGS_AZUREBLOBSTORAGECONNECTIONSTRING_KEY = "we_AzureBlobStorageConnectionstring";
        private const string SettingsSeqserverurlKey = "we_SeqServerUrl";
        private const string SettingsSeqapikeyKey = "we_SeqApiKey";

        private readonly ISettingsProvider _settingsProvider;
        private LogEventLevel _logLevel = LogEventLevel.Error;
        private string _seqServerUrl;
        private string _seqApiKey;
        private Logger _logger;

        /// <summary>
        ///     Get Serilog Azure Blob Storage Logger class
        /// </summary>
        public GetSerilogPluginExecutor(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider ?? throw new ArgumentNullException(nameof(settingsProvider));
            ReadSettings();
        }

        /// <summary>
        ///     Returns the configured instance of the logger
        /// </summary>
        public ILogger Logger
        {
            get
            {
                if (_logger != null)
                {
                    return _logger;
                }

                LoggerConfiguration cfg = new LoggerConfiguration();

                /*
                    Settings können über die Datei CustomerSettings.xml in den CRM Webresourcen angepasst werden

                    <Setting Key="we_PluginLogLevel" Value="Verbose"></Setting>
                    <Setting Key="we_AzureBlobStorageConnectionstring" Value=""></Setting>
                */

                //if (!String.IsNullOrEmpty(_azureBlobStorageConnectionString))
                //{
                //    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_azureBlobStorageConnectionString);
                //    if (storageAccount == null)
                //    {
                //        throw new InvalidPluginExecutionException("Azure storage account is null");
                //    }

                //    if (!String.IsNullOrEmpty(_logmessageFormat))
                //    {
                //        cfg.WriteTo.AzureBlobStorage(storageAccount, restrictedToMinimumLevel: LogEventLevel.Verbose, outputTemplate: _logmessageFormat);
                //    }
                //    else
                //    {
                //        cfg.WriteTo.AzureBlobStorage(storageAccount, restrictedToMinimumLevel: LogEventLevel.Verbose);
                //    }
                //}

                if (!string.IsNullOrEmpty(_seqServerUrl))
                {
                    cfg.WriteTo.Seq(_seqServerUrl, restrictedToMinimumLevel: LogEventLevel.Verbose, apiKey: _seqApiKey);
                }

                switch (_logLevel)
                {
                    case LogEventLevel.Debug:
                        cfg.MinimumLevel.Debug();
                        break;
                    case LogEventLevel.Information:
                        cfg.MinimumLevel.Information();
                        break;
                    case LogEventLevel.Warning:
                        cfg.MinimumLevel.Warning();
                        break;
                    case LogEventLevel.Error:
                        cfg.MinimumLevel.Error();
                        break;
                    case LogEventLevel.Fatal:
                        cfg.MinimumLevel.Fatal();
                        break;
                    case LogEventLevel.Verbose:
                        cfg.MinimumLevel.Verbose();
                        break;
                    default:
                        cfg.MinimumLevel.Warning();
                        break;
                }

                cfg.Enrich.FromLogContext();
                _logger = cfg.CreateLogger();
                Log.Logger = _logger;

                return _logger;
            }
        }

        /// <summary>
        ///     Read the required settings from global settings solution. The settings are stored in the CustomerSettings.xml
        ///     webresource on crm.
        /// </summary>
        private void ReadSettings()
        {
            string cfgLogLevel = _settingsProvider.GetValue<string>(SettingsPluginloglevelKey);
            if (Enum.TryParse(cfgLogLevel, true, out LogEventLevel parsedLogLevel))
            {
                _logLevel = parsedLogLevel;
            }

            _seqServerUrl = _settingsProvider.GetValue<string>(SettingsSeqserverurlKey);
            _seqApiKey = _settingsProvider.GetValue<string>(SettingsSeqapikeyKey);
        }

        /// <summary>
        ///     Runs the passed Func within a logging scope and exception logging
        /// </summary>
        /// <param name="pluginFuncExpression"></param>
        /// <returns>The result of the passed func</returns>
        public T RunWithLogging<T>(Expression<Func<T>> pluginFuncExpression)
        {
            if (pluginFuncExpression == null)
            {
                throw new ArgumentNullException(nameof(pluginFuncExpression));
            }

            Logger.Verbose($"Begin Plugin Orchestration: {pluginFuncExpression.Body}");

            T executionMain;
            try
            {
                Func<T> runFunc = pluginFuncExpression.Compile();
                executionMain = runFunc();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.Message);
                throw;
            }

            Logger.Verbose($"End Plugin Orchestration: {pluginFuncExpression.Body}");
            return executionMain;
        }
    }
}
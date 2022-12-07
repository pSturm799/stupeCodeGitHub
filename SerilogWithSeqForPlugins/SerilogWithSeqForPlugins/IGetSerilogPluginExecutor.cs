using System.Linq.Expressions;
using Serilog;

namespace SerilogWithSeqForPlugins
{
    /// <summary>
    ///     Interface for the Serilog Azure Blob Storage Logger
    /// </summary>
    public interface IGetSerilogPluginExecutor
    {
        /// <summary>
        ///     Runs the passed Func within a logging scope and exception logging
        /// </summary>
        /// <param name="pluginFuncExpression"></param>
        /// <returns>The result of the passed func</returns>
        T RunWithLogging<T>(Expression<Func<T>> pluginFuncExpression);

        /// <summary>
        /// </summary>
        ILogger Logger { get; }
    }
}
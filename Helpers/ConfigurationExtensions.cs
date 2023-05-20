using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace StudentPortal.Helpers
{
    /// <summary>
    /// Extention class of IConfiguration
    /// </summary>
    internal static class ConfigurationExtensions
    {
        /// <summary>
        /// Method to read the configured page size.
        /// </summary>
        /// <param name="configuration">Class of IConfiguration</param>
        /// <returns>Value of page size</returns>
        public static int GetPageSize([NotNull] this IConfiguration configuration)
        {
            return configuration.GetValue("PageSize", 3);
        }
    }
}

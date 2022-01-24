
namespace FG.TradingSystem.Api
{
    /// <summary>
    /// Represents default values related to customer services
    /// </summary>
    public static partial class WeatherForecastServicesDefaults
    {
        /// <summary>
        /// Gets a password salt key size
        /// </summary>
        public static int PasswordSaltKeySize => 5;


        /// <summary>
        /// Gets a default hash format for customer password
        /// </summary>
        public static string DefaultHashedPasswordFormat => "SHA512";


        #region Caching defaults

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : id
        /// </remarks>
        public static string WeatherForecastByIdCacheKey => new("FG.weatherforecast.byId.{0}");




        #endregion

    }
}
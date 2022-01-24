namespace FG.TradingSystem.Core.Configuration
{
    /// <summary>
    /// Represents cache configuration parameters
    /// </summary>
    public partial class CacheConfig : IConfig
    {
        /// <summary>
        /// Gets or sets the default cache time in minutes
        /// </summary>
        public int DefaultCacheTime { get; set; } = 60;

        /// <summary>
        /// Gets or sets the short term cache time in minutes
        /// </summary>
        public int ShortTermCacheTime { get; set; } = 5;
        /// <summary>
        /// Gets or sets the long cache time in minutes
        /// </summary>
        public int LongCacheTime { get; set; } = 60 * 12 * 30 * 365;

        /// <summary>
        /// Gets or sets the bundled files cache time in minutes
        /// </summary>
        public int BundledFilesCacheTime { get; set; } = 120;

        /// <summary>
        /// Gets or sets the redis config
        /// </summary>
        public DistributedConfig Distributed { get; set; }

        /// <summary>
        /// Gets or sets the cluster config
        /// </summary>
        public ClusterConfig Cluster { get; set; }
    }

    public class DistributedConfig
    {
        /// <summary>
        /// Gets or sets the host 
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Gets or sets the port
        /// </summary>
        public string Port { get; set; }
    }


    public class ClusterConfig
    {
        /// <summary>
        /// Gets or sets the host 
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Gets or sets the port
        /// </summary>
        public string Port { get; set; }
        /// <summary>
        /// Gets or sets the bus config
        /// </summary>
        public BusConfig Bus { get; set; }



        public class BusConfig
        {
            /// <summary>
            /// Gets or sets the host 
            /// </summary>
            public string Host { get; set; }
            /// <summary>
            /// Gets or sets the port
            /// </summary>
            public string Port { get; set; }
        }
    }


    
}
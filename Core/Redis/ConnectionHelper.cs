using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Core.Redis;

public class ConnectionHelper
{
    static ConnectionHelper()
    {
        ConnectionHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() => {
            return ConnectionMultiplexer.Connect(ConfigurationManager.AppSetting.GetConnectionString("RedisURL"));
        });
    }
    private static Lazy<ConnectionMultiplexer> lazyConnection;
    public static ConnectionMultiplexer Connection
    {
        get
        {
            return lazyConnection.Value;
        }
    }
}

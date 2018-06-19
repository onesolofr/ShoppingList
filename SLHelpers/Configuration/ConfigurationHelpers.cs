using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace SLHelpers
{
    static public class ConfigurationHelpers
    {
        static public bool ContainsKey(this IConfiguration config, string key)
        {
            return config.GetChildren().Any(item => item.Key == key);
        }
    }
}

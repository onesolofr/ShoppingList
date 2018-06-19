using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace SLHelpers
{
    static public class ConfigurationHelpers
    {
        static public bool ContainsSection(this IConfiguration config, string section)
        {
            return config.GetSection(section).Value != null;
        }

        static public string GetSectionValue(this IConfiguration config, string section)
        {
            return config.GetSection(section).Value;
        }
    }
}

﻿using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace SLHelpers
{
    public interface ITrace
    {
        void Trace(string message);

        void Trace(string message, Exception exception);

        void Trace(Exception exception, string format, params object[] args);
    }

    public class TraceBase
    {
        protected ILog _logger;

        protected TraceBase(string name)
        {
            _logger = LogManager.GetLogger(name);
        }

        static TraceBase()
        {
            XmlConfigurator.Configure();
        }

        protected string GetExceptionData(Exception exception)
        {
            if (exception == null || exception.Data == null || exception.Data.Keys.Count == 0)
                return string.Empty;

            int index = 0;
            StringBuilder result = new StringBuilder("[");
            foreach (object key in exception.Data.Keys)
                result.Append(string.Format("{0} : \"{1}\"{2}", key, exception.Data[key], (index++) == 0 ? ";" : string.Empty));
            result.Append("]");

            return result.ToString();
        }
    }
}

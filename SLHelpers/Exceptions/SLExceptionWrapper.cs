using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using SLHelpers;

namespace SLHelpers.Exceptions
{
    public class SLExceptionWrapper : Exception
    {
        public SLExceptionWrapper() : base()
        {
            DoTrace(error =>
            {
                error.Trace(Message, this);
            });
        }

        public SLExceptionWrapper(Exception innerException) : base()
        {
            DoTrace(error =>
            {
                error.Trace(innerException == null ? innerException.Message : Message, innerException);
            });
        }

        public SLExceptionWrapper(string message) : base(message)
        {
            DoTrace(error =>
            {
                error.Trace(message);
            });
        }

        public SLExceptionWrapper(string message, Exception innerException) : base(message, innerException)
        {
            DoTrace(error =>
            {
                error.Trace(innerException == null ? innerException.Message : Message, innerException);
            });
        }

        public SLExceptionWrapper(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            DoTrace(error =>
            {
                error.Trace(Message, this);
            });
        }

        internal static void DoTrace(Action<ITrace> execute)
        {
            System.Threading.WaitCallback waitCallback = new System.Threading.WaitCallback((o) =>
            {
                ITrace trace = IoC.Resolve<ITrace>();
                if (trace != null)
                    execute(trace);
            });

            waitCallback(null);
        }
    }

    static public class SLExceptionManager
    {
        public static T Wrap<T>(T excpetion) where T : Exception
        {
            new SLExceptionWrapper(excpetion);

            return excpetion;
        }
    }
}

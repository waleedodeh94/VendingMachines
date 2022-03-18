using log4net;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace VendingMachines
{
    public static class Logger
    {

        private static readonly string LOG_CONFIG_FILE = @"log4net.config";
        private static log4net.ILog _log;

        static Logger()
        { }
        public static ILog GetLogger(Type type)
        {


            if (type == null)
            {
                type = typeof(Logger);
            }
            _log = LogManager.GetLogger(type);
            return _log;
        }

        public static void Debug(object message)
        {
            SetLog4NetConfiguration();
            _log.Debug(message);
            Console.WriteLine(message);
        }

        public static void Info(object message)
        {
            SetLog4NetConfiguration();
            _log.Info(message);
            Console.WriteLine($"Info: {message}");
        }
        public static void InfoFormat(string message, params object[] args)
        {
            SetLog4NetConfiguration();
            _log.InfoFormat(message, args);
        }

        //FormatFormat
        public static void ErrorFormat(string message, params object[] args)
        {
            SetLog4NetConfiguration();
            _log.ErrorFormat(message, args);
            Console.WriteLine(message);
        }
        public static void Error(object message)
        {
            SetLog4NetConfiguration();
            _log.Error(message);

            Console.WriteLine($"Error: {message}");
        }

        public static void WarnFormat(string message, params object[] args)
        {
            SetLog4NetConfiguration();
            _log.WarnFormat(message, args);
        }
        public static void Warn(object message)
        {
            SetLog4NetConfiguration();
            _log.Warn(message);
        }

        public static void Fatal(object message)
        {
            SetLog4NetConfiguration();
            _log.Fatal(message);
        }


        public static void DebugFormat(string message, params object[] args)
        {
            SetLog4NetConfiguration();
            _log.DebugFormat(message, args);
        }

        private static void SetLog4NetConfiguration()
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead(LOG_CONFIG_FILE));

            var repo = LogManager.CreateRepository(
                Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
        }
    }
}

using System;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using log4net;
using log4net.Config;

namespace log_in_module
{
    
    class Program
    {
         private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
       static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log in module.config"));
            ILog log = log4net.LogManager.GetLogger(typeof(Program));
            log.Debug("This is a debug message");
            log.Warn("This is a warn message");
            log.Error("This is a error message");
            log.Fatal("This is a fatal message");
            Console.ReadLine();
        }
    }
}

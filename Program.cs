using System;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using log4net;
using log4net.Config;
using NLog;
using Serilog;

namespace log_in_module
{
    
    class Program
    {
       static void Main(string[] args)
        {
            Log4net lg4net = new Log4net();
            lg4net.Login();

            // Nlog nlg = new Nlog();
            // nlg.Login();

            Serilog srlg = new Serilog();
            srlg.Login();
        }          
    }
    class Log4net
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
         public void Login()
         {
            var logRepository = log4net.LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            ILog log = log4net.LogManager.GetLogger(typeof(Program));
            log.Debug("This is a debug message");
            log.Warn("This is a warn message");
            log.Error("This is a error message");
            log.Fatal("This is a fatal message");
         }
    }
    class Nlog
    {
        private static NLog.Logger log = NLog.LogManager.GetLogger("nlog.config");
        public void Login()
        {
            log.Info("This is an info message");
            log.Debug("This is a debug message");
            log.Warn("This is a warn message");
            log.Error("This is an error message");
            log.Fatal("This is a fatal message");
        }
    }
    class Serilog
    {
        public void Login()
         {
            // Create Logger
            var log = new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File("logs/log.txt", rollOnFileSizeLimit: true, fileSizeLimitBytes: 10_000_000, retainedFileCountLimit: 3)
                    .CreateLogger();
            // Output logs
            log.Warning("This is a warning message");
            log.Information("This is an info message");
            log.Error("This is an error message");
            log.Fatal("This is a fatal message");
        }
    }
}

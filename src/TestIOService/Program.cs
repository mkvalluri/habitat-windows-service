using System.Configuration;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using System;

namespace TestIOService
{
    public partial class Program : ServiceBase
    {
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Program()
            };
            Run(ServicesToRun);
        }

        public Program()
        {
            ServiceName = "TestIOService";
            CanStop = true;
            AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            WriteStatus("TestIOService is starting");
            System.Timers.Timer timer = new System.Timers.Timer
            {
                Interval = Convert.ToDouble(ConfigurationManager.AppSettings["statusFileTimer"]) // 60 seconds  
            };
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
            WriteStatus("TestIOService is started");
        }

        protected override void OnStop()
        {
            WriteStatus("TestIOService is stopped");
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            WriteStatus("TestIOService is up");
        }

        private static void WriteStatus(string message)
        {
            var statusFileDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (ConfigurationManager.AppSettings["statusFileDir"] != null)
            {
                statusFileDir = ConfigurationManager.AppSettings["statusFileDir"];
            }
            using (var tw = new StreamWriter(Path.Combine(statusFileDir, "status.txt"), true))
            {
                tw.WriteLine(DateTime.Now.ToString() + ": " + message);
            }
        }
    }
}

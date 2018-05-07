using System.Configuration;
using System.IO;
using System.Reflection;
using System.ServiceProcess;

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
                Interval = 60000 // 60 seconds  
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
            File.CreateText(Path.Combine(statusFileDir, "status.txt"));
            File.WriteAllText(Path.Combine(statusFileDir, "status.txt"), message);
        }
    }
}

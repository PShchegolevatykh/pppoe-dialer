using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Configuration;

namespace PppoeDialer
{
    public partial class DialerService : ServiceBase
    {
        private Timer timer;
        private string connectionName;
        private string username;
        private string password;

        public DialerService()
        {
            InitializeComponent();
            double interval;
            if (!Double.TryParse(ConfigurationManager.AppSettings["PollInverval"], out interval))
            {
                interval = 60000; // default 1 minute
            }
            timer = new Timer(interval);
            timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Process.Start("rasdial.exe", String.Format("{0} {1} {2}",
                    connectionName ?? ConfigurationManager.AppSettings["ConnectionName"],
                    username ?? ConfigurationManager.AppSettings["Username"],
                    password ?? ConfigurationManager.AppSettings["Password"]));
            }
            catch (Exception ex)
            {
                // write to event log
                EventLog.WriteEntry("Application", "Exception: " + ex.Message);
                // or write to a text file (in order to do that you should change installer privelegies)
                //string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "pppoe_dialer_error.log";
                //TextWriter writer = new StreamWriter(path, true);
                //writer.WriteLine(String.Format("Date: {0}\nException: {1}\n\n", DateTime.Now.ToString(CultureInfo.InvariantCulture), ex.Message));
                //writer.Close();
            }
        }

        protected override void OnStart(string[] args)
        {
            timer.Start();
        }

        protected override void OnStop()
        {
            timer.Stop();
        }

        protected override void OnContinue()
        {
            timer.Start();
        }

        protected override void OnPause()
        {
            timer.Stop();
        }

        protected override void OnShutdown()
        {
            timer.Stop();
        }
    }
}

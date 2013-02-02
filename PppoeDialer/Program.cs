using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;

namespace PppoeDialer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new DialerService() 
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}

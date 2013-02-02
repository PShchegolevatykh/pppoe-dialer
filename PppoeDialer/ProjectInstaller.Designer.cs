namespace PppoeDialer
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dialerServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.dialerServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // dialerServiceProcessInstaller
            // 
            this.dialerServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.dialerServiceProcessInstaller.Password = null;
            this.dialerServiceProcessInstaller.Username = null;
            // 
            // dialerServiceInstaller
            // 
            this.dialerServiceInstaller.Description = "Polls preconfigured PPPoE connection.";
            this.dialerServiceInstaller.DisplayName = "PPPoE Connection Dialer";
            this.dialerServiceInstaller.ServiceName = "DialerService";
            this.dialerServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.dialerServiceProcessInstaller,
            this.dialerServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller dialerServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller dialerServiceInstaller;
    }
}
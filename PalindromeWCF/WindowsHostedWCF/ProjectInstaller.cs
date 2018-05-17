using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace WindowsHostedWCF
{
    [RunInstallerAttribute(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;
        public ProjectInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();
            service.ServiceName = "WCFPalindromeWindowsHosted";
            Installers.Add(process);
            Installers.Add(service);
        }
    }
}

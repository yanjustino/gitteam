using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using Gitteam.Services;

namespace Gitteam.WindowsService
{
    public partial class GitteamService : ServiceBase
    {
        private ServiceHost host = null;

        public GitteamService()
        {
            InitializeComponent();
        }

        protected void CreatHost(ServiceHost host, string uri, Type service, Type contract)
        {
            try
            {
                // Criando o Behaivor
                ServiceMetadataBehavior metadatabehavior = new ServiceMetadataBehavior();
                metadatabehavior.HttpGetEnabled = true;

                // Criando e configurando o Binding
                BasicHttpBinding binding = new BasicHttpBinding();

                // Segurança
                binding.SendTimeout = new TimeSpan(0, 2, 0);
                binding.ReceiveTimeout = new TimeSpan(0, 2, 0);
                binding.Security.Mode = BasicHttpSecurityMode.None;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;

                // Transporte
                binding.TransferMode = TransferMode.Buffered;
                binding.MaxReceivedMessageSize = 65536 * 10000;
                binding.MaxBufferPoolSize = 524288;
                binding.MaxBufferSize = 65536 * 10000;

                binding.ReaderQuotas.MaxArrayLength = 16384 * 10000;
                binding.ReaderQuotas.MaxBytesPerRead = 4096 * 10000;
                binding.ReaderQuotas.MaxDepth = 32 * 10000;
                binding.ReaderQuotas.MaxNameTableCharCount = 16384 * 10000;
                binding.ReaderQuotas.MaxStringContentLength = 8192 * 10000;

                //Criando o ServiceHost
                host = new ServiceHost(service, new Uri(uri));
                host.AddServiceEndpoint(contract, binding, uri);
                host.Description.Behaviors.Add(metadatabehavior);

                // Abrindo o ServiceHost
                host.Open();
            }
            catch (Exception ex)
            {
                host.Abort();
                EventLog.WriteEntry("GitteamAddEndPoint", "Erro ao criar endpoint no servicehost (" + uri + "): " + ex.Message, EventLogEntryType.Error, 1000);
            }
        }


        protected override void OnStart(string[] args)
        {
            string port = "5013";
            string dns = System.Net.Dns.GetHostEntry("").HostName;
            string uri = string.Format("http://{0}:{1}/gitteam/services/", dns, port);

            CreatHost(host, uri, typeof(CommandGitService), typeof(ICommandGitService));
        }

        protected override void OnStop()
        {
            try
            {
                if (host != null) host.Close();
            }
            catch (Exception ex)
            {
                host.Abort();
                EventLog.WriteEntry("GitteamOnStop", "Erro ao parar o serviço: " + ex.Message, EventLogEntryType.Error, 1000);
            }
        }
    }
}

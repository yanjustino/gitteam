using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace GitteamClientViewer
{
    public partial class main : Form
    {

        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GitteamServices.CommandGitServiceClient services = new GitteamServices.CommandGitServiceClient();
            services.Endpoint.Address = new System.ServiceModel.EndpointAddress(new Uri("http://" + txtIP.Text + ":5013/gitteam/services/"));
            var result = services.FindNoCommitedFiles();

            richTextBox1.Lines = result.Split(';');
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Gitteam
{
    public class GitCommand
    {
        public static string Execute(string commad, string directory)
        {
            ProcessStartInfo gitInfo = new ProcessStartInfo();
            gitInfo.CreateNoWindow = true;
            gitInfo.RedirectStandardError = true;
            gitInfo.RedirectStandardOutput = true;
            gitInfo.FileName = @"d:\Program Files\git\bin\git.exe";

            Process gitProcess = new Process();
            gitInfo.UseShellExecute = false;
            gitInfo.Arguments = commad; 
            gitInfo.WorkingDirectory = directory;

            gitProcess.StartInfo = gitInfo;
            gitProcess.Start();

            string stderr_str = gitProcess.StandardError.ReadToEnd();  // pick up STDERR
            string stdout_str = gitProcess.StandardOutput.ReadToEnd(); // pick up STDOUT

            gitProcess.WaitForExit();
            gitProcess.Close();

            return stdout_str;
        }
    }
}

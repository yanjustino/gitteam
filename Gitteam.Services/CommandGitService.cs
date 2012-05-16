using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Gitteam.Services
{
    public class CommandGitService : ICommandGitService
    {
        private Dictionary<string, string> DirectoriesPaths()
        {
            var directories = new Dictionary<string,string>();
            directories.Add("Posto On-Line", "D:\\Producao\\Postos\\");
            directories.Add("Phoenix", "D:\\Producao\\Phoenix\\");

            return directories;
        }


        public string FindNoCommitedFiles()
        {
            var result = "";
            var breakLine = "";

            foreach (var directory in DirectoriesPaths())
            {
                GitRepository repository = new GitRepository(directory.Value);
                result += breakLine + directory.Key + " : " + repository.ModifiedFiles().ToString();
                breakLine = ";";                
            }

            return result;
        }
    }
}

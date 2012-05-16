using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Gitteam
{
    public class GitRepository
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public GitRepository()
        {

        }
        
        public GitRepository(string path)
        {
            this.Path = path;
        }

        public GitRepository(string id, string path)
        {
            this.Id = id;
            this.Path = path;
        }

        public GitRepository(string id, string name, string path )
        {
            this.Id = id;
            this.Name = name;
            this.Path = path;
        }

        public int ModifiedFiles()
        {
            int countModified = 0;

            var resutlCommand = GitCommand.Execute("status", this.Path);
            foreach (var line in resutlCommand.Split('\n'))
            {
                if (line.Contains("modified:"))
                    countModified++;
            }
            return countModified;
        }
    }
}

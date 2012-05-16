using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace Gitteam
{
    public class GitRepositoryManager
    {
        private string DIRECTORY_GIT_REPOSITORIES = Environment.CurrentDirectory + "\\.gitteam\\repo\\";
        private string PATH_FILE_GIT_REPOSITORIES = Environment.CurrentDirectory + "\\.gitteam\\repo\\repositories.xml";

        public GitRepositoryManager()
        {
            CreateDependencies();
        }

        private void CreateDependencies()
        {
            if (!Directory.Exists(DIRECTORY_GIT_REPOSITORIES))
                Directory.CreateDirectory(DIRECTORY_GIT_REPOSITORIES);

            if (!File.Exists(PATH_FILE_GIT_REPOSITORIES))
            {
                XDocument doc = new XDocument(new XElement("repositories"));
                doc.Save(PATH_FILE_GIT_REPOSITORIES);
            }
        }

        private XDocument OpenGitRepositoriesFile()
        {
            var xml = XDocument.Load(PATH_FILE_GIT_REPOSITORIES);
            return xml;
        }

        public void Save(GitRepository repository)
        {
            repository.Id = Guid.NewGuid().ToString();

            var xml = OpenGitRepositoriesFile();
            var elements = xml.Element("repositories");
            elements.Add(new XElement("repository", new XAttribute("id", repository.Id), new XAttribute("path", repository.Path)));

            xml.Save(PATH_FILE_GIT_REPOSITORIES);
        }

        public void Remove(string id)
        {
            var xml = OpenGitRepositoriesFile();
            
            xml.Elements("repositories").Elements()
               .Where(e => e.Attribute("id").Value == id)
               .FirstOrDefault().Remove();
            
            xml.Save(PATH_FILE_GIT_REPOSITORIES);
        }

        public GitRepository Find(string id)
        {
            var xml = OpenGitRepositoriesFile();
            var element = xml.Elements("repositories").Elements().Where(e => e.Attribute("id").Value == id).FirstOrDefault();

            if (element == null)
                return null;

            var path = element.Attribute("path").Value;
            return new GitRepository(id, path);
        }

        public IEnumerable<GitRepository> All()
        {
            var xml = OpenGitRepositoriesFile();
            var elements = xml.Elements("repositories").Elements().ToList();

            foreach (var element in elements)
            {
                var id = element.Attribute("id").Value;
                var path = element.Attribute("path").Value;

                yield return new GitRepository(id, path);
            }
        }
    }
}

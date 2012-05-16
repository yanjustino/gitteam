using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Gitteam.Services
{
    [ServiceContract]
    public interface ICommandGitService
    {
        [OperationContract]
        string FindNoCommitedFiles();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Problem1WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceProblem1" in both code and config file together.
    [ServiceContract]
    public interface IServiceProblem1
    {
        [OperationContract]
        string RegisterClient(string nome, string email, string data, string celular, string telefoneResidencial);
    }
}

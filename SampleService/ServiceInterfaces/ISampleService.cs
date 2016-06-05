using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace SampleService.ServiceInterfaces
{
    [ServiceContract]
    public interface ISampleService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/Login?user={username}&pass={password}", Method = "GET")]
        UserInfo Login(string username, string password);     
    }
}

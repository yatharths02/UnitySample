using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SampleServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(SampleService.ServiceClasses.SampleService)))
            {
                host.Open();
                Console.WriteLine("Service started at " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}

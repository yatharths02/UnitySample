using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApp.Helpers
{
    public class DependencyHelper
    {
        public static IUnityContainer container { get; set; }
    }
}
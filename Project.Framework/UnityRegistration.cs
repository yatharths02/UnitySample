using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project.Framework
{
    /// <summary>
    /// Unity Registration Class
    /// </summary>
    public sealed class UnityRegistration
    {
        /// <summary>
        /// Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static IUnityContainer Register(HttpConfiguration config)
        {
            IUnityContainer container = new UnityContainer();

            config.DependencyResolver = new UnityResolver(container);

            return container;
        }


        /// <summary>
        /// Registers the interceptor.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void RegisterInterceptor(IUnityContainer contatiner)
        {
            contatiner.AddNewExtension<Interception>();
        }
    }
}

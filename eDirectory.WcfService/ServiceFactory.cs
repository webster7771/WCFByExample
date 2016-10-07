using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;

namespace eDirectory.WcfService
{
    public class ServiceFactory
        : ServiceHostFactory
    {
        static readonly Object ServiceLock = new object();
        static bool IsInitialized;

        protected override ServiceHost CreateServiceHost(
            Type serviceType, 
            Uri[] baseAddresses)
        {
            if (!IsInitialized) InitializeService();
            return base.CreateServiceHost(serviceType, baseAddresses);
        }

        private void InitializeService()
        {
            lock(ServiceLock)
            {
                if (IsInitialized) return;
                InitializeDependency();
                IsInitialized = true;
            }
        }

        private void InitializeDependency()
        {
            //TODO: Any initialization like Dependency Injection to make sure it's ready.
        }
    }
}
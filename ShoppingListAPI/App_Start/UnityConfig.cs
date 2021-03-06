using Microsoft.Practices.Unity;
using Repository;
using System.Web.Http;
using Unity.WebApi;

namespace ShoppingListAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
                    
            var itemRepository = new InMemoryItemRepository();
            container.RegisterInstance<IItemRepository>(itemRepository);
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}
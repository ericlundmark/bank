using System;
using System.Linq;
using Bank.Models;
using Bank.Repositories;
using Bank.Utility;

namespace Bank.App_Start
{
    public class ProviderConfig
    {
        public static void RegisterProviders()
        {
            var repository = new ProviderRepository(new ApplicationDbContext());
            var providers =
                typeof(ProviderService).Assembly.GetTypes()
                    .Where(t => t.BaseType == typeof(ProviderService))
                    .Select(Activator.CreateInstance);

            foreach (ProviderService providerService in providers)
            {
                var provider = repository.Find(providerService.Name);
                if (provider == null)
                {
                    provider = new Provider { Name = providerService.Name, State = ProviderState.Inactive };
                    repository.Create(provider);
                }
                if (provider.State == ProviderState.Active)
                {
                    providerService.Run();
                }
            }
        }
    }
}
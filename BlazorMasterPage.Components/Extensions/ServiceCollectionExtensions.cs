using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using BlazorMasterPage.Components.Services;
using System.Reflection.Emit;

namespace BlazorMasterPage.Components 
{
    public static class ServiceCollectionExtensions
    {
        /* public static IServiceCollection AddBootstrapProviders(this IServiceCollection serviceCollection, Action<IClassProvider> configureClassProvider = null)
         {
             BootstrapClassProvider classProvider = new BootstrapClassProvider();
             configureClassProvider?.Invoke(classProvider);

             serviceCollection.AddSingleton<IClassProvider>(classProvider);
             serviceCollection.AddSingleton<IStyleProvider, BootstrapStyleProvider>();
             serviceCollection.AddScoped<IJSRunner, BootstrapJSRunner>();
             serviceCollection.AddSingleton<IIDGenerator>(new IDGenerator());
             return serviceCollection;
         }*/

        public static IServiceCollection AddBootstrapProviders(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ClassProvider>(new BootstrapClassProvider());
            serviceCollection.AddSingleton<StyleProvider>(new BootstrapStyleProvider());
            serviceCollection.AddScoped<IJSRunner, BootstrapJSRunner>();
            serviceCollection.AddSingleton<IIDGenerator>(new IDGenerator());
            return serviceCollection;
        }
    }
}

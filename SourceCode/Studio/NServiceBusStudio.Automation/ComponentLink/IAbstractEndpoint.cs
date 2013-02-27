﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBusStudio;
using NuPattern.Runtime;

namespace AbstractEndpoint
{
    public interface IAbstractEndpoint : IToolkitInterface, IProjectReferenced
    {
        string Namespace { get; }
        string InstanceName { get; }

        IAbstractEndpointComponents EndpointComponents { get; }
        Boolean CommandSenderNeedsRegistration { get; }
        
        // For Usage: Use CustomizationFuncs() extension method instead
        EndpointCustomizationFuncs Customization { get; }

        // Propagate application property values on change
        IEnumerable<string> OverridenProperties { get; }
        string ErrorQueue { get; set; }
        string ForwardReceivedMessagesTo { get; set; }
    }

    public static class AbstractEndpointExtensions
    {
        public static void RaiseOnInitializing(this IAbstractEndpoint endpoint)
        {
            endpoint.As<IProductElement>().Root.As<IApplication>().RaiseOnInitializingEndpoint(endpoint);
        }

        public static void RaiseOnInstantiated(this IAbstractEndpoint endpoint)
        {
            endpoint.As<IProductElement>().Root.As<IApplication>().RaiseOnInstantiatedEndpoint(endpoint);
        }

        public static EndpointCustomizationFuncs CustomizationFuncs(this IAbstractEndpoint endpoint)
        {
            if (DefaultCustomizationFuncs == null)
            {
                DefaultCustomizationFuncs = EndpointCustomizationFuncs.CreateDefault(); 
            }
            if (endpoint == null || endpoint.Customization == null)
            {
                return DefaultCustomizationFuncs;
            }
            else
            {
                return endpoint.Customization;
            }
        }

        private static EndpointCustomizationFuncs DefaultCustomizationFuncs { get; set; }
    }

    public class EndpointCustomizationFuncs
    {
        public Func<IComponent, string> GetBaseSenderType { get; set; }
        public Func<IAbstractEndpoint, IService, string> BuildNamespaceForComponentCode { get; set; }
        public Func<IAbstractEndpoint, IService, string, string> BuildPathForComponentCode { get; set; }
        public Func<IComponent, string> GetClassNameSuffix { get; set; }

        public static EndpointCustomizationFuncs CreateDefault()
        {
            return new EndpointCustomizationFuncs
            {
                GetBaseSenderType = c => string.Empty,
                BuildNamespaceForComponentCode = DefaultBuildNamespaceForComponentCode,
                BuildPathForComponentCode = DefaultBuildPathForComponentCode,
                GetClassNameSuffix = c => string.Empty,
            };
        }

        private static string DefaultBuildNamespaceForComponentCode(IAbstractEndpoint endpoint, IService service)
        {
            return endpoint == null ? string.Empty : string.Format(@"{0}.{1}", endpoint.Project.Data.RootNamespace, service.CodeIdentifier);
        }

        private static string DefaultBuildPathForComponentCode(IAbstractEndpoint endpoint, IService service, string subPath)
        {
            var result = string.Format(@"{0}\{1}", endpoint.Project.Name, service.InstanceName);
            if (subPath != string.Empty && subPath != null)
            {
                result = string.Format(@"{0}\Infrastructure\{1}\{2}", endpoint.Project.Name, subPath, service.InstanceName);
            }
            return result;
        }

    }
}

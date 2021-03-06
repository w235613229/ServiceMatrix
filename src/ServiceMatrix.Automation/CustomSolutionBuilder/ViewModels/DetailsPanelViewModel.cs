﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractEndpoint;
using NuPattern.Runtime.UI;
using NuPattern.Runtime;
using System.Windows;
using NServiceBusStudio.Automation.CustomSolutionBuilder.Views;
using NServiceBusStudio.Automation.CustomSolutionBuilder.Infrastructure;
using NuPattern.Runtime.UI.ViewModels;

namespace NServiceBusStudio.Automation.CustomSolutionBuilder.ViewModels
{
    public class DetailsPanelViewModel
    {
        public Action CleanDetails { get; set; }

        public Action<int, FrameworkElement> SetPanel { get; set; }

        public void BuildDetailsForEndpoint(IAbstractEndpoint endpoint, ISolutionBuilderViewModel solutionBuilderModel)
        {
            var application = endpoint.As<IProductElement>().Root.As<IApplication>();
            var allcomponents = application.Design.Services.Service.SelectMany(s => s.Components.Component);
            var components = allcomponents.Where(c => endpoint.EndpointComponents.AbstractComponentLinks.Any(cl => cl.ComponentReference != null && cl.ComponentReference.Value == c));

            this.CleanDetails();

            // Components
            this.CreateComponentsPanelForEndpoint(solutionBuilderModel, components, endpoint.EndpointComponents.AbstractComponentLinks, 0);

            // Commands
            this.CreateCommandsPanel(solutionBuilderModel, components, 1);

            // Events
            this.CreateEventsPanel(solutionBuilderModel, components, 2);
        }

        public void BuildDetailsForEvent(IEvent iEvent, ISolutionBuilderViewModel solutionBuilderModel)
        {
            var application = iEvent.As<IProductElement>().Root.As<IApplication>();
            var componentsPublishing = application.Design.Services.Service
                .SelectMany(s => s.Components.Component.Where(c => c.Publishes.EventLinks.Any(el => el.EventReference.Value == iEvent)));
            var componentsSubscribing = application.Design.Services.Service
                .SelectMany(s => s.Components.Component.Where(c => c.Subscribes.SubscribedEventLinks.Any(el => el.EventReference.Value == iEvent)));
            var endpoints = application.Design.Endpoints.GetAll()
                .Where(ep => ep.EndpointComponents.AbstractComponentLinks.Any(cl => componentsPublishing.Contains(cl.ComponentReference.Value) || componentsSubscribing.Contains(cl.ComponentReference.Value)));

            this.CleanDetails();

            // Endpoints
            this.CreateEndpointsPanel(application, solutionBuilderModel, endpoints, 0);

            // Components
            this.CreateComponentsPanel(solutionBuilderModel, componentsPublishing, 1, "Published by ");
            this.CreateComponentsPanel(solutionBuilderModel, componentsSubscribing, 2, "Subscribed by ");

        }

        public void BuildDetailsForCommand(ICommand command, ISolutionBuilderViewModel solutionBuilderModel)
        {
            var application = command.As<IProductElement>().Root.As<IApplication>();
            var componentsSending = application.Design.Services.Service
                .SelectMany(s => s.Components.Component.Where(c => c.Publishes.CommandLinks.Any(cl => cl.CommandReference.Value == command)));
            var componentsReceiving = application.Design.Services.Service
                .SelectMany(s => s.Components.Component.Where(c => c.Subscribes.ProcessedCommandLinks.Any(cl => cl.CommandReference.Value == command)));
            var endpoints = application.Design.Endpoints.GetAll()
                .Where(ep => ep.EndpointComponents.AbstractComponentLinks.Any(cl => componentsSending.Contains(cl.ComponentReference.Value) || componentsReceiving.Contains(cl.ComponentReference.Value)));

            this.CleanDetails();

            // Endpoints
            this.CreateEndpointsPanel(application, solutionBuilderModel, endpoints, 0);

            // Components
            this.CreateComponentsPanel(solutionBuilderModel, componentsSending, 1, "Sent by ");
            this.CreateComponentsPanel(solutionBuilderModel, componentsReceiving, 2, "Received by ");

        }

        public void BuildDetailsForComponent(IComponent component, ISolutionBuilderViewModel solutionBuilderModel)
        {
            var application = component.As<IProductElement>().Root.As<IApplication>();
            var components = new List<IComponent> { component };
            var endpoints = application.Design.Endpoints.GetAll()
                .Where(ep => ep.EndpointComponents.AbstractComponentLinks.Any(cl => cl.ComponentReference.Value == component));

            this.CleanDetails();

            // Endpoints
            this.CreateEndpointsPanel(application, solutionBuilderModel, endpoints, 0);

            // Commands
            this.CreateCommandsPanel(solutionBuilderModel, components, 1
                , component.Publishes.As<IProductElement>());

            // Events
            this.CreateEventsPanel(solutionBuilderModel, components, 2
                , component.Publishes.As<IProductElement>(), component.Subscribes.As<IProductElement>());

        }

        private void CreateEndpointsPanel(IApplication application, ISolutionBuilderViewModel solutionBuilderModel, IEnumerable<IAbstractEndpoint> endpoints, int position)
        {
            var endpointsVM = new InnerPanelViewModel();
            endpointsVM.Title = "Deployed to the following Endpoints";
            endpointsVM.Items.Add(new InnerPanelTitle { Product = application.As<IProductElement>(), Text = application.InstanceName });
            foreach (var endpoint in endpoints)
            {
                endpointsVM.Items.Add(new InnerPanelItem { Product = endpoint.As<IProductElement>(), Text = endpoint.As<IProductElement>().InstanceName });
            }
            this.SetPanel(position, new LogicalView(new LogicalViewModel(solutionBuilderModel, endpointsVM)));
        }

        private void CreateEventsPanel(ISolutionBuilderViewModel solutionBuilderModel, IEnumerable<IComponent> components, int position
                                        , IProductElement published = null, IProductElement subscribed = null)
        {
            var eventsVM = new InnerPanelViewModel();
            eventsVM.Title = "Events";
            eventsVM.Items.Add(new InnerPanelTitle { Text = "Published", Product = published, MenuFilters = new string[] { "Publish Event" }, ForceText = true });
            foreach (var publish in components.SelectMany(c => c.Publishes.EventLinks.Select(cl => cl.EventReference.Value)).Distinct())
            {
                eventsVM.Items.Add(new InnerPanelItem { Product = publish.As<IProductElement>(), Text = publish.InstanceName });
            }
            eventsVM.Items.Add(new InnerPanelTitle { Text = "Subscribed", Product = subscribed, MenuFilters = new string[] { "Process Messages…" }, ForceText = true });
            foreach (var subscribe in components.SelectMany(c => c.Subscribes.SubscribedEventLinks.Select(cl => cl.EventReference.Value)).Distinct())
            {
                if (subscribe != null)
                {
                    eventsVM.Items.Add(new InnerPanelItem { Product = subscribe.As<IProductElement>(), Text = subscribe.InstanceName });
                }
                else
                {
                    eventsVM.Items.Add(new InnerPanelItem { Product = null, Text = "[All the messages]" });
                }
            }
            this.SetPanel(position, new LogicalView(new LogicalViewModel(solutionBuilderModel, eventsVM)));
        }

        private void CreateCommandsPanel(ISolutionBuilderViewModel solutionBuilderModel, IEnumerable<IComponent> components, int position
                                        , IProductElement sent = null, IProductElement received = null)
        {
            var commandsVM = new InnerPanelViewModel();
            commandsVM.Title = "Commands";
            commandsVM.Items.Add(new InnerPanelTitle { Text = "Sent", Product = sent, MenuFilters = new string[] { "Send Command" }, ForceText = true });
            foreach (var publish in components.SelectMany(c => c.Publishes.CommandLinks.Select(cl => cl.CommandReference.Value)).Distinct())
            {
                commandsVM.Items.Add(new InnerPanelItem { Product = publish.As<IProductElement>(), Text = publish.InstanceName });
            }
            commandsVM.Items.Add(new InnerPanelTitle { Text = "Received", ForceText = true });
            foreach (var subscribe in components.SelectMany(c => c.Subscribes.ProcessedCommandLinks.Select(cl => cl.CommandReference.Value)).Distinct())
            {
                commandsVM.Items.Add(new InnerPanelItem { Product = subscribe.As<IProductElement>(), Text = subscribe.InstanceName });
            }
            this.SetPanel(position, new LogicalView(new LogicalViewModel(solutionBuilderModel, commandsVM)));
        }


        private void CreateComponentsPanelForEndpoint(ISolutionBuilderViewModel solutionBuilderModel, 
            IEnumerable<IComponent> components,
            IEnumerable<IAbstractComponentLink> componentLinks, 
            int position, 
            string Preffix = "")
        {
            var componentsVM = new InnerPanelViewModel();
            componentsVM.Title = Preffix + "Components";
            foreach (var service in components.Select(c => c.Parent.Parent).Distinct())
            {
                componentsVM.Items.Add(new InnerPanelTitle { Product = service.As<IProductElement>(), Text = service.InstanceName });
                foreach (var component in components.Where(c => c.Parent.Parent == service))
                {
                    componentsVM.Items.Add(new InnerPanelItem { Product = component.As<IProductElement>(), Text = component.InstanceName });
                }
            }

            var view = new ComponentsOrderingView();
            view.SetComponentsView(new LogicalView(new LogicalViewModel(solutionBuilderModel, componentsVM)));
            view.SetComponentLinks(componentLinks);
            this.SetPanel(position, view);
        }

        private void CreateComponentsPanel(ISolutionBuilderViewModel solutionBuilderModel, IEnumerable<IComponent> components, int position, string Preffix = "")
        {
            var componentsVM = new InnerPanelViewModel();
            componentsVM.Title = Preffix + "Components";
            foreach (var service in components.Select(c => c.Parent.Parent).Distinct())
            {
                componentsVM.Items.Add(new InnerPanelTitle { Product = service.As<IProductElement>(), Text = service.InstanceName });
                foreach (var component in components.Where(c => c.Parent.Parent == service))
                {
                    componentsVM.Items.Add(new InnerPanelItem { Product = component.As<IProductElement>(), Text = component.InstanceName });
                }
            }
            this.SetPanel(position, new LogicalView(new LogicalViewModel(solutionBuilderModel, componentsVM)));
        }

        private void CreateInfrastructurePanel(ISolutionBuilderViewModel solutionBuilderModel, IInfrastructure infrastructure, int position)
        {
            var infrastructureVM = new InnerPanelViewModel();
            infrastructureVM.Title = "Infrastructure";

            infrastructureVM.Items.Add(new InnerPanelTitle { Product = infrastructure.As<IProductElement>(), Text = infrastructure.InstanceName });

            if (infrastructure.Security != null)
            {
                infrastructureVM.Items.Add(new InnerPanelTitle { Product = infrastructure.Security.As<IProductElement>(), Text = infrastructure.Security.InstanceName });
                if (infrastructure.Security.Authentication != null)
                {
                    infrastructureVM.Items.Add(new InnerPanelItem { Product = infrastructure.Security.Authentication.As<IProductElement>(), Text = infrastructure.Security.Authentication.InstanceName });
                }
            }

            this.SetPanel(position, new LogicalView(new LogicalViewModel(solutionBuilderModel, infrastructureVM)));
        }

        public void BuildDetailsForApplication(IApplication application, ISolutionBuilderViewModel solutionBuilderViewModel)
        {
            var allcomponents = application.Design.Services.Service.SelectMany(s => s.Components.Component);

            this.CleanDetails();

            this.SetPanel(0, new ApplicationPropertiesView { DataContext = application });

            //Infrastructure
            this.CreateInfrastructurePanel(solutionBuilderViewModel, application.Design.Infrastructure, 1);

            //// Components
            this.CreateComponentsPanel(solutionBuilderViewModel, allcomponents, 2);

            //// Commands
            //this.CreateCommandsPanel(solutionBuilderModel, components, 1);

            //// Events
            //this.CreateEventsPanel(solutionBuilderModel, components, 2);
        }

    }
}

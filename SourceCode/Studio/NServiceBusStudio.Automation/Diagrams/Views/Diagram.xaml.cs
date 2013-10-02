﻿using Mindscape.WpfDiagramming;
using Mindscape.WpfDiagramming.Foundation;
using NServiceBusStudio.Automation.Diagrams.ViewModels;
using NServiceBusStudio.Automation.Diagrams.ViewModels.BaseViewModels;
using NServiceBusStudio.Automation.Diagrams.ViewModels.Connections;
using NServiceBusStudio.Automation.Diagrams.ViewModels.Shapes;
using NuPattern.Presentation;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NServiceBusStudio.Automation.Diagrams.Views
{
    /// <summary>
    /// Interaction logic for Diagram.xaml
    /// </summary>
    public partial class Diagram : UserControl
    {
        public Diagram(NServiceBusDiagramAdapter adapter)
        {
            InitializeComponent();
            this.DataContext = new NServiceBusDiagramViewModel (adapter);

            var diagramElementsCollection = ds.DiagramElements as INotifyCollectionChanged;
            diagramElementsCollection.CollectionChanged += diagramElementsCollection_CollectionChanged;
        }

        private void diagramElementsCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                foreach (var item in e.NewItems)
                {
                    var diagramNodeElement = item as DiagramNodeElement;
                    if (diagramNodeElement != null)
                    {
                        diagramNodeElement.MouseEnter += diagramNodeElement_MouseEnter;
                        diagramNodeElement.MouseLeave += diagramNodeElement_MouseLeave;
                    }
                }
                break;
                case NotifyCollectionChangedAction.Remove:
                foreach (var item in e.OldItems)
                {
                    var diagramNodeElement = item as DiagramNodeElement;
                    if (diagramNodeElement != null)
                    {
                        diagramNodeElement.MouseEnter -= diagramNodeElement_MouseEnter;
                        diagramNodeElement.MouseLeave -= diagramNodeElement_MouseLeave;
                    }
                }
                break;
            }
        }

        private void diagramNodeElement_MouseEnter(object sender, MouseEventArgs e)
        {
            var diagramNodeElement = sender as DiagramNodeElement;
            var context = diagramNodeElement.Content as GroupableNode;

            ((NServiceBusDiagramViewModel)this.DataContext).Diagram.HighlightElement(context);
        }

        private void diagramNodeElement_MouseLeave(object sender, MouseEventArgs e)
        {
            var diagramNodeElement = sender as DiagramNodeElement;
            var context = diagramNodeElement.Content as GroupableNode;

            ((NServiceBusDiagramViewModel)this.DataContext).Diagram.UnhighlightElement(context);
        }
    }
}

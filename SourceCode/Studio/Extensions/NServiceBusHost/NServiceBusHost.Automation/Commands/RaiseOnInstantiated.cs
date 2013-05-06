﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using NuPattern.Runtime;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using abs = AbstractEndpoint;
namespace NServiceBusHost.Automation.Commands
{
    [DisplayName("Raise On Instantiated")]
    [Description("Raise On Instantiated")]
    [CLSCompliant(false)]
    public class RaiseOnInstantiated : FeatureCommand
    {
        [Required]
        [Import(AllowDefault = true)]
        public IProductElement CurrentItem { get; set; }

        public override void Execute()
        {
            abs.AbstractEndpointExtensions.RaiseOnInstantiated(this.CurrentItem.As<IToolkitInterface>() as abs.IAbstractEndpoint);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Composition;
using NuPattern.Runtime;

namespace NServiceBusHost.Automation.Commands
{
    [DisplayName("NService Bus Host OpenComponentCodeCommand")]
    [Description("NService Bus Host OpenComponentCodeCommand")]
    [CLSCompliant(false)]
    public class OpenComponentCodeCommand : FeatureCommand
    {
        [Required]
        [Import(AllowDefault = true)]
        public IProductElement CurrentElement { get; set; }

        public override void Execute()
        {
            var componentLink = this.CurrentElement.As<IComponentLink>();

            var automation = componentLink.ComponentReference.Value.As<IProductElement>().AutomationExtensions.FirstOrDefault(a => a.Name == "OpenCode");
            if (automation != null)
            {
                automation.Execute();
            }
            
        }
    }
}

﻿
//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebMVCEndpoint
{
	using global::NuPattern.Runtime;
	using global::System;
	using global::System.Collections.Generic;
	using global::System.ComponentModel;
	using global::System.ComponentModel.Design;
	using global::System.Drawing.Design;
	using Runtime = global::NuPattern.Runtime;

	///	<summary>
	///	Description for AbstractEndpoint.DefaultView.Components
	///	</summary>
	[Description("Description for AbstractEndpoint.DefaultView.Components")]
	[ToolkitInterface(ExtensionId ="e91869eb-ba2e-4420-baad-df72525d4fe5", DefinitionId = "0a1f4ed3-bea5-4caf-b04d-715f489a0a5d", ProxyType = typeof(EndpointComponents))]
	[System.CodeDom.Compiler.GeneratedCode("Pattern Toolkit Automation Library", "1.2.19.0")]
	public partial interface IEndpointComponents : IToolkitInterface
	{ 
		///	<summary>
		///	Notes for this element.
		///	</summary>
		[Description("Notes for this element.")]
		[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		String Notes { get; set; }
		
		///	<summary>
		///	The InTransaction.
		///	</summary>
		Boolean InTransaction { get;  }
		
		///	<summary>
		///	The IsSerializing.
		///	</summary>
		Boolean IsSerializing { get;  }
		
		///	<summary>
		///	The name of this element instance.
		///	</summary>
		[ParenthesizePropertyName(true)]
		[Description("The name of this element instance.")]
		String InstanceName { get; set; }
		
		///	<summary>
		///	The order of this element relative to its siblings.
		///	</summary>
		[ReadOnly(true)]
		[Description("The order of this element relative to its siblings.")]
		Double InstanceOrder { get; set; }
		
		///	<summary>
		///	The references of this element.
		///	</summary>
		[Description("The references of this element.")]
		IEnumerable<IReference> References { get;  }

		/// <summary>
		/// Gets the parent element.
		/// </summary>
		IDefaultView Parent { get; }
		
		/// <summary>
		/// Gets all instances of <see cref="IComponentLink"/> contained in this element.
		/// </summary>
		IEnumerable<IComponentLink> ComponentLinks { get; }
		
		/// <summary>
		///	Creates a new <see cref="IComponentLink"/>  and adds it to the <see cref="ComponentLinks"/> collection,  
		/// executing the optional <paramref name="initializer"/> if not <see langword="null"/>.
		///	</summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		IComponentLink CreateComponentLink(string name, Action<IComponentLink> initializer = null, bool raiseInstantiateEvents = true);
		
		///	<summary>
		///	Deletes this element from the store.
		///	</summary>
		void Delete();

		/// <summary>
		/// Gets the generic <see cref="Runtime.ICollection"/> underlying element.
		/// </summary>
		Runtime.ICollection AsCollection();
	}
}


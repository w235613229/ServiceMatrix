﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NServiceBusStudio
{
	using global::NServiceBusStudio.Automation.TypeConverters;
	using global::NuPattern.Runtime;
	using global::NuPattern.Runtime.Bindings;
	using global::NuPattern.Runtime.ToolkitInterface;
	using global::System;
	using global::System.Collections.Generic;
	using global::System.ComponentModel;
	using global::System.ComponentModel.Design;
	using global::System.Drawing.Design;
	using global::System.Windows.Forms.Design;
	using Runtime = global::NuPattern.Runtime;

	/// <summary>
	/// The root of your design.
	/// </summary>
	[Description("The root of your design.")]
	[ToolkitInterface(ExtensionId = "a5e9f15b-ad7f-4201-851e-186dd8db3bc9", DefinitionId = "2c52bbfe-442d-4f40-8f6f-7df75dd99cac", ProxyType = typeof(Application))]
	[System.CodeDom.Compiler.GeneratedCode("NuPattern Toolkit Library", "1.3.20.0")]
	public partial interface IApplication : IToolkitInterface
	{

		/// <summary>
		/// Description for Application.ForwardReceivedMessagesTo
		/// </summary>
		[Description("Description for Application.ForwardReceivedMessagesTo")]
		[DisplayName("Forward Received Messages To")]
		[Category("General")]
		String ForwardReceivedMessagesTo { get; set; }

		/// <summary>
		/// Description for Application.ErrorQueue
		/// </summary>
		[Description("Description for Application.ErrorQueue")]
		[DisplayName("Error Queue")]
		[Category("General")]
		String ErrorQueue { get; set; }

		/// <summary>
		/// Description for Application.NServiceBusVersion
		/// </summary>
		[Description("Description for Application.NServiceBusVersion")]
		[DisplayName("NService Bus Version")]
		[Category("General")]
		String NServiceBusVersion { get; set; }

		/// <summary>
		/// Description for Application.ExtensionPath
		/// </summary>
		[Description("Description for Application.ExtensionPath")]
		[DisplayName("Extension Path")]
		[Category("General")]
		String ExtensionPath { get; set; }

		/// <summary>
		/// Description for Application.Transport
		/// </summary>
		[Description("Description for Application.Transport")]
		[DisplayName("Transport")]
		[Category("General")]
		[TypeConverter(typeof(TransportTypeConverter))]
		String Transport { get; set; }

		/// <summary>
		/// Description for Application.TransportConnectionString
		/// </summary>
		[Description("Description for Application.TransportConnectionString")]
		[DisplayName("Transport Connection String")]
		[Category("General")]
		String TransportConnectionString { get; set; }

		/// <summary>
		/// Description for Application.CompanyLogo
		/// </summary>
		[Description("Description for Application.CompanyLogo")]
		[DisplayName("Company Logo")]
		[Category("General")]
		[Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
		String CompanyLogo { get; set; }

		/// <summary>
		/// Description for Application.Title
		/// </summary>
		[Description("Description for Application.Title")]
		[DisplayName("Title")]
		[Category("General")]
		String Title { get; set; }

		/// <summary>
		/// Description for Application.ToolkitVersion
		/// </summary>
		[Description("Description for Application.ToolkitVersion")]
		[DisplayName("Toolkit Version")]
		[Category("General")]
		String ToolkitVersion { get; set; }

		/// <summary>
		/// Gets or sets the ToolkitInfo property.
		/// </summary>
		IProductToolkitInfo ToolkitInfo { get; }

		/// <summary>
		/// Gets or sets the CurrentView property.
		/// </summary>
		IView CurrentView { get; set; }

		/// <summary>
		/// The name of this element instance.
		/// </summary>
		[Description("The name of this element instance.")]
		[ParenthesizePropertyName(true)]
		String InstanceName { get; set; }

		/// <summary>
		/// The order of this element relative to its siblings.
		/// </summary>
		[Description("The order of this element relative to its siblings.")]
		[ReadOnly(true)]
		Double InstanceOrder { get; set; }

		/// <summary>
		/// The references of this element.
		/// </summary>
		[Description("The references of this element.")]
		IEnumerable<IReference> References { get; }

		/// <summary>
		/// Notes for this element.
		/// </summary>
		[Description("Notes for this element.")]
		[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		String Notes { get; set; }

		/// <summary>
		/// Gets or sets the InTransaction property.
		/// </summary>
		Boolean InTransaction { get; }

		/// <summary>
		/// Gets or sets the IsSerializing property.
		/// </summary>
		Boolean IsSerializing { get; }

		/// <summary>
		/// Design view of your application, where you create your services and messages.
		/// </summary>
		[Description("Design view of your application, where you create your services and messages.")]
		IDesign Design { get; }

		/// <summary>
		/// Deletes this element.
		/// </summary>
		void Delete();

		/// <summary>
		/// Gets the generalized interface (<see cref="Runtime.IProduct"/>) of this element.
		/// </summary>
		Runtime.IProduct AsProduct();
	}
}

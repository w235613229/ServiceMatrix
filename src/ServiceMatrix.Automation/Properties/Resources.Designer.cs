﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NServiceBusStudio.Automation.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NServiceBusStudio.Automation.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to (None).
        /// </summary>
        internal static string ElementReference_DefaultNone {
            get {
                return ResourceManager.GetString("ElementReference_DefaultNone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Property does not reference any element..
        /// </summary>
        internal static string ElementReference_DefaultNoneDescription {
            get {
                return ResourceManager.GetString("ElementReference_DefaultNoneDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value &apos;{0}&apos; is not a valid TimeStamp.
        ///The syntax for a TimeStamp value is &apos;[-]{{ d | d.hh:mm[:ss[.ff]] | hh:mm[:ss[.ff]] }}&apos;..
        /// </summary>
        internal static string TimeSpanConverter_InvalidString {
            get {
                return ResourceManager.GetString("TimeSpanConverter_InvalidString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Element &apos;{0}&apos; is not valid and command execution cannot continue. Please verify the validation errors in the Errors List tool window..
        /// </summary>
        internal static string VerifyElementIsValid_ElementNotValid {
            get {
                return ResourceManager.GetString("VerifyElementIsValid_ElementNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Element &apos;{0}&apos; or one of its descendents is not valid and command execution cannot continue. Please verify the validation errors in the Errors List tool window..
        /// </summary>
        internal static string VerifyElementIsValid_ElementOrDescendentNotValid {
            get {
                return ResourceManager.GetString("VerifyElementIsValid_ElementOrDescendentNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Determined validation status of current element: &apos;{0}&apos;, with descendants &apos;{1}&apos;, as &apos;{2}&apos;.
        /// </summary>
        internal static string VerifyElementIsValid_TraceEvaluation {
            get {
                return ResourceManager.GetString("VerifyElementIsValid_TraceEvaluation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Determining validation status of current element: &apos;{0}&apos;, with descendants &apos;{1}&apos;..
        /// </summary>
        internal static string VerifyElementIsValid_TraceInitial {
            get {
                return ResourceManager.GetString("VerifyElementIsValid_TraceInitial", resourceCulture);
            }
        }
    }
}

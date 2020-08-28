﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DragonFruit.Six.Locale {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Errors {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Errors() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DragonFruit.Six.Locale.Errors", typeof(Errors).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An internet connection is required to use Dragon6.
        /// </summary>
        public static string NoInternet {
            get {
                return ResourceManager.GetString("NoInternet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Player {0} was not found on {1}.\nPlease check you entered the username correctly (as shown in the killfeed) and try again\nIf the issue still persists, try again later.
        /// </summary>
        public static string PlayerNotFound {
            get {
                return ResourceManager.GetString("PlayerNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Player Not Found.
        /// </summary>
        public static string PlayerNotFoundTitle {
            get {
                return ResourceManager.GetString("PlayerNotFoundTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Something went wrong trying to request data from a {0} server.\nPlease check you have full internet access and try again later..
        /// </summary>
        public static string ServerError {
            get {
                return ResourceManager.GetString("ServerError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Server Error: {0}.
        /// </summary>
        public static string ServerErrorTitle {
            get {
                return ResourceManager.GetString("ServerErrorTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An unexpected error has occured. The Dragon6 team have been notified and will investigate further..
        /// </summary>
        public static string UnexpectedError {
            get {
                return ResourceManager.GetString("UnexpectedError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unexpected Error.
        /// </summary>
        public static string UnexpectedErrorTitle {
            get {
                return ResourceManager.GetString("UnexpectedErrorTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This user&apos;s stats cannot be viewed (usually on GDPR grounds but sometimes by us).
        /// </summary>
        public static string UserBlockedError {
            get {
                return ResourceManager.GetString("UserBlockedError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User unavailable.
        /// </summary>
        public static string UserBlockedErrorTitle {
            get {
                return ResourceManager.GetString("UserBlockedErrorTitle", resourceCulture);
            }
        }
    }
}
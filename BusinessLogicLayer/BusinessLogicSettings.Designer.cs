﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessLogicLayer {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class BusinessLogicSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static BusinessLogicSettings defaultInstance = ((BusinessLogicSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new BusinessLogicSettings())));
        
        public static BusinessLogicSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string passwordRegEx {
            get {
                return ((string)(this["passwordRegEx"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int passwordMinNonAlphaNumericChars {
            get {
                return ((int)(this["passwordMinNonAlphaNumericChars"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int passwordMinUppercase {
            get {
                return ((int)(this["passwordMinUppercase"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int passwordMinLowercase {
            get {
                return ((int)(this["passwordMinLowercase"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int passwordMinNumerals {
            get {
                return ((int)(this["passwordMinNumerals"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8")]
        public int passwordMinLength {
            get {
                return ((int)(this["passwordMinLength"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>Administrator</string>
  <string>Staff</string>
  <string>User</string>
  <string>Sponsor</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection UserRoles {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["UserRoles"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>brake system</string>
  <string>engine</string>
  <string>drivetrain</string>
  <string>chassis</string>
  <string>bodywork</string>
  <string>electrical</string>
  <string>wiring</string>
  <string>Misc, Fit and Finish</string>
  <string>Steering</string>
  <string>Suspension</string>
  <string>Wheels and Tyres</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection DefaultCarParts {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["DefaultCarParts"]));
            }
            set {
                this["DefaultCarParts"] = value;
            }
        }
    }
}

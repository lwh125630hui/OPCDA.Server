﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=2.0.50727.312.
// 
namespace Opc.ConfigTool.Export {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.312")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://opcfoundation.org/ConfigTool", IsNullable=false)]
    public partial class ListOfRegisteredServers {
        
        private RegisteredServer[] serverField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Server")]
        public RegisteredServer[] Server {
            get {
                return this.serverField;
            }
            set {
                this.serverField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.312")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/ConfigTool")]
    public partial class RegisteredServer {
        
        private string progIdField;
        
        private string clsidField;
        
        private string descriptionField;
        
        private string wrapperClsidField;
        
        private string serverClsidField;
        
        private Parameter[] parameterField;
        
        /// <remarks/>
        public string ProgId {
            get {
                return this.progIdField;
            }
            set {
                this.progIdField = value;
            }
        }
        
        /// <remarks/>
        public string Clsid {
            get {
                return this.clsidField;
            }
            set {
                this.clsidField = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public string WrapperClsid {
            get {
                return this.wrapperClsidField;
            }
            set {
                this.wrapperClsidField = value;
            }
        }
        
        /// <remarks/>
        public string ServerClsid {
            get {
                return this.serverClsidField;
            }
            set {
                this.serverClsidField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Parameter")]
        public Parameter[] Parameter {
            get {
                return this.parameterField;
            }
            set {
                this.parameterField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.312")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://opcfoundation.org/ConfigTool")]
    public partial class Parameter {
        
        private string nameField;
        
        private string valueField;
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Process_APP_Desk.ServiceProcess_Region {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceProcess_Region.Process_RegionSoap")]
    public interface Process_RegionSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerRegionSinEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet TraerRegionSinEntidad_Escritorio(int _id_region);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerRegionSinEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> TraerRegionSinEntidad_EscritorioAsync(int _id_region);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerRegionConEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Process_APP_Desk.ServiceProcess_Region.Region TraerRegionConEntidad_Escritorio(int _id_region);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerRegionConEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<Process_APP_Desk.ServiceProcess_Region.Region> TraerRegionConEntidad_EscritorioAsync(int _id_region);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerTodasRegiones_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet TraerTodasRegiones_Escritorio();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerTodasRegiones_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> TraerTodasRegiones_EscritorioAsync();
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Region : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int id_regionField;
        
        private string nombreField;
        
        private string numeroField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int Id_region {
            get {
                return this.id_regionField;
            }
            set {
                this.id_regionField = value;
                this.RaisePropertyChanged("Id_region");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Nombre {
            get {
                return this.nombreField;
            }
            set {
                this.nombreField = value;
                this.RaisePropertyChanged("Nombre");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Numero {
            get {
                return this.numeroField;
            }
            set {
                this.numeroField = value;
                this.RaisePropertyChanged("Numero");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Process_RegionSoapChannel : Process_APP_Desk.ServiceProcess_Region.Process_RegionSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Process_RegionSoapClient : System.ServiceModel.ClientBase<Process_APP_Desk.ServiceProcess_Region.Process_RegionSoap>, Process_APP_Desk.ServiceProcess_Region.Process_RegionSoap {
        
        public Process_RegionSoapClient() {
        }
        
        public Process_RegionSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Process_RegionSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Process_RegionSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Process_RegionSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet TraerRegionSinEntidad_Escritorio(int _id_region) {
            return base.Channel.TraerRegionSinEntidad_Escritorio(_id_region);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> TraerRegionSinEntidad_EscritorioAsync(int _id_region) {
            return base.Channel.TraerRegionSinEntidad_EscritorioAsync(_id_region);
        }
        
        public Process_APP_Desk.ServiceProcess_Region.Region TraerRegionConEntidad_Escritorio(int _id_region) {
            return base.Channel.TraerRegionConEntidad_Escritorio(_id_region);
        }
        
        public System.Threading.Tasks.Task<Process_APP_Desk.ServiceProcess_Region.Region> TraerRegionConEntidad_EscritorioAsync(int _id_region) {
            return base.Channel.TraerRegionConEntidad_EscritorioAsync(_id_region);
        }
        
        public System.Data.DataSet TraerTodasRegiones_Escritorio() {
            return base.Channel.TraerTodasRegiones_Escritorio();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> TraerTodasRegiones_EscritorioAsync() {
            return base.Channel.TraerTodasRegiones_EscritorioAsync();
        }
    }
}

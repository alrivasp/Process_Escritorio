﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Process_APP_Desk.ServiceProcess_Comuna {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceProcess_Comuna.Process_ComunaSoap")]
    public interface Process_ComunaSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerComunaSinEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet TraerComunaSinEntidad_Escritorio(int _id_comuna);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerComunaSinEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> TraerComunaSinEntidad_EscritorioAsync(int _id_comuna);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerComunaConEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Process_APP_Desk.ServiceProcess_Comuna.Comuna TraerComunaConEntidad_Escritorio(int _id_comuna);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerComunaConEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<Process_APP_Desk.ServiceProcess_Comuna.Comuna> TraerComunaConEntidad_EscritorioAsync(int _id_comuna);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerTodasComunasPorProvincia_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet TraerTodasComunasPorProvincia_Escritorio(int _id_provincia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerTodasComunasPorProvincia_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> TraerTodasComunasPorProvincia_EscritorioAsync(int _id_provincia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerTodasComunas_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet TraerTodasComunas_Escritorio();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerTodasComunas_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> TraerTodasComunas_EscritorioAsync();
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Comuna : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int id_comunaField;
        
        private string nombreField;
        
        private int id_provinciaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int Id_comuna {
            get {
                return this.id_comunaField;
            }
            set {
                this.id_comunaField = value;
                this.RaisePropertyChanged("Id_comuna");
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
        public int Id_provincia {
            get {
                return this.id_provinciaField;
            }
            set {
                this.id_provinciaField = value;
                this.RaisePropertyChanged("Id_provincia");
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
    public interface Process_ComunaSoapChannel : Process_APP_Desk.ServiceProcess_Comuna.Process_ComunaSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Process_ComunaSoapClient : System.ServiceModel.ClientBase<Process_APP_Desk.ServiceProcess_Comuna.Process_ComunaSoap>, Process_APP_Desk.ServiceProcess_Comuna.Process_ComunaSoap {
        
        public Process_ComunaSoapClient() {
        }
        
        public Process_ComunaSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Process_ComunaSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Process_ComunaSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Process_ComunaSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet TraerComunaSinEntidad_Escritorio(int _id_comuna) {
            return base.Channel.TraerComunaSinEntidad_Escritorio(_id_comuna);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> TraerComunaSinEntidad_EscritorioAsync(int _id_comuna) {
            return base.Channel.TraerComunaSinEntidad_EscritorioAsync(_id_comuna);
        }
        
        public Process_APP_Desk.ServiceProcess_Comuna.Comuna TraerComunaConEntidad_Escritorio(int _id_comuna) {
            return base.Channel.TraerComunaConEntidad_Escritorio(_id_comuna);
        }
        
        public System.Threading.Tasks.Task<Process_APP_Desk.ServiceProcess_Comuna.Comuna> TraerComunaConEntidad_EscritorioAsync(int _id_comuna) {
            return base.Channel.TraerComunaConEntidad_EscritorioAsync(_id_comuna);
        }
        
        public System.Data.DataSet TraerTodasComunasPorProvincia_Escritorio(int _id_provincia) {
            return base.Channel.TraerTodasComunasPorProvincia_Escritorio(_id_provincia);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> TraerTodasComunasPorProvincia_EscritorioAsync(int _id_provincia) {
            return base.Channel.TraerTodasComunasPorProvincia_EscritorioAsync(_id_provincia);
        }
        
        public System.Data.DataSet TraerTodasComunas_Escritorio() {
            return base.Channel.TraerTodasComunas_Escritorio();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> TraerTodasComunas_EscritorioAsync() {
            return base.Channel.TraerTodasComunas_EscritorioAsync();
        }
    }
}

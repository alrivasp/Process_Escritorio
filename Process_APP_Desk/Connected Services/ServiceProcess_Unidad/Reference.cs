﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Process_APP_Desk.ServiceProcess_Unidad {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceProcess_Unidad.Process_UnidadSoap")]
    public interface Process_UnidadSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertarUnidadConEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int InsertarUnidadConEntidad_Escritorio(System.Data.DataSet _unidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertarUnidadConEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<int> InsertarUnidadConEntidad_EscritorioAsync(System.Data.DataSet _unidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertarUnidadSinEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int InsertarUnidadSinEntidad_Escritorio(string _nombre, string _descripcion, int _estado, string _rut_empresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertarUnidadSinEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<int> InsertarUnidadSinEntidad_EscritorioAsync(string _nombre, string _descripcion, int _estado, string _rut_empresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ActualizarUnidadConEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int ActualizarUnidadConEntidad_Escritorio(System.Data.DataSet _unidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ActualizarUnidadConEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<int> ActualizarUnidadConEntidad_EscritorioAsync(System.Data.DataSet _unidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ActualizarUnidadSinEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int ActualizarUnidadSinEntidad_Escritorio(int _id_unidad, string _nombre, string _descripcion, int _estado, string _rut_empresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ActualizarUnidadSinEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<int> ActualizarUnidadSinEntidad_EscritorioAsync(int _id_unidad, string _nombre, string _descripcion, int _estado, string _rut_empresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerUnidadSinEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet TraerUnidadSinEntidad_Escritorio(int _id_unidad, string _rut_empresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerUnidadSinEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> TraerUnidadSinEntidad_EscritorioAsync(int _id_unidad, string _rut_empresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerUnidadConEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Process_APP_Desk.ServiceProcess_Unidad.Unidad TraerUnidadConEntidad_Escritorio(int _id_unidad, string _rut_empresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerUnidadConEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<Process_APP_Desk.ServiceProcess_Unidad.Unidad> TraerUnidadConEntidad_EscritorioAsync(int _id_unidad, string _rut_empresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerUnidadPorNombrePorEmpresaConEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Process_APP_Desk.ServiceProcess_Unidad.Unidad TraerUnidadPorNombrePorEmpresaConEntidad_Escritorio(string _nombre, string _rut_empresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerUnidadPorNombrePorEmpresaConEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<Process_APP_Desk.ServiceProcess_Unidad.Unidad> TraerUnidadPorNombrePorEmpresaConEntidad_EscritorioAsync(string _nombre, string _rut_empresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerUnidadConClaveSinEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet TraerUnidadConClaveSinEntidad_Escritorio(string _palabra_clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerUnidadConClaveSinEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> TraerUnidadConClaveSinEntidad_EscritorioAsync(string _palabra_clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerTodasUnidades_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet TraerTodasUnidades_Escritorio();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerTodasUnidades_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> TraerTodasUnidades_EscritorioAsync();
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Unidad : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int id_unidadField;
        
        private string nombreField;
        
        private string descripcionField;
        
        private int estadoField;
        
        private string rut_empresaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int Id_unidad {
            get {
                return this.id_unidadField;
            }
            set {
                this.id_unidadField = value;
                this.RaisePropertyChanged("Id_unidad");
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
        public string Descripcion {
            get {
                return this.descripcionField;
            }
            set {
                this.descripcionField = value;
                this.RaisePropertyChanged("Descripcion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int Estado {
            get {
                return this.estadoField;
            }
            set {
                this.estadoField = value;
                this.RaisePropertyChanged("Estado");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Rut_empresa {
            get {
                return this.rut_empresaField;
            }
            set {
                this.rut_empresaField = value;
                this.RaisePropertyChanged("Rut_empresa");
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
    public interface Process_UnidadSoapChannel : Process_APP_Desk.ServiceProcess_Unidad.Process_UnidadSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Process_UnidadSoapClient : System.ServiceModel.ClientBase<Process_APP_Desk.ServiceProcess_Unidad.Process_UnidadSoap>, Process_APP_Desk.ServiceProcess_Unidad.Process_UnidadSoap {
        
        public Process_UnidadSoapClient() {
        }
        
        public Process_UnidadSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Process_UnidadSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Process_UnidadSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Process_UnidadSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int InsertarUnidadConEntidad_Escritorio(System.Data.DataSet _unidad) {
            return base.Channel.InsertarUnidadConEntidad_Escritorio(_unidad);
        }
        
        public System.Threading.Tasks.Task<int> InsertarUnidadConEntidad_EscritorioAsync(System.Data.DataSet _unidad) {
            return base.Channel.InsertarUnidadConEntidad_EscritorioAsync(_unidad);
        }
        
        public int InsertarUnidadSinEntidad_Escritorio(string _nombre, string _descripcion, int _estado, string _rut_empresa) {
            return base.Channel.InsertarUnidadSinEntidad_Escritorio(_nombre, _descripcion, _estado, _rut_empresa);
        }
        
        public System.Threading.Tasks.Task<int> InsertarUnidadSinEntidad_EscritorioAsync(string _nombre, string _descripcion, int _estado, string _rut_empresa) {
            return base.Channel.InsertarUnidadSinEntidad_EscritorioAsync(_nombre, _descripcion, _estado, _rut_empresa);
        }
        
        public int ActualizarUnidadConEntidad_Escritorio(System.Data.DataSet _unidad) {
            return base.Channel.ActualizarUnidadConEntidad_Escritorio(_unidad);
        }
        
        public System.Threading.Tasks.Task<int> ActualizarUnidadConEntidad_EscritorioAsync(System.Data.DataSet _unidad) {
            return base.Channel.ActualizarUnidadConEntidad_EscritorioAsync(_unidad);
        }
        
        public int ActualizarUnidadSinEntidad_Escritorio(int _id_unidad, string _nombre, string _descripcion, int _estado, string _rut_empresa) {
            return base.Channel.ActualizarUnidadSinEntidad_Escritorio(_id_unidad, _nombre, _descripcion, _estado, _rut_empresa);
        }
        
        public System.Threading.Tasks.Task<int> ActualizarUnidadSinEntidad_EscritorioAsync(int _id_unidad, string _nombre, string _descripcion, int _estado, string _rut_empresa) {
            return base.Channel.ActualizarUnidadSinEntidad_EscritorioAsync(_id_unidad, _nombre, _descripcion, _estado, _rut_empresa);
        }
        
        public System.Data.DataSet TraerUnidadSinEntidad_Escritorio(int _id_unidad, string _rut_empresa) {
            return base.Channel.TraerUnidadSinEntidad_Escritorio(_id_unidad, _rut_empresa);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> TraerUnidadSinEntidad_EscritorioAsync(int _id_unidad, string _rut_empresa) {
            return base.Channel.TraerUnidadSinEntidad_EscritorioAsync(_id_unidad, _rut_empresa);
        }
        
        public Process_APP_Desk.ServiceProcess_Unidad.Unidad TraerUnidadConEntidad_Escritorio(int _id_unidad, string _rut_empresa) {
            return base.Channel.TraerUnidadConEntidad_Escritorio(_id_unidad, _rut_empresa);
        }
        
        public System.Threading.Tasks.Task<Process_APP_Desk.ServiceProcess_Unidad.Unidad> TraerUnidadConEntidad_EscritorioAsync(int _id_unidad, string _rut_empresa) {
            return base.Channel.TraerUnidadConEntidad_EscritorioAsync(_id_unidad, _rut_empresa);
        }
        
        public Process_APP_Desk.ServiceProcess_Unidad.Unidad TraerUnidadPorNombrePorEmpresaConEntidad_Escritorio(string _nombre, string _rut_empresa) {
            return base.Channel.TraerUnidadPorNombrePorEmpresaConEntidad_Escritorio(_nombre, _rut_empresa);
        }
        
        public System.Threading.Tasks.Task<Process_APP_Desk.ServiceProcess_Unidad.Unidad> TraerUnidadPorNombrePorEmpresaConEntidad_EscritorioAsync(string _nombre, string _rut_empresa) {
            return base.Channel.TraerUnidadPorNombrePorEmpresaConEntidad_EscritorioAsync(_nombre, _rut_empresa);
        }
        
        public System.Data.DataSet TraerUnidadConClaveSinEntidad_Escritorio(string _palabra_clave) {
            return base.Channel.TraerUnidadConClaveSinEntidad_Escritorio(_palabra_clave);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> TraerUnidadConClaveSinEntidad_EscritorioAsync(string _palabra_clave) {
            return base.Channel.TraerUnidadConClaveSinEntidad_EscritorioAsync(_palabra_clave);
        }
        
        public System.Data.DataSet TraerTodasUnidades_Escritorio() {
            return base.Channel.TraerTodasUnidades_Escritorio();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> TraerTodasUnidades_EscritorioAsync() {
            return base.Channel.TraerTodasUnidades_EscritorioAsync();
        }
    }
}
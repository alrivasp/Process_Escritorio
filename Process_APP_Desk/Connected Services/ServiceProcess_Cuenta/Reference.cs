﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Process_APP_Desk.ServiceProcess_Cuenta {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceProcess_Cuenta.Process_CuentaSoap")]
    public interface Process_CuentaSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertarCuentaConEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int InsertarCuentaConEntidad_Escritorio(System.Data.DataSet _unidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertarCuentaConEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<int> InsertarCuentaConEntidad_EscritorioAsync(System.Data.DataSet _unidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertarCuentaSinEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int InsertarCuentaSinEntidad_Escritorio(string _rut_usuario, string _rut_empresa, string _contrasena, int _estado, int _id_rol, string _correo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertarCuentaSinEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<int> InsertarCuentaSinEntidad_EscritorioAsync(string _rut_usuario, string _rut_empresa, string _contrasena, int _estado, int _id_rol, string _correo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ActualizarCuentaConEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int ActualizarCuentaConEntidad_Escritorio(System.Data.DataSet _unidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ActualizarCuentaConEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<int> ActualizarCuentaConEntidad_EscritorioAsync(System.Data.DataSet _unidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ActualizarCuentaSinEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int ActualizarCuentaSinEntidad_Escritorio(string _rut_usuario, string _rut_empresa, int _estado, int _id_rol, string _correo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ActualizarCuentaSinEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<int> ActualizarCuentaSinEntidad_EscritorioAsync(string _rut_usuario, string _rut_empresa, int _estado, int _id_rol, string _correo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ActualizarCuentaSoloContrasenaSinEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int ActualizarCuentaSoloContrasenaSinEntidad_Escritorio(string _rut_usuario, string _rut_empresa, string _contrasena);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ActualizarCuentaSoloContrasenaSinEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<int> ActualizarCuentaSoloContrasenaSinEntidad_EscritorioAsync(string _rut_usuario, string _rut_empresa, string _contrasena);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerCuentaSinEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet TraerCuentaSinEntidad_Escritorio(string _rut_usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerCuentaSinEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> TraerCuentaSinEntidad_EscritorioAsync(string _rut_usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerCuentaConEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Process_APP_Desk.ServiceProcess_Cuenta.Cuenta TraerCuentaConEntidad_Escritorio(string _rut_usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerCuentaConEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<Process_APP_Desk.ServiceProcess_Cuenta.Cuenta> TraerCuentaConEntidad_EscritorioAsync(string _rut_usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerCuentaConEmpresaSinEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet TraerCuentaConEmpresaSinEntidad_Escritorio(string _rut_usuario, string _rut_empresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerCuentaConEmpresaSinEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> TraerCuentaConEmpresaSinEntidad_EscritorioAsync(string _rut_usuario, string _rut_empresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerCuentaConEmpresaConEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Process_APP_Desk.ServiceProcess_Cuenta.Cuenta TraerCuentaConEmpresaConEntidad_Escritorio(string _rut_usuario, string _rut_empresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerCuentaConEmpresaConEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<Process_APP_Desk.ServiceProcess_Cuenta.Cuenta> TraerCuentaConEmpresaConEntidad_EscritorioAsync(string _rut_usuario, string _rut_empresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerTodasCuentas_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet TraerTodasCuentas_Escritorio();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerTodasCuentas_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> TraerTodasCuentas_EscritorioAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerCuentaConClaveSinEntidad_Escritorio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet TraerCuentaConClaveSinEntidad_Escritorio(string _palabra_clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraerCuentaConClaveSinEntidad_Escritorio", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> TraerCuentaConClaveSinEntidad_EscritorioAsync(string _palabra_clave);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Cuenta : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string rut_usuarioField;
        
        private string rut_empresaField;
        
        private string contrasenaField;
        
        private int estadoField;
        
        private int id_rolField;
        
        private string correoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Rut_usuario {
            get {
                return this.rut_usuarioField;
            }
            set {
                this.rut_usuarioField = value;
                this.RaisePropertyChanged("Rut_usuario");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Rut_empresa {
            get {
                return this.rut_empresaField;
            }
            set {
                this.rut_empresaField = value;
                this.RaisePropertyChanged("Rut_empresa");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Contrasena {
            get {
                return this.contrasenaField;
            }
            set {
                this.contrasenaField = value;
                this.RaisePropertyChanged("Contrasena");
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
        public int Id_rol {
            get {
                return this.id_rolField;
            }
            set {
                this.id_rolField = value;
                this.RaisePropertyChanged("Id_rol");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Correo {
            get {
                return this.correoField;
            }
            set {
                this.correoField = value;
                this.RaisePropertyChanged("Correo");
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
    public interface Process_CuentaSoapChannel : Process_APP_Desk.ServiceProcess_Cuenta.Process_CuentaSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Process_CuentaSoapClient : System.ServiceModel.ClientBase<Process_APP_Desk.ServiceProcess_Cuenta.Process_CuentaSoap>, Process_APP_Desk.ServiceProcess_Cuenta.Process_CuentaSoap {
        
        public Process_CuentaSoapClient() {
        }
        
        public Process_CuentaSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Process_CuentaSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Process_CuentaSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Process_CuentaSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int InsertarCuentaConEntidad_Escritorio(System.Data.DataSet _unidad) {
            return base.Channel.InsertarCuentaConEntidad_Escritorio(_unidad);
        }
        
        public System.Threading.Tasks.Task<int> InsertarCuentaConEntidad_EscritorioAsync(System.Data.DataSet _unidad) {
            return base.Channel.InsertarCuentaConEntidad_EscritorioAsync(_unidad);
        }
        
        public int InsertarCuentaSinEntidad_Escritorio(string _rut_usuario, string _rut_empresa, string _contrasena, int _estado, int _id_rol, string _correo) {
            return base.Channel.InsertarCuentaSinEntidad_Escritorio(_rut_usuario, _rut_empresa, _contrasena, _estado, _id_rol, _correo);
        }
        
        public System.Threading.Tasks.Task<int> InsertarCuentaSinEntidad_EscritorioAsync(string _rut_usuario, string _rut_empresa, string _contrasena, int _estado, int _id_rol, string _correo) {
            return base.Channel.InsertarCuentaSinEntidad_EscritorioAsync(_rut_usuario, _rut_empresa, _contrasena, _estado, _id_rol, _correo);
        }
        
        public int ActualizarCuentaConEntidad_Escritorio(System.Data.DataSet _unidad) {
            return base.Channel.ActualizarCuentaConEntidad_Escritorio(_unidad);
        }
        
        public System.Threading.Tasks.Task<int> ActualizarCuentaConEntidad_EscritorioAsync(System.Data.DataSet _unidad) {
            return base.Channel.ActualizarCuentaConEntidad_EscritorioAsync(_unidad);
        }
        
        public int ActualizarCuentaSinEntidad_Escritorio(string _rut_usuario, string _rut_empresa, int _estado, int _id_rol, string _correo) {
            return base.Channel.ActualizarCuentaSinEntidad_Escritorio(_rut_usuario, _rut_empresa, _estado, _id_rol, _correo);
        }
        
        public System.Threading.Tasks.Task<int> ActualizarCuentaSinEntidad_EscritorioAsync(string _rut_usuario, string _rut_empresa, int _estado, int _id_rol, string _correo) {
            return base.Channel.ActualizarCuentaSinEntidad_EscritorioAsync(_rut_usuario, _rut_empresa, _estado, _id_rol, _correo);
        }
        
        public int ActualizarCuentaSoloContrasenaSinEntidad_Escritorio(string _rut_usuario, string _rut_empresa, string _contrasena) {
            return base.Channel.ActualizarCuentaSoloContrasenaSinEntidad_Escritorio(_rut_usuario, _rut_empresa, _contrasena);
        }
        
        public System.Threading.Tasks.Task<int> ActualizarCuentaSoloContrasenaSinEntidad_EscritorioAsync(string _rut_usuario, string _rut_empresa, string _contrasena) {
            return base.Channel.ActualizarCuentaSoloContrasenaSinEntidad_EscritorioAsync(_rut_usuario, _rut_empresa, _contrasena);
        }
        
        public System.Data.DataSet TraerCuentaSinEntidad_Escritorio(string _rut_usuario) {
            return base.Channel.TraerCuentaSinEntidad_Escritorio(_rut_usuario);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> TraerCuentaSinEntidad_EscritorioAsync(string _rut_usuario) {
            return base.Channel.TraerCuentaSinEntidad_EscritorioAsync(_rut_usuario);
        }
        
        public Process_APP_Desk.ServiceProcess_Cuenta.Cuenta TraerCuentaConEntidad_Escritorio(string _rut_usuario) {
            return base.Channel.TraerCuentaConEntidad_Escritorio(_rut_usuario);
        }
        
        public System.Threading.Tasks.Task<Process_APP_Desk.ServiceProcess_Cuenta.Cuenta> TraerCuentaConEntidad_EscritorioAsync(string _rut_usuario) {
            return base.Channel.TraerCuentaConEntidad_EscritorioAsync(_rut_usuario);
        }
        
        public System.Data.DataSet TraerCuentaConEmpresaSinEntidad_Escritorio(string _rut_usuario, string _rut_empresa) {
            return base.Channel.TraerCuentaConEmpresaSinEntidad_Escritorio(_rut_usuario, _rut_empresa);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> TraerCuentaConEmpresaSinEntidad_EscritorioAsync(string _rut_usuario, string _rut_empresa) {
            return base.Channel.TraerCuentaConEmpresaSinEntidad_EscritorioAsync(_rut_usuario, _rut_empresa);
        }
        
        public Process_APP_Desk.ServiceProcess_Cuenta.Cuenta TraerCuentaConEmpresaConEntidad_Escritorio(string _rut_usuario, string _rut_empresa) {
            return base.Channel.TraerCuentaConEmpresaConEntidad_Escritorio(_rut_usuario, _rut_empresa);
        }
        
        public System.Threading.Tasks.Task<Process_APP_Desk.ServiceProcess_Cuenta.Cuenta> TraerCuentaConEmpresaConEntidad_EscritorioAsync(string _rut_usuario, string _rut_empresa) {
            return base.Channel.TraerCuentaConEmpresaConEntidad_EscritorioAsync(_rut_usuario, _rut_empresa);
        }
        
        public System.Data.DataSet TraerTodasCuentas_Escritorio() {
            return base.Channel.TraerTodasCuentas_Escritorio();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> TraerTodasCuentas_EscritorioAsync() {
            return base.Channel.TraerTodasCuentas_EscritorioAsync();
        }
        
        public System.Data.DataSet TraerCuentaConClaveSinEntidad_Escritorio(string _palabra_clave) {
            return base.Channel.TraerCuentaConClaveSinEntidad_Escritorio(_palabra_clave);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> TraerCuentaConClaveSinEntidad_EscritorioAsync(string _palabra_clave) {
            return base.Channel.TraerCuentaConClaveSinEntidad_EscritorioAsync(_palabra_clave);
        }
    }
}

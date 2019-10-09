using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Process_APP_Desk
{
    public partial class FormCargo : Form
    {
        //Variable Titulo
        public static string _titulo_modal;
        //Variables para cargar datos desde el gridview
        public static string _id_cargo = null;
        public static string _nombre;
        public static string _descripcion;
        public static string _rut_empresa;
        //Variable para interaccion de botones (1 = modificar) - (2 = nuevo) - (3 = Ver)
        public static int _guardar = 0;
        public FormCargo()
        {
            InitializeComponent();
            //Metodo Carga de GridView
            cargarDataGridViewPpal();
            pbSeleccion.Visible = false;
            //vACIAR VARIABLES
            _id_cargo = null;
            _nombre = string.Empty;
            _descripcion = string.Empty;            
            _rut_empresa = string.Empty;

        }

        private void cargarDataGridViewPpal()
        {
            try
            {
                //instansear web service con seguridad
                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Cargo.Process_CargoSoapClient auxServiceCargo = new ServiceProcess_Cargo.Process_CargoSoapClient();
                auxServiceCargo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCargo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Cargo.Cargo auxCargo = new ServiceProcess_Cargo.Cargo();
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();                
                //capturar dataset
                DataSet ds = auxServiceCargo.TraerTodasCargos_Escritorio();
                //Capturar Tabla
                DataTable dt = ds.Tables[0];
                //contar cantidad de empresas
                int _cantidad_cargos = dt.Rows.Count;
                //crear array bidimencional
                string[,] ListaCargos = new string[_cantidad_cargos, 5];
                //Recorrer data table
                int _fila = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Capturar datos de la fila recorridad en objeto cargo
                    auxCargo.Id_cargo = Convert.ToInt32(dt.Rows[i]["Id_Cargo"]);
                    auxCargo.Nombre = (String)dt.Rows[i]["Nombre"];
                    auxCargo.Descripcion = (String)dt.Rows[i]["Descripcion"];                    
                    auxCargo.Rut_empresa = (String)dt.Rows[i]["Rut_empresa"];
                    //variables temporales de apoyo                    
                    string _nombre_empresa = string.Empty;
                    //cargar array con datos de fila
                    ListaCargos[_fila, 0] = auxCargo.Id_cargo.ToString();
                    ListaCargos[_fila, 1] = auxCargo.Nombre;
                    auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(auxCargo.Rut_empresa);
                    ListaCargos[_fila, 2] = auxEmpresa.Nombre;
                    ListaCargos[_fila, 3] = auxEmpresa.Rut_empresa;
                    ListaCargos[_fila, 4] = auxCargo.Descripcion;
                    //agregar lista a gridview
                    dgvCargo.Rows.Add(ListaCargos[_fila, 0], ListaCargos[_fila, 1], ListaCargos[_fila, 2], ListaCargos[_fila, 3], ListaCargos[_fila, 4]);
                    _fila++;

                }
                pbSeleccion.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo cargarDataGridViewPpal, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            System.GC.Collect();
        }

        private void TxtFiltrar_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dgvCargo.Rows.Clear();
                dgvCargo.Refresh();
                //instansear web service con seguridad
                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Cargo.Process_CargoSoapClient auxServiceCargo = new ServiceProcess_Cargo.Process_CargoSoapClient();
                auxServiceCargo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCargo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Cargo.Cargo auxCargo = new ServiceProcess_Cargo.Cargo();
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();                
                //capturar dataset
                DataSet ds = auxServiceCargo.TraerCargoConClaveSinEntidad_Escritorio(txtFiltrar.Text.ToUpper());
                if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    //Capturar Tabla
                    DataTable dt = ds.Tables[0];
                    //contar cantidad de empresas
                    int _cantidad_Cargos = dt.Rows.Count;
                    //crear array bidimencional
                    string[,] ListaCargos = new string[_cantidad_Cargos, 5];
                    //Recorrer data table
                    int _fila = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Capturar datos de la fila recorridad en objeto empresa
                        auxCargo.Id_cargo = Convert.ToInt32(dt.Rows[i]["Id_cargo"]);
                        auxCargo.Nombre = (String)dt.Rows[i]["Nombre"];
                        auxCargo.Descripcion = (String)dt.Rows[i]["Descripcion"];                        
                        auxCargo.Rut_empresa = (String)dt.Rows[i]["Rut_empresa"];
                        //variables temporales de apoyo                        
                        string _nombre_empresa = string.Empty;
                        //cargar array con datos de fila
                        ListaCargos[_fila, 0] = auxCargo.Id_cargo.ToString();
                        ListaCargos[_fila, 1] = auxCargo.Nombre;
                        auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(auxCargo.Rut_empresa);
                        ListaCargos[_fila, 2] = auxEmpresa.Nombre;
                        ListaCargos[_fila, 3] = auxEmpresa.Rut_empresa;
                        ListaCargos[_fila, 4] = auxCargo.Descripcion;
                        //agregar lista a gridview
                        dgvCargo.Rows.Add(ListaCargos[_fila, 0], ListaCargos[_fila, 1], ListaCargos[_fila, 2], ListaCargos[_fila, 3], ListaCargos[_fila, 4]);
                        _fila++;

                    }
                    //vACIAR VARIABLES
                    _id_cargo = null;
                    _nombre = string.Empty;
                    _descripcion = string.Empty;                    
                    _rut_empresa = string.Empty;
                    pbSeleccion.Visible = false;
                }
                else
                {
                    //Mostrar GridView Vacio
                    //vACIAR VARIABLES
                    _id_cargo = null;
                    _nombre = string.Empty;
                    _descripcion = string.Empty;                    
                    _rut_empresa = string.Empty;
                    pbSeleccion.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion TxtFiltrar_KeyUp, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_id_cargo == null)//validador que se seleccione un fila de CARGO
                {
                    MessageBox.Show("Seleccione una Fila a Modificar", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    _titulo_modal = "MODIFICAR CARGO";
                    _guardar = 1;
                    FormCargoModal frmModal = new FormCargoModal(_titulo_modal, _guardar, Convert.ToInt32(_id_cargo), _nombre, _descripcion, _rut_empresa);
                    if (frmModal.ShowDialog() == DialogResult.OK)
                    {

                        //Vaciar variables
                        _id_cargo = null;
                        _nombre = string.Empty;
                        _descripcion = string.Empty;                       
                        _rut_empresa = string.Empty;
                        //limpiar GridView
                        dgvCargo.Rows.Clear();
                        dgvCargo.Refresh();
                        //cargar gridview
                        cargarDataGridViewPpal();
                        MessageBox.Show("Cargo Modificado Correctamente.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion BtnModificar_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                FormCargoModalNuevo frmModal = new FormCargoModalNuevo();
                if (frmModal.ShowDialog() == DialogResult.OK)
                {                    
                    //Vaciar variables
                    _id_cargo = null;
                    _nombre = string.Empty;
                    _descripcion = string.Empty;                    
                    _rut_empresa = string.Empty;
                    //limpiar GridView
                    dgvCargo.Rows.Clear();
                    dgvCargo.Refresh();
                    //cargar gridview
                    cargarDataGridViewPpal();
                    MessageBox.Show("Cargo creado Correctamente.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Boton de accion BtnNuevo_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCargo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                _nombre = dgvCargo.Rows[e.RowIndex].Cells["NOMBRE_CARGO"].Value.ToString();
                _rut_empresa = dgvCargo.Rows[e.RowIndex].Cells["RUT_EMPRESA"].Value.ToString();

                //instansear web service con seguridad
                ServiceProcess_Cargo.Process_CargoSoapClient auxServiceCargo = new ServiceProcess_Cargo.Process_CargoSoapClient();
                auxServiceCargo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCargo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Cargo.Cargo auxCargo = new ServiceProcess_Cargo.Cargo();
                auxCargo = auxServiceCargo.TraerCargoPorNombrePorEmpresaConEntidad_Escritorio(_nombre, _rut_empresa);

                _id_cargo = auxCargo.Id_cargo.ToString();
                _descripcion = auxCargo.Descripcion;

                pbSeleccion.Visible = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion DgvUnidad_CellClick, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVer_Click(object sender, EventArgs e)
        {

            try
            {
                if (_id_cargo == null)//validador que se seleccione un fila de unidad
                {
                    MessageBox.Show("Seleccione una Fila para Mostrar", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _titulo_modal = "MOSTRAR CARGO";
                    _guardar = 3;
                    FormCargoModal frmModal = new FormCargoModal(_titulo_modal, _guardar, Convert.ToInt32(_id_cargo), _nombre, _descripcion, _rut_empresa);
                    if (frmModal.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Boton de accion BtnVer_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

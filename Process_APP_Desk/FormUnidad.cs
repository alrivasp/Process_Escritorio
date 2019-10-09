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
    public partial class FormUnidad : Form
    {
        //Variable Titulo
        public static string _titulo_modal;
        //Variables para cargar datos desde el gridview
        public static string _id_unidad = null;
        public static string _nombre;
        public static string _descripcion;
        public static string _estado;
        public static string _rut_empresa;
        //Variable para interaccion de botones (1 = modificar) - (2 = nuevo) - (3 = Ver)
        public static int _guardar = 0;
        public FormUnidad()
        {
            InitializeComponent();
            //Metodo Carga de GridView
            cargarDataGridViewPpal();
            pbSeleccion.Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            //vACIAR VARIABLES
            _id_unidad = null;
            _nombre = string.Empty;
            _descripcion = string.Empty;
            _estado = string.Empty;
            _rut_empresa = string.Empty;
        }

        //Metodo Carga de GridView
        private void cargarDataGridViewPpal()
        {
            try
            {
                //instansear web service con seguridad
                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Unidad.Process_UnidadSoapClient auxServiceUnidad = new ServiceProcess_Unidad.Process_UnidadSoapClient();
                auxServiceUnidad.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUnidad.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                ServiceProcess_Unidad.Unidad auxUnidad = new ServiceProcess_Unidad.Unidad();
                //capturar dataset
                DataSet ds = auxServiceUnidad.TraerTodasUnidades_Escritorio();
                //Capturar Tabla
                DataTable dt = ds.Tables[0];
                //contar cantidad de empresas
                int _cantidad_unidades = dt.Rows.Count;
                //crear array bidimencional
                string[,] ListaUnidad = new string[_cantidad_unidades, 6];
                //Recorrer data table
                int _fila = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Capturar datos de la fila recorridad en objeto empresa
                    auxUnidad.Id_unidad = Convert.ToInt32(dt.Rows[i]["Id_unidad"]);
                    auxUnidad.Nombre = (String)dt.Rows[i]["Nombre"];
                    auxUnidad.Descripcion = (String)dt.Rows[i]["Descripcion"];
                    auxUnidad.Estado = Convert.ToInt32(dt.Rows[i]["Estado"]);
                    auxUnidad.Rut_empresa = (String)dt.Rows[i]["Rut_empresa"];
                    //variables temporales de apoyo
                    string _estado = string.Empty;
                    string _nombre_empresa = string.Empty;
                    //cargar array con datos de fila
                    ListaUnidad[_fila, 0] = auxUnidad.Id_unidad.ToString();
                    ListaUnidad[_fila, 1] = auxUnidad.Nombre;
                    auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(auxUnidad.Rut_empresa);
                    ListaUnidad[_fila, 2] = auxEmpresa.Nombre;
                    ListaUnidad[_fila, 3] = auxEmpresa.Rut_empresa;
                    if (auxUnidad.Estado == 0)
                    {
                        _estado = "DESACTIVADO";
                    }
                    else
                    {
                        _estado = "ACTIVADO";
                    }
                    ListaUnidad[_fila, 4] = _estado;
                    ListaUnidad[_fila, 5] = auxUnidad.Descripcion;
                    //agregar lista a gridview
                    dgvUnidad.Rows.Add(ListaUnidad[_fila, 0], ListaUnidad[_fila, 1], ListaUnidad[_fila, 2], ListaUnidad[_fila, 3], ListaUnidad[_fila, 4], ListaUnidad[_fila, 5]);
                    _fila++;

                }
                pbSeleccion.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo cargarDataGridViewPpal, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Boton Cerrar
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            System.GC.Collect();
        }

        private void TxtFiltrar_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dgvUnidad.Rows.Clear();
                dgvUnidad.Refresh();
                //instansear web service con seguridad
                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Unidad.Process_UnidadSoapClient auxServiceUnidad = new ServiceProcess_Unidad.Process_UnidadSoapClient();
                auxServiceUnidad.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUnidad.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                ServiceProcess_Unidad.Unidad auxUnidad = new ServiceProcess_Unidad.Unidad();
                //capturar dataset
                DataSet ds = auxServiceUnidad.TraerUnidadConClaveSinEntidad_Escritorio(txtFiltrar.Text.ToUpper());                
                if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    //Capturar Tabla
                    DataTable dt = ds.Tables[0];
                    //contar cantidad de empresas
                    int _cantidad_unidades = dt.Rows.Count;
                    //crear array bidimencional
                    string[,] ListaUnidad = new string[_cantidad_unidades, 6];
                    //Recorrer data table
                    int _fila = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Capturar datos de la fila recorridad en objeto empresa
                        auxUnidad.Id_unidad = Convert.ToInt32(dt.Rows[i]["Id_unidad"]);
                        auxUnidad.Nombre = (String)dt.Rows[i]["Nombre"];
                        auxUnidad.Descripcion = (String)dt.Rows[i]["Descripcion"];
                        auxUnidad.Estado = Convert.ToInt32(dt.Rows[i]["Estado"]);
                        auxUnidad.Rut_empresa = (String)dt.Rows[i]["Rut_empresa"];
                        //variables temporales de apoyo
                        string _estado = string.Empty;
                        string _nombre_empresa = string.Empty;
                        //cargar array con datos de fila
                        ListaUnidad[_fila, 0] = auxUnidad.Id_unidad.ToString();
                        ListaUnidad[_fila, 1] = auxUnidad.Nombre;
                        auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(auxUnidad.Rut_empresa);
                        ListaUnidad[_fila, 2] = auxEmpresa.Nombre;
                        ListaUnidad[_fila, 3] = auxEmpresa.Rut_empresa;
                        if (auxUnidad.Estado == 0)
                        {
                            _estado = "DESACTIVADO";
                        }
                        else
                        {
                            _estado = "ACTIVADO";
                        }
                        ListaUnidad[_fila, 4] = _estado;
                        ListaUnidad[_fila, 5] = auxUnidad.Descripcion;
                        //agregar lista a gridview
                        dgvUnidad.Rows.Add(ListaUnidad[_fila, 0], ListaUnidad[_fila, 1], ListaUnidad[_fila, 2], ListaUnidad[_fila, 3], ListaUnidad[_fila, 4], ListaUnidad[_fila, 5]);
                        _fila++;

                    }
                    //vACIAR VARIABLES
                    _id_unidad = null;
                    _nombre = string.Empty;
                    _descripcion = string.Empty;
                    _estado = string.Empty;
                    _rut_empresa = string.Empty;
                    pbSeleccion.Visible = false;
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                }
                else
                {
                    //Mostrar GridView Vacio
                    //vACIAR VARIABLES
                    _id_unidad = null;
                    _nombre = string.Empty;
                    _descripcion = string.Empty;
                    _estado = string.Empty;
                    _rut_empresa = string.Empty;
                    pbSeleccion.Visible = false;
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
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
                if (_id_unidad == null)//validador que se seleccione un fila de Unidad
                {
                    MessageBox.Show("Seleccione una Fila a Modificar", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    _titulo_modal = "MODIFICAR UNIDAD";
                    _guardar = 1;
                    FormUnidadModal frmModal = new FormUnidadModal(_titulo_modal, _guardar, Convert.ToInt32(_id_unidad), _nombre, _descripcion, Convert.ToInt32(_estado), _rut_empresa);
                    if (frmModal.ShowDialog() == DialogResult.OK)
                    {
                        btnActivar.Visible = false;
                        btnDesactivar.Visible = false;
                        //Vaciar variables
                        _id_unidad = null;
                        _nombre = string.Empty;
                        _descripcion = string.Empty;
                        _estado = string.Empty;
                        _rut_empresa = string.Empty;
                        //limpiar GridView
                        dgvUnidad.Rows.Clear();
                        dgvUnidad.Refresh();
                        //cargar gridview
                        cargarDataGridViewPpal();
                        MessageBox.Show("Unidad Modificada Correctamente.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                FormUnidadModalNuevo frmModal = new FormUnidadModalNuevo();
                if (frmModal.ShowDialog() == DialogResult.OK)
                {
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                    //Vaciar variables
                    _id_unidad = null;
                    _nombre = string.Empty;
                    _descripcion = string.Empty;
                    _estado = string.Empty;
                    _rut_empresa = string.Empty;
                    //limpiar GridView
                    dgvUnidad.Rows.Clear();
                    dgvUnidad.Refresh();
                    //cargar gridview
                    cargarDataGridViewPpal();
                    MessageBox.Show("Unidad creada Correctamente.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Boton de accion BtnNuevo_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void DgvUnidad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                _id_unidad = dgvUnidad.Rows[e.RowIndex].Cells["ID_UNIDAD"].Value.ToString();
                _rut_empresa = dgvUnidad.Rows[e.RowIndex].Cells["RUT_EMPRESA"].Value.ToString();

                //instansear web service con seguridad
                ServiceProcess_Unidad.Process_UnidadSoapClient auxServiceUnidad = new ServiceProcess_Unidad.Process_UnidadSoapClient();
                auxServiceUnidad.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUnidad.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Unidad.Unidad auxUnidad = new ServiceProcess_Unidad.Unidad();
                auxUnidad = auxServiceUnidad.TraerUnidadConEntidad_Escritorio(Convert.ToInt32(_id_unidad), _rut_empresa);

                _nombre = auxUnidad.Nombre;
                _descripcion = auxUnidad.Descripcion;
                _estado = auxUnidad.Estado.ToString();

                pbSeleccion.Visible = true;

                if (_estado.Equals("0"))
                {
                    btnActivar.Visible = true;
                    btnDesactivar.Visible = false;
                }
                else
                {
                    btnDesactivar.Visible = true;
                    btnActivar.Visible = false;
                }


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
                if (_id_unidad == null)//validador que se seleccione un fila de unidad
                {
                    MessageBox.Show("Seleccione una Fila para Mostrar", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _titulo_modal = "MOSTRAR UNIDAD";
                    _guardar = 3;
                    FormUnidadModal frmModal = new FormUnidadModal(_titulo_modal, _guardar, Convert.ToInt32(_id_unidad), _nombre,_descripcion, Convert.ToInt32(_estado), _rut_empresa);
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

        private void BtnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                //Instancia de Web service con credenciales NT
                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(_rut_empresa);
                if (MessageBox.Show("¿Esta Seguro de Activar la Unidad " + _nombre + " de la Empresa "+ auxEmpresa.Nombre +"?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Instancia de Web service con credenciales NT
                    ServiceProcess_Unidad.Process_UnidadSoapClient auxServiceUnidad = new ServiceProcess_Unidad.Process_UnidadSoapClient();
                    auxServiceUnidad.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                    auxServiceUnidad.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                    //Insertar datos via web service
                    auxServiceUnidad.ActualizarUnidadSinEntidad_Escritorio(Convert.ToInt32(_id_unidad), _nombre, _descripcion, 1, _rut_empresa);
                    //ocultar botones
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                    //Vaciar variables
                    _id_unidad = null;
                    _nombre = string.Empty;
                    _descripcion = string.Empty;
                    _estado = string.Empty;
                    _rut_empresa = string.Empty;
                    //limpiar GridView
                    dgvUnidad.Rows.Clear();
                    dgvUnidad.Refresh();
                    //Metodo Carga de GridView
                    cargarDataGridViewPpal();
                    MessageBox.Show("Unidad Activada.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    //continua CON LA VISTA ACTUAL
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion BtnActivar_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                //Instancia de Web service con credenciales NT
                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(_rut_empresa);
                if (MessageBox.Show("¿Esta Seguro de Desactivar la Unidad " + _nombre + " de la Empresa "+ auxEmpresa.Nombre + "?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Instancia de Web service con credenciales NT
                    ServiceProcess_Unidad.Process_UnidadSoapClient auxServiceUnidad = new ServiceProcess_Unidad.Process_UnidadSoapClient();
                    auxServiceUnidad.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                    auxServiceUnidad.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                    //Insertar datos via web service
                    auxServiceUnidad.ActualizarUnidadSinEntidad_Escritorio(Convert.ToInt32(_id_unidad), _nombre, _descripcion,  0, _rut_empresa);
                    //ocultar botones
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                    //Vaciar variables
                    _id_unidad = null;
                    _nombre = string.Empty;
                    _descripcion = string.Empty;
                    _estado = string.Empty;
                    _rut_empresa = string.Empty;                    
                    //limpiar GridView
                    dgvUnidad.Rows.Clear();
                    dgvUnidad.Refresh();
                    //Metodo Carga de GridView
                    cargarDataGridViewPpal();
                    MessageBox.Show("Unidad Desactivada.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    //continua CON LA VISTA ACTUAL
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion BtnDesactivar_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

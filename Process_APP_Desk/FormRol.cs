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
    public partial class FormRol : Form
    {
        //Variable Titulo
        public static string _titulo_modal;
        //Variables para cargar datos desde el gridview
        public static string _id_rol = null;
        public static string _nombre;
        public static string _estado;        
        //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
        public static int _guardar = 0;
        public FormRol()
        {
            InitializeComponent();
            //Estas lineas eliminan los parpadeos del formulario o controles en la interfaz grafica (Pero no en un 100%)
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            //Metodo Carga de GridView
            cargarDataGridViewPpal();

        }
        //Metodo Carga Cuadro de Datos en Blanco
        private void cargarDataGridViewPpal()
        {
            try
            {
                //instansear web service con seguridad
                ServiceProcess_Rol.Process_RolSoapClient auxServiceRol = new ServiceProcess_Rol.Process_RolSoapClient();
                auxServiceRol.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceRol.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Rol.Rol auxRol = new ServiceProcess_Rol.Rol();
                //capturar dataset
                DataSet ds = auxServiceRol.TraerTodasRoles_Escritorio();
                //Capturar Tabla
                DataTable dt = ds.Tables[0];
                //contar cantidad de empresas
                int _cantidad_roles = dt.Rows.Count;
                //crear array bidimencional
                string[,] ListaRoles = new string[_cantidad_roles, 3];
                //Recorrer data table
                int _fila = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Capturar datos de la fila recorridad en objeto rol
                    auxRol.Id_rol = Convert.ToInt32(dt.Rows[i]["Id_rol"]);
                    auxRol.Nombre = (String)dt.Rows[i]["Nombre"];
                    auxRol.Estado = Convert.ToInt32(dt.Rows[i]["Estado"]);
                    //variables temporales de apoyo
                    string _estado = string.Empty;
                    //cargar array con datos de fila
                    ListaRoles[_fila, 0] = auxRol.Id_rol.ToString();
                    ListaRoles[_fila, 1] = auxRol.Nombre;
                    if (auxRol.Estado == 0)
                    {
                        _estado = "DESACTIVADO";
                    }
                    else
                    {
                        _estado = "ACTIVADO";
                    }
                    ListaRoles[_fila, 2] = _estado;
                    //agregar lista a gridview
                    dgvRol.Rows.Add(ListaRoles[_fila, 0], ListaRoles[_fila, 1], ListaRoles[_fila, 2]);
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
                dgvRol.Rows.Clear();
                dgvRol.Refresh();
                dgvAccesos.Rows.Clear();
                dgvAccesos.Refresh();
                //instansear web service con seguridad
                ServiceProcess_Rol.Process_RolSoapClient auxServiceRol = new ServiceProcess_Rol.Process_RolSoapClient();
                auxServiceRol.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceRol.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Rol.Rol auxRol = new ServiceProcess_Rol.Rol();
                //capturar dataset
                DataSet ds = auxServiceRol.TraerRolConClaveSinEntidad_Escritorio(txtFiltrar.Text.ToUpper());
                if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
                {                   
                    //Capturar Tabla
                    DataTable dt = ds.Tables[0];
                    //contar cantidad de empresas
                    int _cantidad_roles = dt.Rows.Count;
                    //crear array bidimencional
                    string[,] ListaRoles = new string[_cantidad_roles, 3];
                    //Recorrer data table
                    int _fila = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Capturar datos de la fila recorridad en objeto rol
                        auxRol.Id_rol = Convert.ToInt32(dt.Rows[i]["Id_rol"]);
                        auxRol.Nombre = (String)dt.Rows[i]["Nombre"];
                        auxRol.Estado = Convert.ToInt32(dt.Rows[i]["Estado"]);
                        //variables temporales de apoyo
                        string _estado = string.Empty;
                        //cargar array con datos de fila
                        ListaRoles[_fila, 0] = auxRol.Id_rol.ToString();
                        ListaRoles[_fila, 1] = auxRol.Nombre;
                        if (auxRol.Estado == 0)
                        {
                            _estado = "DESACTIVADO";
                        }
                        else
                        {
                            _estado = "ACTIVADO";
                        }
                        ListaRoles[_fila, 2] = _estado;
                        //agregar lista a gridview
                        dgvRol.Rows.Add(ListaRoles[_fila, 0], ListaRoles[_fila, 1], ListaRoles[_fila, 2]);
                        _fila++;

                    }
                    //vACIAR VARIABLES
                    _id_rol = null;
                    _nombre = string.Empty;                    
                    _estado = string.Empty;                    
                    pbSeleccion.Visible = false;
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                }
                else
                {
                    //vACIAR VARIABLES
                    _id_rol = null;
                    _nombre = string.Empty;
                    _estado = string.Empty;
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
            if (_id_rol == null)//validador que se seleccione un fila de GridView de usuario
            {
                MessageBox.Show("Seleccione una Fila a Modificar", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _titulo_modal = "MODIFICAR ROL";
                _guardar = 1;
                FormRolModal frmModal = new FormRolModal(_titulo_modal, _guardar, _id_rol, _nombre, _estado);
                if (frmModal.ShowDialog() == DialogResult.OK)
                {
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                    //Vaciar variables
                    _id_rol = null;
                    _nombre = string.Empty;
                    _estado = string.Empty;
                    //limpiar GridView
                    dgvRol.Rows.Clear();
                    dgvAccesos.Refresh();
                    dgvAccesos.Rows.Clear();
                    dgvAccesos.Refresh();
                    //cargar gridview
                    cargarDataGridViewPpal();
                    MessageBox.Show("Rol Modificado Correctamente.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                _titulo_modal = "NUEVO ROL";
                _guardar = 2;
                FormRolModal frmModal = new FormRolModal(_titulo_modal, _guardar, _id_rol, _nombre, _estado);
                if (frmModal.ShowDialog() == DialogResult.OK)
                {
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                    //Vaciar variables
                    _id_rol = null;
                    _nombre = string.Empty;
                    _estado = string.Empty;
                    //limpiar GridView
                    dgvRol.Rows.Clear();
                    dgvAccesos.Refresh();
                    dgvAccesos.Rows.Clear();
                    dgvAccesos.Refresh();
                    //cargar gridview
                    cargarDataGridViewPpal();
                    MessageBox.Show("Rol creada Correctamente.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Boton de accion BtnNuevo_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvRol_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                _id_rol = dgvRol.Rows[e.RowIndex].Cells["ID_ROL"].Value.ToString();

                //instansear web service con seguridad
                ServiceProcess_Rol.Process_RolSoapClient auxServiceRol = new ServiceProcess_Rol.Process_RolSoapClient();
                auxServiceRol.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceRol.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Rol.Rol auxRol = new ServiceProcess_Rol.Rol();
                auxRol = auxServiceRol.TraerRolConEntidad_Escritorio(Convert.ToInt32(_id_rol));

                _nombre = auxRol.Nombre;
                _estado = auxRol.Estado.ToString();

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
                dgvAccesos.Rows.Clear();
                dgvAccesos.Refresh();
                cargarDataGridViewAccesos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion DgvRol_CellClick, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarDataGridViewAccesos()
        {
            try
            {

                //instansear web service con seguridad
                ServiceProcess_Permisos.Process_PermisosSoapClient auxServicePermisos = new ServiceProcess_Permisos.Process_PermisosSoapClient();
                auxServicePermisos.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServicePermisos.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Permisos.Permisos auxPermisos = new ServiceProcess_Permisos.Permisos();
                ServiceProcess_Acceso.Process_AccesoSoapClient auxServiceAcceso = new ServiceProcess_Acceso.Process_AccesoSoapClient();
                auxServiceAcceso.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceAcceso.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Acceso.Acceso auxAcceso = new ServiceProcess_Acceso.Acceso();
                //capturar dataset
                DataSet ds = auxServicePermisos.TraerPermisosPorRolSinEntidad_Escritorio(Convert.ToInt32(_id_rol));
                //Capturar Tabla
                DataTable dt = ds.Tables[0];
                //contar cantidad de empresas
                int _cantidad_permisos = dt.Rows.Count;
                //crear array bidimencional
                string[,] ListaPermisos = new string[_cantidad_permisos, 1];
                //Recorrer data table
                int _fila = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Capturar datos de la fila recorridad en objeto rol
                    auxPermisos.Id_acceso = Convert.ToInt32(dt.Rows[i]["Id_acceso"]);
                    auxPermisos.Id_rol = Convert.ToInt32(dt.Rows[i]["Id_rol"]);

                    auxAcceso = auxServiceAcceso.TraerAccesoConEntidad_Escritorio(auxPermisos.Id_acceso);
                    //cargar array con datos de fila
                    ListaPermisos[_fila, 0] = auxAcceso.Nombre.ToString();
                    //agregar lista a gridview
                    dgvAccesos.Rows.Add(ListaPermisos[_fila, 0]);
                    _fila++;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en metodo cargarDataGridViewAccesos, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                //Instancia de Web service con credenciales NT                
                ServiceProcess_Rol.Process_RolSoapClient auxServiceRol = new ServiceProcess_Rol.Process_RolSoapClient();
                auxServiceRol.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceRol.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Rol.Rol auxRol = new ServiceProcess_Rol.Rol();
                auxRol = auxServiceRol.TraerRolConEntidad_Escritorio(Convert.ToInt32(_id_rol));
                if (MessageBox.Show("¿Esta Seguro de Desactivar El Rol " + _nombre + "?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Insertar datos via web service
                    auxServiceRol.ActualizarRolSinEntidad_Escritorio(Convert.ToInt32(_id_rol), _nombre, 0);
                    //ocultar botones
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                    //Vaciar variables
                    _id_rol = null;
                    _nombre = string.Empty;
                    _estado = string.Empty;
                    //limpiar GridView
                    dgvRol.Rows.Clear();
                    dgvRol.Refresh();
                    dgvAccesos.Rows.Clear();
                    dgvAccesos.Refresh();
                    //Metodo Carga de GridView
                    cargarDataGridViewPpal();
                    MessageBox.Show("Rol Desactivado.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void BtnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                //Instancia de Web service con credenciales NT                
                ServiceProcess_Rol.Process_RolSoapClient auxServiceRol = new ServiceProcess_Rol.Process_RolSoapClient();
                auxServiceRol.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceRol.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Rol.Rol auxRol = new ServiceProcess_Rol.Rol();
                auxRol = auxServiceRol.TraerRolConEntidad_Escritorio(Convert.ToInt32(_id_rol));
                if (MessageBox.Show("¿Esta Seguro de Activar El Rol " + _nombre + "?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Insertar datos via web service
                    auxServiceRol.ActualizarRolSinEntidad_Escritorio(Convert.ToInt32(_id_rol), _nombre, 1);
                    //ocultar botones
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                    //Vaciar variables
                    _id_rol = null;
                    _nombre = string.Empty;
                    _estado = string.Empty;
                    //limpiar GridView
                    dgvRol.Rows.Clear();
                    dgvRol.Refresh();
                    dgvAccesos.Rows.Clear();
                    dgvAccesos.Refresh();
                    //Metodo Carga de GridView
                    cargarDataGridViewPpal();
                    MessageBox.Show("Rol Activado.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
        
    }
}

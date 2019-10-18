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
    public partial class FormCuenta : Form
    {
        //Variables para cargar datos desde el gridview
        public static string _rut_usuario = null;
        public static string _rut_empresa;
        public static string _contrasena;
        public static string _estado;
        public static string _id_rol;
        public static string _correo;
        //
        public static string _titulo_modal = string.Empty;
        //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
        public static int _guardar = 0;
        public FormCuenta()
        {
            InitializeComponent();
            //Estas lineas eliminan los parpadeos del formulario o controles en la interfaz grafica (Pero no en un 100%)
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            //Metodo Carga de GridView
            cargarDataGridViewPpal();
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            pbSeleccion.Visible = false;
            //Vaciar variables
            _rut_usuario = null;
            _rut_empresa = string.Empty;
            _contrasena = string.Empty;
            _estado = string.Empty;
            _id_rol = string.Empty;
            _correo = string.Empty;
        }


        private void cargarDataGridViewPpal()
        {
            try
            {
                //instansear web service con seguridad
                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();

                ServiceProcess_Cuenta.Process_CuentaSoapClient auxServiceCuenta = new ServiceProcess_Cuenta.Process_CuentaSoapClient();
                auxServiceCuenta.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCuenta.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Cuenta.Cuenta auxCuenta = new ServiceProcess_Cuenta.Cuenta();

                ServiceProcess_Rol.Process_RolSoapClient auxServiceRol = new ServiceProcess_Rol.Process_RolSoapClient();
                auxServiceRol.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceRol.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Rol.Rol auxRol = new ServiceProcess_Rol.Rol();

                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Usuario.Usuario auxUsuario = new ServiceProcess_Usuario.Usuario();

                //capturar dataset
                DataSet ds = auxServiceCuenta.TraerTodasCuentas_Escritorio();
                //Capturar Tabla
                DataTable dt = ds.Tables[0];
                //contar cantidad de empresas
                int _cantidad_Cuentas = dt.Rows.Count;
                //crear array bidimencional
                string[,] ListaCuenta = new string[_cantidad_Cuentas, 8];
                //Recorrer data table
                int _fila = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Capturar datos de la fila recorridad en objeto empresa
                    auxCuenta.Rut_usuario = (String)dt.Rows[i]["Rut_usuario"];
                    auxCuenta.Rut_empresa = (String)dt.Rows[i]["Rut_empresa"];
                    auxCuenta.Contrasena = (String)dt.Rows[i]["Contrasena"];
                    auxCuenta.Estado = Convert.ToInt32(dt.Rows[i]["Estado"]);
                    auxCuenta.Id_rol = Convert.ToInt32(dt.Rows[i]["Id_rol"]);
                    auxCuenta.Correo = (String)dt.Rows[i]["Correo"];
                    //variables temporales de apoyo
                    string _estado_iteracion = string.Empty;
                    //cargar array con datos de fila
                    ListaCuenta[_fila, 0] = auxCuenta.Rut_usuario;
                    auxUsuario = auxServiceUsuario.TraerUsuarioConEntidad_Escritorio(auxCuenta.Rut_usuario);
                    ListaCuenta[_fila, 1] = auxUsuario.Primer_nombre + " " + auxUsuario.Primer_apellido;
                    auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(auxCuenta.Rut_empresa);
                    ListaCuenta[_fila, 2] = auxEmpresa.Nombre;
                    ListaCuenta[_fila, 3] = auxCuenta.Rut_empresa;
                    ListaCuenta[_fila, 4] = auxCuenta.Correo;
                    auxRol = auxServiceRol.TraerRolConEntidad_Escritorio(auxCuenta.Id_rol);
                    ListaCuenta[_fila, 5] = auxCuenta.Id_rol.ToString();
                    ListaCuenta[_fila, 6] = auxRol.Nombre;
                    if (auxCuenta.Estado == 0)
                    {
                        _estado_iteracion = "DESACTIVADO";
                    }
                    else
                    {
                        _estado_iteracion = "ACTIVADO";
                    }
                    ListaCuenta[_fila, 7] = _estado_iteracion;
                    //agregar lista a gridview
                    dgvCuenta.Rows.Add(ListaCuenta[_fila, 0], ListaCuenta[_fila, 1], ListaCuenta[_fila, 2], ListaCuenta[_fila, 3], ListaCuenta[_fila, 4], ListaCuenta[_fila, 5],ListaCuenta[_fila, 6], ListaCuenta[_fila, 7]);
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
                dgvCuenta.Rows.Clear();
                dgvCuenta.Refresh();
                //instansear web service con seguridad
                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();

                ServiceProcess_Cuenta.Process_CuentaSoapClient auxServiceCuenta = new ServiceProcess_Cuenta.Process_CuentaSoapClient();
                auxServiceCuenta.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCuenta.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Cuenta.Cuenta auxCuenta = new ServiceProcess_Cuenta.Cuenta();

                ServiceProcess_Rol.Process_RolSoapClient auxServiceRol = new ServiceProcess_Rol.Process_RolSoapClient();
                auxServiceRol.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceRol.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Rol.Rol auxRol = new ServiceProcess_Rol.Rol();

                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Usuario.Usuario auxUsuario = new ServiceProcess_Usuario.Usuario();
                //capturar dataset
                DataSet ds = auxServiceCuenta.TraerCuentaConClaveSinEntidad_Escritorio(txtFiltrar.Text.ToUpper());
                if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    //Capturar Tabla
                    DataTable dt = ds.Tables[0];
                    //contar cantidad de empresas
                    int _cantidad_Cuentas = dt.Rows.Count;
                    //crear array bidimencional
                    string[,] ListaCuenta = new string[_cantidad_Cuentas, 8];
                    //Recorrer data table
                    int _fila = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Capturar datos de la fila recorridad en objeto empresa
                        auxCuenta.Rut_usuario = (String)dt.Rows[i]["Rut_usuario"];
                        auxCuenta.Rut_empresa = (String)dt.Rows[i]["Rut_empresa"];
                        auxCuenta.Contrasena = (String)dt.Rows[i]["Contrasena"];
                        auxCuenta.Estado = Convert.ToInt32(dt.Rows[i]["Estado"]);
                        auxCuenta.Id_rol = Convert.ToInt32(dt.Rows[i]["Id_rol"]);
                        auxCuenta.Correo = (String)dt.Rows[i]["Correo"];
                        //variables temporales de apoyo
                        string _estado_iteracion = string.Empty;
                        //cargar array con datos de fila
                        ListaCuenta[_fila, 0] = auxCuenta.Rut_usuario;
                        auxUsuario = auxServiceUsuario.TraerUsuarioConEntidad_Escritorio(auxCuenta.Rut_usuario);
                        ListaCuenta[_fila, 1] = auxUsuario.Primer_nombre + " " + auxUsuario.Primer_apellido;
                        auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(auxCuenta.Rut_empresa);
                        ListaCuenta[_fila, 2] = auxEmpresa.Nombre;
                        ListaCuenta[_fila, 3] = auxCuenta.Rut_empresa;
                        ListaCuenta[_fila, 4] = auxCuenta.Correo;
                        auxRol = auxServiceRol.TraerRolConEntidad_Escritorio(auxCuenta.Id_rol);
                        ListaCuenta[_fila, 5] = auxCuenta.Id_rol.ToString();
                        ListaCuenta[_fila, 6] = auxRol.Nombre;
                        if (auxCuenta.Estado == 0)
                        {
                            _estado_iteracion = "DESACTIVADO";
                        }
                        else
                        {
                            _estado_iteracion = "ACTIVADO";
                        }
                        ListaCuenta[_fila, 7] = _estado_iteracion;
                        //agregar lista a gridview
                        dgvCuenta.Rows.Add(ListaCuenta[_fila, 0], ListaCuenta[_fila, 1], ListaCuenta[_fila, 2], ListaCuenta[_fila, 3], ListaCuenta[_fila, 4], ListaCuenta[_fila, 5], ListaCuenta[_fila, 6], ListaCuenta[_fila, 7]);
                        _fila++;

                    }
                    //Vaciar variables
                    _rut_usuario = null;
                    _rut_empresa = string.Empty;
                    _contrasena = string.Empty;
                    _estado = string.Empty;
                    _id_rol = string.Empty;
                    _correo = string.Empty;
                    //deseleccionar
                    pbSeleccion.Visible = false;
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                }
                else
                {
                    //Vaciar variables
                    _rut_usuario = null;
                    _rut_empresa = string.Empty;
                    _contrasena = string.Empty;
                    _estado = string.Empty;
                    _id_rol = string.Empty;
                    _correo = string.Empty;
                    //deseleccionar
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
                if (_rut_usuario == null)//validador que se seleccione un fila de CUENTA
                {
                    MessageBox.Show("Seleccione una Cuenta a Modificar", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _titulo_modal = "MODIFICAR CUENTA";
                    _guardar = 1;
                    FormCuentaModal frmModal = new FormCuentaModal(_titulo_modal, _guardar.ToString(), _rut_usuario, _rut_empresa, _contrasena,
                                        _estado, _id_rol, _correo);
                    if (frmModal.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Cuenta Modificado Correctamente.", "MODIFICACION DE USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnActivar.Visible = false;
                        btnDesactivar.Visible = false;
                        //Vaciar variables                        
                        _rut_usuario = null;
                        _rut_empresa = string.Empty;
                        _contrasena = string.Empty;
                        _estado = string.Empty;
                        _id_rol = string.Empty;
                        _correo = string.Empty;
                        //
                        dgvCuenta.Rows.Clear();
                        dgvCuenta.Refresh();
                        //cargar gridview
                        cargarDataGridViewPpal();
                        pbSeleccion.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo BtnModificar_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }     

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                _titulo_modal = "NUEVA CUENTA";
                _guardar = 3;
                FormCuentaModalNuevo frmModal = new FormCuentaModalNuevo();
                if (frmModal.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Cuenta Creada Correctamente.", "CREACION DE USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                    //Vaciar variables
                    _rut_usuario = null;
                    _rut_empresa = string.Empty;
                    _contrasena = string.Empty;
                    _estado = string.Empty;
                    _id_rol = string.Empty;
                    _correo = string.Empty;
                    //
                    dgvCuenta.Rows.Clear();
                    dgvCuenta.Refresh();
                    //cargar gridview
                    cargarDataGridViewPpal();
                    pbSeleccion.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo BtnNuevo_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCuenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ServiceProcess_Cuenta.Process_CuentaSoapClient auxServiceCuenta = new ServiceProcess_Cuenta.Process_CuentaSoapClient();
                auxServiceCuenta.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCuenta.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Cuenta.Cuenta auxCuenta = new ServiceProcess_Cuenta.Cuenta();

                if (e.RowIndex < 0)
                    return;

                _rut_usuario = dgvCuenta.Rows[e.RowIndex].Cells["RUT_USUARIO"].Value.ToString();
                _rut_empresa = dgvCuenta.Rows[e.RowIndex].Cells["RUT_EMPRESA"].Value.ToString();                
                _estado = dgvCuenta.Rows[e.RowIndex].Cells["ESTADO"].Value.ToString();
                _id_rol = dgvCuenta.Rows[e.RowIndex].Cells["ID_ROL"].Value.ToString();
                _correo = dgvCuenta.Rows[e.RowIndex].Cells["CORREO"].Value.ToString();

                auxCuenta = auxServiceCuenta.TraerCuentaConEntidad_Escritorio(_rut_usuario);

                _contrasena = auxCuenta.Contrasena;

                pbSeleccion.Visible = true;

                if (_estado.Equals("DESACTIVADO"))
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
                MessageBox.Show("Error en metodo de accion DgvCuenta_CellClick, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVer_Click(object sender, EventArgs e)
        {
            try
            {
                if (_rut_usuario == null)//validador que se seleccione un fila de CUENTA
                {
                    MessageBox.Show("Seleccione una Cuenta a Modificar", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _titulo_modal = "MOSTRAR CUENTA";
                    _guardar = 3;
                    FormCuentaModal frmModal = new FormCuentaModal(_titulo_modal, _guardar.ToString(), _rut_usuario, _rut_empresa, _contrasena,
                                        _estado, _id_rol, _correo);
                    if (frmModal.ShowDialog() == DialogResult.OK)
                    {                        
                        btnActivar.Visible = false;
                        btnDesactivar.Visible = false;
                        pbSeleccion.Visible = false;
                        //Vaciar variables
                        _rut_usuario = null;
                        _rut_empresa = string.Empty;
                        _contrasena = string.Empty;
                        _estado = string.Empty;
                        _id_rol = string.Empty;
                        _correo = string.Empty;

                    }
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo BtnVer_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void BtnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                //Instancia de Web service con credenciales NT
                ServiceProcess_Cuenta.Process_CuentaSoapClient auxServiceCuenta = new ServiceProcess_Cuenta.Process_CuentaSoapClient();
                auxServiceCuenta.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCuenta.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Usuario.Usuario auxUsuario = new ServiceProcess_Usuario.Usuario();
                ServiceProcess_Cuenta.Cuenta auxCuenta = new ServiceProcess_Cuenta.Cuenta();
                auxCuenta = auxServiceCuenta.TraerCuentaConEmpresaConEntidad_Escritorio(_rut_usuario, _rut_empresa);
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(_rut_empresa);

                if (MessageBox.Show("¿Esta Seguro de Desactivar Cuenta " + _rut_usuario + "  Para la Empresa " + auxEmpresa.Nombre + "?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {


                    //Insertar datos via web service
                    auxServiceCuenta.ActualizarCuentaSinEntidad_Escritorio(auxCuenta.Rut_usuario, auxCuenta.Rut_empresa, auxCuenta.Contrasena, 0, auxCuenta.Id_rol, auxCuenta.Correo);
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                    //Vaciar variables
                    _rut_usuario = null;
                    _rut_empresa = string.Empty;
                    _contrasena = string.Empty;
                    _estado = string.Empty;
                    _id_rol = string.Empty;
                    _correo = string.Empty;
                    pbSeleccion.Visible = false;
                    //limpiar GridView
                    dgvCuenta.Rows.Clear();
                    dgvCuenta.Refresh();
                    //Metodo Carga de GridView
                    cargarDataGridViewPpal();
                    MessageBox.Show("Cuenta Desactivada Para Empresa " + auxEmpresa.Nombre + " .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void BtnResetClave_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceProcess_Cuenta.Process_CuentaSoapClient auxServiceCuenta = new ServiceProcess_Cuenta.Process_CuentaSoapClient();
                auxServiceCuenta.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCuenta.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Cuenta.Cuenta auxCuenta = new ServiceProcess_Cuenta.Cuenta();
                auxCuenta = auxServiceCuenta.TraerCuentaConEmpresaConEntidad_Escritorio(_rut_usuario, _rut_empresa);

                if (MessageBox.Show("¿Esta Seguro de Resetear Contaseña de Cuenta de Acceso?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    auxCuenta = auxServiceCuenta.TraerCuentaConEmpresaConEntidad_Escritorio(_rut_usuario, _rut_empresa);

                    string contrasena = _rut_usuario.Substring(0, 5);
                    //Insertar datos via web service
                    auxServiceCuenta.ActualizarCuentaSinEntidad_Escritorio(auxCuenta.Rut_usuario, auxCuenta.Rut_empresa, contrasena, auxCuenta.Estado, auxCuenta.Id_rol, auxCuenta.Correo);
                    MessageBox.Show("Contraseña Reseteada con los primeros 5 Digitos del RUT.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    //vuleve a pantalla 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion BtnResetClave_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                //Instancia de Web service con credenciales NT
                ServiceProcess_Cuenta.Process_CuentaSoapClient auxServiceCuenta = new ServiceProcess_Cuenta.Process_CuentaSoapClient();
                auxServiceCuenta.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCuenta.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Usuario.Usuario auxUsuario = new ServiceProcess_Usuario.Usuario();
                ServiceProcess_Cuenta.Cuenta auxCuenta = new ServiceProcess_Cuenta.Cuenta();
                auxCuenta = auxServiceCuenta.TraerCuentaConEmpresaConEntidad_Escritorio(_rut_usuario, _rut_empresa);
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(_rut_empresa);

                if (MessageBox.Show("¿Esta Seguro de Activar Cuenta " + _rut_usuario + "  Para la Empresa " + auxEmpresa.Nombre + "?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {


                    //Insertar datos via web service
                    auxServiceCuenta.ActualizarCuentaSinEntidad_Escritorio(auxCuenta.Rut_usuario, auxCuenta.Rut_empresa, auxCuenta.Contrasena,1, auxCuenta.Id_rol, auxCuenta.Correo);
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                    //Vaciar variables
                    _rut_usuario = null;
                    _rut_empresa = string.Empty;
                    _contrasena = string.Empty;
                    _estado = string.Empty;
                    _id_rol = string.Empty;
                    _correo = string.Empty;
                    pbSeleccion.Visible = false;
                    //limpiar GridView
                    dgvCuenta.Rows.Clear();
                    dgvCuenta.Refresh();
                    //Metodo Carga de GridView
                    cargarDataGridViewPpal();
                    MessageBox.Show("Cuenta Activada Para Empresa " + auxEmpresa.Nombre + " .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

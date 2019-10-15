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
    public partial class FormUsuario : Form
    {
        //Variable Titulo
        public static string _titulo_modal;
        //Variables para cargar datos desde el gridview
        public static string _rut_usuario = null;
        public static string _primer_nombre;
        public static string _segundo_nombre;
        public static string _primer_apellido;
        public static string _segundo_apellido;
        public static string _direccion;
        public static string _correo;
        public static string _telefono_fijo;
        public static string _telefono_movil;
        public static string _estado;
        public static string _id_comuna;
        public static string _rut_empresa;
        public static string _id_cargo;
        //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
        public static int _guardar = 0;
        public FormUsuario()
        {
            InitializeComponent();
            //Estas lineas eliminan los parpadeos del formulario o controles en la interfaz grafica (Pero no en un 100%)
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            //Metodo Carga de GridView
            cargarDataGridViewPpal();
        }

        //Metodo Carga GridView 
        private void cargarDataGridViewPpal()
        {
            try
            {
                //instansear web service con seguridad
                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Usuario.Usuario auxUsuario = new ServiceProcess_Usuario.Usuario();

                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();

                //capturar dataset
                DataSet ds = auxServiceUsuario.TraerTodasUsuariosJoin_Escritorio();
                //Capturar Tabla
                DataTable dt = ds.Tables[0];
                //contar cantidad de empresas
                int _cantidad_usuarios = dt.Rows.Count;
                //crear array bidimencional
                string[,] ListaUsuario = new string[_cantidad_usuarios, 7];
                //Recorrer data table
                int _fila = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Capturar datos de la fila recorridad en objeto empresa
                    auxUsuario.Rut_usuario = (String)dt.Rows[i]["Rut_usuario"];
                    auxUsuario.Primer_nombre = (String)dt.Rows[i]["Primer_nombre"];
                    auxUsuario.Segundo_nombre = (String)dt.Rows[i]["Segundo_nombre"];
                    auxUsuario.Primer_apellido = (String)dt.Rows[i]["Primer_apellido"];
                    auxUsuario.Segundo_apellido = (String)dt.Rows[i]["Segundo_apellido"];
                    auxUsuario.Direccion = (String)dt.Rows[i]["Direccion"];
                    auxUsuario.Telefono_fijo = Convert.ToInt32(dt.Rows[i]["Telefono_fijo"]);
                    auxUsuario.Telefono_movil = Convert.ToInt32(dt.Rows[i]["Telefono_movil"]);
                    auxUsuario.Id_comuna = Convert.ToInt32(dt.Rows[i]["Id_comuna"]);
                    //variables temporales de apoyo
                    string _estado_resultado = string.Empty;
                    string _estado_iteracion = (String)dt.Rows[i]["Estado"];
                    int _id_cargo_iteracion = Convert.ToInt32(dt.Rows[i]["Id_cargo"]);
                    string _rut_empresa_iteracion = (String)dt.Rows[i]["Rut_empresa"];
                    //cargar array con datos de fila
                    ListaUsuario[_fila, 0] = auxUsuario.Primer_nombre + " " + auxUsuario.Segundo_nombre + " " + auxUsuario.Primer_apellido + " " + auxUsuario.Segundo_apellido;
                    ListaUsuario[_fila, 1] = auxUsuario.Rut_usuario;
                    ListaUsuario[_fila, 2] = auxUsuario.Direccion;
                    auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(_rut_empresa_iteracion);
                    ListaUsuario[_fila, 3] = auxEmpresa.Nombre;
                    if (Convert.ToInt32(_estado_iteracion) == 0)
                    {
                        _estado_resultado = "DESACTIVADO";
                    }
                    else
                    {
                        _estado_resultado = "ACTIVADO";
                    }
                    ListaUsuario[_fila, 4] = _estado_resultado;
                    ListaUsuario[_fila, 5] = _id_cargo_iteracion.ToString();
                    ListaUsuario[_fila, 6] = _rut_empresa_iteracion;
                    //agregar lista a gridview
                    dgvUsuario.Rows.Add(ListaUsuario[_fila, 0], ListaUsuario[_fila, 1], ListaUsuario[_fila, 2], ListaUsuario[_fila, 3], ListaUsuario[_fila, 4], ListaUsuario[_fila, 5], ListaUsuario[_fila, 6]);
                    _fila++;

                }
                pbSeleccion.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo cargarDataGridViewPpal, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Metodo Boton Cerrar
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            System.GC.Collect();
        }

        private void TxtFiltrar_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dgvUsuario.Rows.Clear();
                dgvUsuario.Refresh();
                //instansear web service con seguridad                
                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Usuario.Usuario auxUsuario = new ServiceProcess_Usuario.Usuario();

                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                //capturar dataset
                DataSet ds = auxServiceUsuario.TraerUsuarioConClaveSinEntidad_Escritorio(txtFiltrar.Text.ToUpper());
                if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    //Capturar Tabla
                    DataTable dt = ds.Tables[0];
                    //contar cantidad de empresas
                    int _cantidad_usuarios = dt.Rows.Count;
                    //crear array bidimencional
                    string[,] ListaUsuario = new string[_cantidad_usuarios, 7];
                    //Recorrer data table
                    int _fila = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Capturar datos de la fila recorridad en objeto empresa
                        auxUsuario.Rut_usuario = (String)dt.Rows[i]["Rut_usuario"];
                        auxUsuario.Primer_nombre = (String)dt.Rows[i]["Primer_nombre"];
                        auxUsuario.Segundo_nombre = (String)dt.Rows[i]["Segundo_nombre"];
                        auxUsuario.Primer_apellido = (String)dt.Rows[i]["Primer_apellido"];
                        auxUsuario.Segundo_apellido = (String)dt.Rows[i]["Segundo_apellido"];
                        auxUsuario.Direccion = (String)dt.Rows[i]["Direccion"];
                        auxUsuario.Telefono_fijo = Convert.ToInt32(dt.Rows[i]["Telefono_fijo"]);
                        auxUsuario.Telefono_movil = Convert.ToInt32(dt.Rows[i]["Telefono_movil"]);
                        auxUsuario.Id_comuna = Convert.ToInt32(dt.Rows[i]["Id_comuna"]);
                        //variables temporales de apoyo
                        string _estado_resultado = string.Empty;
                        string _estado_iteracion = (String)dt.Rows[i]["Estado"];
                        int _id_cargo_iteracion = Convert.ToInt32(dt.Rows[i]["Id_cargo"]);
                        string _rut_empresa_iteracion = (String)dt.Rows[i]["Rut_empresa"];
                        //cargar array con datos de fila
                        ListaUsuario[_fila, 0] = auxUsuario.Primer_nombre + " " + auxUsuario.Segundo_nombre + " " + auxUsuario.Primer_apellido + " " + auxUsuario.Segundo_apellido;
                        ListaUsuario[_fila, 1] = auxUsuario.Rut_usuario;
                        ListaUsuario[_fila, 2] = auxUsuario.Direccion;
                        auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(_rut_empresa_iteracion);
                        ListaUsuario[_fila, 3] = auxEmpresa.Nombre;
                        if (Convert.ToInt32(_estado_iteracion) == 0)
                        {
                            _estado_resultado = "DESACTIVADO";
                        }
                        else
                        {
                            _estado_resultado = "ACTIVADO";
                        }
                        ListaUsuario[_fila, 4] = _estado_resultado;
                        ListaUsuario[_fila, 5] = _id_cargo_iteracion.ToString();
                        ListaUsuario[_fila, 6] = _rut_empresa_iteracion;
                        //agregar lista a gridview
                        dgvUsuario.Rows.Add(ListaUsuario[_fila, 0], ListaUsuario[_fila, 1], ListaUsuario[_fila, 2], ListaUsuario[_fila, 3], ListaUsuario[_fila, 4], ListaUsuario[_fila, 5], ListaUsuario[_fila, 6]);
                        _fila++;

                    }
                    //Vaciar variables                    
                    _rut_usuario = null;
                    _primer_nombre = string.Empty;
                    _segundo_nombre = string.Empty;
                    _primer_apellido = string.Empty;
                    _segundo_apellido = string.Empty;
                    _direccion = string.Empty;
                    _telefono_fijo = string.Empty;
                    _telefono_movil = string.Empty;
                    _estado = string.Empty;
                    _id_comuna = string.Empty;
                    _rut_empresa = string.Empty;
                    _id_cargo = string.Empty;
                    //deseleccionar
                    pbSeleccion.Visible = false;
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                }
                else
                {
                    //Mostrar GridView Vacio
                    //Vaciar variables
                    _rut_usuario = null;
                    _primer_nombre = string.Empty;
                    _segundo_nombre = string.Empty;
                    _primer_apellido = string.Empty;
                    _segundo_apellido = string.Empty;
                    _direccion = string.Empty;
                    _telefono_fijo = string.Empty;
                    _telefono_movil = string.Empty;
                    _estado = string.Empty;
                    _id_comuna = string.Empty;
                    _rut_empresa = string.Empty;
                    _id_cargo = string.Empty;
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
                if (_rut_usuario == null)//validador que se seleccione un fila de GridView de usuario
                {
                    MessageBox.Show("Seleccione una Fila a Modificar", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _titulo_modal = "MODIFICAR USUARIO";
                    _guardar = 1;
                    FormUsuarioModal frmModal = new FormUsuarioModal(_titulo_modal, _guardar, _rut_usuario, _primer_nombre, _segundo_nombre,
                                        _primer_apellido, _segundo_apellido, _direccion, _telefono_fijo, _telefono_movil, _estado, _id_comuna, _rut_empresa, _id_cargo);
                    if (frmModal.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Usuario Modificado Correctamente.", "MODIFICACION DE USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnActivar.Visible = false;
                        btnDesactivar.Visible = false;
                        //Vaciar variables
                        _rut_usuario = null;
                        _primer_nombre = string.Empty;
                        _segundo_nombre = string.Empty;
                        _primer_apellido = string.Empty;
                        _segundo_apellido = string.Empty;
                        _direccion = string.Empty;
                        _telefono_fijo = string.Empty;
                        _telefono_movil = string.Empty;
                        _estado = string.Empty;
                        _id_comuna = string.Empty;
                        _rut_empresa = string.Empty;
                        _id_cargo = string.Empty;
                        //
                        dgvUsuario.Rows.Clear();
                        dgvUsuario.Refresh();
                        //cargar gridview
                        cargarDataGridViewPpal();
                        pbSeleccion.Visible = false;

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Boton de accion BtnModificar_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                _titulo_modal = "NUEVO USUARIO";
                _guardar = 2;
                FormUsuarioModalNuevo frmModal = new FormUsuarioModalNuevo(_titulo_modal, _guardar, _rut_usuario, _primer_nombre, _segundo_nombre,
                                    _primer_apellido, _segundo_apellido, _direccion, _telefono_fijo, _telefono_movil, _estado, _id_comuna, _rut_empresa, _id_cargo);
                if (frmModal.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Usuario Creado Correctamente.", "CREACION DE USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                    //Vaciar variables
                    _rut_usuario = null;
                    _primer_nombre = string.Empty;
                    _segundo_nombre = string.Empty;
                    _primer_apellido = string.Empty;
                    _segundo_apellido = string.Empty;
                    _direccion = string.Empty;
                    _telefono_fijo = string.Empty;
                    _telefono_movil = string.Empty;
                    _estado = string.Empty;
                    _id_comuna = string.Empty;
                    _rut_empresa = string.Empty;
                    _id_cargo = string.Empty;
                    //
                    dgvUsuario.Rows.Clear();
                    dgvUsuario.Refresh();
                    //cargar gridview
                    cargarDataGridViewPpal();
                    pbSeleccion.Visible = false;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Boton de accion BtnNuevo_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVer_Click(object sender, EventArgs e)
        {
            try
            {
                if (_rut_usuario == null)//validador que se seleccione un fila de GridView de usuario
                {
                    MessageBox.Show("Seleccione una Fila a Mostrar", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _titulo_modal = "MOSTRAR USUARIO";
                    _guardar = 3;
                    FormUsuarioModal frmModal = new FormUsuarioModal(_titulo_modal, _guardar, _rut_usuario, _primer_nombre, _segundo_nombre,
                                        _primer_apellido, _segundo_apellido, _direccion, _telefono_fijo, _telefono_movil, _estado, _id_comuna, _rut_empresa, _id_cargo);
                    if (frmModal.ShowDialog() == DialogResult.OK)
                    {
                        btnActivar.Visible = false;
                        btnDesactivar.Visible = false;
                        //Vaciar variables
                        _rut_usuario = null;
                        _primer_nombre = string.Empty;
                        _segundo_nombre = string.Empty;
                        _primer_apellido = string.Empty;
                        _segundo_apellido = string.Empty;
                        _direccion = string.Empty;
                        _telefono_fijo = string.Empty;
                        _telefono_movil = string.Empty;
                        _estado = string.Empty;
                        _id_comuna = string.Empty;
                        _rut_empresa = string.Empty;
                        _id_cargo = string.Empty;
                        pbSeleccion.Visible = false;

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Boton de accion BtnVer_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0)
                    return;
                //captura de rut selecccionado
                _rut_usuario = dgvUsuario.Rows[e.RowIndex].Cells["RUT_USUARIO"].Value.ToString();
                _estado = dgvUsuario.Rows[e.RowIndex].Cells["ESTADO"].Value.ToString();
                if (_estado.Equals("ACTIVADO"))
                {
                    _estado = "1";
                }
                else
                {
                    _estado = "0";
                }
                _rut_empresa = dgvUsuario.Rows[e.RowIndex].Cells["RUT_EMPRESA"].Value.ToString();
                _id_cargo = dgvUsuario.Rows[e.RowIndex].Cells["ID_CARGO"].Value.ToString();

                //instansear web service con seguridad
                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Usuario.Usuario auxUsuario = new ServiceProcess_Usuario.Usuario();
                auxUsuario = auxServiceUsuario.TraerUsuarioConEntidad_Escritorio(_rut_usuario);


                _primer_nombre = auxUsuario.Primer_nombre;
                _segundo_nombre = auxUsuario.Segundo_nombre;
                _primer_apellido = auxUsuario.Primer_apellido;
                _segundo_apellido = auxUsuario.Segundo_apellido;
                _direccion = auxUsuario.Direccion;
                _telefono_fijo = auxUsuario.Telefono_fijo.ToString();
                _telefono_movil = auxUsuario.Telefono_movil.ToString();
                _id_comuna = auxUsuario.Id_comuna.ToString();

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

                pbSeleccion.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion DgvUsuario_CellClick, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                ServiceProcess_CargosUsuarios.Process_CargosUsuariosSoapClient auxServiceCargosUsuarios = new ServiceProcess_CargosUsuarios.Process_CargosUsuariosSoapClient();
                auxServiceCargosUsuarios.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCargosUsuarios.ClientCredentials.UserName.Password = Cuenta.Clave_iis;


                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(_rut_empresa);

                if (MessageBox.Show("¿Esta Seguro de Activar Usuario " + _primer_nombre + " " + _primer_apellido + " Para la Empresa " + auxEmpresa.Nombre + "?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {


                    //Insertar datos via web service
                    auxServiceCargosUsuarios.ActualizarCargosUsuarioSinEntidad_Escritorio(_rut_usuario, Convert.ToInt32(_id_cargo), 1);
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                    //Vaciar variables
                    _rut_usuario = null;
                    _primer_nombre = string.Empty;
                    _segundo_nombre = string.Empty;
                    _primer_apellido = string.Empty;
                    _segundo_apellido = string.Empty;
                    _direccion = string.Empty;
                    _telefono_fijo = string.Empty;
                    _telefono_movil = string.Empty;
                    _estado = string.Empty;
                    _id_comuna = string.Empty;
                    _rut_empresa = string.Empty;
                    _id_cargo = string.Empty;
                    pbSeleccion.Visible = false;
                    //limpiar GridView
                    dgvUsuario.Rows.Clear();
                    dgvUsuario.Refresh();
                    //Metodo Carga de GridView
                    cargarDataGridViewPpal();
                    MessageBox.Show("Usuario Activado Para Empresa " + auxEmpresa.Nombre + " .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

                ServiceProcess_CargosUsuarios.Process_CargosUsuariosSoapClient auxServiceCargosUsuarios = new ServiceProcess_CargosUsuarios.Process_CargosUsuariosSoapClient();
                auxServiceCargosUsuarios.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCargosUsuarios.ClientCredentials.UserName.Password = Cuenta.Clave_iis;


                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(_rut_empresa);

                if (MessageBox.Show("¿Esta Seguro de Desactivar Usuario " + _primer_nombre + " " + _primer_apellido + " Para la Empresa " + auxEmpresa.Nombre + "?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {


                    //Insertar datos via web service
                    auxServiceCargosUsuarios.ActualizarCargosUsuarioSinEntidad_Escritorio(_rut_usuario, Convert.ToInt32(_id_cargo), 0);
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                    //Vaciar variables
                    _rut_usuario = null;
                    _primer_nombre = string.Empty;
                    _segundo_nombre = string.Empty;
                    _primer_apellido = string.Empty;
                    _segundo_apellido = string.Empty;
                    _direccion = string.Empty;
                    _telefono_fijo = string.Empty;
                    _telefono_movil = string.Empty;
                    _estado = string.Empty;
                    _id_comuna = string.Empty;
                    _rut_empresa = string.Empty;
                    _id_cargo = string.Empty;
                    pbSeleccion.Visible = false;
                    //limpiar GridView
                    dgvUsuario.Rows.Clear();
                    dgvUsuario.Refresh();
                    //Metodo Carga de GridView
                    cargarDataGridViewPpal();
                    MessageBox.Show("Usuario Desactivado Para Empresa " + auxEmpresa.Nombre + " .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void BtnMultiempresa_Click(object sender, EventArgs e)
        {
            try
            {
                FormUsuarioModalMultiempresa frmModal = new FormUsuarioModalMultiempresa();
                if (frmModal.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Usuario Creado En Multiempresas Correctamente.", "CREACION DE USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                    //Vaciar variables
                    _rut_usuario = null;
                    _primer_nombre = string.Empty;
                    _segundo_nombre = string.Empty;
                    _primer_apellido = string.Empty;
                    _segundo_apellido = string.Empty;
                    _direccion = string.Empty;
                    _telefono_fijo = string.Empty;
                    _telefono_movil = string.Empty;
                    _estado = string.Empty;
                    _id_comuna = string.Empty;
                    _rut_empresa = string.Empty;
                    _id_cargo = string.Empty;
                    //
                    dgvUsuario.Rows.Clear();
                    dgvUsuario.Refresh();
                    //cargar gridview
                    cargarDataGridViewPpal();
                    pbSeleccion.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Boton de accion BtnMultiempresa_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

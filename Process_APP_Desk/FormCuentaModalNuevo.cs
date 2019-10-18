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
    public partial class FormCuentaModalNuevo : Form
    {
        public static string _rut_usuario = null;
        public static string _rut_empresa = null;
        public static string _correo = null;
        public static string _id_rol = null;
        public static string _contrasena = null;
        public FormCuentaModalNuevo()
        {
            InitializeComponent();
            txtUsuario.Enabled = false;
            txtEmpresa.Enabled = false;
            txtCuenta.Enabled = false;
            pbSeleccionUsuario.Visible = false;
            pbSeleccionEmpresa.Visible = false;
            pbSeleccion.Visible = false;

            cargarComboEmpresa();
            cargarComboRol();
        }

        private void cargarDataGridViewUsuario()
        {
            try
            {

                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Usuario.Usuario auxUsuario = new ServiceProcess_Usuario.Usuario();

                ServiceProcess_Cuenta.Process_CuentaSoapClient auxServiceCuenta = new ServiceProcess_Cuenta.Process_CuentaSoapClient();
                auxServiceCuenta.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCuenta.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Cuenta.Cuenta auxCuenta = new ServiceProcess_Cuenta.Cuenta();

                //capturar dataset
                DataSet ds = auxServiceUsuario.TraerUsuarioPorEmpresaSinEntidad_Escritorio(_rut_empresa);
                if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    //Capturar Tabla
                    DataTable dt = ds.Tables[0];
                    //contar cantidad de empresas
                    int _cantidad_Usuarios = dt.Rows.Count;
                    //crear array bidimencional
                    string[,] ListaUsuarios = new string[_cantidad_Usuarios, 2];
                    //Recorrer data table
                    int _fila = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Capturar datos de la fila recorridad en objeto empresa
                        string rut_usuario = (String)dt.Rows[i]["Rut_usuario"];
                        string nombre = (String)dt.Rows[i]["Primer_nombre"] + " " + (String)dt.Rows[i]["Primer_apellido"];
                        string rut_empresa = (String)dt.Rows[i]["Rut_empresa"];

                        //CAPTURAR DATASET 
                        DataSet dsU = auxServiceCuenta.TraerCuentaConEmpresaSinEntidad_Escritorio(rut_usuario, _rut_empresa);
                        if ((dsU.Tables.Count != 0) && (dsU.Tables[0].Rows.Count > 0))
                        {
                            //no carga nada al gridview por que ya es usuario  de la empresa
                        }
                        else
                        {
                            //cargar array con datos de fila
                            ListaUsuarios[_fila, 0] = rut_usuario;
                            ListaUsuarios[_fila, 1] = nombre;
                            //agregar lista a gridview
                            dgvUsuario.Rows.Add(ListaUsuarios[_fila, 0], ListaUsuarios[_fila, 1]);
                            _fila++;
                        }
                    }

                    if (dgvUsuario.Rows.Count == 0)
                    {
                        MessageBox.Show("Empresa Seleccionada ya tiene Todas las cuentas creadas.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Empresa Seleccionada Sin Usuarios Disponibles Para Crear Cuentas.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo cargarDataGridViewUsuario, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarComboEmpresa()
        {

            try
            {

                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ds = auxServiceEmpresa.TraerTodasEmpresas_Escritorio();
                dt = ds.Tables[0];
                DataRow fila = dt.NewRow();
                fila["RUT_EMPRESA"] = 0;
                fila["NOMBRE"] = "SELECCIONE EMPRESA";
                fila["GIRO"] = " ";
                fila["DIRECCION"] = " ";
                fila["ESTADO"] = 0;
                fila["ID_COMUNA"] = 0;
                dt.Rows.InsertAt(fila, 0);
                cbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
                cbEmpresa.DataSource = dt;
                cbEmpresa.DisplayMember = "NOMBRE";
                cbEmpresa.ValueMember = "RUT_EMPRESA";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion cargarComboEmpresa, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
            auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
            auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
            ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();

            if (Convert.ToInt32(cbEmpresa.SelectedIndex) > 0)
            {
                string rut_empresa = cbEmpresa.SelectedValue.ToString();
                auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(rut_empresa);
                _rut_empresa = rut_empresa;
                txtEmpresa.Text = auxEmpresa.Nombre;

                //limpiar GridView
                dgvUsuario.Rows.Clear();
                dgvUsuario.Refresh();




                //limpiar 
                dgvUsuario.Rows.Clear();
                dgvUsuario.Refresh();
                pbSeleccionUsuario.Visible = false;
                pbSeleccionEmpresa.Visible = true;
                pbSeleccion.Visible = false;
                txtUsuario.Text = string.Empty;
                txtCorreo.Text = string.Empty;
                _rut_usuario = null;
                _correo = null;
                _id_rol = null;
                //vaciar combobox
                cbRol.DataSource = null;
                cbRol.Items.Clear();
                //cargar como rol
                cargarComboRol();
                cargarDataGridViewUsuario();
            }
            else
            {
                //limpiar GridView
                dgvUsuario.Rows.Clear();
                dgvUsuario.Refresh();
                pbSeleccionUsuario.Visible = false;
                pbSeleccionEmpresa.Visible = false;
                pbSeleccion.Visible = false;
                txtUsuario.Text = string.Empty;
                txtEmpresa.Text = string.Empty;
                txtCorreo.Text = string.Empty;
                //vaciar combobox
                cbRol.DataSource = null;
                cbRol.Items.Clear();
                //cargar como rol
                cargarComboRol();

            }
        }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion CbEmpresa_SelectedIndexChanged, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void cargarComboRol()
        {

            try
            {

                ServiceProcess_Rol.Process_RolSoapClient auxServiceRol = new ServiceProcess_Rol.Process_RolSoapClient();
                auxServiceRol.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceRol.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ds = auxServiceRol.TraerTodasRoles_Escritorio();
                dt = ds.Tables[0];
                DataRow fila = dt.NewRow();
                fila["ID_ROL"] = 0;
                fila["NOMBRE"] = "SELECCIONE ROL";
                fila["ESTADO"] = 0;
                dt.Rows.InsertAt(fila, 0);
                cbRol.DropDownStyle = ComboBoxStyle.DropDownList;
                cbRol.DataSource = dt;
                cbRol.DisplayMember = "NOMBRE";
                cbRol.ValueMember = "ID_ROL";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion cargarComboRol, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex < 0)
                    return;

                _rut_usuario = dgvUsuario.Rows[e.RowIndex].Cells["Rut_usuario"].Value.ToString();

                //instansear web service con seguridad                
                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Usuario.Usuario auxUsuario = new ServiceProcess_Usuario.Usuario();


                auxUsuario = auxServiceUsuario.TraerUsuarioConEntidad_Escritorio(_rut_usuario);
                txtUsuario.Text = auxUsuario.Primer_nombre + " " + auxUsuario.Primer_apellido;
                txtCuenta.Text = _rut_usuario;
                //limpiar                 
                pbSeleccionUsuario.Visible = true;
                pbSeleccionEmpresa.Visible = true;
                pbSeleccion.Visible = true;                
                txtCorreo.Text = string.Empty;                
                _correo = null;
                _id_rol = null;
                //vaciar combobox
                cbRol.DataSource = null;
                cbRol.Items.Clear();
                //cargar como rol
                cargarComboRol();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion DgvUsuario_CellClick, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtFiltrarUsuario_KeyUp(object sender, KeyEventArgs e)
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

                ServiceProcess_Cuenta.Process_CuentaSoapClient auxServiceCuenta = new ServiceProcess_Cuenta.Process_CuentaSoapClient();
                auxServiceCuenta.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCuenta.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Cuenta.Cuenta auxCuenta = new ServiceProcess_Cuenta.Cuenta();

                if (txtFiltrarUsuario.Text.Equals(""))
                {
                    cargarDataGridViewUsuario();
                }
                else
                {

                    //capturar dataset
                    DataSet ds = auxServiceUsuario.TraerUsuarioConClavePorEmpresaSinEntidad_Escritorio(_rut_empresa, txtFiltrarUsuario.Text.ToUpper());
                    if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
                    {
                        //Capturar Tabla
                        DataTable dt = ds.Tables[0];
                        //contar cantidad de empresas
                        int _cantidad_Usuarios = dt.Rows.Count;
                        //crear array bidimencional
                        string[,] ListaUsuarios = new string[_cantidad_Usuarios, 2];
                        //Recorrer data table
                        int _fila = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //Capturar datos de la fila recorridad en objeto empresa
                            string rut_usuario = (String)dt.Rows[i]["Rut_usuario"];
                            string nombre = (String)dt.Rows[i]["Primer_nombre"] + " " + (String)dt.Rows[i]["Primer_apellido"];
                            string rut_empresa = (String)dt.Rows[i]["Rut_empresa"];

                            //CAPTURAR DATASET 
                            DataSet dsU = auxServiceCuenta.TraerCuentaConEmpresaSinEntidad_Escritorio(rut_usuario, _rut_empresa);
                            if ((dsU.Tables.Count != 0) && (dsU.Tables[0].Rows.Count > 0))
                            {
                                //no carga nada al gridview por que ya es usuario  de la empresa
                            }
                            else
                            {
                                //cargar array con datos de fila
                                ListaUsuarios[_fila, 0] = rut_usuario;
                                ListaUsuarios[_fila, 1] = nombre;
                                //agregar lista a gridview
                                dgvUsuario.Rows.Add(ListaUsuarios[_fila, 0], ListaUsuarios[_fila, 1]);
                                _fila++;
                            }
                        }
                        pbSeleccionUsuario.Visible = false;
                        pbSeleccionEmpresa.Visible = true;
                        pbSeleccion.Visible = false;
                        txtUsuario.Text = string.Empty;
                        txtCorreo.Text = string.Empty;
                        _rut_usuario = null;
                        _correo = null;
                        _id_rol = null;
                        //vaciar combobox
                        cbRol.DataSource = null;
                        cbRol.Items.Clear();
                        //cargar como rol
                        cargarComboRol();

                    }
                    else
                    {
                        pbSeleccionUsuario.Visible = false;
                        pbSeleccionEmpresa.Visible = true;
                        pbSeleccion.Visible = false;
                        txtUsuario.Text = string.Empty;
                        txtCorreo.Text = string.Empty;
                        _rut_usuario = null;
                        _correo = null;
                        _id_rol = null;
                        //vaciar combobox
                        cbRol.DataSource = null;
                        cbRol.Items.Clear();
                        //cargar como rol
                        cargarComboRol();
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion TxtFiltrarUsuario_KeyUp, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de Cancelar?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                System.GC.Collect();
                //volver al menu de Mantenedor
            }
            else
            {
                //volver al Modal
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceProcess_Validadores.Process_ValidadoresSoapClient auxServiceValidadores = new ServiceProcess_Validadores.Process_ValidadoresSoapClient();
                auxServiceValidadores.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceValidadores.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Cuenta.Process_CuentaSoapClient auxServiceCuenta = new ServiceProcess_Cuenta.Process_CuentaSoapClient();
                auxServiceCuenta.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCuenta.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Cuenta.Cuenta auxCuenta = new ServiceProcess_Cuenta.Cuenta();

                if (_rut_usuario == null || _rut_empresa == null || Convert.ToInt32(cbRol.SelectedIndex) == 0 || txtCorreo.Text.Equals(""))
                {
                    if (_rut_usuario == null)
                    {
                        MessageBox.Show("Debe Seleccionar Usuario antes de Crear Cuenta.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (_rut_empresa == null)
                    {
                        MessageBox.Show("Debe Seleccionar Empresa antes de Crear Cuenta.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (Convert.ToInt32(cbRol.SelectedIndex) == 0)
                    {
                        MessageBox.Show("Debe Seleccionar Rol antes de Crear Cuenta.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (txtCorreo.Text.Equals(""))
                    {
                        MessageBox.Show("Correo no puede estar vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (txtCorreo.Text.Trim().Length < 6 || txtCorreo.Text.Trim().Length > 60)
                    {
                        MessageBox.Show("Correo debe tener mas de 6 caracteres y menos de 60.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (!auxServiceValidadores.correoValidacionService(txtCorreo.Text.ToUpper()))
                        {
                            MessageBox.Show("Formato de correo no es  Valido.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (MessageBox.Show("Confirmar La Creacion de la Cuenta", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {

                                _contrasena = _rut_usuario.Substring(0, 5);                                
                                //Insertar datos via web service
                                auxServiceCuenta.InsertarCuentaSinEntidad_Escritorio(_rut_usuario, _rut_empresa, _contrasena,1, Convert.ToInt32(cbRol.SelectedIndex), txtCorreo.Text.Trim().ToUpper());
                                //Metodo Carga de GridView
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                //se devuelve al Cuadro de datos
                            }
                        }
                    }
;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion BtnGuardar_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

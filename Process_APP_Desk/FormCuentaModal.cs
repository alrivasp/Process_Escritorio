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
    public partial class FormCuentaModal : Form
    {
        public static string _rut_usuario;
        public static string _rut_empresa;
        public static string _contrasena;
        public static string _estado;
        public static string _id_rol;
        public static string _correo;
        //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
        public static int _guardar = 0;
        public FormCuentaModal()
        {
            InitializeComponent();
        }

        public FormCuentaModal(string Titulo, string accion, string rut_usuario, string rut_empresa, string contrasena, string estado, string id_rol, string correo)
        {
            InitializeComponent();
            try
            {
                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Usuario.Usuario auxUsuario = new ServiceProcess_Usuario.Usuario();

                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();

                auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(rut_empresa);
                auxUsuario = auxServiceUsuario.TraerUsuarioConEntidad_Escritorio(rut_usuario);

                if (accion.Equals("1"))// modificar
                {
                    lblTitulo.Text = Titulo;
                    //bloquear textbox
                    txtCuenta.Enabled = false;
                    txtUsuario.Enabled = false;
                    txtEmpresa.Enabled = false;
                    txtEstado.Enabled = false;
                    //pasar datos  a textbox
                    txtCuenta.Text = rut_usuario;
                    txtUsuario.Text = auxUsuario.Primer_nombre + " " + auxUsuario.Primer_apellido;
                    txtEmpresa.Text = auxEmpresa.Nombre;
                    if (estado.Equals("ACTIVADO"))
                    {
                        txtEstado.Text = "ACTIVADO";
                        _estado = "1";
                    }
                    else
                    {
                        txtEstado.Text = "DASACTIVADO";
                        _estado = "0";
                    }
                    txtCorreo.Text = correo;
                    cargarComboRol();
                    cbRol.SelectedValue = id_rol;
                    btnCancelar.Visible = true;
                    btnGuardar.Visible = true;
                    btnVolver.Visible = false;

                    _rut_usuario = rut_usuario;
                    _rut_empresa = rut_empresa;
                    _contrasena = contrasena;                    
                    _id_rol = id_rol;
                    _correo = correo;

                }
                else
                {

                    lblTitulo.Text = Titulo;
                    //bloquear textbox
                    txtCuenta.Enabled = false;
                    txtUsuario.Enabled = false;
                    txtEmpresa.Enabled = false;
                    txtEstado.Enabled = false;
                    txtCorreo.Enabled = false;
                    //pasar datos  a textbox
                    txtCuenta.Text = rut_usuario;
                    txtUsuario.Text = auxUsuario.Primer_nombre + " " + auxUsuario.Primer_apellido;
                    txtEmpresa.Text = auxEmpresa.Nombre;
                    if (estado.Equals("ACTIVADO"))
                    {
                        txtEstado.Text = "ACTIVADO";
                        _estado = "1";
                    }
                    else
                    {
                        txtEstado.Text = "DASACTIVADO";
                        _estado = "0";
                    }
                    txtCorreo.Text = correo;
                    cargarComboRol();
                    cbRol.SelectedValue = Convert.ToInt32(id_rol);
                    cbRol.Enabled = false;
                    btnCancelar.Visible = false;
                    btnGuardar.Visible = false;
                    btnVolver.Visible = true;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion Modal Cuenta, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if (Convert.ToInt32(cbRol.SelectedIndex) == 0 || txtCorreo.Text.Equals(""))
                {
                    
                    if (Convert.ToInt32(cbRol.SelectedIndex) == 0)
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
                            if (MessageBox.Show("Confirmar La Modificacion de la Cuenta", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //Insertar datos via web service
                                auxServiceCuenta.ActualizarCuentaSinEntidad_Escritorio(_rut_usuario, _rut_empresa, _contrasena,  Convert.ToInt32(_estado), Convert.ToInt32(cbRol.SelectedIndex), txtCorreo.Text.Trim().ToUpper());
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
    

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Volver?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                //se devuelve al Cuadro de datos
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
    }
}

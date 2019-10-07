using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Process_APP_Desk
{
    public partial class PantallaLogin : Form
    {
        public PantallaLogin()
        {
            InitializeComponent();

        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void TxtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
            }
        }

        private void TxtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void TxtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.Black;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void TxtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void PbCerrar_Click(object sender, EventArgs e)
        {
            //confirmacion Salir del Sistema
            if (MessageBox.Show("¿Esta seguro de Salir del Sistema Process?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                //se devuelve al Login
            }
        }

        private void PbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PantallaLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void PanelLeft_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                //Instancia de web service con credenciales NT
                ServiceProcess_Cuenta.Process_CuentaSoapClient auxServiceCuenta = new ServiceProcess_Cuenta.Process_CuentaSoapClient();
                auxServiceCuenta.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCuenta.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Rol.Process_RolSoapClient auxServiceRol = new ServiceProcess_Rol.Process_RolSoapClient();
                auxServiceRol.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceRol.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Cuenta.Cuenta auxCuenta = new ServiceProcess_Cuenta.Cuenta();

                auxCuenta = auxServiceCuenta.TraerCuentaConEntidad_Escritorio(txtUser.Text.ToUpper());

                if (txtUser.Text != "USUARIO")
                {
                    if (txtPass.Text != "CONTRASEÑA")
                    {
                        if (txtUser.Text.Trim().Length < 12)
                        {
                            if (txtPass.Text.Trim().Length < 20)
                            {
                                if (auxCuenta.Rut_usuario != null)
                                {
                                    if (auxCuenta.Estado != 0)
                                    {
                                        if (auxCuenta.Id_rol == 1)
                                        {
                                            if (auxCuenta.Rut_usuario.Equals(txtUser.Text.ToUpper()) && auxCuenta.Contrasena.Equals(txtPass.Text))
                                            {
                                                ServiceProcess_Usuario.Usuario auxUsuario = new ServiceProcess_Usuario.Usuario();
                                                ServiceProcess_Rol.Rol auxRol = new ServiceProcess_Rol.Rol();

                                                auxUsuario = auxServiceUsuario.TraerUsuarioConEntidad_Escritorio(auxCuenta.Rut_usuario);
                                                auxRol = auxServiceRol.TraerRolConEntidad_Escritorio(auxCuenta.Id_rol);

                                                string nombreCorto = auxUsuario.Primer_nombre + " " + auxUsuario.Primer_apellido;
                                                string nombres = auxUsuario.Primer_nombre + " " + auxUsuario.Segundo_nombre;
                                                string apellidos = auxUsuario.Primer_apellido + " " + auxUsuario.Segundo_apellido;
                                                string pefil = auxRol.Nombre;

                                                this.Hide();
                                                PantallaCarga mainPantallaCarga = new PantallaCarga(nombreCorto);
                                                mainPantallaCarga.ShowDialog();
                                                PantallaMenuPrincipal mainPantallaMenuPrincipal = new PantallaMenuPrincipal(nombres, apellidos, pefil);
                                                mainPantallaMenuPrincipal.Show();


                                            }
                                            else
                                            {
                                                msgError("Usuario o clave incorrecto, por favor intente Nuevamente");
                                                txtPass.Clear();
                                                txtUser.Focus();
                                            }

                                        }
                                        else
                                        {
                                            msgError("Cuenta No tiene permisos para acceder a este Modulo");
                                            txtPass.Clear();
                                            txtUser.Focus();
                                        }
                                    }
                                    else
                                    {
                                        msgError("Cuenta Deshabilitada, contacte al Administrador");
                                        txtPass.Clear();
                                        txtUser.Focus();
                                    }
                                }
                                else
                                {
                                    msgError("Cuenta no Existe, favor usar formato 11111111-K");
                                    txtUser.Clear();
                                    txtUser.Focus();
                                }
                            }
                            else
                            {
                                msgError("La Password no puede tener menos de 5 Caracteres y mas de 20");
                                txtPass.Clear();
                                txtUser.Focus();
                            }
                        }
                        else
                        {
                            msgError("El largo de caracteres del usuario no puede ser mayor a 12");
                            txtUser.Clear();
                            txtUser.Focus();
                        }

                    }
                    else msgError("Por favor ingrese su Contraseña");
                }
                else
                    msgError("Por favor ingrese su Nombre de Usuario");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Web Service Process Fuera de Linea, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Clear();
                txtUser.Focus();
            }

        }

        private void msgError(string msg)
        {
            lblErrorMenssage.Text = "    " + msg;
            lblErrorMenssage.Visible = true;
        }
    }
}

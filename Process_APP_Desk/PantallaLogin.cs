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
            if (txtUser.Text=="USUARIO")
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
            Application.Exit();
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
            if (txtUser.Text != "USUARIO")
            {
                if (txtPass.Text != "CONTRASEÑA")
                {
                    //Consultar usuario y clave y resultado validar
                    String user = "admin";
                    int pass = 12345;
                    
                    if (user.Equals(txtUser.Text) && pass == Convert.ToInt32(txtPass.Text))
                    {
                        this.Hide();
                        PantallaCarga mainPantallaCarga = new PantallaCarga();
                        mainPantallaCarga.ShowDialog();
                        PantallaMenuPrincipal mainPantallaMenuPrincipal = new PantallaMenuPrincipal();                                             
                        mainPantallaMenuPrincipal.Show();
                        
                       
                    }
                    else
                    {
                        msgError("Usuario o clave incorrecto, por favor intente Nuevamente");
                        txtPass.Clear();
                        txtUser.Focus();
                    }
                }
                else msgError("Por favor ingrese su Contraseña");
            }
            else
            msgError("Por favor ingrese su Nombre de Usuario");
            
        }

        private void msgError(string msg)
        {
            lblErrorMenssage.Text = "    " + msg;
            lblErrorMenssage.Visible = true;
        }
    }
}

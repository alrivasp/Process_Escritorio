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
    public partial class PantallaMenuPrincipal : Form
    {
        //Variables globales
        string nombres;
        string apellidos;
        string perfil;
        public PantallaMenuPrincipal()
        {
            InitializeComponent();
            //Estas lineas eliminan los parpadeos del formulario o controles en la interfaz grafica (Pero no en un 100%)
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            lblTituloMenu.Text = "";
        }

        public PantallaMenuPrincipal(string _nombres, string _apellidos, string _perfil)
        {
            InitializeComponent();
            nombres = _nombres;
            apellidos = _apellidos;
            perfil = _perfil;
            lblApellidos.Text = apellidos;
            lblNombres.Text = nombres;
            lblPerfil.Text = perfil;
            //Estas lineas eliminan los parpadeos del formulario o controles en la interfaz grafica (Pero no en un 100%)
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            lblTituloMenu.Text = "";
        }

        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
       
       
        private void BtnSlide_Click(object sender, EventArgs e)
        {
            if (menuVertical.Width == 250)
            {
                menuVertical.Width = 70;
            }
            else
                menuVertical.Width = 250;

        }

        
        private void IconCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de Salir del Sistema Process?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                //continua en el programa
            }
        }

        int LX, LY;
        private void IconMaximizar_Click(object sender, EventArgs e)
        {
            LX = this.Location.X;
            LY = this.Location.Y;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            //this.WindowState = FormWindowState.Maximized;
            iconMaximizar.Visible = false;
            iconRestaurar.Visible = true;
        }

        
        private void IconRestaurar_Click(object sender, EventArgs e)
        {            
            this.Size = new Size(1300, 650);
            this.Location = new Point(LX, LY);
            //this.WindowState = FormWindowState.Normal;
            iconRestaurar.Visible = false;
            iconMaximizar.Visible = true;
        }

        private void IconMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de Salir del Sistema Process?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                //volver al menu
            }
        }

        private void TmFechaHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString().ToUpper();
        }

        private void AbrirFormEnPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void BtnEmpresas_Click(object sender, EventArgs e)
        {
            lblTituloMenu.Text = "MANTENCION EMPRESA";
            FormEmpresa frm = new FormEmpresa();
            frm.FormClosed += new FormClosedEventHandler(mostrarLogoAlCerrarPantalla);
            AbrirFormEnPanel(frm);
        }

        private void PantallaMenuPrincipal_Load(object sender, EventArgs e)
        {
            mostrarLogo();
        }

        private void PbNombreLogo_Click(object sender, EventArgs e)
        {
            mostrarLogo();
        }

        private void PbLogo_Click(object sender, EventArgs e)
        {
            mostrarLogo();
        }

        private void mostrarLogoAlCerrarPantalla(object sender, FormClosedEventArgs e)
        {
            mostrarLogo();
        }

        private void BtnUnidad_Click(object sender, EventArgs e)
        {
            FormUnidad frm = new FormUnidad();
            frm.FormClosed += new FormClosedEventHandler(mostrarLogoAlCerrarPantalla);
            AbrirFormEnPanel(frm);
        }

        private void BtnUsuario_Click(object sender, EventArgs e)
        {
            FormUsuario frm = new FormUsuario();
            frm.FormClosed += new FormClosedEventHandler(mostrarLogoAlCerrarPantalla);
            AbrirFormEnPanel(frm);
        }

        private void BtnPerfil_Click(object sender, EventArgs e)
        {
            FormRol frm = new FormRol();
            frm.FormClosed += new FormClosedEventHandler(mostrarLogoAlCerrarPantalla);
            AbrirFormEnPanel(frm);
        }

        private void BtnCuenta_Click(object sender, EventArgs e)
        {
            FormCuenta frm = new FormCuenta();
            frm.FormClosed += new FormClosedEventHandler(mostrarLogoAlCerrarPantalla);
            AbrirFormEnPanel(frm);
        }

        private void BtnCargo_Click(object sender, EventArgs e)
        {
            FormCargo frm = new FormCargo();
            frm.FormClosed += new FormClosedEventHandler(mostrarLogoAlCerrarPantalla);
            AbrirFormEnPanel(frm);
        }

        private void mostrarLogo()
        {
            lblTituloMenu.Text = "";
            AbrirFormEnPanel(new PantallaLogo());
        }
    }
}

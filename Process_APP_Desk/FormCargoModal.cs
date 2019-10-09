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
    public partial class FormCargoModal : Form
    {
        //Variable para interaccion de botones (1 = modificar) - (2 = nuevo) - (3 = Ver)
        public static int _guardar = 0;
        int id_cargo = 0;
        string rut_empresa = string.Empty;

        public FormCargoModal()
        {
            InitializeComponent();
        }

        public FormCargoModal(string _tituloModal, int _accion, int _id_cargo, string _nombre, string _descripcion, string _rut_empresa)
        {
            InitializeComponent();
            try
            {
                //Modalidad de Modal segun Accion Padre 1 = modificar / 2 = nuevo / 3 = Ver
                if (_accion == 1)
                {
                    //Cambiar Titulo de Modal
                    lblTitulo.Text = _tituloModal;
                    //Instancia de Web service con credenciales NT
                    ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                    auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                    auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                    ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                    //Se carga variable de id unidad
                    id_cargo = _id_cargo;
                    //Capturar rut empresa
                    rut_empresa = _rut_empresa;
                    //Se habilita Boton
                    btnGuardar.Visible = true;
                    btnCancelar.Visible = true;
                    // desactivar boton volver
                    btnVolver.Visible = false;
                    //se inactiva txtbox de rut de empresa
                    txtEmpresa.ReadOnly = true;
                    txtEmpresa.Enabled = false;
                    //desbloquear cajas de texto                 
                    txtNombre.ReadOnly = false;
                    txtDescripcion.ReadOnly = false;
                    //se pasan datos a cajas de texto desde formulario principal
                    txtNombre.Text = _nombre;
                    txtDescripcion.Text = _descripcion;
                    auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(_rut_empresa);
                    txtEmpresa.Text = auxEmpresa.Nombre;

                    //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar) - (3 = Ver)
                    _guardar = 1;
                }
                else
                {
                    //Cambiar Titulo de Modal
                    lblTitulo.Text = _tituloModal;
                    //Instancia de Web service con credenciales NT
                    ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                    auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                    auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                    ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                    //Se desactiva Botones
                    btnGuardar.Visible = false;
                    btnCancelar.Visible = false;
                    // activar boton volver
                    btnVolver.Visible = true;
                    //se pasan datos a cajas de texto de cuadro de datos
                    txtNombre.Text = _nombre;
                    txtDescripcion.Text = _descripcion;                   
                    auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(_rut_empresa);
                    txtEmpresa.Text = auxEmpresa.Nombre;
                    //se inactiva txtbox de nombre unidad
                    txtNombre.ReadOnly = true;
                    txtNombre.Enabled = false;
                    //se inactiva txtbox de descripcion
                    txtDescripcion.ReadOnly = true;
                    txtDescripcion.Enabled = false;
                    //se inactiva txtbox de empresa
                    txtEmpresa.ReadOnly = true;
                    txtEmpresa.Enabled = false;
                    //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar) - (3 = Ver)
                    _guardar = 3;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion Modal Unidad, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //Instancia de Web service con credenciales NT
                ServiceProcess_Cargo.Process_CargoSoapClient auxServiceCargo = new ServiceProcess_Cargo.Process_CargoSoapClient();
                auxServiceCargo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCargo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;               
                ServiceProcess_Cargo.Cargo auxCargo = new ServiceProcess_Cargo.Cargo();

                //Validacion espacion en blanco y combobox vacios
                if (txtNombre.Text.Equals("") || txtDescripcion.Text.Equals("") || txtEmpresa.Text.Equals(""))
                {
                    if (txtNombre.Text.Equals(""))
                    {
                        MessageBox.Show("El Nombre del Cargo no Puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (txtDescripcion.Text.Equals(""))
                    {
                        MessageBox.Show("La Descripcion del Cargo no Puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (txtEmpresa.Text.Equals(""))
                    {
                        MessageBox.Show("Debe seleccionar una Empresa a la cual pertenesca el Cargo, en la Lista de la Izquierda.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //Validacion de longitud de caracteres
                    if (txtNombre.Text.Trim().Length < 3 || txtNombre.Text.Trim().Length > 99
                        || txtDescripcion.Text.Trim().Length < 10 || txtDescripcion.Text.Trim().Length > 250)
                    {
                        if (txtNombre.Text.Trim().Length < 3 || txtNombre.Text.Trim().Length > 99)
                        {
                            MessageBox.Show("El Nombre del Cargo debe tener Minimo 3 caracteres y Maximo 99 .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (txtDescripcion.Text.Trim().Length < 10 || txtDescripcion.Text.Trim().Length > 250)
                        {
                            MessageBox.Show("La Descripcion del Cargo debe tener Minimo 10 caracteres y Maximo 250 .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        auxCargo = auxServiceCargo.TraerCargoPorNombrePorEmpresaConEntidad_Escritorio(txtNombre.Text.ToUpper(), rut_empresa);
                        //Validar si Nombre cargo ya existe en la empresa
                        if (auxCargo.Nombre == null || auxCargo.Nombre.ToUpper().Equals(txtNombre.Text.ToUpper()))
                        {

                            if (MessageBox.Show("Confirmar la modificacion del Cargo", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //Insertar datos via web service
                                auxServiceCargo.ActualizarCargoSinEntidad_Escritorio(id_cargo, txtNombre.Text.ToUpper(), txtDescripcion.Text.ToUpper(), rut_empresa);
                                //Metodo Carga de GridView
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                //se devuelve al Cuadro de datos
                            }
                        }
                        else
                        {
                            MessageBox.Show("Este Nombre de Cargo ya Existe en la Empresa Seleccionada", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion BtnGuardar_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

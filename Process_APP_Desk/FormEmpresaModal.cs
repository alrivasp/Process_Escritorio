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
    public partial class FormEmpresaModal : Form
    {
        //Variable para interaccion de botones (1 = modificar) - (2 = nuevo) - (3 = Ver)
        public static int _guardar = 0;
        public FormEmpresaModal()
        {
            InitializeComponent();
        }

        public FormEmpresaModal(string _tituloModal, int _accion, string _rut_empresa, string _nombre, string _giro, string _direccion, string _estado, string _id_comuna)
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
                    ServiceProcess_Provincia.Process_ProvinciaSoapClient auxServiceProvincia = new ServiceProcess_Provincia.Process_ProvinciaSoapClient();
                    auxServiceProvincia.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                    auxServiceProvincia.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                    ServiceProcess_Comuna.Process_ComunaSoapClient auxServiceComuna = new ServiceProcess_Comuna.Process_ComunaSoapClient();
                    auxServiceComuna.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                    auxServiceComuna.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                    //Se cargan las clases de comuna provincia y region mediante web service
                    ServiceProcess_Comuna.Comuna auxComuna = new ServiceProcess_Comuna.Comuna();
                    ServiceProcess_Provincia.Provincia auxProvincia = new ServiceProcess_Provincia.Provincia();
                    ServiceProcess_Region.Region auxRegion = new ServiceProcess_Region.Region();
                    //Se trae informacion de comuna y provincia de la empresa selecciionada
                    auxComuna = auxServiceComuna.TraerComunaConEntidad_Escritorio(Convert.ToInt32(_id_comuna));
                    auxProvincia = auxServiceProvincia.TraerProvinciaConEntidad_Escritorio(auxComuna.Id_provincia);
                    //Se almacena en variables
                    int _id_provincia = auxProvincia.Id_provincia;
                    int _region = auxProvincia.Id_region;
                    //Se habilita Boton
                    btnGuardar.Visible = true;
                    btnCancelar.Visible = true;
                    // desactivar boton acepatar
                    btnVolver.Visible = false;
                    //Se carga combos de estado y region
                    cargarComboRegion();
                    //bloquear combobox
                    cbRegion.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbComuna.DropDownStyle = ComboBoxStyle.DropDownList;
                    //se inactiva txtbox de rut de empresa
                    txtRutEmpresa.ReadOnly = true;
                    txtRutEmpresa.Enabled = false;
                    //se inactiva txtbox de ESTADO de empresa
                    txtEstado.ReadOnly = true;
                    txtEstado.Enabled = false;
                    //desbloquear cajas de texto                 
                    txtNombreEmpresa.ReadOnly = false;
                    txtGiro.ReadOnly = false;
                    txtDireccion.ReadOnly = false;
                    //se pasan datos a cajas de texto de cuadro de datos
                    txtRutEmpresa.Text = _rut_empresa;
                    txtNombreEmpresa.Text = _nombre;
                    txtGiro.Text = _giro;
                    txtDireccion.Text = _direccion;
                    cbRegion.SelectedIndex = _region;
                    cbProvincia.SelectedValue = _id_provincia;
                    cbComuna.SelectedValue = _id_comuna;
                    if (_estado.Equals("1"))
                    {
                        txtEstado.Text = "ACTIVO";
                    }
                    else
                    {
                        txtEstado.Text = "DASACTIVADO";
                    }

                    //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar) - (3 = Ver)
                    _guardar = 1;
                }
                else if (_accion == 2)
                {
                    //Cambiar Titulo de Modal
                    lblTitulo.Text = _tituloModal;
                    //Se habilita Boton
                    btnGuardar.Visible = true;
                    btnCancelar.Visible = true;
                    // desactivar boton acepatar
                    btnVolver.Visible = false;
                    //desbloquear cajas de texto
                    txtRutEmpresa.ReadOnly = false;
                    txtNombreEmpresa.ReadOnly = false;
                    txtGiro.ReadOnly = false;
                    txtDireccion.ReadOnly = false;
                    //Cargar comobox de region
                    cargarComboRegion();
                    //vaciar textbox
                    txtRutEmpresa.Text = string.Empty;
                    txtNombreEmpresa.Text = string.Empty;
                    txtGiro.Text = string.Empty;
                    txtDireccion.Text = string.Empty;
                    //bloquear combobox
                    cbRegion.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbComuna.DropDownStyle = ComboBoxStyle.DropDownList;
                    //vaciar combobox
                    cbProvincia.DataSource = null;
                    cbProvincia.Items.Clear();
                    cbComuna.DataSource = null;
                    cbComuna.Items.Clear();
                    //Dasactivar estado
                    txtEstado.Visible = false;
                    lblEstado.Visible = false;
                    //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = Nuevo) - (3 = Ver)
                    _guardar = 2;
                }
                else
                {
                    //Cambiar Titulo de Modal
                    lblTitulo.Text = _tituloModal;
                    //Instancia de Web service con credenciales NT
                    ServiceProcess_Provincia.Process_ProvinciaSoapClient auxServiceProvincia = new ServiceProcess_Provincia.Process_ProvinciaSoapClient();
                    auxServiceProvincia.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                    auxServiceProvincia.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                    ServiceProcess_Comuna.Process_ComunaSoapClient auxServiceComuna = new ServiceProcess_Comuna.Process_ComunaSoapClient();
                    auxServiceComuna.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                    auxServiceComuna.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                    //Se cargan las clases de comuna provincia y region mediante web service
                    ServiceProcess_Comuna.Comuna auxComuna = new ServiceProcess_Comuna.Comuna();
                    ServiceProcess_Provincia.Provincia auxProvincia = new ServiceProcess_Provincia.Provincia();
                    ServiceProcess_Region.Region auxRegion = new ServiceProcess_Region.Region();
                    //Se trae informacion de comuna y provincia de la empresa selecciionada
                    auxComuna = auxServiceComuna.TraerComunaConEntidad_Escritorio(Convert.ToInt32(_id_comuna));
                    auxProvincia = auxServiceProvincia.TraerProvinciaConEntidad_Escritorio(auxComuna.Id_provincia);
                    //Se almacena en variables
                    int _id_provincia = auxProvincia.Id_provincia;
                    int _region = auxProvincia.Id_region;
                    //Se habilita Boton
                    btnGuardar.Visible = false;
                    btnCancelar.Visible = false;
                    // desactivar boton acepatar
                    btnVolver.Visible = true;
                    //Se carga combos de estado y region
                    cargarComboRegion();
                    //bloquear combobox
                    cbRegion.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbComuna.DropDownStyle = ComboBoxStyle.DropDownList;                        
                    //se pasan datos a cajas de texto de cuadro de datos
                    txtRutEmpresa.Text = _rut_empresa;
                    txtNombreEmpresa.Text = _nombre;
                    txtGiro.Text = _giro;
                    txtDireccion.Text = _direccion;
                    cbRegion.SelectedIndex = _region;
                    cbProvincia.SelectedValue = _id_provincia;
                    cbComuna.SelectedValue = _id_comuna;
                    if (_estado.Equals("1"))
                    {
                        txtEstado.Text = "ACTIVO";
                    }
                    else
                    {
                        txtEstado.Text = "DASACTIVADO";
                    }

                    //se inactiva txtbox de rut de empresa
                    txtRutEmpresa.ReadOnly = true;
                    txtRutEmpresa.Enabled = false;
                    //se inactiva txtbox de nombre
                    txtNombreEmpresa.ReadOnly = true;
                    txtNombreEmpresa.Enabled = false;
                    //se inactiva txtbox de giro
                    txtGiro.ReadOnly = true;
                    txtGiro.Enabled = false;
                    //se inactiva txtbox de direccion
                    txtDireccion.ReadOnly = true;
                    txtDireccion.Enabled = false;
                    //se inactiva combo de region                    
                    cbRegion.Enabled = false;
                    //se inactiva combo de provincia                    
                    cbProvincia.Enabled = false;
                    //se inactiva combo de comuna                    
                    cbComuna.Enabled = false;
                    //se inactiva txtbox de ESTADO de empresa
                    txtEstado.ReadOnly = true;
                    txtEstado.Enabled = false;                    
                    //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar) - (3 = Ver)
                    _guardar = 3;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion Modal Empresa, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de Cancelar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                System.GC.Collect();
                //volver al menu de Mantenedor
            }
            else
            {
                // volver al Modal
            }

        }

        //Metodo Carga ComboBox Comuna
        public void cargarComboComuna(int _id_provincia)
        {
            try
            {
                ServiceProcess_Comuna.Process_ComunaSoapClient auxServiceComuna = new ServiceProcess_Comuna.Process_ComunaSoapClient();
                auxServiceComuna.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceComuna.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ds = auxServiceComuna.TraerTodasComunasPorProvincia_Escritorio(_id_provincia);
                dt = ds.Tables[0];
                DataRow fila = dt.NewRow();
                fila["ID_COMUNA"] = 0;
                fila["NOMBRE"] = "SELECCIONE COMUNA";
                fila["ID_PROVINCIA"] = 1;
                dt.Rows.InsertAt(fila, 0);
                cbComuna.DropDownStyle = ComboBoxStyle.DropDownList;
                cbComuna.DataSource = dt;
                cbComuna.DisplayMember = "NOMBRE";
                cbComuna.ValueMember = "ID_COMUNA";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo Carga Combo Comuna, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Metodo Carga ComboBox Provincia
        public void cargarComboProvincia(int _id_region)
        {
            try
            {
                ServiceProcess_Provincia.Process_ProvinciaSoapClient auxServiceProvincia = new ServiceProcess_Provincia.Process_ProvinciaSoapClient();
                auxServiceProvincia.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceProvincia.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ds = auxServiceProvincia.TraerTodasProvinciasPorRegion_Escritorio(_id_region);
                dt = ds.Tables[0];
                DataRow fila = dt.NewRow();
                fila["ID_PROVINCIA"] = 0;
                fila["NOMBRE"] = "SELECCIONE PROVINCIA";
                fila["ID_REGION"] = 1;
                dt.Rows.InsertAt(fila, 0);
                cbProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
                cbProvincia.DataSource = dt;
                cbProvincia.DisplayMember = "NOMBRE";
                cbProvincia.ValueMember = "ID_PROVINCIA";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo Carga Combo Provincia, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Metodo Carga ComboBox Region
        private void cargarComboRegion()
        {
            try
            {
                ServiceProcess_Region.Process_RegionSoapClient auxServiceRegion = new ServiceProcess_Region.Process_RegionSoapClient();
                auxServiceRegion.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceRegion.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ds = auxServiceRegion.TraerTodasRegiones_Escritorio();
                dt = ds.Tables[0];
                DataRow fila = dt.NewRow();
                fila["ID_REGION"] = 0;
                fila["NOMBRE"] = "SELECCIONE REGION";
                fila["NUMERO"] = " ";
                dt.Rows.InsertAt(fila, 0);
                cbRegion.DropDownStyle = ComboBoxStyle.DropDownList;
                cbRegion.DataSource = dt;
                cbRegion.DisplayMember = "NOMBRE";
                cbRegion.ValueMember = "ID_REGION";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo Carga Combo Region, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbRegion.SelectedIndex) > 0)
                {
                    int id_region = Convert.ToInt32(cbRegion.SelectedIndex);
                    cargarComboProvincia(id_region);
                    cbComuna.DataSource = null;
                    cbComuna.Items.Clear();
                    cbComuna.Enabled = false;
                    cbProvincia.Enabled = true;
                }
                else
                {
                    cbProvincia.DataSource = null;
                    cbProvincia.Items.Clear();
                    cbComuna.DataSource = null;
                    cbComuna.Items.Clear();
                    cbComuna.Enabled = false;
                    cbProvincia.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion CbRegion_SelectedIndexChanged, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbProvincia.SelectedIndex) > 0)
                {
                    int id_provincia = Convert.ToInt32(cbProvincia.SelectedValue);
                    cargarComboComuna(id_provincia);
                    cbComuna.Enabled = true;
                }
                else
                {
                    cbComuna.DataSource = null;
                    cbComuna.Items.Clear();
                    cbComuna.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion CbProvincia_SelectedIndexChanged, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Instancia de Web service con credenciales NT
                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Validadores.Process_ValidadoresSoapClient auxServiceValidadores = new ServiceProcess_Validadores.Process_ValidadoresSoapClient();
                auxServiceValidadores.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceValidadores.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                if (_guardar == 1)//Modificar empresa
                {
                    //Validacion espacion en blanco y combobox vacios
                    if (txtRutEmpresa.Text.Equals("") || txtNombreEmpresa.Text.Equals("") || txtGiro.Text.Equals("")
                        || txtDireccion.Text.Equals("") || txtEstado.Text.Equals("") || Convert.ToInt32(cbRegion.SelectedIndex) == 0
                        || cbProvincia.SelectedValue == null || cbComuna.SelectedValue == null)
                    {
                        if (txtRutEmpresa.Text.Equals(""))
                        {
                            MessageBox.Show("El Rut de la Empresa no Puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (txtNombreEmpresa.Text.Equals(""))
                        {
                            MessageBox.Show("El Nombre de la Empresa no Puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (txtGiro.Text.Equals(""))
                        {
                            MessageBox.Show("El Giro de la Empresa no Puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (txtEstado.Text.Equals(""))
                        {
                            MessageBox.Show("El Estado de la Empresa no Puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (Convert.ToInt32(cbRegion.SelectedIndex) == 0)
                        {
                            MessageBox.Show("Debe seleccionar una Region.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (cbProvincia.SelectedValue == null)
                        {
                            MessageBox.Show("Debe seleccionar una Provincia.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (cbComuna.SelectedValue == null)
                        {
                            MessageBox.Show("Debe seleccionar una Comuna.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        //Validacion de longitud de caracteres
                        if (txtRutEmpresa.Text.Trim().Length < 9 || txtRutEmpresa.Text.Trim().Length > 12
                            || txtNombreEmpresa.Text.Trim().Length < 4 || txtNombreEmpresa.Text.Trim().Length > 50
                            || txtGiro.Text.Trim().Length < 4 || txtGiro.Text.Trim().Length > 50
                            || txtDireccion.Text.Trim().Length < 4 || txtDireccion.Text.Trim().Length > 50)
                        {
                            if (txtRutEmpresa.Text.Trim().Length < 9 || txtRutEmpresa.Text.Trim().Length > 12)
                            {
                                MessageBox.Show("El Rut de la empresa debe tener Minimo 9 caracteres y Maximo 12 .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (txtNombreEmpresa.Text.Trim().Length < 4 || txtNombreEmpresa.Text.Trim().Length > 50)
                            {
                                MessageBox.Show("El Nombre de la empresa debe tener Minimo 4 caracteres y Maximo 50 .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (txtGiro.Text.Trim().Length < 4 || txtGiro.Text.Trim().Length > 50)
                            {
                                MessageBox.Show("El Giro de la empresa debe tener Minimo 4 caracteres y Maximo 50 .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (txtDireccion.Text.Trim().Length < 4 || txtDireccion.Text.Trim().Length > 50)
                            {
                                MessageBox.Show("La Direccion de la empresa debe tener Minimo 4 caracteres y Maximo 50 .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else
                        {
                            //confirmacion de crear nueva empresa
                            if (MessageBox.Show("Confirmar La Modificacion de la Empresa Seleccionada", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //ESTADO
                                int _estado;
                                if (txtEstado.Equals("ACTIVO"))
                                {
                                    _estado = 1;
                                }
                                else
                                {
                                    _estado = 0;
                                }
                                //Insertar datos via web service
                                auxServiceEmpresa.ActualizarEmpresaSinEntidad_Escritorio(txtRutEmpresa.Text.ToUpper(), txtNombreEmpresa.Text.ToUpper(), txtGiro.Text.ToUpper(), txtDireccion.Text.ToUpper(), _estado, Convert.ToInt32(cbComuna.SelectedValue));
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
                }
                else//Nueva empresa
                {
                    //Validacion espacion en blanco y combobox vacios
                    if (txtRutEmpresa.Text.Equals("") || txtNombreEmpresa.Text.Equals("") || txtGiro.Text.Equals("")
                        || txtDireccion.Text.Equals("") || Convert.ToInt32(cbRegion.SelectedIndex) == 0
                        || cbProvincia.SelectedValue == null || cbComuna.SelectedValue == null)
                    {
                        if (txtRutEmpresa.Text.Equals(""))
                        {
                            MessageBox.Show("El Rut de la Empresa no Puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (txtNombreEmpresa.Text.Equals(""))
                        {
                            MessageBox.Show("El Nombre de la Empresa no Puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (txtGiro.Text.Equals(""))
                        {
                            MessageBox.Show("El Giro de la Empresa no Puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (Convert.ToInt32(cbRegion.SelectedIndex) == 0)
                        {
                            MessageBox.Show("Debe seleccionar una Region.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (cbProvincia.SelectedValue == null)
                        {
                            MessageBox.Show("Debe seleccionar una Provincia.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (cbComuna.SelectedValue == null)
                        {
                            MessageBox.Show("Debe seleccionar una Comuna.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        //Validacion de longitud de caracteres
                        if (txtRutEmpresa.Text.Trim().Length < 9 || txtRutEmpresa.Text.Trim().Length > 12
                            || txtNombreEmpresa.Text.Trim().Length < 4 || txtNombreEmpresa.Text.Trim().Length > 50
                            || txtGiro.Text.Trim().Length < 4 || txtGiro.Text.Trim().Length > 50
                            || txtDireccion.Text.Trim().Length < 4 || txtDireccion.Text.Trim().Length > 50)
                        {
                            if (txtRutEmpresa.Text.Trim().Length < 9 || txtRutEmpresa.Text.Trim().Length > 12)
                            {
                                MessageBox.Show("El Rut de la empresa debe tener Minimo 9 caracteres y Maximo 12 .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (txtNombreEmpresa.Text.Trim().Length < 4 || txtNombreEmpresa.Text.Trim().Length > 50)
                            {
                                MessageBox.Show("El Nombre de la empresa debe tener Minimo 4 caracteres y Maximo 50 .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (txtGiro.Text.Trim().Length < 4 || txtGiro.Text.Trim().Length > 50)
                            {
                                MessageBox.Show("El Giro de la empresa debe tener Minimo 4 caracteres y Maximo 50 .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (txtDireccion.Text.Trim().Length < 4 || txtDireccion.Text.Trim().Length > 50)
                            {
                                MessageBox.Show("La Direccion de la empresa debe tener Minimo 4 caracteres y Maximo 50 .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else
                        {
                            //Validacion de rut
                            if (!auxServiceValidadores.rutValidacionService(txtRutEmpresa.Text.ToUpper()))
                            {
                                MessageBox.Show("El RUT de la Empresa ingresado no es Valido.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                //carga clase empresa
                                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                                auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(txtRutEmpresa.Text);
                                //Validar si empresa nueva ya esta registrada en sistema
                                if (auxEmpresa.Rut_empresa == null)
                                {
                                    //confirmacion de crear nueva empresa
                                    if (MessageBox.Show("Confirmar La Creacion de la Empresa.", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //ESTADO
                                        int _estado;
                                        _estado = 1;
                                        //Insertar datos via web service
                                        auxServiceEmpresa.InsertarEmpresaSinEntidad_Escritorio(txtRutEmpresa.Text.ToUpper(), txtNombreEmpresa.Text.ToUpper(), txtGiro.Text.ToUpper(), txtDireccion.Text.ToUpper(), _estado, Convert.ToInt32(cbComuna.SelectedValue));
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
                                    MessageBox.Show("La Empresa que intenta registrar ya esta en el Sistema.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }//fin if principal
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en Metodo de Accion BtnGuardar_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "Mensaje de sistema");

            }//fin try catch
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

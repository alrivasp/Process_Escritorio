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
    public partial class FormUsuarioModal : Form
    {
        //Variables para cargar datos desde el gridview
        public static string _rut_usuario = null;
        public static string _primer_nombre;
        public static string _segundo_nombre;
        public static string _primer_apellido;
        public static string _segundo_apellido;
        public static string _direccion;
        public static string _telefono_fijo;
        public static string _telefono_movil;
        public static string _estado;
        public static string _id_comuna;
        public static string _rut_empresa;
        public static string _id_cargo;
        //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
        public static int _guardar = 0;
        public FormUsuarioModal()
        {
            InitializeComponent();
        }

        public FormUsuarioModal(string tituloModal, int accion, string rut_usuario, string primer_nombre, string segundo_nombre,
                                    string primer_apellido, string segundo_apellido, string direccion, string telefono_fijo, string telefono_movil,
                                    string estado, string id_comuna, string rut_empresa, string id_cargo)
        {
            InitializeComponent();

            try
            {

                //Carga de Web Service
                ServiceProcess_Cargo.Process_CargoSoapClient auxServiceCargo = new ServiceProcess_Cargo.Process_CargoSoapClient();
                auxServiceCargo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCargo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Region.Process_RegionSoapClient auxServiceRegion = new ServiceProcess_Region.Process_RegionSoapClient();
                auxServiceRegion.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceRegion.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Provincia.Process_ProvinciaSoapClient auxServiceProvincia = new ServiceProcess_Provincia.Process_ProvinciaSoapClient();
                auxServiceProvincia.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceProvincia.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Comuna.Process_ComunaSoapClient auxServiceComuna = new ServiceProcess_Comuna.Process_ComunaSoapClient();
                auxServiceComuna.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceComuna.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(rut_empresa);

                _rut_empresa = rut_empresa;
                if (accion == 1)// modificar
                {
                    //Se cargan las clases de comuna provincia y region mediante web service
                    ServiceProcess_Comuna.Comuna auxComuna = new ServiceProcess_Comuna.Comuna();
                    ServiceProcess_Provincia.Provincia auxProvincia = new ServiceProcess_Provincia.Provincia();
                    //Se buscan comuna y provincia
                    auxComuna = auxServiceComuna.TraerComunaConEntidad_Escritorio(Convert.ToInt32(id_comuna));
                    auxProvincia = auxServiceProvincia.TraerProvinciaConEntidad_Escritorio(auxComuna.Id_provincia);
                    //Se almacena en variables
                    int _id_provincia = auxProvincia.Id_provincia;
                    int _region = auxProvincia.Id_region;                    
                    //Cambiar Titulo de Modal
                    lblTitulo.Text = tituloModal;
                    //Se habilita Boton
                    btnGuardar.Visible = true;
                    btnCancelar.Visible = true;
                    btnVolver.Visible = false;
                    //Se carga combos de estado y region                    
                    cargarComboRegion();
                    cargarComboCargo(rut_empresa);
                    //bloquear combobox
                    cbRegion.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbComuna.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbCargo.DropDownStyle = ComboBoxStyle.DropDownList;
                    //se inactiva txtbox de rut de Usuario
                    txtRutUsuario.ReadOnly = true;
                    txtRutUsuario.Enabled = false;
                    //desbloquear cajas de texto                 
                    txtPrimerNombre.ReadOnly = false;
                    txtSegundoNombre.ReadOnly = false;
                    txtPrimerApellido.ReadOnly = false;
                    txtSegundoApellido.ReadOnly = false;
                    txtDireccion.ReadOnly = false;
                    txtTelefonoFijo.ReadOnly = false;
                    txtTelefonoMovil.ReadOnly = false;
                    //se pasan datos a cajas de texto de cuadro de datos
                    txtRutUsuario.Text = rut_usuario;
                    txtPrimerNombre.Text = primer_nombre;
                    txtSegundoNombre.Text = segundo_nombre;
                    txtPrimerApellido.Text = primer_apellido;
                    txtSegundoApellido.Text = segundo_apellido;
                    txtDireccion.Text = direccion;
                    txtTelefonoFijo.Text = telefono_fijo;
                    txtTelefonoMovil.Text = telefono_movil;
                    cbRegion.SelectedValue = _region;
                    cbProvincia.SelectedValue = _id_provincia;
                    cbComuna.SelectedValue = id_comuna;
                    _estado = estado;
                    if (_estado.Equals("1"))
                    {
                        txtEstado.Text = "ACTIVO";
                    }
                    else
                    {
                        txtEstado.Text = "DASACTIVADO";
                    }
                    txtEstado.Enabled = false;
                    txtEmpresa.Text = auxEmpresa.Nombre;
                    txtEmpresa.ReadOnly = true;
                    txtEmpresa.Enabled = false;
                    cbCargo.SelectedValue = id_cargo;
                    //se vacian variables para que no queden con informacion
                    _rut_usuario = null;
                    _primer_nombre = null;
                    _segundo_nombre = null;
                    _primer_apellido = null;
                    _segundo_apellido = null;
                    _direccion = null;
                    _telefono_fijo = null;
                    _telefono_movil = null;
                    _estado = null;
                    _id_comuna = null;
                    //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
                    _guardar = 1;
                }
                else// mostrar
                {
                    //Se cargan las clases de comuna provincia y region mediante web service
                    ServiceProcess_Comuna.Comuna auxComuna = new ServiceProcess_Comuna.Comuna();
                    ServiceProcess_Provincia.Provincia auxProvincia = new ServiceProcess_Provincia.Provincia();
                    //Se buscan comuna y provincia
                    auxComuna = auxServiceComuna.TraerComunaConEntidad_Escritorio(Convert.ToInt32(id_comuna));
                    auxProvincia = auxServiceProvincia.TraerProvinciaConEntidad_Escritorio(auxComuna.Id_provincia);
                    //Se almacena en variables
                    int _id_provincia = auxProvincia.Id_provincia;
                    int _region = auxProvincia.Id_region;
                    //Cambiar Titulo de Modal
                    lblTitulo.Text = tituloModal;
                    //Se habilita Boton
                    btnGuardar.Visible = false;
                    btnCancelar.Visible = false;
                    btnVolver.Visible = true;
                    //Se carga combos de estado y region                    
                    cargarComboRegion();
                    cargarComboCargo(rut_empresa);
                    //bloquear combobox
                    cbRegion.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbComuna.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbCargo.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbRegion.Enabled = false;                    
                    cbCargo.Enabled = false;
                    //se inactiva txtbox de rut de Usuario
                    txtRutUsuario.ReadOnly = true;
                    txtRutUsuario.Enabled = false;
                    //bloquear cajas de texto   
                    txtRutUsuario.Enabled = false;
                    txtPrimerNombre.Enabled = false;
                    txtSegundoNombre.Enabled = false;
                    txtPrimerApellido.Enabled = false;
                    txtSegundoApellido.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtTelefonoFijo.Enabled = false;
                    txtTelefonoMovil.Enabled = false;
                    txtEmpresa.Enabled = false;
                    //se pasan datos a cajas de texto de cuadro de datos
                    txtRutUsuario.Text = rut_usuario;
                    txtPrimerNombre.Text = primer_nombre;
                    txtSegundoNombre.Text = segundo_nombre;
                    txtPrimerApellido.Text = primer_apellido;
                    txtSegundoApellido.Text = segundo_apellido;
                    txtDireccion.Text = direccion;
                    txtTelefonoFijo.Text = telefono_fijo;
                    txtTelefonoMovil.Text = telefono_movil;
                    cbRegion.SelectedValue = _region;
                    cbProvincia.SelectedValue = _id_provincia;
                    cbComuna.SelectedValue = id_comuna;
                    _estado = estado;
                    if (_estado.Equals("1"))
                    {
                        txtEstado.Text = "ACTIVO";
                    }
                    else
                    {
                        txtEstado.Text = "DASACTIVADO";
                    }
                    txtEstado.Enabled = false;
                    txtEmpresa.Text = auxEmpresa.Nombre;
                    cbCargo.SelectedValue = id_cargo;
                    cbProvincia.Enabled = false;
                    cbComuna.Enabled = false;
                    //se vacian variables para que no queden con informacion
                    _rut_usuario = null;
                    _primer_nombre = null;
                    _segundo_nombre = null;
                    _primer_apellido = null;
                    _segundo_apellido = null;
                    _direccion = null;
                    _telefono_fijo = null;
                    _telefono_movil = null;
                    _estado = null;
                    _id_comuna = null;
                    //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
                    _guardar = 3;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion Modal Usuario, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarComboCargo(string rut_empresa)
        {
            ServiceProcess_Cargo.Process_CargoSoapClient auxServiceCargo = new ServiceProcess_Cargo.Process_CargoSoapClient();
            auxServiceCargo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
            auxServiceCargo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = auxServiceCargo.TraerCargoConEmpresaSinEntidad_Escritorio(rut_empresa);
            dt = ds.Tables[0];
            DataRow fila = dt.NewRow();
            fila["ID_CARGO"] = 0;
            fila["NOMBRE"] = "SELECCIONE CARGO";
            fila["DESCRIPCION"] = " ";
            fila["RUT_EMPRESA"] = " ";
            dt.Rows.InsertAt(fila, 0);
            cbCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCargo.DataSource = dt;
            cbCargo.DisplayMember = "NOMBRE";
            cbCargo.ValueMember = "ID_CARGO";
        }

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
                MessageBox.Show("Error al cargar Informacion cargarComboRegion, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                MessageBox.Show("Error al cargar Informacion cargarComboProvincia, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarComboComuna(int _id_provincia)
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
                MessageBox.Show("Error al cargar Informacion cargarComboComuna, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error al cargar Informacion CbRegion_SelectedIndexChanged, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                MessageBox.Show("Error al cargar Informacion CbProvincia_SelectedIndexChanged, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_CargosUsuarios.Process_CargosUsuariosSoapClient auxServiceCargosUsuarios = new ServiceProcess_CargosUsuarios.Process_CargosUsuariosSoapClient();
                auxServiceCargosUsuarios.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCargosUsuarios.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                //Validacion espacio en blanco y seleccion de combobox
                if (txtRutUsuario.Text.Trim().Equals("") || txtPrimerNombre.Text.Trim().Equals("") || txtSegundoNombre.Text.Trim().Equals("")
                    || txtPrimerApellido.Text.Equals("") || txtSegundoApellido.Text.Equals("") || txtDireccion.Text.Equals("")
                    || txtTelefonoFijo.Text.Equals("") || txtTelefonoMovil.Text.Equals("")
                    || Convert.ToInt32(cbRegion.SelectedIndex) == 0 || Convert.ToInt32(cbProvincia.SelectedIndex) == 0
                    || Convert.ToInt32(cbComuna.SelectedIndex) == 0 || Convert.ToInt32(cbCargo.SelectedIndex) == 0)
                {
                    if (txtRutUsuario.Text.Trim().Equals(""))//Mensaje Para Rut Vacio
                    {
                        MessageBox.Show("El campo Rut No puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtPrimerNombre.Text.Trim().Equals(""))//Mensaje Para Primer Nombre Vacio
                    {
                        MessageBox.Show("El campo Primer Nombre No puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtSegundoNombre.Text.Trim().Equals(""))//Mensaje Para Segundo Nombre Vacio
                    {
                        MessageBox.Show("El campo Segundo Nombre No puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtPrimerApellido.Text.Equals(""))//Mensaje Para Primer Apellido Vacio
                    {
                        MessageBox.Show("El campo Primer Apellido No puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtSegundoApellido.Text.Equals(""))//Mensaje Para Segundo Apellido Vacio
                    {
                        MessageBox.Show("El campo Segundo Apellido No puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtDireccion.Text.Equals(""))//Mensaje Para Direccion Vacio
                    {
                        MessageBox.Show("El campo Direccion No puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtTelefonoFijo.Text.Equals(""))//Mensaje Para Telefono fijo Vacio
                    {
                        MessageBox.Show("El campo Telefono Fijo No puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (txtTelefonoMovil.Text.Equals(""))//Mensaje Para Telefono Movil Vacio
                    {
                        MessageBox.Show("El campo Telefono Movil No puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (Convert.ToInt32(cbRegion.SelectedIndex) == 0)//Mensaje Para Combo region Sin seleccionar
                    {
                        MessageBox.Show("Debe seleccionar una Region .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (Convert.ToInt32(cbProvincia.SelectedIndex) == 0)//Mensaje Para Combo provincia Sin seleccionar
                    {
                        MessageBox.Show("Debe seleccionar una Provincia .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (Convert.ToInt32(cbComuna.SelectedIndex) == 0)//Mensaje Para Combo Comuna Sin seleccionar
                    {
                        MessageBox.Show("Debe seleccionar una Comuna .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (Convert.ToInt32(cbCargo.SelectedIndex) == 0)//Mensaje Para Combo Cargo Sin seleccionar
                    {
                        MessageBox.Show("Debe seleccionar un cargo .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    //Validar longitud de caracteres
                    if (txtRutUsuario.Text.Trim().Length < 10 || txtRutUsuario.Text.Trim().Length > 12
                        || txtPrimerNombre.Text.Trim().Length < 2 || txtPrimerNombre.Text.Trim().Length > 70
                        || txtSegundoNombre.Text.Trim().Length < 2 || txtSegundoNombre.Text.Trim().Length > 70
                        || txtPrimerApellido.Text.Trim().Length < 2 || txtPrimerApellido.Text.Trim().Length > 70
                        || txtSegundoApellido.Text.Trim().Length < 2 || txtSegundoApellido.Text.Trim().Length > 70
                        || txtDireccion.Text.Trim().Length < 5 || txtDireccion.Text.Trim().Length > 70
                        || txtTelefonoFijo.Text.Trim().Length < 9 || txtTelefonoFijo.Text.Trim().Length > 10
                        || txtTelefonoMovil.Text.Trim().Length < 8 || txtTelefonoMovil.Text.Trim().Length > 10)
                    {
                        if (txtRutUsuario.Text.Trim().Length < 10 || txtRutUsuario.Text.Trim().Length > 12)//Mensaje longitud fuera de rango rut usuario
                        {
                            MessageBox.Show("El Rut, debe tener un minimo de 10 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (txtPrimerNombre.Text.Trim().Length < 2 || txtPrimerNombre.Text.Trim().Length > 70)//Mensaje longitud fuera de rango primer nombre
                        {
                            MessageBox.Show("El Primer Nombre, debe tener un minimo de 2 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (txtSegundoNombre.Text.Trim().Length < 2 || txtSegundoNombre.Text.Trim().Length > 70)//Mensaje longitud fuera de rango segundo nombre
                        {
                            MessageBox.Show("El Segundo Nombre, debe tener un minimo de 2 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (txtPrimerApellido.Text.Trim().Length < 2 || txtPrimerApellido.Text.Trim().Length > 70)//Mensaje longitud fuera de rango primer apellido
                        {
                            MessageBox.Show("El Primer Apellido, debe tener un minimo de 2 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (txtSegundoApellido.Text.Trim().Length < 2 || txtSegundoApellido.Text.Trim().Length > 70)//Mensaje longitud fuera de rango segundo apellido
                        {
                            MessageBox.Show("El Segundo Apellido, debe tener un minimo de 2 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (txtDireccion.Text.Trim().Length < 5 || txtDireccion.Text.Trim().Length > 70)//Mensaje longitud fuera de rango direccion
                        {
                            MessageBox.Show("La Direccion, debe tener un minimo de 5 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (txtTelefonoFijo.Text.Trim().Length < 9 || txtTelefonoFijo.Text.Trim().Length > 10) //Mensaje longitud fuera de rango telefono fijo
                        {
                            MessageBox.Show("El Telefono Fijo, debe tener un minimo de 9 Caracteres y Maximo de 10.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (txtTelefonoMovil.Text.Trim().Length < 8 || txtTelefonoMovil.Text.Trim().Length > 10) //Mensaje longitud fuera de rango telefono movil
                        {
                            MessageBox.Show("El Telefono Movil, debe tener un minimo de 8 Caracteres y Maximo de 10.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }


                    }
                    else
                    {
                        //Validacion de formato de correo, validacion numero de telefono, validacion rut correcto
                        if (!auxServiceValidadores.numeroValidacionService(txtTelefonoFijo.Text)
                            || !auxServiceValidadores.numeroValidacionService(txtTelefonoMovil.Text)
                            || !auxServiceValidadores.rutValidacionService(txtRutUsuario.Text))
                        {
                            if (!auxServiceValidadores.numeroValidacionService(txtTelefonoFijo.Text))//Mensaje de ingreso de caracteres en telefono fijo
                            {
                                MessageBox.Show("El Telefono Fijo debe contener solo Numeros.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if (!auxServiceValidadores.numeroValidacionService(txtTelefonoMovil.Text))//Mensaje de ingreso de caracteres en telefono movil
                            {
                                MessageBox.Show("El Telefono Movil debe contener solo Numeros.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if (!auxServiceValidadores.rutValidacionService(txtRutUsuario.Text))//Mensaje de rut no valido
                            {
                                MessageBox.Show("Rut Ingresado No Valido.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }
                        else
                        {
                            DataSet ds = auxServiceUsuario.TraerUsuarioPorRutPorEmpresaSinEntidad_Escritorio(txtRutUsuario.Text.ToUpper(), txtEmpresa.Text.ToUpper());
                            //Validacion si existe Usuario
                            if (ds.Tables.Count == 0)
                            {
                                //confirmacion de crear nuevo usuario
                                if (MessageBox.Show("Confirmar La Modificacion del Usuario.", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //Insertar datos via web service tabla usuario
                                    auxServiceUsuario.ActualizarUsuarioSinEntidad_Escritorio(txtRutUsuario.Text.ToUpper(), txtPrimerNombre.Text.ToUpper(), txtSegundoNombre.Text.ToUpper(),
                                                                                             txtPrimerApellido.Text.ToUpper(), txtSegundoApellido.Text.ToUpper(), txtDireccion.Text.ToUpper(),
                                                                                             Convert.ToInt32(txtTelefonoFijo.Text.ToUpper()), Convert.ToInt32(txtTelefonoMovil.Text.ToString()),
                                                                                             Convert.ToInt32(cbComuna.SelectedValue.ToString()));
                                    //Insertar datos via web service tabla cargo_usuario
                                    auxServiceCargosUsuarios.InsertarCargosUsuarioSinEntidad_Escritorio(txtRutUsuario.Text, Convert.ToInt32(_id_cargo), Convert.ToInt32(_estado));

                                    this.DialogResult = DialogResult.OK;
                                    this.Close();

                                }
                                else
                                {
                                    //se devuelve al Cuadro de datos
                                    MessageBox.Show("Se cancelo la Modificacion del Usuario.", "Modificacion DE USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                            }
                            else
                            {
                                string nombreEmpresa = txtEmpresa.Text;
                                MessageBox.Show("El Usuario Ya existe En la Empresa " + nombreEmpresa + ".", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion BtnGuardar_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

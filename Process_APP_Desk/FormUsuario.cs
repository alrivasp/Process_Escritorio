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
            //Metodo Carga Cuadro de Datos en Blanco
            cargarDatosEnBlanco();
        }
        //Metodo Carga Cuadro de Datos en Blanco
        private void cargarDatosEnBlanco()
        {
            //CAMBIO DE TITULO DE CUADRO DE DATOS
            lblTituloCuadro.Text = "DATOS DE USUARIO";
            //bloquear cajas de texto
            txtRutUsuario.ReadOnly = true;
            txtPrimerNombre.ReadOnly = true;
            txtSegundoNombre.ReadOnly = true;
            txtPrimerApellido.ReadOnly = true;
            txtSegundoApellido.ReadOnly = true;
            txtDireccion.ReadOnly = true;
            txtCorreo.ReadOnly = true;
            txtTelefonoFijo.ReadOnly = true;
            txtTelefonoMovil.ReadOnly = true;
            //vaciar cajas de texto
            txtRutUsuario.Text = string.Empty;
            txtPrimerNombre.Text = string.Empty;
            txtSegundoNombre.Text = string.Empty;
            txtPrimerApellido.Text = string.Empty;
            txtSegundoApellido.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtTelefonoFijo.Text = string.Empty;
            txtTelefonoMovil.Text = string.Empty;
            //bloquear combobox
            cbRegion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
            cbComuna.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            //vaciar combobox
            cbRegion.DataSource = null;
            cbRegion.Items.Clear();
            cbProvincia.DataSource = null;
            cbProvincia.Items.Clear();
            cbComuna.DataSource = null;
            cbComuna.Items.Clear();
            cbEstado.DataSource = null;
            cbEstado.Items.Clear();
            cbEmpresa.DataSource = null;
            cbEmpresa.Items.Clear();
            cbCargo.DataSource = null;
            cbCargo.Items.Clear();
            //inactivar boton guardar
            btnGuardar.Visible = false;
            //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
            _guardar = 0;
        }
        //Metodo Carga GridView 
        private void cargarDataGridViewPpal()
        {
            ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
            DataSet ds = auxServiceUsuario.TraerTodasUsuariosJoin_Escritorio();
            DataTable dt = ds.Tables[0];
            dgvUsuario.DataSource = dt;
        }
        //Metodo Carga ComboBox Estado
        private void cargarComboEstado()
        {
            DataTable dtEstado = new DataTable();
            DataRow dr = dtEstado.NewRow();
            dtEstado.TableName = "Estado";
            dtEstado.Columns.Add(new DataColumn("ID"));
            dtEstado.Columns.Add(new DataColumn("Nombre"));
            dr["ID"] = "";
            dr["Nombre"] = "SELECCIONE ESTADO";
            dtEstado.Rows.Add(dr);
            DataRow dr1 = dtEstado.NewRow();
            dr1["ID"] = 0;
            dr1["Nombre"] = "INACTIVO";
            dtEstado.Rows.Add(dr1);
            DataRow dr2 = dtEstado.NewRow();
            dr2["ID"] = 1;
            dr2["Nombre"] = "ACTIVO";
            dtEstado.Rows.Add(dr2);


            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstado.DataSource = dtEstado;
            cbEstado.DisplayMember = "Nombre";
            cbEstado.ValueMember = "ID";
        }
        //Metodo Carga ComboBox Comuna
        public void cargarComboComuna(int _id_provincia)
        {
            ServiceProcess_Comuna.Process_ComunaSoapClient auxServiceComuna = new ServiceProcess_Comuna.Process_ComunaSoapClient();
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
        //Metodo Carga ComboBox Provincia
        public void cargarComboProvincia(int _id_region)
        {
            ServiceProcess_Provincia.Process_ProvinciaSoapClient auxServiceProvincia = new ServiceProcess_Provincia.Process_ProvinciaSoapClient();
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
        //Metodo Carga ComboBox Region
        private void cargarComboRegion()
        {
            ServiceProcess_Region.Process_RegionSoapClient auxServiceRegion = new ServiceProcess_Region.Process_RegionSoapClient();
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
        //Metodo Carga ComboBox Empresa
        private void cargarComboEmpresa()
        {
            ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
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
        //Metodo Carga ComboBox Cargo
        private void cargarComboCargo(string aux_rut_empresa)
        {
            ServiceProcess_Cargo.Process_CargoSoapClient auxServiceCargo = new ServiceProcess_Cargo.Process_CargoSoapClient();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = auxServiceCargo.TraerCargoConEmpresaSinEntidad_Escritorio(aux_rut_empresa);
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
        //Metodo Carga ComboBox Rol
        //private void cargarComboRol()
        //{
        //    ServiceProcess_Rol.Process_RolSoapClient auxServiceRol = new ServiceProcess_Rol.Process_RolSoapClient();
        //    DataSet ds = new DataSet();
        //    DataTable dt = new DataTable();
        //    ds = auxServiceRol.TraerTodasRoles_Escritorio();
        //    dt = ds.Tables[0];
        //    DataRow fila = dt.NewRow();
        //    fila["ID_ROL"] = 0;
        //    fila["NOMBRE"] = "SELECCIONE EMPRESA";
        //    fila["ESTADO"] = 0;          
        //    dt.Rows.InsertAt(fila, 0);
        //    cbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
        //    cbEmpresa.DataSource = dt;
        //    cbEmpresa.DisplayMember = "NOMBRE";
        //    cbEmpresa.ValueMember = "ID_ROL";
        //}
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
                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                DataSet ds = auxServiceUsuario.TraerUsuarioConClaveSinEntidad_Escritorio(txtFiltrar.Text.ToUpper());
                DataTable dt = ds.Tables[0];
                dgvUsuario.DataSource = dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                DataRow dr = dt.NewRow();
                dt.TableName = "USUARIO";
                dt.Columns.Add(new DataColumn("RUT_USUARIO"));
                dt.Columns.Add(new DataColumn("PRIMER_NOMBRE"));
                dt.Columns.Add(new DataColumn("SEGUNDO_NOMBRE"));
                dt.Columns.Add(new DataColumn("PRIMER_APELLIDO"));
                dt.Columns.Add(new DataColumn("SEGUNDO_APELLIDO"));
                dt.Columns.Add(new DataColumn("DIRECCION"));
                dt.Columns.Add(new DataColumn("CORREO"));
                dt.Columns.Add(new DataColumn("TELEFONO_FIJO"));
                dt.Columns.Add(new DataColumn("TELEFONO_MOVIL"));
                dt.Columns.Add(new DataColumn("ESTADO"));
                dt.Columns.Add(new DataColumn("ID_CUMUNA"));
                dr["RUT_USUARIO"] = "SIN REGISTRO";
                dr["PRIMER_NOMBRE"] = "SIN REGISTRO";
                dr["SEGUNDO_NOMBRE"] = "SIN REGISTRO";
                dr["PRIMER_APELLIDO"] = "SIN REGISTRO";
                dr["SEGUNDO_APELLIDO"] = "SIN REGISTRO";
                dr["DIRECCION"] = "SIN REGISTRO";
                dr["CORREO"] = "SIN REGISTRO";
                dr["TELEFONO_FIJO"] = "SIN REGISTRO";
                dr["TELEFONO_MOVIL"] = "SIN REGISTRO";
                dr["ESTADO"] = "SIN REGISTRO";
                dr["ID_CUMUNA"] = "SIN REGISTRO";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);

                dgvUsuario.DataSource = ds;

            }
        }

        private void DgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _rut_usuario = dgvUsuario.Rows[e.RowIndex].Cells["RUT_USUARIO"].Value.ToString();
            _primer_nombre = dgvUsuario.Rows[e.RowIndex].Cells["PRIMER_NOMBRE"].Value.ToString();
            _segundo_nombre = dgvUsuario.Rows[e.RowIndex].Cells["SEGUNDO_NOMBRE"].Value.ToString();
            _primer_apellido = dgvUsuario.Rows[e.RowIndex].Cells["PRIMER_APELLIDO"].Value.ToString();
            _segundo_apellido = dgvUsuario.Rows[e.RowIndex].Cells["SEGUNDO_APELLIDO"].Value.ToString();
            _direccion = dgvUsuario.Rows[e.RowIndex].Cells["DIRECCION"].Value.ToString();
            _correo = dgvUsuario.Rows[e.RowIndex].Cells["CORREO"].Value.ToString();
            _telefono_fijo = dgvUsuario.Rows[e.RowIndex].Cells["TELEFONO_FIJO"].Value.ToString();
            _telefono_movil = dgvUsuario.Rows[e.RowIndex].Cells["TELEFONO_MOVIL"].Value.ToString();
            _estado = dgvUsuario.Rows[e.RowIndex].Cells["ESTADO"].Value.ToString();
            _id_comuna = dgvUsuario.Rows[e.RowIndex].Cells["ID_COMUNA"].Value.ToString();
            _rut_empresa = dgvUsuario.Rows[e.RowIndex].Cells["RUT_EMPRESA"].Value.ToString();
            _id_cargo = dgvUsuario.Rows[e.RowIndex].Cells["ID_CARGO"].Value.ToString();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            //Carga de Web Service
            ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
            ServiceProcess_Cargo.Process_CargoSoapClient auxServiceCargo = new ServiceProcess_Cargo.Process_CargoSoapClient();
            ServiceProcess_Region.Process_RegionSoapClient auxServiceRegion = new ServiceProcess_Region.Process_RegionSoapClient();
            ServiceProcess_Provincia.Process_ProvinciaSoapClient auxServiceProvincia = new ServiceProcess_Provincia.Process_ProvinciaSoapClient();
            ServiceProcess_Comuna.Process_ComunaSoapClient auxServiceComuna = new ServiceProcess_Comuna.Process_ComunaSoapClient();

            if (_rut_usuario == null)//validador que se seleccione un fila de GridView de usuario
            {
                MessageBox.Show("Seleccione una Fila a Modificar", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Se cargan las clases de comuna provincia y region mediante web service
                ServiceProcess_Comuna.Comuna auxComuna = new ServiceProcess_Comuna.Comuna();
                ServiceProcess_Provincia.Provincia auxProvincia = new ServiceProcess_Provincia.Provincia();
                //Se buscan comuna y provincia
                auxComuna = auxServiceComuna.TraerComunaConEntidad_Escritorio(Convert.ToInt32(_id_comuna));
                auxProvincia = auxServiceProvincia.TraerProvinciaConEntidad_Escritorio(auxComuna.Id_provincia);
                //Se almacena en variables
                int _id_provincia = auxProvincia.Id_provincia;
                int _region = auxProvincia.Id_region;
                //Se edita titulo de cuadro de datos
                lblTituloCuadro.Text = "MODIFICAR USUARIO";
                //Se habilita Boton
                btnGuardar.Visible = true;
                //Se carga combos de estado y region
                cargarComboEstado();
                cargarComboRegion();
                cargarComboEmpresa();
                //bloquear combobox
                cbRegion.DropDownStyle = ComboBoxStyle.DropDownList;
                cbProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
                cbComuna.DropDownStyle = ComboBoxStyle.DropDownList;
                cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
                cbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
                cbCargo.DropDownStyle = ComboBoxStyle.DropDownList;
                //Se deja combo empresa inahabilitado
                cbEmpresa.Enabled = false;
                //se inactiva txtbox de rut de Usuario
                txtRutUsuario.ReadOnly = true;
                txtRutUsuario.Enabled = false;
                //desbloquear cajas de texto                 
                txtPrimerNombre.ReadOnly = false;
                txtSegundoNombre.ReadOnly = false;
                txtPrimerApellido.ReadOnly = false;
                txtSegundoApellido.ReadOnly = false;
                txtDireccion.ReadOnly = false;
                txtCorreo.ReadOnly = false;
                txtTelefonoFijo.ReadOnly = false;
                txtTelefonoMovil.ReadOnly = false;
                //se pasan datos a cajas de texto de cuadro de datos
                txtRutUsuario.Text = _rut_usuario;
                txtPrimerNombre.Text = _primer_nombre;
                txtSegundoNombre.Text = _segundo_nombre;
                txtPrimerApellido.Text = _primer_apellido;
                txtSegundoApellido.Text = _segundo_apellido;
                txtDireccion.Text = _direccion;
                txtCorreo.Text = _correo;
                txtTelefonoFijo.Text = _telefono_fijo;
                txtTelefonoMovil.Text = _telefono_movil;
                cbRegion.SelectedValue = _region;
                cbProvincia.SelectedValue = _id_provincia;
                cbComuna.SelectedValue = _id_comuna;
                cbEstado.SelectedValue = _estado;
                cbEmpresa.SelectedValue = _rut_empresa;
                cbCargo.SelectedValue = _id_cargo;
                //se vacian variables para que no queden con informacion
                _rut_usuario = null;
                _primer_nombre = null;
                _segundo_nombre = null;
                _primer_apellido = null;
                _segundo_apellido = null;
                _direccion = null;
                _correo = null;
                _telefono_fijo = null;
                _telefono_movil = null;
                _estado = null;
                _id_comuna = null;
                //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
                _guardar = 1;

            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            //cambiar titulo
            lblTituloCuadro.Text = "NUEVO USUARIO";
            //habilitar boton guardar
            btnGuardar.Visible = true;
            //desbloquear cajas de texto
            txtRutUsuario.ReadOnly = false;
            txtRutUsuario.Enabled = true;
            txtPrimerNombre.ReadOnly = false;
            txtSegundoNombre.ReadOnly = false;
            txtPrimerApellido.ReadOnly = false;
            txtSegundoApellido.ReadOnly = false;
            txtDireccion.ReadOnly = false;
            txtCorreo.ReadOnly = false;
            txtTelefonoFijo.ReadOnly = false;
            txtTelefonoMovil.ReadOnly = false;
            //Cargar comobox de region y estado
            cargarComboEstado();
            cargarComboRegion();
            cargarComboEmpresa();
            //vaciar textbox
            txtRutUsuario.Text = string.Empty;
            txtPrimerNombre.Text = string.Empty;
            txtSegundoNombre.Text = string.Empty;
            txtPrimerApellido.Text = string.Empty;
            txtSegundoApellido.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtTelefonoFijo.Text = string.Empty;
            txtTelefonoMovil.Text = string.Empty;
            //bloquear combobox de edicion
            cbRegion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
            cbComuna.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            //Habilitar combobox
            cbEmpresa.Enabled = true;
            cbRegion.Enabled = true;
            //Inahabilitar combobox secundarios
            cbProvincia.Enabled = false;
            cbComuna.Enabled = false;
            //vaciar combobox
            cbProvincia.DataSource = null;
            cbProvincia.Items.Clear();
            cbComuna.DataSource = null;
            cbComuna.Items.Clear();
            cbCargo.DataSource = null;
            cbCargo.Items.Clear();
            //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = Nuevo)
            _guardar = 2;

        }

        private void CbRegion_SelectedIndexChanged(object sender, EventArgs e)
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

        private void CbProvincia_SelectedIndexChanged(object sender, EventArgs e)
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

        private void CbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbEmpresa.SelectedIndex) > 0)
            {
                string rut_empresa = cbEmpresa.SelectedValue.ToString();
                cargarComboCargo(rut_empresa);
                cbCargo.Enabled = true;
            }
            else
            {
                cbCargo.DataSource = null;
                cbCargo.Items.Clear();
                cbCargo.Enabled = false;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Instanacia de web service Validadores
                ServiceProcess_Validadores.Process_ValidadoresSoapClient auxServiceValidadores = new ServiceProcess_Validadores.Process_ValidadoresSoapClient();
                //Instancia de Web service Usuario
                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                //Instancia de Web service CargosUsuarios
                ServiceProcess_CargosUsuarios.Process_CargosUsuariosSoapClient auxServiceCargosUsuarios = new ServiceProcess_CargosUsuarios.Process_CargosUsuariosSoapClient();
                if (_guardar == 1)//Modificar Usuario
                {
                    //Validacion espacio en blanco y seleccion de combobox
                    if (txtRutUsuario.Text.Trim().Equals("") || txtPrimerNombre.Text.Trim().Equals("") || txtSegundoNombre.Text.Trim().Equals("")
                        || txtPrimerApellido.Text.Equals("") || txtSegundoApellido.Text.Equals("") || txtDireccion.Text.Equals("")
                        || txtCorreo.Text.Equals("") || txtTelefonoFijo.Text.Equals("") || txtTelefonoMovil.Text.Equals("")
                        || Convert.ToInt32(cbRegion.SelectedIndex) == 0 || Convert.ToInt32(cbProvincia.SelectedIndex) == 0
                        || Convert.ToInt32(cbComuna.SelectedIndex) == 0 || Convert.ToInt32(cbEmpresa.SelectedIndex) == 0
                        || Convert.ToInt32(cbCargo.SelectedIndex) == 0 || Convert.ToInt32(cbEstado.SelectedIndex) == 0)
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
                        else if (txtCorreo.Text.Equals(""))//Mensaje Para Correo Vacio
                        {
                            MessageBox.Show("El campo Correo No puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        else if (Convert.ToInt32(cbEmpresa.SelectedIndex) == 0)//Mensaje Para Combo Empresa Sin seleccionar
                        {
                            MessageBox.Show("Debe seleccionar una Empresa .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (Convert.ToInt32(cbCargo.SelectedIndex) == 0)//Mensaje Para Combo Cargo Sin seleccionar
                        {
                            MessageBox.Show("Debe seleccionar un Cargo .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (Convert.ToInt32(cbEstado.SelectedIndex) == 0)//Mensaje Para Combo Estado Sin seleccionar
                        {
                            MessageBox.Show("Debe seleccionar un Estado .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            || txtCorreo.Text.Trim().Length < 4 || txtCorreo.Text.Trim().Length > 70
                            || txtTelefonoFijo.Text.Trim().Length < 9 || txtTelefonoFijo.Text.Trim().Length > 12
                            || txtTelefonoMovil.Text.Trim().Length < 8 || txtTelefonoMovil.Text.Trim().Length > 12)
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
                            else if (txtCorreo.Text.Trim().Length < 4 || txtCorreo.Text.Trim().Length > 70)//Mensaje longitud fuera de rango correo
                            {
                                MessageBox.Show("El Correo, debe tener un minimo de 5 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if (txtTelefonoFijo.Text.Trim().Length < 9 || txtTelefonoFijo.Text.Trim().Length > 12) //Mensaje longitud fuera de rango telefono fijo
                            {
                                MessageBox.Show("El Telefono Fijo, debe tener un minimo de 9 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if (txtTelefonoMovil.Text.Trim().Length < 8 || txtTelefonoMovil.Text.Trim().Length > 12) //Mensaje longitud fuera de rango telefono movil
                            {
                                MessageBox.Show("El Telefono Movil, debe tener un minimo de 8 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }


                        }
                        else
                        {
                            //Validacion de formato de correo, validacion numero de telefono, validacion rut correcto
                            if (!auxServiceValidadores.correoValidacionService(txtCorreo.Text)
                                || !auxServiceValidadores.numeroValidacionService(txtTelefonoFijo.Text)
                                || !auxServiceValidadores.numeroValidacionService(txtTelefonoMovil.Text)
                                || !auxServiceValidadores.rutValidacionService(txtRutUsuario.Text))
                            {
                                if (!auxServiceValidadores.correoValidacionService(txtCorreo.Text))//Mensaje de formato de correo incorrecto
                                {
                                    MessageBox.Show("El formato de Correo No es valido.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else if (!auxServiceValidadores.numeroValidacionService(txtTelefonoFijo.Text))//Mensaje de ingreso de caracteres en telefono fijo
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
                                //confirmacion de Actualizar  usuario
                                if (MessageBox.Show("Confirmar La Actualizacion del Usuario.", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //Insertar datos via web service tabla usuario
                                    auxServiceUsuario.ActualizarUsuarioSinEntidad_Escritorio(txtRutUsuario.Text.ToUpper(), txtPrimerNombre.Text.ToUpper(), txtSegundoNombre.Text.ToUpper(),
                                                                                             txtPrimerApellido.Text.ToUpper(), txtSegundoApellido.Text.ToUpper(), txtDireccion.Text.ToUpper(),
                                                                                             txtCorreo.Text.ToUpper(), Convert.ToInt32(txtTelefonoFijo.Text.ToUpper()), Convert.ToInt32(txtTelefonoMovil.Text.ToString()),
                                                                                             Convert.ToInt32(cbEstado.SelectedValue.ToString()), Convert.ToInt32(cbComuna.SelectedValue.ToString()));
                                    //Insertar datos via web service tabla cargo_usuario
                                    auxServiceCargosUsuarios.ActualizarCargosUsuarioSinEntidad_Escritorio(txtRutUsuario.Text, Convert.ToInt32(cbCargo.SelectedValue.ToString()), Convert.ToInt32(cbEstado.SelectedValue.ToString()));
                                    //Metodo Carga de cuadro de datos
                                    cargarDatosEnBlanco();
                                    ////Metodo Carga de GridView
                                    cargarDataGridViewPpal();
                                    MessageBox.Show("Usuario Actualizado Correctamente.", "ACTUALIZACION DE USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    //se devuelve al Cuadro de datos
                                    MessageBox.Show("NO se Actualizo Usuario.", "ACTUALIZACION DE USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }


                            }
                        }

                    }
                }
                else//Nueva empresa
                {
                    //Validacion espacio en blanco y seleccion de combobox
                    if (txtRutUsuario.Text.Trim().Equals("") || txtPrimerNombre.Text.Trim().Equals("") || txtSegundoNombre.Text.Trim().Equals("")
                        || txtPrimerApellido.Text.Equals("") || txtSegundoApellido.Text.Equals("") || txtDireccion.Text.Equals("")
                        || txtCorreo.Text.Equals("") || txtTelefonoFijo.Text.Equals("") || txtTelefonoMovil.Text.Equals("")
                        || Convert.ToInt32(cbRegion.SelectedIndex) == 0 || Convert.ToInt32(cbProvincia.SelectedIndex) == 0
                        || Convert.ToInt32(cbComuna.SelectedIndex) == 0 || Convert.ToInt32(cbEmpresa.SelectedIndex) == 0
                        || Convert.ToInt32(cbCargo.SelectedIndex) == 0 || Convert.ToInt32(cbEstado.SelectedIndex) == 0)
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
                        else if (txtCorreo.Text.Equals(""))//Mensaje Para Correo Vacio
                        {
                            MessageBox.Show("El campo Correo No puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        else if (Convert.ToInt32(cbEmpresa.SelectedIndex) == 0)//Mensaje Para Combo Empresa Sin seleccionar
                        {
                            MessageBox.Show("Debe seleccionar una Empresa .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (Convert.ToInt32(cbCargo.SelectedIndex) == 0)//Mensaje Para Combo Cargo Sin seleccionar
                        {
                            MessageBox.Show("Debe seleccionar un Cargo .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (Convert.ToInt32(cbEstado.SelectedIndex) == 0)//Mensaje Para Combo Estado Sin seleccionar
                        {
                            MessageBox.Show("Debe seleccionar un Estado .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            || txtCorreo.Text.Trim().Length < 4 || txtCorreo.Text.Trim().Length > 70
                            || txtTelefonoFijo.Text.Trim().Length < 9 || txtTelefonoFijo.Text.Trim().Length > 12
                            || txtTelefonoMovil.Text.Trim().Length < 8 || txtTelefonoMovil.Text.Trim().Length > 12)
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
                            else if (txtCorreo.Text.Trim().Length < 4 || txtCorreo.Text.Trim().Length > 70)//Mensaje longitud fuera de rango correo
                            {
                                MessageBox.Show("El Correo, debe tener un minimo de 5 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if (txtTelefonoFijo.Text.Trim().Length < 9 || txtTelefonoFijo.Text.Trim().Length > 12) //Mensaje longitud fuera de rango telefono fijo
                            {
                                MessageBox.Show("El Telefono Fijo, debe tener un minimo de 9 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if (txtTelefonoMovil.Text.Trim().Length < 8 || txtTelefonoMovil.Text.Trim().Length > 12) //Mensaje longitud fuera de rango telefono movil
                            {
                                MessageBox.Show("El Telefono Movil, debe tener un minimo de 8 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }


                        }
                        else
                        {
                            //Validacion de formato de correo, validacion numero de telefono, validacion rut correcto
                            if (!auxServiceValidadores.correoValidacionService(txtCorreo.Text)
                                || !auxServiceValidadores.numeroValidacionService(txtTelefonoFijo.Text)
                                || !auxServiceValidadores.numeroValidacionService(txtTelefonoMovil.Text)
                                || !auxServiceValidadores.rutValidacionService(txtRutUsuario.Text))
                            {
                                if (!auxServiceValidadores.correoValidacionService(txtCorreo.Text))//Mensaje de formato de correo incorrecto
                                {
                                    MessageBox.Show("El formato de Correo No es valido.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else if (!auxServiceValidadores.numeroValidacionService(txtTelefonoFijo.Text))//Mensaje de ingreso de caracteres en telefono fijo
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
                                DataSet ds = auxServiceUsuario.TraerUsuarioPorRutPorEmpresaSinEntidad_Escritorio(txtRutUsuario.Text.ToUpper(), cbEmpresa.SelectedValue.ToString().ToUpper());
                                //Validacion si existe Usuario
                                if (ds.Tables.Count == 0)
                                {
                                    //confirmacion de crear nuevo usuario
                                    if (MessageBox.Show("Confirmar La Creacion del Usuario.", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //Insertar datos via web service tabla usuario
                                        auxServiceUsuario.InsertarUsuarioSinEntidad_Escritorio(txtRutUsuario.Text.ToUpper(), txtPrimerNombre.Text.ToUpper(), txtSegundoNombre.Text.ToUpper(),
                                                                                                 txtPrimerApellido.Text.ToUpper(), txtSegundoApellido.Text.ToUpper(), txtDireccion.Text.ToUpper(),
                                                                                                 txtCorreo.Text.ToUpper(), Convert.ToInt32(txtTelefonoFijo.Text.ToUpper()), Convert.ToInt32(txtTelefonoMovil.Text.ToString()),
                                                                                                 Convert.ToInt32(cbEstado.SelectedValue.ToString()), Convert.ToInt32(cbComuna.SelectedValue.ToString()));
                                        //Insertar datos via web service tabla cargo_usuario
                                        auxServiceCargosUsuarios.InsertarCargosUsuarioSinEntidad_Escritorio(txtRutUsuario.Text, Convert.ToInt32(cbCargo.SelectedValue.ToString()), Convert.ToInt32(cbEstado.SelectedValue.ToString()));
                                        //Metodo Carga de cuadro de datos
                                        cargarDatosEnBlanco();
                                        ////Metodo Carga de GridView
                                        cargarDataGridViewPpal();
                                        MessageBox.Show("Usuario Creado Correctamente.", "CREACION DE USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        //se devuelve al Cuadro de datos
                                        MessageBox.Show("Se cancelo la creacion del Usuario.", "CREACION DE USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                }
                                else
                                {
                                    string nombreEmpresa = Convert.ToString(cbEmpresa.GetItemText(cbEmpresa.SelectedItem));
                                    MessageBox.Show("El Usuario Ya existe En la Empresa " + nombreEmpresa + ".", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Web Service Process Fuera de Linea, Contactese con el Administrador Detalle de Error: " + ex.Message, "Mensaje de sistema");

            }//fin try catch
        }
    }
}

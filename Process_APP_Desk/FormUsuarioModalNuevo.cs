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
    public partial class FormUsuarioModalNuevo : Form
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
        public FormUsuarioModalNuevo()
        {
            InitializeComponent();
        }

        public FormUsuarioModalNuevo(string tituloModal, int accion, string rut_usuario, string primer_nombre, string segundo_nombre,
                                    string primer_apellido, string segundo_apellido, string direccion, string telefono_fijo, string telefono_movil,
                                    string estado, string id_comuna, string rut_empresa, string id_cargo)
        {
            InitializeComponent();
            try
            {
                //Cambiar Titulo de Modal
                lblTitulo.Text = tituloModal;
                //Se habilita Boton
                btnGuardar.Visible = true;
                btnCancelar.Visible = true;
                //vaciar textbox
                txtRutUsuario.Text = string.Empty;
                txtPrimerNombre.Text = string.Empty;
                txtSegundoNombre.Text = string.Empty;
                txtPrimerApellido.Text = string.Empty;
                txtSegundoApellido.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtTelefonoFijo.Text = string.Empty;
                txtTelefonoMovil.Text = string.Empty;
                txtCargo.Text = string.Empty;
                txtCargo.Enabled = false;
                //bloquear combobox DE EDICION
                cbRegion.DropDownStyle = ComboBoxStyle.DropDownList;
                cbProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
                cbComuna.DropDownStyle = ComboBoxStyle.DropDownList;
                cbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
                //BLOQUEAR COMBOBOX DE CAMBIO
                cbProvincia.Enabled = false;
                cbComuna.Enabled = false;
                //vaciar combobox
                cbProvincia.DataSource = null;
                cbProvincia.Items.Clear();
                cbComuna.DataSource = null;
                cbComuna.Items.Clear();
                //cargar combobox empresa
                cargarComboEmpresa();
                //Cargar comobox de region
                cargarComboRegion();
                pbSeleccion.Visible = false;
                pbSeleccionCargo.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion Modal Usuario, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void CbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbEmpresa.SelectedIndex) > 0)
                {
                    string rut_empresa = cbEmpresa.SelectedValue.ToString();                    
                    pbSeleccion.Visible = false;
                    pbSeleccionCargo.Visible = false;
                    txtCargo.Text = string.Empty;
                    //limpiar GridView
                    dgvCargo.Rows.Clear();
                    dgvCargo.Refresh();
                    cargarDataGridViewCargos(rut_empresa);
                }
                else
                {
                    //limpiar GridView
                    dgvCargo.Rows.Clear();
                    dgvCargo.Refresh();
                    pbSeleccion.Visible = false;
                    pbSeleccionCargo.Visible = false;
                    txtCargo.Text = string.Empty;
                    _id_cargo = string.Empty;
                    _rut_empresa = string.Empty;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion CbEmpresa_SelectedIndexChanged, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarDataGridViewCargos(string rut_empresa)
        {
            try
            {
                //instansear web service con seguridad
                ServiceProcess_Cargo.Process_CargoSoapClient auxServiceCargo = new ServiceProcess_Cargo.Process_CargoSoapClient();
                auxServiceCargo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCargo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Cargo.Cargo auxCargo = new ServiceProcess_Cargo.Cargo();                
                //capturar dataset
                DataSet ds = auxServiceCargo.TraerCargoConEmpresaSinEntidad_Escritorio(rut_empresa);
                //Capturar Tabla
                DataTable dt = ds.Tables[0];
                //contar cantidad de empresas
                int _cantidad_cargos = dt.Rows.Count;
                //crear array bidimencional
                string[,] ListaCargos = new string[_cantidad_cargos, 2];
                //Recorrer data table
                int _fila = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Capturar datos de la fila recorridad en objeto cargos
                    auxCargo.Id_cargo = Convert.ToInt32(dt.Rows[i]["Id_cargo"]);
                    auxCargo.Nombre = (String)dt.Rows[i]["Nombre"];
                    auxCargo.Descripcion = (String)dt.Rows[i]["Descripcion"];
                    auxCargo.Rut_empresa = (String)dt.Rows[i]["Rut_empresa"];


                    ListaCargos[_fila, 0] = auxCargo.Id_cargo.ToString();
                    ListaCargos[_fila, 1] = auxCargo.Nombre;
                    //agregar lista a gridview
                    dgvCargo.Rows.Add(ListaCargos[_fila, 0], ListaCargos[_fila, 1]);
                    _fila++;

                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo cargarDataGridViewCargos, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCargo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0)
                    return;

                _id_cargo = dgvCargo.Rows[e.RowIndex].Cells["ID_CARGO"].Value.ToString();
                _rut_empresa = cbEmpresa.SelectedValue.ToString();

                //instansear web service con seguridad                
                ServiceProcess_Cargo.Process_CargoSoapClient auxServiceCargo = new ServiceProcess_Cargo.Process_CargoSoapClient();
                auxServiceCargo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCargo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Cargo.Cargo auxCargo = new ServiceProcess_Cargo.Cargo();

                auxCargo = auxServiceCargo.TraerCargoConEntidad_Escritorio(Convert.ToInt32(_id_cargo));
                txtCargo.Text = auxCargo.Nombre.ToUpper();
                pbSeleccion.Visible = true;
                pbSeleccionCargo.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion DgvEmpresas_CellClick, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    || txtTelefonoFijo.Text.Equals("") || txtTelefonoMovil.Text.Equals("") || txtCargo.Text.Equals("")
                    || Convert.ToInt32(cbRegion.SelectedIndex) == 0 || Convert.ToInt32(cbProvincia.SelectedIndex) == 0
                    || Convert.ToInt32(cbComuna.SelectedIndex) == 0 || Convert.ToInt32(cbEmpresa.SelectedIndex) == 0)
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
                    else if (txtCargo.Text.Equals(""))//Mensaje Para cargo Vacio
                    {
                        MessageBox.Show("Debe seleccionar un Cargo para el usuario.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                                                                                             Convert.ToInt32(txtTelefonoFijo.Text.ToUpper()), Convert.ToInt32(txtTelefonoMovil.Text.ToString()),
                                                                                             Convert.ToInt32(cbComuna.SelectedValue.ToString()));
                                    //Insertar datos via web service tabla cargo_usuario
                                    auxServiceCargosUsuarios.InsertarCargosUsuarioSinEntidad_Escritorio(txtRutUsuario.Text, Convert.ToInt32(_id_cargo), 1);

                                    this.DialogResult = DialogResult.OK;
                                    this.Close();

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
            catch (Exception ex)
            {
             MessageBox.Show("Error en metodo BtnGuardar_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "Mensaje de sistema");
            }
        }
    }
}

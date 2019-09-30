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
    public partial class FormCuenta : Form
    {
        //Variables para cargar datos desde el gridview
        public static string _rut_usuario = null;
        public static string _rut_empresa;
        public static string _contrasena;
        public static string _estado;
        public static string _id_rol;
        //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
        public static int _guardar = 0;
        public FormCuenta()
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

        private void cargarDatosEnBlanco()
        {
            //CAMBIO DE TITULO DE CUADRO DE DATOS
            lblTituloCuadro.Text = "DATOS DE CUENTA";
            //bloquear cajas de texto
            txtPass.ReadOnly = true;
            txtPass2.ReadOnly = true;
            //vaciar cajas de texto
            txtPass.Text = string.Empty;
            txtPass2.Text = string.Empty;
            //bloquear combobox
            cbRutUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRutEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            //vaciar combobox
            cbRutUsuario.DataSource = null;
            cbRutUsuario.Items.Clear();
            cbRutEmpresa.DataSource = null;
            cbRutEmpresa.Items.Clear();
            cbEstado.DataSource = null;
            cbEstado.Items.Clear();
            cbRol.DataSource = null;
            cbRol.Items.Clear();
            //inactivar boton guardar
            btnGuardar.Visible = false;
            //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
            _guardar = 0;
        }

        private void cargarDataGridViewPpal()
        {
            ServiceProcess_Cuenta.Process_CuentaSoapClient auxServiceCuenta = new ServiceProcess_Cuenta.Process_CuentaSoapClient();
            DataSet ds = auxServiceCuenta.TraerTodasCuentas_Escritorio();
            DataTable dt = ds.Tables[0];
            dgvCuenta.DataSource = dt;
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
            cbRutEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRutEmpresa.DataSource = dt;
            cbRutEmpresa.DisplayMember = "NOMBRE";
            cbRutEmpresa.ValueMember = "RUT_EMPRESA";
        }
        //Metodo Carga ComboBox Usuario
        private void cargarComboUsuario()
        {
            ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario= new ServiceProcess_Usuario.Process_UsuarioSoapClient();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = auxServiceUsuario.TraerTodasUsuarios_Escritorio();
            dt = ds.Tables[0];
            DataRow fila = dt.NewRow();
            fila["RUT_USUARIO"] = "USUARIO";
            fila["PRIMER_NOMBRE"] = "0";
            fila["SEGUNDO_NOMBRE"] = "0";
            fila["PRIMER_APELLIDO"] = "0";
            fila["SEGUNDO_APELLIDO"] = "0";
            fila["DIRECCION"] = " ";
            fila["CORREO"] = " ";
            fila["TELEFONO_FIJO"] = 0;
            fila["TELEFONO_MOVIL"] = 0;
            fila["ESTADO"] = 0;
            fila["ID_COMUNA"] = 0;
            dt.Rows.InsertAt(fila, 0);
            cbRutUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRutUsuario.DataSource = dt;
            cbRutUsuario.DisplayMember = "RUT_USUARIO";
            cbRutUsuario.ValueMember = "RUT_USUARIO";
        }
        //Metodo Carga ComboBox Empresa
        private void cargarComboRol()
        {
            ServiceProcess_Rol.Process_RolSoapClient auxServiceRol = new ServiceProcess_Rol.Process_RolSoapClient();
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
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            System.GC.Collect();
        }

        private void TxtFiltrar_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                ServiceProcess_Cuenta.Process_CuentaSoapClient auxServiceCuenta = new ServiceProcess_Cuenta.Process_CuentaSoapClient();
                DataSet ds = auxServiceCuenta.TraerCuentaConClaveSinEntidad_Escritorio(txtFiltrar.Text.ToUpper());
                DataTable dt = ds.Tables[0];
                dgvCuenta.DataSource = dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                DataRow dr = dt.NewRow();
                dt.TableName = "CUENTA";
                dt.Columns.Add(new DataColumn("RUT_USUARIO"));
                dt.Columns.Add(new DataColumn("RUT_EMPRESA"));
                dt.Columns.Add(new DataColumn("CONTRASENA"));
                dt.Columns.Add(new DataColumn("ESTADO"));
                dt.Columns.Add(new DataColumn("ID_ROL"));
                dr["RUT_USUARIO"] = "SIN REGISTRO";
                dr["RUT_EMPRESA"] = "SIN REGISTRO";
                dr["CONTRASENA"] = "SIN REGISTRO";
                dr["ESTADO"] = "SIN REGISTRO";
                dr["ID_ROL"] = "SIN REGISTRO";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);

                dgvCuenta.DataSource = ds;

            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (_rut_usuario == null)//validador que se seleccione un fila de CUENTA
            {
                MessageBox.Show("Seleccione una Fila a Modificar", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Se edita titulo de cuadro de datos
                lblTituloCuadro.Text = "MODIFICAR CUENTA";
                //Se habilita Boton
                btnGuardar.Visible = true;
                //Se cargam comnbos de estado y empresa
                cargarComboEstado();
                cargarComboEmpresa();
                cargarComboRol();
                cargarComboUsuario();
                //bloquear combobox
                cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
                cbRutEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
                cbRol.DropDownStyle = ComboBoxStyle.DropDownList;
                cbRutUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
                //combo solo lectura
                cbRutEmpresa.Enabled = false;
                cbRutUsuario.Enabled = false;
                cbRol.Enabled = true;
                cbEstado.Enabled = true;
                //desbloquear cajas de texto                 
                txtPass.ReadOnly = false;
                txtPass2.ReadOnly = false;
                //se pasan datos a cajas de texto de cuadro de datos
                txtPass.Text = _contrasena;
                txtPass2.Text = _contrasena;
                cbRutUsuario.SelectedValue = _rut_usuario;
                cbRutEmpresa.SelectedValue = _rut_empresa;
                cbEstado.SelectedValue = _estado;
                cbRol.SelectedValue = _id_rol;
                //se vacian variables para que no queden con informacion
                _rut_usuario = null;
                _rut_empresa = null;
                _contrasena = null;
                _estado = null;
                _id_rol = null;
                //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
                _guardar = 1;

            }
        }

        private void DgvCuenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _rut_usuario = dgvCuenta.Rows[e.RowIndex].Cells["RUT_USUARIO"].Value.ToString();
            _rut_empresa = dgvCuenta.Rows[e.RowIndex].Cells["RUT_EMPRESA"].Value.ToString();
            _contrasena = dgvCuenta.Rows[e.RowIndex].Cells["CONTRASENA"].Value.ToString();
            _estado = dgvCuenta.Rows[e.RowIndex].Cells["ESTADO"].Value.ToString();
            _id_rol = dgvCuenta.Rows[e.RowIndex].Cells["ID_ROL"].Value.ToString();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            //cambiar titulo
            lblTituloCuadro.Text = "NUEVA CUENTA";
            //habilitar boton guardar
            btnGuardar.Visible = true;
            //desbloquear cajas de texto
            txtPass.ReadOnly = false;
            txtPass2.ReadOnly = false;
            //Cargar comobox de empresa y estado
            cargarComboEstado();
            cargarComboEmpresa();
            cargarComboRol();
            cargarComboUsuario();
            //combo solo lectura
            cbRutEmpresa.Enabled = true;
            cbRutUsuario.Enabled = true;
            cbRol.Enabled = true;
            cbEstado.Enabled = true;
            //vaciar textbox
            txtPass.Text = string.Empty;
            txtPass2.Text = string.Empty;
            //bloquear combobox
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRutEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRutUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = Nuevo)
            _guardar = 2;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {                
                //Instancia de Web service Usuario
                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                //Instancia de Web service Empresa
                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                //Instancia de Web Service Cuenta
                ServiceProcess_Cuenta.Process_CuentaSoapClient auxServiceCuenta = new ServiceProcess_Cuenta.Process_CuentaSoapClient();
                if (_guardar == 1)//Modificar Cuenta
                {
                    //Validacion espacio en blanco y seleccion de combobox
                    if (txtPass.Text.Trim().Equals("") || txtPass2.Text.Trim().Equals("") 
                        || Convert.ToInt32(cbRutEmpresa.SelectedIndex) == 0 || Convert.ToInt32(cbRutUsuario.SelectedIndex) == 0
                        || Convert.ToInt32(cbRol.SelectedIndex) == 0 || Convert.ToInt32(cbEstado.SelectedIndex) == 0)
                    {
                        if (txtPass.Text.Trim().Equals(""))//Mensaje Para contraseña Vacio
                        {
                            MessageBox.Show("El campo Constraseña No puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (txtPass2.Text.Trim().Equals(""))//Mensaje Para confirmacion de contraseña Vacio
                        {
                            MessageBox.Show("EEl campo Confirmar Constraseña No puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (Convert.ToInt32(cbRutEmpresa.SelectedIndex) == 0)//Mensaje Para Combo Empresa Sin seleccionar
                        {
                            MessageBox.Show("Debe seleccionar una Empresa .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (Convert.ToInt32(cbRutUsuario.SelectedIndex) == 0)//Mensaje Para Combo Usuario Sin seleccionar
                        {
                            MessageBox.Show("Debe seleccionar una Usuario .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (Convert.ToInt32(cbRol.SelectedIndex) == 0)//Mensaje Para Combo Rol Sin seleccionar
                        {
                            MessageBox.Show("Debe seleccionar un Rol .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (Convert.ToInt32(cbEstado.SelectedIndex) == 0)//Mensaje Para Combo Estado Sin seleccionar
                        {
                            MessageBox.Show("Debe seleccionar un Estado .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        //Validar longitud de caracteres
                        if (txtPass.Text.Trim().Length < 5 || txtPass.Text.Trim().Length > 25)
                        {
                            if (txtPass.Text.Trim().Length < 5 || txtPass.Text.Trim().Length > 25)//Mensaje longitud fuera de rango contraeña
                            {
                                MessageBox.Show("La Contraseña, debe tener un minimo de 5 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            //Validacion de Contraseña
                            if (!txtPass.Text.Equals(txtPass2.Text))
                            {
                                MessageBox.Show("Las Contraseñas No Coinciden.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                //confirmacion de Actualizar  usuario
                                if (MessageBox.Show("Confirmar La Actualizacion de la Cuenta.", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //Insertar datos via web service tabla usuario
                                    auxServiceCuenta.ActualizarCuentaSinEntidad_Escritorio(cbRutUsuario.SelectedValue.ToString(), cbRutEmpresa.SelectedValue.ToString(),
                                                                                            txtPass2.Text, Convert.ToInt32(cbEstado.SelectedValue.ToString()), Convert.ToInt32(cbRol.SelectedValue.ToString()));
                                    //Metodo Carga de cuadro de datos
                                    cargarDatosEnBlanco();
                                    ////Metodo Carga de GridView
                                    cargarDataGridViewPpal();
                                    MessageBox.Show("Cuenta Actualizada Correctamente.", "ACTUALIZACION DE CUENTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    //se devuelve al Cuadro de datos
                                    MessageBox.Show("NO se Actualizo Cuenta.", "ACTUALIZACION DE CUENTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }

                    }
                }
                else//Nueva Cuenta
                {
                    //Validacion espacio en blanco y seleccion de combobox
                    if (txtPass.Text.Trim().Equals("") || txtPass2.Text.Trim().Equals("")
                        || Convert.ToInt32(cbRutEmpresa.SelectedIndex) == 0 || Convert.ToInt32(cbRutUsuario.SelectedIndex) == 0
                        || Convert.ToInt32(cbRol.SelectedIndex) == 0 || Convert.ToInt32(cbEstado.SelectedIndex) == 0)
                    {
                        if (txtPass.Text.Trim().Equals(""))//Mensaje Para contraseña Vacio
                        {
                            MessageBox.Show("El campo Constraseña No puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (txtPass2.Text.Trim().Equals(""))//Mensaje Para confirmacion de contraseña Vacio
                        {
                            MessageBox.Show("EEl campo Confirmar Constraseña No puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (Convert.ToInt32(cbRutEmpresa.SelectedIndex) == 0)//Mensaje Para Combo Empresa Sin seleccionar
                        {
                            MessageBox.Show("Debe seleccionar una Empresa .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (Convert.ToInt32(cbRutUsuario.SelectedIndex) == 0)//Mensaje Para Combo Usuario Sin seleccionar
                        {
                            MessageBox.Show("Debe seleccionar una Usuario .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (Convert.ToInt32(cbRol.SelectedIndex) == 0)//Mensaje Para Combo Rol Sin seleccionar
                        {
                            MessageBox.Show("Debe seleccionar un Rol .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (Convert.ToInt32(cbEstado.SelectedIndex) == 0)//Mensaje Para Combo Estado Sin seleccionar
                        {
                            MessageBox.Show("Debe seleccionar un Estado .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        //Validar longitud de caracteres
                        if (txtPass.Text.Trim().Length < 5 || txtPass.Text.Trim().Length > 25)
                        {
                            if (txtPass.Text.Trim().Length < 5 || txtPass.Text.Trim().Length > 25)//Mensaje longitud fuera de rango contraeña
                            {
                                MessageBox.Show("La Contraseña, debe tener un minimo de 5 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            //Validacion de Contraseña
                            if (!txtPass.Text.Equals(txtPass2.Text))
                            {
                                MessageBox.Show("Las Contraseñas No Coinciden.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                DataSet ds = auxServiceCuenta.TraerCuentaConEmpresaSinEntidad_Escritorio(cbRutUsuario.SelectedValue.ToString(), cbRutEmpresa.SelectedValue.ToString());
                                if (ds.Tables.Count == 0)
                                {
                                    //confirmacion de Crecion  de cuenta
                                    if (MessageBox.Show("Confirmar La Creacion de la Cuenta.", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //Insertar datos via web service tabla usuario
                                        auxServiceCuenta.InsertarCuentaSinEntidad_Escritorio(cbRutUsuario.SelectedValue.ToString(), cbRutEmpresa.SelectedValue.ToString(),
                                                                                                txtPass2.Text, Convert.ToInt32(cbEstado.SelectedValue.ToString()), Convert.ToInt32(cbRol.SelectedValue.ToString()));
                                        //Metodo Carga de cuadro de datos
                                        cargarDatosEnBlanco();
                                        ////Metodo Carga de GridView
                                        cargarDataGridViewPpal();
                                        MessageBox.Show("Cuenta Creada Correctamente.", "CREACION DE CUENTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        //se devuelve al Cuadro de datos
                                        MessageBox.Show("NO se Actualizo Cuenta.", "CREACION DE CUENTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("La Cuenta Ya existe.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

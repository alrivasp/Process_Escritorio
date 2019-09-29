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
    public partial class FormRol : Form
    {
        //Variables para cargar datos desde el gridview
        public static string _id_rol = null;
        public static string _nombre;
        public static string _estado;
        public static string _id_acceso;
        //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
        public static int _guardar = 0;
        public FormRol()
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
            lblTituloCuadro.Text = "DATOS DE ROL";
            //bloquear cajas de texto
            txtNombre.ReadOnly = true;
            //vaciar cajas de texto
            txtNombre.Text = string.Empty;
            //bloquear combobox
            cbAcceso.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            //vaciar combobox
            cbAcceso.DataSource = null;
            cbAcceso.Items.Clear();
            cbEstado.DataSource = null;
            cbEstado.Items.Clear();
            //inactivar boton guardar
            btnGuardar.Visible = false;
            //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
            _guardar = 0;
        }
        //Metodo Carga GridView 
        private void cargarDataGridViewPpal()
        {
            ServiceProcess_Rol.Process_RolSoapClient auxServiceRol = new ServiceProcess_Rol.Process_RolSoapClient();
            DataSet ds = auxServiceRol.TraerTodasRoles_Escritorio();
            DataTable dt = ds.Tables[0];
            dgvRol.DataSource = dt;
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
        //Metodo Carga ComboBox Accesos
        private void cargarComboAcceso()
        {

            ServiceProcess_Acceso.Process_AccesoSoapClient auxServiceAcceso = new ServiceProcess_Acceso.Process_AccesoSoapClient();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = auxServiceAcceso.TraerTodasAccesos_Escritorio();
            dt = ds.Tables[0];
            DataRow fila = dt.NewRow();
            fila["ID_ACCESO"] = 0;
            fila["NOMBRE"] = "SELECCIONE ACCESO";
            dt.Rows.InsertAt(fila, 0);
            cbAcceso.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAcceso.DataSource = dt;
            cbAcceso.DisplayMember = "NOMBRE";
            cbAcceso.ValueMember = "ID_ACCESO";
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
                ServiceProcess_Rol.Process_RolSoapClient auxServiceRol = new ServiceProcess_Rol.Process_RolSoapClient();
                DataSet ds = auxServiceRol.TraerRolConClaveSinEntidad_Escritorio(txtFiltrar.Text.ToUpper());
                DataTable dt = ds.Tables[0];
                dgvRol.DataSource = dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                DataRow dr = dt.NewRow();
                dt.TableName = "ROL";
                dt.Columns.Add(new DataColumn("ID_ROL"));
                dt.Columns.Add(new DataColumn("NOMBRE"));
                dt.Columns.Add(new DataColumn("ESTADO"));
                dr["ID_ROL"] = "SIN REGISTRO";
                dr["NOMBRE"] = "SIN REGISTRO";
                dr["ESTADO"] = "SIN REGISTRO";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);

                dgvRol.DataSource = ds;

            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (_id_rol == null)//validador que se seleccione un fila de GridView de usuario
            {
                MessageBox.Show("Seleccione una Fila a Modificar", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ServiceProcess_Acceso.Process_AccesoSoapClient auxServiceAcceso = new ServiceProcess_Acceso.Process_AccesoSoapClient();
                ServiceProcess_Permisos.Process_PermisosSoapClient auxServicePermisos = new ServiceProcess_Permisos.Process_PermisosSoapClient();
                ServiceProcess_Permisos.Permisos auxPermisos = new ServiceProcess_Permisos.Permisos();
                auxPermisos = auxServicePermisos.TraerPermisosPorRolConEntidad_Escritorio(Convert.ToInt32(_id_rol));
                _id_acceso = auxPermisos.Id_acceso.ToString();
                //Se edita titulo de cuadro de datos
                lblTituloCuadro.Text = "MODIFICAR ROL";
                //Se habilita Boton
                btnGuardar.Visible = true;
                //Se carga combos de estado y ACCESO
                cargarComboEstado();
                cargarComboAcceso();
                //bloquear combobox
                cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
                cbAcceso.DropDownStyle = ComboBoxStyle.DropDownList;
                //desbloquear cajas de texto                 
                txtNombre.ReadOnly = false;
                //se pasan datos a cajas de texto de cuadro de datos
                txtNombre.Text = _nombre;
                cbAcceso.SelectedValue = _id_acceso;
                cbEstado.SelectedValue = _estado;
                //se vacian variables para que no queden con informacion
                _nombre = null;
                _estado = null;
                _id_acceso = null;
                //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
                _guardar = 1;

            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            //cambiar titulo
            lblTituloCuadro.Text = "NUEVO ROL";
            //habilitar boton guardar
            btnGuardar.Visible = true;
            //desbloquear cajas de texto
            txtNombre.ReadOnly = false;
            //Cargar comobox de region y estado
            cargarComboEstado();
            cargarComboAcceso();
            //vaciar textbox
            txtNombre.Text = string.Empty;
            //bloquear combobox de edicion
            cbAcceso.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            //Habilitar combobox
            cbAcceso.Enabled = true;
            cbEstado.Enabled = true;
            //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = Nuevo)
            _guardar = 2;
        }

        private void DgvRol_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _id_rol = dgvRol.Rows[e.RowIndex].Cells["ID_ROL"].Value.ToString();
            _nombre = dgvRol.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
            _estado = dgvRol.Rows[e.RowIndex].Cells["ESTADO"].Value.ToString();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                //Instancia de Web service permisos, Rol y acceso
                ServiceProcess_Acceso.Process_AccesoSoapClient auxServiceAcceso = new ServiceProcess_Acceso.Process_AccesoSoapClient();
                ServiceProcess_Permisos.Process_PermisosSoapClient auxServicePermisos = new ServiceProcess_Permisos.Process_PermisosSoapClient();
                ServiceProcess_Rol.Process_RolSoapClient auxServiceRol = new ServiceProcess_Rol.Process_RolSoapClient();
                if (_guardar == 1)//Modificar ROL
                {
                    //Validacion espacio en blanco y seleccion de combobox
                    if (txtNombre.Text.Trim().Equals("") || Convert.ToInt32(cbAcceso.SelectedIndex) == 0 || Convert.ToInt32(cbEstado.SelectedIndex) == 0)
                    {
                        if (txtNombre.Text.Trim().Equals(""))//Mensaje Para Nombre
                        {
                            MessageBox.Show("El campo Nombre No puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (Convert.ToInt32(cbAcceso.SelectedIndex) == 0)//Mensaje Para Combo Acceso Sin seleccionar
                        {
                            MessageBox.Show("Debe seleccionar un Acceso .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (Convert.ToInt32(cbEstado.SelectedIndex) == 0)//Mensaje Para Combo Estado Sin seleccionar
                        {
                            MessageBox.Show("Debe seleccionar un Estado .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        //Validar longitud de caracteres
                        if (txtNombre.Text.Trim().Length < 2 || txtNombre.Text.Trim().Length > 50)
                        {
                            if (txtNombre.Text.Trim().Length < 2 || txtNombre.Text.Trim().Length > 50)//Mensaje longitud fuera de rango nombre
                            {
                                MessageBox.Show("El Nombre, debe tener un minimo de 2 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }


                        }
                        else
                        {

                            //confirmacion de Actualizar  ROL
                            if (MessageBox.Show("Confirmar La Actualizacion del Rol.", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //Insertar datos via web service tabla ROL
                                auxServiceRol.ActualizarRolSinEntidad_Escritorio(Convert.ToInt32(_id_rol), txtNombre.Text, Convert.ToInt32(cbEstado.SelectedValue.ToString()));
                                //Insertar datos via web service tabla cargo_usuario
                                auxServicePermisos.ActualizarPermisosSinEntidad_Escritorio(Convert.ToInt32(_id_rol), Convert.ToInt32(cbAcceso.SelectedValue.ToString()));
                                //Metodo Carga de cuadro de datos
                                cargarDatosEnBlanco();
                                ////Metodo Carga de GridView
                                cargarDataGridViewPpal();
                                MessageBox.Show("Rol Actualizado Correctamente.", "ACTUALIZACION DE ROL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _id_rol = null;
                            }
                            else
                            {
                                //se devuelve al Cuadro de datos
                                MessageBox.Show("NO se Actualizo Rol.", "ACTUALIZACION DE ROL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }



                        }

                    }
                }
                else//Nuevo Rol
                {
                    //Validacion espacio en blanco y seleccion de combobox
                    if (txtNombre.Text.Trim().Equals("") || Convert.ToInt32(cbAcceso.SelectedIndex) == 0 || Convert.ToInt32(cbEstado.SelectedIndex) == 0)
                    {
                        if (txtNombre.Text.Trim().Equals(""))//Mensaje Para nombre Vacio
                        {
                            MessageBox.Show("El campo Nombre No puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (Convert.ToInt32(cbAcceso.SelectedIndex) == 0)//Mensaje Para Combo Acceso Sin seleccionar
                        {
                            MessageBox.Show("Debe seleccionar un Acceso .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (Convert.ToInt32(cbEstado.SelectedIndex) == 0)//Mensaje Para Combo Estado Sin seleccionar
                        {
                            MessageBox.Show("Debe seleccionar un Estado .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        //Validar longitud de caracteres
                        if (txtNombre.Text.Trim().Length < 2 || txtNombre.Text.Trim().Length > 70)
                        {
                            if (txtNombre.Text.Trim().Length < 2 || txtNombre.Text.Trim().Length > 70)//Mensaje longitud fuera de rango  nombre
                            {
                                MessageBox.Show("El Nombre, debe tener un minimo de 2 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }
                        else
                        {
                            ServiceProcess_Rol.Rol auxRol = new ServiceProcess_Rol.Rol();
                            DataSet ds = auxServiceRol.TraerRolPorNombreSinEntidad_Escritorio(txtNombre.Text.ToUpper());
                            //Validacion si existe Usuario
                            if (ds.Tables.Count == 0)
                            {
                                //confirmacion de crear nuevo usuario
                                if (MessageBox.Show("Confirmar La Creacion del Rol.", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //Insertar datos via web service tabla Rol
                                    auxServiceRol.InsertarRolSinEntidad_Escritorio(txtNombre.Text.ToUpper(), Convert.ToInt32(cbEstado.SelectedValue.ToString()));
                                    //Consultar nombre de rol insertado
                                    auxRol = auxServiceRol.TraerRolPorNombreConEntidad_Escritorio(txtNombre.Text.ToUpper());
                                    int id_rol = auxRol.Id_rol;
                                    //Insertar datos via web service tabla Permisos
                                    auxServicePermisos.InsertarPermisosSinEntidad_Escritorio(Convert.ToInt32(cbAcceso.SelectedValue.ToString()), id_rol);
                                    //Metodo Carga de cuadro de datos
                                    cargarDatosEnBlanco();
                                    ////Metodo Carga de GridView
                                    cargarDataGridViewPpal();
                                    MessageBox.Show("Rol Creado Correctamente.", "CREACION DE ROL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    //se devuelve al Cuadro de datos
                                    MessageBox.Show("Se cancelo la creacion del Rol.", "CREACION DE ROL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                            }
                            else
                            {                                
                                MessageBox.Show("El Rol Ya existe.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

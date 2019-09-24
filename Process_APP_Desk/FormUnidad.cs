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
    public partial class FormUnidad : Form
    {
        //Carga de Web Service
        ServiceProcess_Unidad.Process_UnidadSoapClient auxServiceUnidad = new ServiceProcess_Unidad.Process_UnidadSoapClient();
        ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
        //Variables para cargar datos desde el gridview
        public static string _id_unidad = null;
        public static string _nombre;       
        public static string _descripcion;
        public static string _estado;
        public static string _rut_empresa;
        //Variables de verificacion
        public static string _id_unidad_enviar;
        public static string _nombre_consulta;
        public static string _rut_empresa_consulta;
        //Variable para interaccion de botones (0 = modificar) - (1 = guardar)
        public static int _guardar = 0;
        public FormUnidad()
        {
            InitializeComponent();
            //Metodo Carga de GridView
            cargarDataGridViewPpal();
            //Metodo Carga Cuadro de Datos en Blanco
            cargarDatosEnBlanco();
        }
        //Metodo Carga Cuadro de Datos en Blanco
        private void cargarDatosEnBlanco()
        {
            //CAMBIO DE TITULO DE CUADRO DE DATOS
            lblTituloCuadro.Text = "DATOS DE UNIDAD";
            //bloquear cajas de texto
            txtNombre.ReadOnly = true;
            txtDescripcion.ReadOnly = true;
            //vaciar cajas de texto
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;           
            //bloquear combobox
            cbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            //vaciar combobox
            cbEmpresa.DataSource = null;
            cbEmpresa.Items.Clear();
            cbEstado.DataSource = null;
            cbEstado.Items.Clear();            
            //inactivar boton guaradar
            btnGuardar.Visible = false;
            //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
            _guardar = 0;
        }
        //Metodo Carga de GridView
        private void cargarDataGridViewPpal()
        {
            DataSet ds = auxServiceUnidad.TraerTodasUnidades_Escritorio();
            DataTable dt = ds.Tables[0];
            dgvUnidad.DataSource = dt;
        }
        //Boton Cerrar
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            System.GC.Collect();
        }

        private void TxtFiltrar_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                DataSet ds = auxServiceUnidad.TraerUnidadConClaveSinEntidad_Escritorio(txtFiltrar.Text.ToUpper());
                DataTable dt = ds.Tables[0];
                dgvUnidad.DataSource = dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                DataRow dr = dt.NewRow();
                dt.TableName = "Unidad";
                dt.Columns.Add(new DataColumn("ID_UNIDAD"));
                dt.Columns.Add(new DataColumn("NOMBRE"));
                dt.Columns.Add(new DataColumn("DESCRIPCION"));                
                dt.Columns.Add(new DataColumn("ESTADO"));
                dt.Columns.Add(new DataColumn("RUT_EMPRESA"));
                dr["ID_UNIDAD"] = "SIN REGISTRO";
                dr["NOMBRE"] = "SIN REGISTRO";
                dr["DESCRIPCION"] = "SIN REGISTRO";
                dr["ESTADO"] = "SIN REGISTRO";
                dr["RUT_EMPRESA"] = "SIN REGISTRO";                
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);

                dgvUnidad.DataSource = ds;

            }
        }

        //Metodo Carga ComboBox Empresa
        private void cargarComboEmpresa()
        {
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

        private void DgvUnidad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _id_unidad = dgvUnidad.Rows[e.RowIndex].Cells["ID_UNIDAD"].Value.ToString();
            _nombre = dgvUnidad.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
            _descripcion = dgvUnidad.Rows[e.RowIndex].Cells["DESCRIPCION"].Value.ToString();
            _estado = dgvUnidad.Rows[e.RowIndex].Cells["ESTADO"].Value.ToString();
            _rut_empresa = dgvUnidad.Rows[e.RowIndex].Cells["RUT_EMPRESA"].Value.ToString();
            //variables de validacion
            _id_unidad_enviar = dgvUnidad.Rows[e.RowIndex].Cells["ID_UNIDAD"].Value.ToString();
            _nombre_consulta = dgvUnidad.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
            _rut_empresa_consulta = dgvUnidad.Rows[e.RowIndex].Cells["RUT_EMPRESA"].Value.ToString();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (_id_unidad == null)//validador que se seleccione un fila de UNIDAD
            {
                MessageBox.Show("Seleccione una Fila a Modificar", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {               
                //Se edita titulo de cuadro de datos
                lblTituloCuadro.Text = "MODIFICAR UNIDAD";
                //Se habilita Boton
                btnGuardar.Visible = true;
                //Se cargam comnbos de estado y empresa
                cargarComboEstado();
                cargarComboEmpresa();
                //bloquear combobox
                cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
                cbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
                //combo solo lectura
                cbEmpresa.Enabled = false;
                //desbloquear cajas de texto                 
                txtNombre.ReadOnly = false;
                txtDescripcion.ReadOnly = false;                
                //se pasan datos a cajas de texto de cuadro de datos
                txtNombre.Text = _nombre;
                txtDescripcion.Text = _descripcion;
                cbEmpresa.SelectedValue = _rut_empresa;
                cbEstado.SelectedValue = _estado;                    
                //se vacian variables para que no queden con informacion
                _id_unidad = null;
                _nombre = null;
                _descripcion = null;                
                _estado = null;
                _rut_empresa = null;
               //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
               _guardar = 1;
                
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            //cambiar titulo
            lblTituloCuadro.Text = "NUEVA UNIDAD";
            //habilitar boton guardar
            btnGuardar.Visible = true;
            //desbloquear cajas de texto
            txtNombre.ReadOnly = false;
            txtDescripcion.ReadOnly = false;
            //Cargar comobox de empresa y estado
            cargarComboEstado();
            cargarComboEmpresa();
            //combo solo lectura
            cbEmpresa.Enabled = true;
            //vaciar textbox
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            //bloquear combobox
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;       
            //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = Nuevo)
            _guardar = 2;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (_guardar == 1)//Modificar Unidad
                {
                    //Validacion espacion en blanco y combobox vacios
                    if (txtNombre.Text.Equals("") || txtDescripcion.Text.Equals("") || cbEstado.SelectedValue.ToString().Equals(""))
                    {
                        MessageBox.Show("Debe Completar todos los campos.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //Validacion numero de caracteres minimo para  Unidad
                        if (txtNombre.Text.Trim().Length < 8 || txtDescripcion.Text.Trim().Length < 8)
                        {
                            MessageBox.Show("La Informacion Ingresada debe ser superior a 8 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //Validar si se modifica nombre de Unidad
                            if (_nombre_consulta.ToUpper().Equals(txtNombre.Text.ToUpper()))//NO se modifica nombre de Unidad
                            {
                                //confirmacion de modificar Unidad
                                if (MessageBox.Show("Confirmar La Modificacion de la Unidad Seleccionada", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //actualizar datos via web service
                                    auxServiceUnidad.ActualizarUnidadSinEntidad_Escritorio(Convert.ToInt32(_id_unidad_enviar), txtNombre.Text.ToUpper(), txtDescripcion.Text.ToUpper(), Convert.ToInt32(cbEstado.SelectedValue), _rut_empresa_consulta);
                                    //Metodo Carga de cuadro de datos
                                    cargarDatosEnBlanco();
                                    //Metodo Carga de GridView
                                    cargarDataGridViewPpal();
                                    //Vaciar variables de consulta
                                    _id_unidad_enviar = string.Empty;
                                    _nombre_consulta = string.Empty;
                                    _rut_empresa_consulta = string.Empty;
                                }
                                else
                                {
                                    //se devuelve al Cuadro de datos
                                }
                            }
                            else//SI se modifica nombre de Unidad
                            {
                                //carga clase Unidad
                                ServiceProcess_Unidad.Unidad auxUnidad = new ServiceProcess_Unidad.Unidad();
                                auxUnidad = auxServiceUnidad.TraerUnidadPorNombrePorEmpresaConEntidad_Escritorio(txtNombre.Text.ToUpper(), _rut_empresa_consulta);
                                //Validar si Nombre Unidad ya existe en la empresa
                                if (auxUnidad.Nombre == null)
                                {
                                    //confirmacion de modificar Unidad
                                    if (MessageBox.Show("Confirmar La Modificacion de la Unidad Seleccionada", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //actualizar datos via web service
                                        auxServiceUnidad.ActualizarUnidadSinEntidad_Escritorio(Convert.ToInt32(_id_unidad_enviar), txtNombre.Text.ToUpper(), txtDescripcion.Text.ToUpper(), Convert.ToInt32(cbEstado.SelectedValue), _rut_empresa_consulta);
                                        //Metodo Carga de cuadro de datos
                                        cargarDatosEnBlanco();
                                        //Metodo Carga de GridView
                                        cargarDataGridViewPpal();
                                        //Vaciar variables de consulta
                                        _id_unidad_enviar = string.Empty;
                                        _nombre_consulta = string.Empty;
                                        _rut_empresa_consulta = string.Empty;
                                    }
                                    else
                                    {
                                        //se devuelve al Cuadro de datos
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Este Nombre de Unidad ya Existe en la Empresa", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);                                    
                                }
                            }   
                        }
                    }
                }
                else//Nueva Unidad
                {
                    //Validacion espacion en blanco y combobox vacios
                    if (txtNombre.Text.Equals("") || txtDescripcion.Text.Equals("") || Convert.ToInt32(cbEmpresa.SelectedIndex) == 0 || cbEstado.SelectedValue.ToString().Equals(""))
                    {
                        MessageBox.Show("Debe Completar todos los campos.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //Validacion numero de caracteres minumo para  8 
                        if (txtNombre.Text.Trim().Length < 4 || txtDescripcion.Text.Trim().Length < 8)
                        {
                            MessageBox.Show("La Informacion Ingresada debe ser superior a 8 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //carga clase Unidad
                            ServiceProcess_Unidad.Unidad auxUnidad = new ServiceProcess_Unidad.Unidad();
                            auxUnidad = auxServiceUnidad.TraerUnidadPorNombrePorEmpresaConEntidad_Escritorio(txtNombre.Text.ToUpper(), cbEmpresa.SelectedValue.ToString());
                            //Validar si Nombre Unidad ya existe en la empresa
                            if (auxUnidad.Nombre == null)
                            {
                                //confirmacion de modificar Unidad
                                if (MessageBox.Show("Confirmar La Creacion de la Unidad", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {                                    
                                    //Insertar datos via web service
                                    auxServiceUnidad.InsertarUnidadSinEntidad_Escritorio(txtNombre.Text.ToUpper(), txtDescripcion.Text.ToUpper(), Convert.ToInt32(cbEstado.SelectedValue), cbEmpresa.SelectedValue.ToString());
                                    //Metodo Carga de cuadro de datos
                                    cargarDatosEnBlanco();
                                    //Metodo Carga de GridView
                                    cargarDataGridViewPpal();
                                    //Vaciar variables de consulta
                                    _id_unidad_enviar = string.Empty;
                                    _nombre_consulta = string.Empty;
                                    _rut_empresa_consulta = string.Empty;
                                }
                                else
                                {
                                    //se devuelve al Cuadro de datos
                                }
                            }
                            else
                            {
                                MessageBox.Show("Este Nombre de Unidad ya Existe en la Empresa Seleccionada", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }//fin if principal
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("Web Service Process Fuera de Linea, Contactese con el Administrador Detalle de Error: " + ex.Message, "Mensaje de sistema");

            //}//fin try catch
        }
    }
}

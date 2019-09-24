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
    public partial class FormCargo : Form
    {
        //Variables para cargar datos desde el gridview
        public static string _id_cargo = null;
        public static string _nombre;
        public static string _descripcion;
        public static string _rut_empresa;
        //Variables de verificacion
        public static string _id_cargo_enviar;
        public static string _nombre_consulta;
        public static string _rut_empresa_consulta;
        //Variable para interaccion de botones (0 = modificar) - (1 = guardar)
        public static int _guardar = 0;
        public FormCargo()
        {
            InitializeComponent();
            //Metodo Carga de GridView
            cargarDataGridViewPpal();
            //Metodo Carga Cuadro de Datos en Blanco
            cargarDatosEnBlanco();
        }

        private void cargarDatosEnBlanco()
        {
            //CAMBIO DE TITULO DE CUADRO DE DATOS
            lblTituloCuadro.Text = "DATOS DE CARGO";
            //bloquear cajas de texto
            txtNombre.ReadOnly = true;
            txtDescripcion.ReadOnly = true;
            //vaciar cajas de texto
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            //bloquear combobox
            cbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;            
            //vaciar combobox
            cbEmpresa.DataSource = null;
            cbEmpresa.Items.Clear();
            //inactivar boton guaradar
            btnGuardar.Visible = false;            
            //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
            _guardar = 0;
        }

        private void cargarDataGridViewPpal()
        {
            //Carga de Web Service
            ServiceProcess_Cargo.Process_CargoSoapClient auxServiceCargo = new ServiceProcess_Cargo.Process_CargoSoapClient();

            DataSet ds = auxServiceCargo.TraerTodasCargos_Escritorio();
            DataTable dt = ds.Tables[0];
            dgvCargo.DataSource = dt;
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
                ServiceProcess_Cargo.Process_CargoSoapClient auxServiceCargo = new ServiceProcess_Cargo.Process_CargoSoapClient();
                DataSet ds = auxServiceCargo.TraerCargoConClaveSinEntidad_Escritorio(txtFiltrar.Text.ToUpper());
                DataTable dt = ds.Tables[0];
                dgvCargo.DataSource = dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                DataRow dr = dt.NewRow();
                dt.TableName = "Cargo";
                dt.Columns.Add(new DataColumn("ID_UNIDAD"));
                dt.Columns.Add(new DataColumn("NOMBRE"));
                dt.Columns.Add(new DataColumn("DESCRIPCION"));
                dt.Columns.Add(new DataColumn("RUT_EMPRESA"));
                dr["ID_UNIDAD"] = "SIN REGISTRO";
                dr["NOMBRE"] = "SIN REGISTRO";
                dr["DESCRIPCION"] = "SIN REGISTRO";                
                dr["RUT_EMPRESA"] = "SIN REGISTRO";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);

                dgvCargo.DataSource = ds;

            }
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

        private void DgvCargo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _id_cargo = dgvCargo.Rows[e.RowIndex].Cells["ID_CARGO"].Value.ToString();
            _nombre = dgvCargo.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
            _descripcion = dgvCargo.Rows[e.RowIndex].Cells["DESCRIPCION"].Value.ToString();
            _rut_empresa = dgvCargo.Rows[e.RowIndex].Cells["RUT_EMPRESA"].Value.ToString();
            //variables de validacion
            _id_cargo_enviar = dgvCargo.Rows[e.RowIndex].Cells["ID_CARGO"].Value.ToString();
            _nombre_consulta = dgvCargo.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
            _rut_empresa_consulta = dgvCargo.Rows[e.RowIndex].Cells["RUT_EMPRESA"].Value.ToString();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (_id_cargo == null)//validador que se seleccione un fila de Cargo
            {
                MessageBox.Show("Seleccione una Fila a Modificar", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Se edita titulo de cuadro de datos
                lblTituloCuadro.Text = "MODIFICAR CARGO";
                //Se habilita Boton               
                btnGuardar.Visible = true;
                //Se cargam comnbos de estado y empresa                
                cargarComboEmpresa();
                //bloquear combobox
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
                //se vacian variables para que no queden con informacion
                _id_cargo = null;
                _nombre = null;
                _descripcion = null;                
                _rut_empresa = null;
                //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
                _guardar = 1;

            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            //cambiar titulo
            lblTituloCuadro.Text = "NUEVO CARGO";
            //habilitar boton guardar
            btnGuardar.Visible = true;
            //desbloquear cajas de texto
            txtNombre.ReadOnly = false;
            txtDescripcion.ReadOnly = false;
            //Cargar comobox de empresa y estado            
            cargarComboEmpresa();
            //combo solo lectura
            cbEmpresa.Enabled = true;
            //vaciar textbox
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            //bloquear combobox
            cbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
            //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = Nuevo)
            _guardar = 2;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            //try
            //{
            ServiceProcess_Cargo.Process_CargoSoapClient auxServiceCargo = new ServiceProcess_Cargo.Process_CargoSoapClient();
            if (_guardar == 1)//Modificar Cargo
            {
                //Validacion espacion en blanco y combobox vacios
                if (txtNombre.Text.Equals("") || txtDescripcion.Text.Equals("") )
                {
                    MessageBox.Show("Debe Completar todos los campos.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Validacion numero de caracteres minimo para  Cargo
                    if (txtNombre.Text.Trim().Length < 3 || txtDescripcion.Text.Trim().Length < 10)
                    {
                        MessageBox.Show("El Nombre debe ser superior a 2 Caracteres y la Descripcion superior a 10.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //Validar si se modifica nombre de Cargo
                        if (_nombre_consulta.ToUpper().Equals(txtNombre.Text.ToUpper()))//NO se modifica nombre de Cargo
                        {
                            //confirmacion de modificar Unidad
                            if (MessageBox.Show("Confirmar La Modificacion de el Cargo Seleccionado.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //actualizar datos via web service
                                auxServiceCargo.ActualizarCargoSinEntidad_Escritorio(Convert.ToInt32(_id_cargo_enviar), txtNombre.Text.ToUpper(), txtDescripcion.Text.ToUpper(),  _rut_empresa_consulta);
                                //Metodo Carga de cuadro de datos
                                cargarDatosEnBlanco();
                                //Metodo Carga de GridView
                                cargarDataGridViewPpal();
                                //Vaciar variables de consulta
                                _id_cargo_enviar = string.Empty;
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
                            ServiceProcess_Cargo.Cargo auxCargo = new ServiceProcess_Cargo.Cargo();
                            auxCargo = auxServiceCargo.TraerCargoPorNombrePorEmpresaConEntidad_Escritorio(txtNombre.Text.ToUpper(), _rut_empresa_consulta);
                            //Validar si Nombre Unidad ya existe en la empresa
                            if (auxCargo.Nombre == null)
                            {
                                //confirmacion de modificar Unidad
                                if (MessageBox.Show("Confirmar La Modificacion del Cargo Seleccionado.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //actualizar datos via web service
                                    auxServiceCargo.ActualizarCargoSinEntidad_Escritorio(Convert.ToInt32(_id_cargo_enviar), txtNombre.Text.ToUpper(), txtDescripcion.Text.ToUpper(), _rut_empresa_consulta);
                                    //Metodo Carga de cuadro de datos
                                    cargarDatosEnBlanco();
                                    //Metodo Carga de GridView
                                    cargarDataGridViewPpal();
                                    //Vaciar variables de consulta
                                    _id_cargo_enviar = string.Empty;
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
                                MessageBox.Show("Este Nombre de Cargo ya Existe en la Empresa", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            else//Nueva Unidad
            {
                //Validacion espacion en blanco y combobox vacios
                if (txtNombre.Text.Equals("") || txtDescripcion.Text.Equals("") || Convert.ToInt32(cbEmpresa.SelectedIndex) == 0)
                {
                    MessageBox.Show("Debe Completar todos los Campos.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Validacion numero de caracteres minumo para  8 
                    if (txtNombre.Text.Trim().Length < 4 || txtDescripcion.Text.Trim().Length < 8)
                    {
                        MessageBox.Show("El Nombre debe ser superior a 2 Caracteres y la Descripcion superior a 10.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //carga clase Unidad
                        ServiceProcess_Cargo.Cargo auxCargo = new ServiceProcess_Cargo.Cargo();
                        auxCargo = auxServiceCargo.TraerCargoPorNombrePorEmpresaConEntidad_Escritorio(txtNombre.Text.ToUpper(), cbEmpresa.SelectedValue.ToString());
                        //Validar si Nombre Unidad ya existe en la empresa
                        if (auxCargo.Nombre == null)
                        {
                            //confirmacion de modificar Unidad
                            if (MessageBox.Show("Confirmar La Creacion del Cargo", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //Insertar datos via web service
                                auxServiceCargo.InsertarCargoSinEntidad_Escritorio(txtNombre.Text.ToUpper(), txtDescripcion.Text.ToUpper(), cbEmpresa.SelectedValue.ToString());
                                //Metodo Carga de cuadro de datos
                                cargarDatosEnBlanco();
                                //Metodo Carga de GridView
                                cargarDataGridViewPpal();
                                //Vaciar variables de consulta
                                _id_cargo_enviar = string.Empty;
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
                            MessageBox.Show("Este Nombre de Cargo ya Existe en la Empresa Seleccionada", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

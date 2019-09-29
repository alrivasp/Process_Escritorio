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
    public partial class FormEmpresa : Form
    {
        //Carga de Web Service
        ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
        ServiceProcess_Region.Process_RegionSoapClient auxServiceRegion = new ServiceProcess_Region.Process_RegionSoapClient();
        ServiceProcess_Provincia.Process_ProvinciaSoapClient auxServiceProvincia = new ServiceProcess_Provincia.Process_ProvinciaSoapClient();
        ServiceProcess_Comuna.Process_ComunaSoapClient auxServiceComuna = new ServiceProcess_Comuna.Process_ComunaSoapClient();
        ServiceProcess_Validadores.Process_ValidadoresSoapClient auxServiceValidadores = new ServiceProcess_Validadores.Process_ValidadoresSoapClient();
        //Variables para cargar datos desde el gridview
        public static string _rut_empresa = null;
        public static string _nombre;
        public static string _giro;
        public static string _direccion;
        public static string _estado;
        public static string _id_comuna;
        //Variable para interaccion de botones (0 = modificar) - (1 = guardar)
        public static int _guardar = 0;        
        public FormEmpresa()
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
            lblTituloCuadro.Text = "DATOS DE EMPRESA";
            //bloquear cajas de texto
            txtRutEmpresa.ReadOnly = true;
            txtNombreEmpresa.ReadOnly = true;
            txtGiro.ReadOnly = true;
            txtDireccion.ReadOnly = true;
            //vaciar cajas de texto
            txtRutEmpresa.Text = string.Empty;
            txtNombreEmpresa.Text = string.Empty;
            txtGiro.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            //bloquear combobox
            cbRegion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
            cbComuna.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            //vaciar combobox
            cbRegion.DataSource = null;
            cbRegion.Items.Clear();
            cbProvincia.DataSource = null;
            cbProvincia.Items.Clear();
            cbComuna.DataSource = null;
            cbComuna.Items.Clear();
            cbEstado.DataSource = null;
            cbEstado.Items.Clear();
            //inactivar boton guaradar
            btnGuardar.Visible = false;
            //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
            _guardar = 0;

        }
        //Metodo Carga ComboBox Comuna
        public void cargarComboComuna(int _id_provincia)
        {
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
        //Metodo Carga GridView 
        private void cargarDataGridViewPpal()
        {
            DataSet ds = auxServiceEmpresa.TraerTodasEmpresas_Escritorio();
            DataTable dt = ds.Tables[0];
            dgvEmpresas.DataSource = dt;
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
        //Metodo Boton Cerrar
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            System.GC.Collect();
        }
        //Metodo Accion para filtrar automatico
        private void TxtFiltrar_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                DataSet ds = auxServiceEmpresa.TraerEmpresaConClaveSinEntidad_Escritorio(txtFiltrar.Text.ToUpper());
                DataTable dt = ds.Tables[0];
                dgvEmpresas.DataSource = dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                DataRow dr = dt.NewRow();
                dt.TableName = "Empresa";
                dt.Columns.Add(new DataColumn("Rut_empresa"));
                dt.Columns.Add(new DataColumn("Nombre"));
                dt.Columns.Add(new DataColumn("Giro"));
                dt.Columns.Add(new DataColumn("Direccion"));
                dt.Columns.Add(new DataColumn("Estado"));
                dt.Columns.Add(new DataColumn("Id_comuna"));
                dr["Rut_empresa"] = "SIN REGISTRO";
                dr["Nombre"] = "SIN REGISTRO";
                dr["Giro"] = "SIN REGISTRO";
                dr["Direccion"] = "SIN REGISTRO";
                dr["Estado"] = "SIN REGISTRO";
                dr["Id_comuna"] = "SIN REGISTRO";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                
                dgvEmpresas.DataSource = ds;
                
            }
                        
        }
        //Metodo Poblar combo provicnica segun seleccion de region
        private void CbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbRegion.SelectedIndex) > 0)
            {
                int id_region = Convert.ToInt32(cbRegion.SelectedIndex);
                cargarComboProvincia(id_region);
            }
        }
        //Metodo Poblar combo comuna segun seleccion de provincia
        private void CbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbProvincia.SelectedIndex) > 0)
            {
                int id_provincia = Convert.ToInt32(cbProvincia.SelectedValue);
                cargarComboComuna(id_provincia);
            }
        }
        //Metodo Boton Nuevo
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            //cambiar titulo
            lblTituloCuadro.Text = "NUEVA EMPRESA";
            //habilitar boton guardar
            btnGuardar.Visible = true;            
            //desbloquear cajas de texto
            txtRutEmpresa.ReadOnly = false;
            txtNombreEmpresa.ReadOnly = false;
            txtGiro.ReadOnly = false;
            txtDireccion.ReadOnly = false;
            //Cargar comobox de region y estado
            cargarComboEstado();
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
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            //vaciar combobox
            cbProvincia.DataSource = null;
            cbProvincia.Items.Clear();
            cbComuna.DataSource = null;
            cbComuna.Items.Clear();
            //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = Nuevo)
            _guardar = 2;

        }
        //Metodo Boton Modificar
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (_rut_empresa == null)//validador que se seleccione un fila de empresa
            {               
                MessageBox.Show("Seleccione una Fila a Modificar", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (_rut_empresa.Equals("82982300"))//No se puede editar la empresa dueña del software
                {
                    MessageBox.Show("La Empresa Process S.A. NO se puede Modificar", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
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
                    //Se edita titulo de cuadro de datos
                    lblTituloCuadro.Text = "MODIFICAR EMPRESA";
                    //Se habilita Boton
                    btnGuardar.Visible = true;
                    //Se carga combos de estado y region
                    cargarComboEstado();
                    cargarComboRegion();
                    //bloquear combobox
                    cbRegion.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbComuna.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
                    //se inactiva txtbox de rut de empresa
                    txtRutEmpresa.ReadOnly = true;
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
                    cbEstado.SelectedValue = _estado;
                    //se vacian variables para que no queden con informacion
                    _rut_empresa = null;
                    _nombre = null;
                    _giro = null;
                    _direccion = null;
                    _estado = null;
                    _id_comuna = null;
                    //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar)
                    _guardar = 1;
                }
            }            
        }        
        //Accion para rescatar fila eleginda del gridview
        private void DgvEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _rut_empresa = dgvEmpresas.Rows[e.RowIndex].Cells["RUT_EMPRESA"].Value.ToString();
            _nombre = dgvEmpresas.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
            _giro = dgvEmpresas.Rows[e.RowIndex].Cells["GIRO"].Value.ToString();
            _direccion = dgvEmpresas.Rows[e.RowIndex].Cells["DIRECCION"].Value.ToString();
            _estado = dgvEmpresas.Rows[e.RowIndex].Cells["ESTADO"].Value.ToString();
            _id_comuna = dgvEmpresas.Rows[e.RowIndex].Cells["ID_COMUNA"].Value.ToString();
        }
        //Metodo Boton Guardar
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_guardar == 1)//Modificar empresa
                {
                    //Validacion espacion en blanco y combobox vacios
                    if (txtRutEmpresa.Text.Equals("") || txtNombreEmpresa.Text.Equals("") || txtGiro.Text.Equals("") || txtDireccion.Text.Equals("") || Convert.ToInt32(cbRegion.SelectedIndex) == 0 || cbProvincia.SelectedValue == null || cbComuna.SelectedValue == null || cbEstado.SelectedValue.ToString().Equals(""))
                    {
                        MessageBox.Show("Debe Completar todos los campos.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //Validacion numero de caracteres minumo para rut 8 
                        if (txtRutEmpresa.Text.Trim().Length < 8 || txtNombreEmpresa.Text.Trim().Length < 4 || txtGiro.Text.Trim().Length < 4 || txtDireccion.Text.Trim().Length < 4)
                        {
                            MessageBox.Show("La Informacion Ingresada debe ser superior a 4 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //confirmacion de crear nueva empresa
                            if (MessageBox.Show("Confirmar La Modificacion de la Empresa Seleccionada", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //Insertar datos via web service
                                auxServiceEmpresa.ActualizarEmpresaSinEntidad_Escritorio(txtRutEmpresa.Text.ToUpper(), txtNombreEmpresa.Text.ToUpper(), txtGiro.Text.ToUpper(), txtDireccion.Text.ToUpper(), Convert.ToInt32(cbEstado.SelectedValue), Convert.ToInt32(cbComuna.SelectedValue));
                                //Metodo Carga de cuadro de datos
                                cargarDatosEnBlanco();
                                //Metodo Carga de GridView
                                cargarDataGridViewPpal();
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
                    if (txtRutEmpresa.Text.Equals("") || txtNombreEmpresa.Text.Equals("") || txtGiro.Text.Equals("") || txtDireccion.Text.Equals("") || Convert.ToInt32(cbRegion.SelectedIndex) == 0 || cbProvincia.SelectedValue == null || cbComuna.SelectedValue == null || cbEstado.SelectedValue.ToString().Equals(""))
                    {
                        MessageBox.Show("Debe Completar todos los campos.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //Validacion numero de caracteres minumo para rut 8 
                        if (txtRutEmpresa.Text.Trim().Length < 8 || txtNombreEmpresa.Text.Trim().Length < 4 || txtGiro.Text.Trim().Length < 4 || txtDireccion.Text.Trim().Length < 4)
                        {
                            MessageBox.Show("La Informacion Ingresada debe ser superior a 4 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                    if (MessageBox.Show("Confirmar Creacion de Nueva Empresa", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //Insertar datos via web service
                                        auxServiceEmpresa.InsertarEmpresaSinEntidad_Escritorio(txtRutEmpresa.Text.ToUpper(), txtNombreEmpresa.Text.ToUpper(), txtGiro.Text.ToUpper(), txtDireccion.Text.ToUpper(), Convert.ToInt32(cbEstado.SelectedValue), Convert.ToInt32(cbComuna.SelectedValue));
                                        //Metodo Carga de cuadro de datos
                                        cargarDatosEnBlanco();
                                        //Metodo Carga de GridView
                                        cargarDataGridViewPpal();
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

                MessageBox.Show("Web Service Process Fuera de Linea, Contactese con el Administrador Detalle de Error: " + ex.Message, "Mensaje de sistema");

            }//fin try catch
        }//Fin Boton Guardar
    }
}

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
    public partial class FormEquipoModal : Form
    {
        //variables de apoyo
        public static string _rut_empresa = null;
        public static string _id_unidad = null;
        public static string _id_equipo = null;
        public static string _nombre = null;
        public static string _guardar = null;

        public FormEquipoModal()
        {
            InitializeComponent();
        }

        public FormEquipoModal(string titulo_modal, string accion, string id_equipo, string rut_empresa, string id_unidad)
        {
            InitializeComponent();
            try
            {
                if (Convert.ToInt32(accion) == 1)
                {

                    ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                    auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                    auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                    ServiceProcess_Equipo.Process_EquipoSoapClient auxServiceEquipo = new ServiceProcess_Equipo.Process_EquipoSoapClient();
                    auxServiceEquipo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                    auxServiceEquipo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                    ServiceProcess_Unidad.Process_UnidadSoapClient auxServiceUnidad = new ServiceProcess_Unidad.Process_UnidadSoapClient();
                    auxServiceUnidad.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                    auxServiceUnidad.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                   
                    ServiceProcess_Unidad.Unidad auxUnidad = new ServiceProcess_Unidad.Unidad();
                    ServiceProcess_Equipo.Equipo auxEquipo = new ServiceProcess_Equipo.Equipo();
                    ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();

                    auxEquipo = auxServiceEquipo.TraerEquipoConEntidad_Escritorio(Convert.ToInt32(id_equipo));
                    auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(rut_empresa);
                    _id_equipo = id_equipo;
                    _rut_empresa = rut_empresa;
                    _id_unidad = id_unidad;
                    _guardar = accion;
                    lblTitulo.Text = titulo_modal;
                    cargarComboEmpresa();
                    cbEmpresa.SelectedValue = auxEmpresa.Rut_empresa;
                    cbEmpresa.Enabled = false;
                    txtEmpresa.Text = auxEmpresa.Nombre;
                    txtEmpresa.Enabled = false;
                    pbSeleccionEmpresa.Visible = true;
                    cargarDataGridViewUnidad();
                    auxUnidad = auxServiceUnidad.TraerUnidadConEntidad_Escritorio(Convert.ToInt32(id_unidad), rut_empresa);
                    txtUnidad.Text = auxUnidad.Nombre;
                    pbSeleccionUnidad.Visible = true;
                    txtUnidad.Enabled = false;
                    txtNombreEquipo.Text = auxEquipo.Nombre;
                }
                else
                {
                    _id_equipo = id_equipo;
                    _id_unidad = id_unidad;
                    _guardar = accion;
                    lblTitulo.Text = titulo_modal;
                    cargarComboEmpresa();
                    pbSeleccionEmpresa.Visible = false;
                    pbSeleccionUnidad.Visible = false;
                    txtEmpresa.Enabled = false;
                    txtUnidad.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion Modal Equipo, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pbSeleccionEmpresa.Visible = false;
                if (Convert.ToInt32(cbEmpresa.SelectedIndex) > 0)
                {
                    _rut_empresa = cbEmpresa.SelectedValue.ToString();
                    pbSeleccionUnidad.Visible = false;
                    pbSeleccionEmpresa.Visible = true;

                    ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                    auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                    auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                    ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                    auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(_rut_empresa);

                    txtEmpresa.Text = auxEmpresa.Nombre;
                    //limpiar GridView
                    dgvUnidad.Rows.Clear();
                    dgvUnidad.Refresh();


                    //limpiar 

                    _id_unidad = string.Empty;

                    //vaciar combobox

                    cargarDataGridViewUnidad();
                }
                else
                {
                    pbSeleccionUnidad.Visible = false;
                    pbSeleccionEmpresa.Visible = false;

                    //limpiar GridView
                    dgvUnidad.Rows.Clear();
                    dgvUnidad.Refresh();

                    //limpiar                   
                    _id_unidad = string.Empty;
                    _rut_empresa = string.Empty;

                    //vaciar txtbox
                    txtNombreEquipo.Text = string.Empty;
                    txtEmpresa.Text = string.Empty;
                    txtUnidad.Text = string.Empty;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion CbEmpresa_SelectedIndexChanged, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarDataGridViewUnidad()
        {
            try
            {


                dgvUnidad.Rows.Clear();
                dgvUnidad.Refresh();
                //instansear web service con seguridad

                ServiceProcess_Unidad.Process_UnidadSoapClient auxServiceUnidad = new ServiceProcess_Unidad.Process_UnidadSoapClient();
                auxServiceUnidad.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUnidad.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                ServiceProcess_Unidad.Unidad auxUnidad = new ServiceProcess_Unidad.Unidad();

                //capturar dataset
                DataSet ds = auxServiceUnidad.TraerUnidadPorEmpresaSinEntidad_Escritorio(_rut_empresa);
                if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    //Capturar Tabla
                    DataTable dt = ds.Tables[0];
                    //contar cantidad de empresas
                    int _cantidad_unidades = dt.Rows.Count;
                    //crear array bidimencional
                    string[,] ListaUnidades = new string[_cantidad_unidades, 2];
                    //Recorrer data table
                    int _fila = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Capturar datos de la fila recorridad en objeto Unidad
                        int id_unidad = Convert.ToInt32(dt.Rows[i]["Id_unidad"]);
                        string nombre_unidad = (String)dt.Rows[i]["Nombre"];
                        //cargar array con datos de fila
                        ListaUnidades[_fila, 0] = id_unidad.ToString();
                        ListaUnidades[_fila, 1] = nombre_unidad;

                        //agregar lista a gridview
                        dgvUnidad.Rows.Add(ListaUnidades[_fila, 0], ListaUnidades[_fila, 1]);
                        _fila++;
                    }
                }
                else
                {
                    MessageBox.Show("La Empresa Seleccionada No tienes Unidades creadas .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pbSeleccionUnidad.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo cargarDataGridViewEquipo, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvUnidad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                _id_unidad = dgvUnidad.Rows[e.RowIndex].Cells["ID_UNIDAD"].Value.ToString();
                _nombre = dgvUnidad.Rows[e.RowIndex].Cells["UNIDAD"].Value.ToString();
                txtUnidad.Text = _nombre;

                pbSeleccionUnidad.Visible = true;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion DgvUnidad_CellClick, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //try
            //{
                //instansear web service con seguridad
                ServiceProcess_Equipo.Process_EquipoSoapClient auxServiceEquipo = new ServiceProcess_Equipo.Process_EquipoSoapClient();
                auxServiceEquipo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEquipo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Equipo.Equipo auxEquipo = new ServiceProcess_Equipo.Equipo();
                ServiceProcess_Equipo.Equipo auxEquipo1 = new ServiceProcess_Equipo.Equipo();

            if (Convert.ToInt32(_guardar) == 1)//Modificar equipo
                {
                    //Validacion espacio en blanco y seleccion de combobox
                    if (txtNombreEquipo.Text.Trim().Equals("") || txtEmpresa.Text.Trim().Equals("") || txtUnidad.Text.Trim().Equals(""))
                    {
                        if (txtNombreEquipo.Text.Trim().Equals(""))
                        {
                            MessageBox.Show("El campo Nombre de Equipo No puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (txtEmpresa.Text.Trim().Equals(""))
                        {
                            MessageBox.Show("Debe seleccionar una Empresa.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (txtUnidad.Text.Trim().Equals(""))
                        {
                            MessageBox.Show("Debe Seleccionar una Unidad.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        //Validar longitud de caracteres
                        if (txtNombreEquipo.Text.Trim().Length < 5 || txtNombreEquipo.Text.Trim().Length > 50)
                        {
                            MessageBox.Show("El Nombre, debe tener un minimo de 5 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            //validar equipo no exista
                            auxEquipo = auxServiceEquipo.TraerEquipoConEntidad_Escritorio(Convert.ToInt32(_id_equipo));
                        auxEquipo1 = auxServiceEquipo.TraerEquipoPorNombreConEntidad_Escritorio(txtNombreEquipo.Text.ToUpper(), auxEquipo.Id_unidad);
                            if (auxEquipo1.Nombre == null || txtNombreEquipo.Text.ToUpper().Equals(auxEquipo.Nombre))
                            {
                                //confirmacion de Creacion equipo
                                if (MessageBox.Show("Confirmar la Modificacion del  Equipo.", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    auxServiceEquipo.ActualizarEquipoSinEntidad_Escritorio(Convert.ToInt32(_id_equipo), txtNombreEquipo.Text.ToUpper(), Convert.ToInt32(auxEquipo.Id_unidad));
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    //se devuelve al Cuadro de datos
                                    MessageBox.Show("NO se Modifico Equipo.", "MODIFICAR EQUIPO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("El Nombre de Equipo ya Existe en Esta unidad.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);                                

                            }
                        }
                    }
                }            
                else//Nuevo Rol
                {
                    //Validacion espacio en blanco y seleccion de combobox
                    if (txtNombreEquipo.Text.Trim().Equals("") || txtEmpresa.Text.Trim().Equals("") || txtUnidad.Text.Trim().Equals(""))
                    {
                        if (txtNombreEquipo.Text.Trim().Equals(""))
                        {
                            MessageBox.Show("El campo Nombre de Equipo No puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (txtEmpresa.Text.Trim().Equals(""))
                        {
                            MessageBox.Show("Debe seleccionar una Empresa.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (txtUnidad.Text.Trim().Equals(""))
                        {
                            MessageBox.Show("Debe Seleccionar una Unidad.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        } 
                        
                    }
                    else
                    {
                        //Validar longitud de caracteres
                        if (txtNombreEquipo.Text.Trim().Length < 5 || txtNombreEquipo.Text.Trim().Length > 50)
                        {
                            MessageBox.Show("El Nombre, debe tener un minimo de 5 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            //validar equipo no exista
                            DataSet ds = auxServiceEquipo.TraerEquipoPorNombreSinEntidad_Escritorio(txtNombreEquipo.Text.ToUpper(),Convert.ToInt32(_id_unidad));
                            if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
                            {
                                MessageBox.Show("El Nombre de Equipo ya Existe en Esta unidad.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {                                
                                    //confirmacion de Creacion equipo
                                    if (MessageBox.Show("Confirmar la Creacion del Nuevo Equipo.", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                    auxServiceEquipo.InsertarEquipoSinEntidad_Escritorio(txtNombreEquipo.Text.ToUpper(), Convert.ToInt32(_id_unidad));
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                    else
                                    {
                                        //se devuelve al Cuadro de datos
                                        MessageBox.Show("NO se Creo Equipo.", "NUEVO EQUIPO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                
                            }
                        }
                    }
                }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("Error en metodo de accion BtnGuardar_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}//fin try catch
        }
    }
}

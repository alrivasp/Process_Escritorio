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
    public partial class FormEquipo : Form
    {
        //variables de apoyo
        public static string _id_equipo = null;
        public static string _nombre = null;
        public static string _id_unidad = null;
        public static string _rut_empresa = null;
        public static string _rut_usuario = null;
        public static string _lider_equipo = null;
        public FormEquipo()
        {
            InitializeComponent();
            cargarComboEmpresa();
            pbSeleccionEmpresa.Visible = false;
            btnColaborador.Visible = false;
            btnLider.Visible = false;
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

        private void cargarDataGridViewMiembro()
        {
            try
            {
                dgvMiembros.Rows.Clear();
                dgvMiembros.Refresh();
                //instansear web service con seguridad               
                ServiceProcess_UsuarioEquipo.Process_UsuarioEquipoSoapClient auxServiceUsuarioCargo = new ServiceProcess_UsuarioEquipo.Process_UsuarioEquipoSoapClient();
                auxServiceUsuarioCargo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuarioCargo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Usuario.Usuario auxUsuario = new ServiceProcess_Usuario.Usuario();

                //capturar dataset
                DataSet ds = auxServiceUsuarioCargo.TraerUsuarioEquipoSinEntidad_Escritorio(Convert.ToInt32(_id_equipo));
                if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    //Capturar Tabla
                    DataTable dt = ds.Tables[0];
                    //contar cantidad de Miembos
                    int _cantidad_miembros = dt.Rows.Count;
                    //crear array bidimencional
                    string[,] ListaMiembros = new string[_cantidad_miembros, 3];
                    //Recorrer data table
                    int _fila = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Capturar datos de la fila recorridad en objeto rol
                        string rut_usuario = (String)dt.Rows[i]["Rut_usuario"];
                        auxUsuario = auxServiceUsuario.TraerUsuarioConEntidad_Escritorio(rut_usuario);
                        string nombre_usuario = auxUsuario.Primer_nombre + " " + auxUsuario.Segundo_nombre + " " + auxUsuario.Primer_apellido + " " + auxUsuario.Segundo_apellido;
                        int id_equipo = Convert.ToInt32(dt.Rows[i]["Id_equipo"]);
                        int responsable = Convert.ToInt32(dt.Rows[i]["Responsable"]);
                        string responsable_iteracion;
                        //cargar array con datos de fila
                        ListaMiembros[_fila, 0] = rut_usuario;
                        ListaMiembros[_fila, 1] = nombre_usuario;
                        if (responsable == 1)
                        {
                            responsable_iteracion = "LIDER DE EQUIPO";
                        }
                        else
                        {
                            responsable_iteracion = "COLABORADOR";
                        }
                        ListaMiembros[_fila, 2] = responsable_iteracion;
                        //agregar lista a gridview
                        dgvMiembros.Rows.Add(ListaMiembros[_fila, 0], ListaMiembros[_fila, 1], ListaMiembros[_fila, 2]);
                        _fila++;
                    }
                }
                else
                {
                    MessageBox.Show("El Equipo Seleccionado No tiene Miembros Agregados .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo cargarDataGridViewMiembro, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarDataGridViewEquipo()
        {
            try
            {
                dgvEquipo.Rows.Clear();
                dgvEquipo.Refresh();
                //instansear web service con seguridad
                ServiceProcess_Equipo.Process_EquipoSoapClient auxServiceEquipo = new ServiceProcess_Equipo.Process_EquipoSoapClient();
                auxServiceEquipo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEquipo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Unidad.Process_UnidadSoapClient auxServiceUnidad = new ServiceProcess_Unidad.Process_UnidadSoapClient();
                auxServiceUnidad.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUnidad.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                ServiceProcess_Unidad.Unidad auxUnidad = new ServiceProcess_Unidad.Unidad();

                //capturar dataset
                DataSet ds = auxServiceEquipo.TraerEquipoPorEmpresaPorUnidadSinEntidad_Escritorio(Convert.ToInt32(_id_unidad), _rut_empresa);
                if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    //Capturar Tabla
                    DataTable dt = ds.Tables[0];
                    //contar cantidad de empresas
                    int _cantidad_equipos = dt.Rows.Count;
                    //crear array bidimencional
                    string[,] ListaEquipos = new string[_cantidad_equipos, 6];
                    //Recorrer data table
                    int _fila = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Capturar datos de la fila recorridad en objeto rol
                        int id_equipo = Convert.ToInt32(dt.Rows[i]["Id_equipo"]);

                        string nombre_equipo = (String)dt.Rows[i]["Nombre"];
                        string rut_empresa = (String)dt.Rows[i]["Rut_empresa"];
                        auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(rut_empresa);
                        string nombre_empresa = auxEmpresa.Nombre;
                        int id_unidad = Convert.ToInt32(dt.Rows[i]["Id_unidad"]);
                        auxUnidad = auxServiceUnidad.TraerUnidadConEntidad_Escritorio(id_unidad, rut_empresa);
                        string nombre_unidad = auxUnidad.Nombre;
                        //cargar array con datos de fila
                        ListaEquipos[_fila, 0] = id_equipo.ToString();
                        ListaEquipos[_fila, 1] = nombre_equipo;
                        ListaEquipos[_fila, 2] = rut_empresa;
                        ListaEquipos[_fila, 3] = nombre_empresa;
                        ListaEquipos[_fila, 4] = id_unidad.ToString();
                        ListaEquipos[_fila, 5] = nombre_unidad;
                        //agregar lista a gridview
                        dgvEquipo.Rows.Add(ListaEquipos[_fila, 0], ListaEquipos[_fila, 1], ListaEquipos[_fila, 2], ListaEquipos[_fila, 3], ListaEquipos[_fila, 4], ListaEquipos[_fila, 5]);
                        _fila++;
                    }
            }
            else
            {
                MessageBox.Show("La Unidad seleccionada no tiene Equipos de Procesos Creados .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pbSeleccionEquipo.Visible = false;
            }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo cargarDataGridViewEquipo, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    pbSeleccionEquipo.Visible = false;

                    //limpiar GridView
                    dgvEquipo.Rows.Clear();
                    dgvEquipo.Refresh();

                    dgvMiembros.Rows.Clear();
                    dgvMiembros.Refresh();


                    //limpiar 
                    _id_equipo = null;
                    _nombre = string.Empty;
                    _id_unidad = string.Empty;                    

                    //vaciar combobox
                    cbUnidad.DataSource = null;
                    cbUnidad.Items.Clear();
                    cargarComboUnidad();
                    btnColaborador.Visible = false;
                    btnLider.Visible = false;
                }
                else
                {
                    
                    pbSeleccionUnidad.Visible = false;
                    pbSeleccionEquipo.Visible = false;

                    //limpiar GridView
                    dgvEquipo.Rows.Clear();
                    dgvEquipo.Refresh();

                    dgvMiembros.Rows.Clear();
                    dgvMiembros.Refresh();


                    //limpiar 
                    _id_equipo = null;
                    _nombre = string.Empty;
                    _id_unidad = string.Empty;
                    _rut_empresa = string.Empty;

                    //vaciar combobox
                    cbUnidad.DataSource = null;
                    cbUnidad.Items.Clear();
                    pbSeleccionEmpresa.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion CbEmpresa_SelectedIndexChanged, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarComboUnidad()
        {
            try
            {
                ServiceProcess_Unidad.Process_UnidadSoapClient auxServiceUnidad = new ServiceProcess_Unidad.Process_UnidadSoapClient();
                auxServiceUnidad.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUnidad.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                pbSeleccionEmpresa.Visible = true;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ds = auxServiceUnidad.TraerUnidadPorEmpresaSinEntidad_Escritorio(_rut_empresa);
            if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
            {
                dt = ds.Tables[0];
                DataRow fila = dt.NewRow();
                fila["ID_UNIDAD"] = 0;
                fila["NOMBRE"] = "SELECCIONE UNIDAD";
                fila["DESCRIPCION"] = " ";
                fila["ESTADO"] = 0;
                fila["RUT_EMPRESA"] = 0;
                dt.Rows.InsertAt(fila, 0);
                cbUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
                cbUnidad.DataSource = dt;
                cbUnidad.DisplayMember = "NOMBRE";
                cbUnidad.ValueMember = "ID_UNIDAD";
            }
            else
            {
                MessageBox.Show("Empresa Seleccionada No Tiene Unidades Registradas.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion cargarComboUnidad, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void CbUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbUnidad.SelectedIndex) > 0)
                {
                    _id_unidad = cbUnidad.SelectedValue.ToString();
                    pbSeleccionEmpresa.Visible = true;
                    pbSeleccionUnidad.Visible = true;
                    pbSeleccionEquipo.Visible = false;
                    
                    //limpiar GridView

                    dgvMiembros.Rows.Clear();
                    dgvMiembros.Refresh();


                    //limpiar 
                    _id_equipo = null;
                    _nombre = string.Empty;

                    btnColaborador.Visible = false;
                    btnLider.Visible = false;
                    cargarDataGridViewEquipo();
                }
                else
                {
                    pbSeleccionEmpresa.Visible = true;
                    pbSeleccionUnidad.Visible = false;
                    pbSeleccionEquipo.Visible = false;

                    //limpiar GridView
                    dgvEquipo.Rows.Clear();
                    dgvEquipo.Refresh();

                    dgvMiembros.Rows.Clear();
                    dgvMiembros.Refresh();


                    //limpiar 
                    _id_equipo = null;
                    _nombre = string.Empty;
                    _id_unidad = string.Empty;                   


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion CbUnidad_SelectedIndexChanged, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvEquipo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                _id_equipo = dgvEquipo.Rows[e.RowIndex].Cells["ID_EQUIPO"].Value.ToString();

                            

                pbSeleccionEquipo.Visible = true;

                btnColaborador.Visible = false;
                btnLider.Visible = false;
                dgvMiembros.Rows.Clear();
                dgvMiembros.Refresh();
                cargarDataGridViewMiembro();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion DgvEquipo_CellClick, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtFiltrar_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dgvEquipo.Rows.Clear();
                dgvEquipo.Refresh();
                dgvMiembros.Rows.Clear();
                dgvMiembros.Refresh();
                //instansear web service con seguridad
                ServiceProcess_Equipo.Process_EquipoSoapClient auxServiceEquipo = new ServiceProcess_Equipo.Process_EquipoSoapClient();
                auxServiceEquipo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEquipo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Unidad.Process_UnidadSoapClient auxServiceUnidad = new ServiceProcess_Unidad.Process_UnidadSoapClient();
                auxServiceUnidad.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUnidad.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                ServiceProcess_Unidad.Unidad auxUnidad = new ServiceProcess_Unidad.Unidad();

                //capturar dataset
                DataSet ds = auxServiceEquipo.TraerEquipoPorClaveSinEntidad_Escritorio(Convert.ToInt32(_id_unidad), _rut_empresa, txtFiltrar.Text.ToUpper());
                if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    //Capturar Tabla
                    DataTable dt = ds.Tables[0];
                    //contar cantidad de empresas
                    int _cantidad_equipos = dt.Rows.Count;
                    //crear array bidimencional
                    string[,] ListaEquipos = new string[_cantidad_equipos, 6];
                    //Recorrer data table
                    int _fila = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Capturar datos de la fila recorridad en objeto rol
                        int id_equipo = Convert.ToInt32(dt.Rows[i]["Id_equipo"]);

                        string nombre_equipo = (String)dt.Rows[i]["Nombre"];
                        string rut_empresa = (String)dt.Rows[i]["Rut_empresa"];
                        auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(rut_empresa);
                        string nombre_empresa = auxEmpresa.Nombre;
                        int id_unidad = Convert.ToInt32(dt.Rows[i]["Id_unidad"]);
                        auxUnidad = auxServiceUnidad.TraerUnidadConEntidad_Escritorio(id_unidad, rut_empresa);
                        string nombre_unidad = auxUnidad.Nombre;
                        //cargar array con datos de fila
                        ListaEquipos[_fila, 0] = id_equipo.ToString();
                        ListaEquipos[_fila, 1] = nombre_equipo;
                        ListaEquipos[_fila, 2] = rut_empresa;
                        ListaEquipos[_fila, 3] = nombre_empresa;
                        ListaEquipos[_fila, 4] = id_unidad.ToString();
                        ListaEquipos[_fila, 5] = nombre_unidad;
                        //agregar lista a gridview
                        dgvEquipo.Rows.Add(ListaEquipos[_fila, 0], ListaEquipos[_fila, 1], ListaEquipos[_fila, 2], ListaEquipos[_fila, 3], ListaEquipos[_fila, 4], ListaEquipos[_fila, 5]);
                        _fila++;
                    }
                    _id_equipo = null;
                    _nombre = string.Empty;
      
                }
                else
                {
                    _id_equipo = null;
                    _nombre = string.Empty;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion TxtFiltrar_KeyUp, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                string _titulo_modal = "NUEVO EQUIPO";
                string _guardar = "2";
                FormEquipoModal frmModal = new FormEquipoModal(_titulo_modal, _guardar, _id_equipo, _rut_empresa, _id_unidad);
                if (frmModal.ShowDialog() == DialogResult.OK)
                {                    
                    //Vaciar variables
                    _id_equipo = null;
                    _nombre = string.Empty;
                    _id_unidad = string.Empty;
                    _rut_empresa = string.Empty;
                    btnColaborador.Visible = false;
                    btnLider.Visible = false;
                    //vaciar combobox
                    cbUnidad.DataSource = null;
                    cbUnidad.Items.Clear();
                    pbSeleccionEmpresa.Visible = false;
                    //limpiar GridView
                    dgvEquipo.Rows.Clear();
                    dgvEquipo.Refresh();
                    dgvMiembros.Rows.Clear();
                    dgvMiembros.Refresh();
                    //cargar combo unidad
                    cargarComboEmpresa();
                    //cargar gridview                    
                    MessageBox.Show("Equipo Creado Correctamente.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Boton de accion BtnNuevo_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_id_equipo == null || _nombre == null)
                {
                    MessageBox.Show("Debe Seleccionar un Equipo antes de Modificar.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    string _titulo_modal = "MODIFICAR EQUIPO";
                    string _guardar = "1";
                    FormEquipoModal frmModal = new FormEquipoModal(_titulo_modal, _guardar, _id_equipo, _rut_empresa, _id_unidad);
                    if (frmModal.ShowDialog() == DialogResult.OK)
                    {
                        //Vaciar variables
                        _id_equipo = null;
                        _nombre = string.Empty;
                        pbSeleccionEquipo.Visible = false;
                        //limpiar GridView
                        dgvEquipo.Rows.Clear();
                        dgvEquipo.Refresh();
                        dgvMiembros.Rows.Clear();
                        dgvMiembros.Refresh();
                        btnColaborador.Visible = false;
                        btnLider.Visible = false;
                        cargarDataGridViewEquipo();
                        //cargar gridview                    
                        MessageBox.Show("Equipo Modificado Correctamente.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Boton de accion BtnNuevo_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnMiembros_Click(object sender, EventArgs e)
        {
            try
            {
                if (_id_equipo == null || _nombre == null)
                {
                    MessageBox.Show("Debe Seleccionar un Equipo antes de agragar Miembros.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    FormEquipoModalMiembros frmModal = new FormEquipoModalMiembros(_rut_empresa, _id_unidad, _id_equipo);
                    if (frmModal.ShowDialog() == DialogResult.OK)
                    {
                        //Vaciar variables
                        _id_equipo = null;
                        _nombre = string.Empty;
                        pbSeleccionEquipo.Visible = false;
                        //limpiar GridView
                        dgvEquipo.Rows.Clear();
                        dgvEquipo.Refresh();
                        dgvMiembros.Rows.Clear();
                        dgvMiembros.Refresh();
                        cargarDataGridViewEquipo();
                        btnColaborador.Visible = false;
                        btnLider.Visible = false;
                        //cargar gridview                    
                        MessageBox.Show("Equipo Modificado Correctamente.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Boton de accion BtnNuevo_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvMiembros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                btnColaborador.Visible = false;
                btnLider.Visible = false;
                _rut_usuario = dgvMiembros.Rows[e.RowIndex].Cells["RUT_USUARIO"].Value.ToString();
                string responsable = dgvMiembros.Rows[e.RowIndex].Cells["JERARQUIA"].Value.ToString();

                if (responsable.Equals("LIDER DE EQUIPO"))
                {
                    btnColaborador.Visible = true;
                }
                else
                {
                    btnLider.Visible = true;
                }
                pbSeleccionEquipo.Visible = true;

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion DgvEquipo_CellClick, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            System.GC.Collect();
        }

        private void BtnColaborador_Click(object sender, EventArgs e)
        {

            //Instancia de Web service con credenciales NT

            ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
            auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
            auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

            ServiceProcess_UsuarioEquipo.Process_UsuarioEquipoSoapClient auxServiceUsuarioCargo = new ServiceProcess_UsuarioEquipo.Process_UsuarioEquipoSoapClient();
            auxServiceUsuarioCargo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
            auxServiceUsuarioCargo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

            ServiceProcess_Usuario.Usuario auxUsuario = new ServiceProcess_Usuario.Usuario();
            auxUsuario = auxServiceUsuario.TraerUsuarioConEntidad_Escritorio(_rut_usuario);

            try
            {

                if (MessageBox.Show("¿Esta Seguro de Cambiar a Miembro " + auxUsuario.Primer_nombre + " " + auxUsuario.Primer_apellido + " como Colaborador ?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    //Insertar datos via web service
                    auxServiceUsuarioCargo.ActualizarUsuarioEquipoSinEntidad_Escritorio(_rut_usuario, Convert.ToInt32(_id_equipo), 0);
                    btnLider.Visible = false;
                    btnColaborador.Visible = false;
                    //Vaciar variables

                    _lider_equipo = null;
                    //limpiar GridView
                    dgvMiembros.Rows.Clear();
                    dgvMiembros.Refresh();
                    //Metodo Carga de GridView
                    cargarDataGridViewMiembro();
                    MessageBox.Show("Usuario " + auxUsuario.Primer_nombre + " " + auxUsuario.Primer_apellido + " ahora es Colaborador .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    //continua CON LA VISTA ACTUAL
                }            

        }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion buscarLiderEquipo, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void BtnLider_Click(object sender, EventArgs e)
        {
            try
            {
                //Instancia de Web service con credenciales NT

                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_UsuarioEquipo.Process_UsuarioEquipoSoapClient auxServiceUsuarioCargo = new ServiceProcess_UsuarioEquipo.Process_UsuarioEquipoSoapClient();
                auxServiceUsuarioCargo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuarioCargo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Usuario.Usuario auxUsuario = new ServiceProcess_Usuario.Usuario();
                auxUsuario = auxServiceUsuario.TraerUsuarioConEntidad_Escritorio(_rut_usuario);

           
                buscarLiderEquipo();

                if (_lider_equipo == null)
                {
                    if (MessageBox.Show("¿Esta Seguro de Cambiar a Miembro " + auxUsuario.Primer_nombre + " " + auxUsuario.Primer_apellido + " como Lider de Equipo ?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        //Insertar datos via web service
                        auxServiceUsuarioCargo.ActualizarUsuarioEquipoSinEntidad_Escritorio(_rut_usuario, Convert.ToInt32(_id_equipo), 1);
                        btnLider.Visible = false;
                        btnColaborador.Visible = false;
                        //Vaciar variables

                        _lider_equipo = null;
                        //limpiar GridView
                        dgvMiembros.Rows.Clear();
                        dgvMiembros.Refresh();
                        //Metodo Carga de GridView
                        cargarDataGridViewMiembro();
                        MessageBox.Show("Usuario " + auxUsuario.Primer_nombre + " " + auxUsuario.Primer_apellido + " ahora es Lider de Equipo .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        //continua CON LA VISTA ACTUAL
                    }
                }
                else
                {
                    _lider_equipo = null;
                    MessageBox.Show("Ya existe un Lider de Equipo, primero debe cambiarlo a Colaborador antes de designar un Nuevo Lider .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion BtnActivar_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buscarLiderEquipo()
        {
            try
            {
                //instansear web service con seguridad               
                ServiceProcess_UsuarioEquipo.Process_UsuarioEquipoSoapClient auxServiceUsuarioCargo = new ServiceProcess_UsuarioEquipo.Process_UsuarioEquipoSoapClient();
                auxServiceUsuarioCargo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuarioCargo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Usuario.Usuario auxUsuario = new ServiceProcess_Usuario.Usuario();

                //capturar dataset
                DataSet ds = auxServiceUsuarioCargo.TraerUsuarioEquipoSinEntidad_Escritorio(Convert.ToInt32(_id_equipo));
                if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    //Capturar Tabla
                    DataTable dt = ds.Tables[0];
                    //contar cantidad de Miembos              
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        int responsable = Convert.ToInt32(dt.Rows[i]["RESPONSABLE"]);
                        if (responsable == 1)
                        {
                            _lider_equipo = (String)dt.Rows[i]["RUT_USUARIO"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo buscarLiderEquipo, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

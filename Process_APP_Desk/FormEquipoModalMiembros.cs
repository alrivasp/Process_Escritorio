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
    public partial class FormEquipoModalMiembros : Form
    {
        public static string _rut_empresa = null;
        public static string _id_unidad = null;
        public static string _rut_usuario = null;
        public static string _nombre_usuario = null;
        public static string _id_equipo = null;
        public static string _rut_usuario_seleccion = null;
        public static string _nombre_usuario_seleccion = null;
        public static string _lider_equipo = null;
        public FormEquipoModalMiembros()
        {
            InitializeComponent();
        }

        public FormEquipoModalMiembros(string rut_empresa, string id_unidad, string id_equipo)
        {
            InitializeComponent();
            ServiceProcess_Equipo.Process_EquipoSoapClient auxServiceEquipo = new ServiceProcess_Equipo.Process_EquipoSoapClient();
            auxServiceEquipo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
            auxServiceEquipo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
            ServiceProcess_Equipo.Equipo auxEquipo = new ServiceProcess_Equipo.Equipo();
            auxEquipo = auxServiceEquipo.TraerEquipoConEntidad_Escritorio(Convert.ToInt32(id_equipo));
            _rut_empresa = rut_empresa;
            _id_unidad = id_unidad;
            _id_equipo = id_equipo;
            txtEquipo.Text = auxEquipo.Nombre;
            txtEquipo.Enabled = false;
            txtNombre.Enabled = false;
            txtRut.Enabled = false;
            pbSeleccion.Visible = false;
            cargarComboUsuario();
            cargarDataGridViewMiembro();

            buscarLiderEquipo();
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
                MessageBox.Show("Error en metodo cargarDataGridViewMiembro, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarDataGridViewMiembro()
        {
            try
            {
                dgvMiembro.Rows.Clear();
                dgvMiembro.Refresh();
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
                    string[,] ListaMiembros = new string[_cantidad_miembros, 2];
                    //Recorrer data table
                    int _fila = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Capturar datos de la fila recorridad en objeto rol
                        string rut_usuario = (String)dt.Rows[i]["Rut_usuario"];
                        auxUsuario = auxServiceUsuario.TraerUsuarioConEntidad_Escritorio(rut_usuario);
                        string nombre_usuario = auxUsuario.Primer_nombre + " " + auxUsuario.Segundo_nombre + " " + auxUsuario.Primer_apellido + " " + auxUsuario.Segundo_apellido;
                        ListaMiembros[_fila, 0] = rut_usuario;
                        ListaMiembros[_fila, 1] = nombre_usuario;
                        //agregar lista a gridview
                        dgvMiembro.Rows.Add(ListaMiembros[_fila, 0], ListaMiembros[_fila, 1]);
                        _fila++;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo cargarDataGridViewMiembro, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cargarComboUsuario()
        {
            try
            {
                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Usuario.Usuario auxUsuario = new ServiceProcess_Usuario.Usuario();

                DataSet ds = auxServiceUsuario.TraerUsuarioPorEmpresaSinEntidad_Escritorio(_rut_empresa);
                //Capturar Tabla
                DataTable dt = ds.Tables[0];
                //DATA TABLE NUEVO
                DataSet dsUsuario = new DataSet();
                DataTable dtUsuario = new DataTable();
                dsUsuario.Tables.Add(dtUsuario);
                dtUsuario.Columns.Add("RUT_USUARIO", typeof(string));
                dtUsuario.Columns.Add("NOMBRE", typeof(string));
                dtUsuario.Rows.Add("0", "SELECCIONE USUARIO");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Capturar datos de la fila recorridad en objeto rol
                    string rut_usuario = (String)dt.Rows[i]["Rut_usuario"];
                    auxUsuario = auxServiceUsuario.TraerUsuarioConEntidad_Escritorio(rut_usuario);
                    string nombre_usuario = auxUsuario.Primer_nombre + " " + auxUsuario.Segundo_nombre + " " + auxUsuario.Primer_apellido + " " + auxUsuario.Segundo_apellido;
                    dtUsuario.Rows.Add(rut_usuario, nombre_usuario);
                }

                cbUsuarios.DataSource = dtUsuario;
                cbUsuarios.DisplayMember = "NOMBRE";
                cbUsuarios.ValueMember = "RUT_USUARIO";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo cargarComboAcceso, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pbSeleccion.Visible = false;
                if (Convert.ToInt32(cbUsuarios.SelectedIndex) > 0)
                {
                    _rut_usuario = cbUsuarios.SelectedValue.ToString();
                    pbSeleccion.Visible = true;

                    //limpiar 
                    txtNombre.Text = string.Empty;
                    txtRut.Text = string.Empty;
                    //vaciar combobox                   
                }
                else
                {

                    pbSeleccion.Visible = false;
                    _rut_usuario = null;

                    //limpiar 
                    txtNombre.Text = string.Empty;
                    txtRut.Text = string.Empty;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion CbUsuarios_SelectedIndexChanged, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvMiembro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                _rut_usuario_seleccion = dgvMiembro.Rows[e.RowIndex].Cells["RUT_USUARIO"].Value.ToString();
                _nombre_usuario_seleccion = dgvMiembro.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();

                txtRut.Text = _rut_usuario_seleccion;
                txtNombre.Text = _nombre_usuario_seleccion;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion DgvMiembro_CellClick, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAgregarMiembro_Click(object sender, EventArgs e)
        {
            try
            {
                int valor_repetido = 0;
                if (cbUsuarios.SelectedIndex == 0)
                {
                    MessageBox.Show("Debe seleccionar un Usuario antes de Agregar.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Capturo datos de combo acceso
                    _rut_usuario_seleccion = cbUsuarios.SelectedValue.ToString();
                    _nombre_usuario_seleccion = cbUsuarios.GetItemText(cbUsuarios.SelectedItem);

                    // validar si acceso seleccionado ya esta en los permisos que tiene el rol
                    for (int i = 0; i < dgvMiembro.Rows.Count; i++)
                    {
                        if (dgvMiembro.Rows[i].Cells[0].Value.ToString().Equals(_rut_usuario_seleccion))
                        {
                            valor_repetido = 1;
                            MessageBox.Show("El Usuario ya existe como Miembro de este Equipo.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }

                    if (valor_repetido == 0)
                    {
                        int contador = dgvMiembro.Rows.Count;
                        dgvMiembro.Rows.Insert(contador, _rut_usuario_seleccion, _nombre_usuario_seleccion);
                        MessageBox.Show("Miembro Agregado a la lista.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    cbUsuarios.SelectedValue = 0;
                    pbSeleccion.Visible = false;
                    _rut_usuario_seleccion = null;
                    _nombre_usuario_seleccion = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion BtnAgregarAcceso_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnQuitarMiembro_Click(object sender, EventArgs e)
        {
            try
            {
                if (_rut_usuario_seleccion == null)
                {
                    MessageBox.Show("Debe seleccionar un Usuario de la Lista.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int fila = dgvMiembro.CurrentRow.Index;
                    dgvMiembro.Rows.RemoveAt(fila);
                    pbSeleccion.Visible = false;
                    _rut_usuario_seleccion = null;
                    _nombre_usuario_seleccion = null;
                    MessageBox.Show("Miembro Eliminado de la lista.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion BtnQuitarAcceso_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //instansear web service con seguridad
                ServiceProcess_UsuarioEquipo.Process_UsuarioEquipoSoapClient auxServiceUsuarioEquipo = new ServiceProcess_UsuarioEquipo.Process_UsuarioEquipoSoapClient();
                auxServiceUsuarioEquipo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuarioEquipo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Rol.Rol auxRol = new ServiceProcess_Rol.Rol();
                ServiceProcess_Acceso.Process_AccesoSoapClient auxServiceAcceso = new ServiceProcess_Acceso.Process_AccesoSoapClient();
                auxServiceAcceso.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceAcceso.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Acceso.Acceso auxAcceso = new ServiceProcess_Acceso.Acceso();
                ServiceProcess_Permisos.Process_PermisosSoapClient auxServicePermisos = new ServiceProcess_Permisos.Process_PermisosSoapClient();
                auxServicePermisos.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServicePermisos.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Permisos.Permisos auxPermisos = new ServiceProcess_Permisos.Permisos();


                //Validacion de equipo vacio
                if (dgvMiembro.Rows.Count == 0)
                {
                    MessageBox.Show("NO puede Guardar el Equipo Sin Miembros.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    //confirmacion de Actualizar  ROL
                    if (MessageBox.Show("Confirmar la Nueva Lista de Miembros.", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //capturar dataset
                        DataSet ds = auxServiceUsuarioEquipo.TraerUsuarioEquipoSinEntidad_Escritorio(Convert.ToInt32(_id_equipo));// CAPTURAR REGISTROS SEGUN equipo
                        if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))//VALIDAR QUE DATASET NO VENGA VACIO SI CON INFORMACION SE BORRAR LOS PERMISOS PARA EL equipo
                        {
                            auxServiceUsuarioEquipo.EliminarUsuarioEquipoSinEntidad_Escritorio(Convert.ToInt32(_id_equipo));
                        }

                        for (int i = 0; i < dgvMiembro.Rows.Count; i++)//recorrer data gred view
                        {                          

                            string _id_rut_insertar = dgvMiembro.Rows[i].Cells["RUT_USUARIO"].Value.ToString();
                            if (_id_rut_insertar.Equals(_lider_equipo))
                            {
                                auxServiceUsuarioEquipo.InsertarUsuarioEquipoSinEntidad_Escritorio(_id_rut_insertar, Convert.ToInt32(_id_equipo), 1);
                            }
                            else
                            {
                                auxServiceUsuarioEquipo.InsertarUsuarioEquipoSinEntidad_Escritorio(_id_rut_insertar, Convert.ToInt32(_id_equipo), 0);
                            }                            
                        }

                        _lider_equipo = null;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        //se devuelve al Cuadro de datos
                        MessageBox.Show("No se creo Miembros de Equipo.", "MIEMBROS DE EQUIPOL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en metodo de accion BtnGuardar_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }//fin try catch
        }
    }
}

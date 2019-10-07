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
        //Variable Titulo
        public static string _titulo_modal;
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
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            pbSeleccion.Visible = false;
        }

        //Metodo Carga GridView 
        public void cargarDataGridViewPpal()
        {
            try
            {
                //instansear web service con seguridad
                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Comuna.Process_ComunaSoapClient auxServiceComuna = new ServiceProcess_Comuna.Process_ComunaSoapClient();
                auxServiceComuna.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceComuna.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Comuna.Comuna auxComuna = new ServiceProcess_Comuna.Comuna();
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                //capturar dataset
                DataSet ds = auxServiceEmpresa.TraerTodasEmpresas_Escritorio();
                //Capturar Tabla
                DataTable dt = ds.Tables[0];
                //contar cantidad de empresas
                int _cantidad_empresas = dt.Rows.Count;
                //crear array bidimencional
                string[,] ListaEmpresa = new string[_cantidad_empresas, 6];
                //Recorrer data table
                int _fila = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Capturar datos de la fila recorridad en objeto empresa
                    auxEmpresa.Rut_empresa = (String)dt.Rows[i]["Rut_empresa"];
                    auxEmpresa.Nombre = (String)dt.Rows[i]["Nombre"];
                    auxEmpresa.Giro = (String)dt.Rows[i]["Giro"];
                    auxEmpresa.Direccion = (String)dt.Rows[i]["Direccion"];
                    auxEmpresa.Estado = Convert.ToInt32(dt.Rows[i]["Estado"]);
                    auxEmpresa.Id_comuna = Convert.ToInt32(dt.Rows[i]["Id_comuna"]);
                    //variables temporales de apoyo
                    string _estado = string.Empty;
                    string _comuna = string.Empty;
                    //cargar array con datos de fila
                    ListaEmpresa[_fila, 0] = auxEmpresa.Rut_empresa;
                    ListaEmpresa[_fila, 1] = auxEmpresa.Nombre;
                    ListaEmpresa[_fila, 2] = auxEmpresa.Giro;
                    ListaEmpresa[_fila, 3] = auxEmpresa.Direccion;
                    if (auxEmpresa.Estado == 0)
                    {
                        _estado = "DESACTIVADO";
                    }
                    else
                    {
                        _estado = "ACTIVADO";
                    }
                    ListaEmpresa[_fila, 4] = _estado;
                    auxComuna = auxServiceComuna.TraerComunaConEntidad_Escritorio(auxEmpresa.Id_comuna);
                    ListaEmpresa[_fila, 5] = auxComuna.Nombre;
                    //agregar lista a gridview
                    dgvEmpresas.Rows.Add(ListaEmpresa[_fila, 0], ListaEmpresa[_fila, 1], ListaEmpresa[_fila, 2], ListaEmpresa[_fila, 3], ListaEmpresa[_fila, 4], ListaEmpresa[_fila, 5]);
                    _fila++;

                }
                pbSeleccion.Visible = false;
                //dgvEmpresas.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo cargarDataGridViewPpal, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Metodo Boton Cerrar
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                System.GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar Apliacion, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Metodo Accion para filtrar automatico
        private void TxtFiltrar_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dgvEmpresas.Rows.Clear();
                dgvEmpresas.Refresh();
                //instansear web service con seguridad
                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Comuna.Process_ComunaSoapClient auxServiceComuna = new ServiceProcess_Comuna.Process_ComunaSoapClient();
                auxServiceComuna.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceComuna.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Comuna.Comuna auxComuna = new ServiceProcess_Comuna.Comuna();
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                //capturar dataset
                DataSet ds = auxServiceEmpresa.TraerEmpresaConClaveSinEntidad_Escritorio(txtFiltrar.Text.ToUpper());
                if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    //Capturar Tabla
                    DataTable dt = ds.Tables[0];
                    //contar cantidad de empresas
                    int _cantidad_empresas = dt.Rows.Count;
                    //crear array bidimencional
                    string[,] ListaEmpresa = new string[_cantidad_empresas, 6];
                    //Recorrer data table
                    int _fila = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Capturar datos de la fila recorridad en objeto empresa
                        auxEmpresa.Rut_empresa = (String)dt.Rows[i]["Rut_empresa"];
                        auxEmpresa.Nombre = (String)dt.Rows[i]["Nombre"];
                        auxEmpresa.Giro = (String)dt.Rows[i]["Giro"];
                        auxEmpresa.Direccion = (String)dt.Rows[i]["Direccion"];
                        auxEmpresa.Estado = Convert.ToInt32(dt.Rows[i]["Estado"]);
                        auxEmpresa.Id_comuna = Convert.ToInt32(dt.Rows[i]["Id_comuna"]);
                        //variables temporales de apoyo
                        string _estado = string.Empty;
                        string _comuna = string.Empty;
                        //cargar array con datos de fila
                        ListaEmpresa[_fila, 0] = auxEmpresa.Rut_empresa;
                        ListaEmpresa[_fila, 1] = auxEmpresa.Nombre;
                        ListaEmpresa[_fila, 2] = auxEmpresa.Giro;
                        ListaEmpresa[_fila, 3] = auxEmpresa.Direccion;
                        if (auxEmpresa.Estado == 0)
                        {
                            _estado = "DESACTIVADO";
                        }
                        else
                        {
                            _estado = "ACTIVADO";
                        }
                        ListaEmpresa[_fila, 4] = _estado;
                        auxComuna = auxServiceComuna.TraerComunaConEntidad_Escritorio(auxEmpresa.Id_comuna);
                        ListaEmpresa[_fila, 5] = auxComuna.Nombre;
                        //agregar lista a gridview
                        dgvEmpresas.Rows.Add(ListaEmpresa[_fila, 0], ListaEmpresa[_fila, 1], ListaEmpresa[_fila, 2], ListaEmpresa[_fila, 3], ListaEmpresa[_fila, 4], ListaEmpresa[_fila, 5]);
                        _fila++;
                    }
                }
                else
                {
                    //Mostrar GridView Vacio
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion TxtFiltrar_KeyUp, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Metodo Boton Nuevo
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                _titulo_modal = "NUEVA EMPRESA";
                _guardar = 2;
                FormEmpresaModal frmModal = new FormEmpresaModal(_titulo_modal, _guardar, _rut_empresa, _nombre, _giro, _direccion, _estado, _id_comuna);
                if (frmModal.ShowDialog() == DialogResult.OK)
                {
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                    //Vaciar variables
                    _rut_empresa = null;
                    _nombre = string.Empty;
                    _giro = string.Empty;
                    _direccion = string.Empty;
                    _estado = string.Empty;
                    _id_comuna = string.Empty;
                    //limpiar GridView
                    dgvEmpresas.Rows.Clear();
                    dgvEmpresas.Refresh();
                    //cargar gridview
                    cargarDataGridViewPpal();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Boton de accion BtnNuevo_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        //Metodo Boton Modificar
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_rut_empresa == null)//validador que se seleccione un fila de empresa
                {
                    MessageBox.Show("Seleccione una Fila a Modificar", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (_rut_empresa.Equals("82982300-4"))//No se puede editar la empresa dueña del software
                    {
                        pbSeleccion.Visible = false;
                        MessageBox.Show("La Empresa Process S.A. NO se puede Modificar", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        _titulo_modal = "MODIFICAR EMPRESA";
                        _guardar = 1;
                        FormEmpresaModal frmModal = new FormEmpresaModal(_titulo_modal, _guardar, _rut_empresa, _nombre, _giro, _direccion, _estado, _id_comuna);
                        if (frmModal.ShowDialog() == DialogResult.OK)
                        {
                            btnActivar.Visible = false;
                            btnDesactivar.Visible = false;
                            //Vaciar variables
                            _rut_empresa = null;
                            _nombre = string.Empty;
                            _giro = string.Empty;
                            _direccion = string.Empty;
                            _estado = string.Empty;
                            _id_comuna = string.Empty;
                            //limpiar GridView
                            dgvEmpresas.Rows.Clear();
                            dgvEmpresas.Refresh();
                            //cargar gridview
                            cargarDataGridViewPpal();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion BtnModificar_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Accion para rescatar fila eleginda del gridview
        private void DgvEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                _rut_empresa = dgvEmpresas.Rows[e.RowIndex].Cells["RUT"].Value.ToString();

                if (_rut_empresa.Equals("82982300-4"))//No se puede editar la empresa dueña del software
                {
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                    pbSeleccion.Visible = false;
                    _rut_empresa = null;
                    MessageBox.Show("La Empresa Process S.A. NO se puede Modificar", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //instansear web service con seguridad
                    ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                    auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                    auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                    ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                    auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(_rut_empresa);

                    _nombre = auxEmpresa.Nombre;
                    _giro = auxEmpresa.Giro;
                    _direccion = auxEmpresa.Direccion;
                    _estado = auxEmpresa.Estado.ToString();
                    _id_comuna = auxEmpresa.Id_comuna.ToString();

                    pbSeleccion.Visible = true;

                    if (_estado.Equals("0"))
                    {
                        btnActivar.Visible = true;
                    }
                    else
                    {
                        btnDesactivar.Visible = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion DgvEmpresas_CellClick, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Boton desactivar Estado de Empresa
        private void BtnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Esta Seguro de Desactivar Empresa " + _nombre + "?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Instancia de Web service con credenciales NT
                    ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                    auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                    auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                    //Insertar datos via web service
                    auxServiceEmpresa.ActualizarEmpresaSinEntidad_Escritorio(_rut_empresa, _nombre, _giro, _direccion, 0, Convert.ToInt32(_id_comuna));
                    //ocultar botones
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                    //Vaciar variables
                    _rut_empresa = null;
                    _nombre = string.Empty;
                    _giro = string.Empty;
                    _direccion = string.Empty;
                    _estado = string.Empty;
                    _id_comuna = string.Empty;
                    //limpiar GridView
                    dgvEmpresas.Rows.Clear();
                    dgvEmpresas.Refresh();
                    //Metodo Carga de GridView
                    cargarDataGridViewPpal();
                }
                else
                {
                    //continua CON LA VISTA ACTUAL
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion BtnDesactivar_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Boton Activar Estado de Empresa
        private void BtnActivar_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("¿Esta Seguro de Activar Empresa " + _nombre + "?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Instancia de Web service con credenciales NT
                    ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                    auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                    auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                    //Insertar datos via web service
                    auxServiceEmpresa.ActualizarEmpresaSinEntidad_Escritorio(_rut_empresa, _nombre, _giro, _direccion, 1, Convert.ToInt32(_id_comuna));
                    //ocultar botones
                    btnActivar.Visible = false;
                    btnDesactivar.Visible = false;
                    //Vaciar variables
                    _rut_empresa = null;
                    _nombre = string.Empty;
                    _giro = string.Empty;
                    _direccion = string.Empty;
                    _estado = string.Empty;
                    _id_comuna = string.Empty;
                    //limpiar GridView
                    dgvEmpresas.Rows.Clear();
                    dgvEmpresas.Refresh();
                    //Metodo Carga de GridView
                    cargarDataGridViewPpal();
                }
                else
                {
                    //continua CON LA VISTA ACTUAL
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion BtnActivar_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Boton Mostrar Empresa
        private void BtnVer_Click(object sender, EventArgs e)
        {
            try
            {
                if (_rut_empresa == null)//validador que se seleccione un fila de empresa
                {
                    MessageBox.Show("Seleccione una Fila para Mostrar", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _titulo_modal = "MOSTRAR EMPRESA";
                    _guardar = 3;
                    FormEmpresaModal frmModal = new FormEmpresaModal(_titulo_modal, _guardar, _rut_empresa, _nombre, _giro, _direccion, _estado, _id_comuna);
                    if (frmModal.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Boton de accion BtnNuevo_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

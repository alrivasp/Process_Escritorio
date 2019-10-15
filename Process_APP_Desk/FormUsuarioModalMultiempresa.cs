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
    public partial class FormUsuarioModalMultiempresa : Form
    {
        //vARIABLE DE APOYO
        public static string _rut_usuario = null;
        public static string _id_cargo = null;        
        public static string _rut_empresa = null;
        public FormUsuarioModalMultiempresa()
        {
            InitializeComponent();
            lblPaso1.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Bold);
            lblPaso2.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Regular);
            lblPaso3.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Regular);
            cargarDataGridViewUsuario();

        }

        //Metodo Carga GridView Usuario
        private void cargarDataGridViewUsuario()
        {
            try
            {
                //instansear web service con seguridad
                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Usuario.Usuario auxUsuario = new ServiceProcess_Usuario.Usuario();


                //capturar dataset
                DataSet ds = auxServiceUsuario.TraerTodasUsuarios_Escritorio();
                //Capturar Tabla
                DataTable dt = ds.Tables[0];
                //contar cantidad de empresas
                int _cantidad_usuarios = dt.Rows.Count;
                //crear array bidimencional
                string[,] ListaUsuario = new string[_cantidad_usuarios, 2];
                //Recorrer data table
                int _fila = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Capturar datos de la fila recorridad en objeto empresa
                    auxUsuario.Rut_usuario = (String)dt.Rows[i]["Rut_usuario"];
                    auxUsuario.Primer_nombre = (String)dt.Rows[i]["Primer_nombre"];
                    auxUsuario.Segundo_nombre = (String)dt.Rows[i]["Segundo_nombre"];
                    auxUsuario.Primer_apellido = (String)dt.Rows[i]["Primer_apellido"];
                    auxUsuario.Segundo_apellido = (String)dt.Rows[i]["Segundo_apellido"];
                    auxUsuario.Direccion = (String)dt.Rows[i]["Direccion"];
                    auxUsuario.Telefono_fijo = Convert.ToInt32(dt.Rows[i]["Telefono_fijo"]);
                    auxUsuario.Telefono_movil = Convert.ToInt32(dt.Rows[i]["Telefono_movil"]);
                    auxUsuario.Id_comuna = Convert.ToInt32(dt.Rows[i]["Id_comuna"]);
                    //cargar array con datos de fila
                    ListaUsuario[_fila, 0] = auxUsuario.Rut_usuario;
                    ListaUsuario[_fila, 1] = auxUsuario.Primer_nombre + " " + auxUsuario.Primer_apellido; ;
                    //agregar lista a gridview
                    dgvUsuario.Rows.Add(ListaUsuario[_fila, 0], ListaUsuario[_fila, 1]);
                    _fila++;

                }
                pbSeleccion1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo cargarDataGridViewUsuario, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0)
                    return;
                //captura de rut selecccionado
                _rut_usuario = dgvUsuario.Rows[e.RowIndex].Cells["RUT_USUARIO"].Value.ToString();

                lblPaso1.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Regular);
                lblPaso2.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Bold);
                lblPaso3.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Regular);
                pbSeleccion1.Visible = true;
                pbSeleccion2.Visible = false;
                pbSeleccion3.Visible = false;
                pbFlecha1.Visible = true;
                pbFlecha2.Visible = false;
                dgvEmpresas.Rows.Clear();
                dgvEmpresas.Refresh();
                dgvCargo.Rows.Clear();
                dgvCargo.Refresh();
                _rut_empresa = null;
                _id_cargo = null;
                cargarDataGridViewEmpresa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion DgvUsuario_CellClick, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Metodo Carga GridView Usuario Empresa
        private void cargarDataGridViewEmpresa()
        {
            try
            {

                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();

                //capturar dataset
                DataSet ds = auxServiceEmpresa.TraerTodasEmpresas_Escritorio();
                //Capturar Tabla
                DataTable dt = ds.Tables[0];
                //contar cantidad de empresas
                int _cantidad_empresas = dt.Rows.Count;
                //crear array bidimencional
                string[,] ListaEmpresas = new string[_cantidad_empresas, 2];
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

                    //CAPTURAR DATASET 
                    DataSet dsU = auxServiceUsuario.TraerUsuarioPorRutPorEmpresaSinEntidad_Escritorio(_rut_usuario, auxEmpresa.Rut_empresa);
                    if ((dsU.Tables.Count != 0) && (dsU.Tables[0].Rows.Count > 0))
                    {
                        //no carga nada al gridview por que ya es usuario  de la empresa
                    }
                    else
                    {
                        //cargar array con datos de fila
                        ListaEmpresas[_fila, 0] = auxEmpresa.Rut_empresa;
                        ListaEmpresas[_fila, 1] = auxEmpresa.Nombre;
                        //agregar lista a gridview
                        dgvEmpresas.Rows.Add(ListaEmpresas[_fila, 0], ListaEmpresas[_fila, 1]);
                        _fila++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo cargarDataGridViewUsuario, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0)
                    return;
                //captura de rut selecccionado
                _rut_empresa = dgvEmpresas.Rows[e.RowIndex].Cells["RUT_EMPRESA"].Value.ToString();

                lblPaso1.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Regular);
                lblPaso2.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Regular);
                lblPaso3.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Bold);
                pbSeleccion1.Visible = true;
                pbSeleccion2.Visible = true;
                pbSeleccion3.Visible = false;
                pbFlecha1.Visible = true;
                pbFlecha2.Visible = true;
                dgvCargo.Rows.Clear();
                dgvCargo.Refresh();
                _id_cargo = null;
                cargarDataGridViewCargo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion DgvEmpresas_CellClick, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarDataGridViewCargo()
        {
            try
            {
                //instansear web service con seguridad
                ServiceProcess_Cargo.Process_CargoSoapClient auxServiceCargo = new ServiceProcess_Cargo.Process_CargoSoapClient();
                auxServiceCargo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCargo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Cargo.Cargo auxCargo = new ServiceProcess_Cargo.Cargo();
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                //capturar dataset
                DataSet ds = auxServiceCargo.TraerCargoConEmpresaSinEntidad_Escritorio(_rut_empresa);
                //Capturar Tabla
                DataTable dt = ds.Tables[0];
                //contar cantidad de empresas
                int _cantidad_cargos = dt.Rows.Count;
                //crear array bidimencional
                string[,] ListaCargos = new string[_cantidad_cargos, 5];
                //Recorrer data table
                int _fila = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Capturar datos de la fila recorridad en objeto cargo
                    auxCargo.Id_cargo = Convert.ToInt32(dt.Rows[i]["Id_Cargo"]);
                    auxCargo.Nombre = (String)dt.Rows[i]["Nombre"];
                    auxCargo.Descripcion = (String)dt.Rows[i]["Descripcion"];
                    auxCargo.Rut_empresa = (String)dt.Rows[i]["Rut_empresa"];
                    //variables temporales de apoyo                    
                    string _nombre_empresa = string.Empty;
                    //cargar array con datos de fila
                    ListaCargos[_fila, 0] = auxCargo.Id_cargo.ToString();
                    ListaCargos[_fila, 1] = auxCargo.Nombre;
                    //agregar lista a gridview
                    dgvCargo.Rows.Add(ListaCargos[_fila, 0], ListaCargos[_fila, 1]);
                    _fila++;

                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo cargarDataGridViewCargo, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCargo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0)
                    return;
                //captura de rut selecccionado
                _id_cargo = dgvCargo.Rows[e.RowIndex].Cells["ID_CARGO"].Value.ToString();

                lblPaso1.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Regular);
                lblPaso2.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Regular);
                lblPaso3.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Bold);
                pbSeleccion1.Visible = true;
                pbSeleccion2.Visible = true;
                pbSeleccion3.Visible = true;
                pbFlecha1.Visible = true;
                pbFlecha2.Visible = true;
                MessageBox.Show("Seleccion Completada paso siguiente Guardar.", "CREACION DE USUARIO MULTIEMPRESA", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion DgvCargo_CellClick, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                if (_rut_usuario == null || _rut_empresa == null || _id_cargo == null)
                {
                    if (_rut_usuario == null)
                    {
                        MessageBox.Show("Debe Seleccionar Usuario antes de Guardar.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (_rut_empresa == null)
                    {
                        MessageBox.Show("Debe Seleccionar Empresa antes de Guardar.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (_id_cargo == null)
                    {
                        MessageBox.Show("Debe Seleccionar Cargo antes de Guardar.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    ServiceProcess_CargosUsuarios.Process_CargosUsuariosSoapClient auxServiceCargosUsuarios = new ServiceProcess_CargosUsuarios.Process_CargosUsuariosSoapClient();
                    auxServiceCargosUsuarios.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                    auxServiceCargosUsuarios.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                    
                    if (MessageBox.Show("Confirmar La Creacion del Nuevo Usuario Multiempresa", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //Insertar datos via web service
                        auxServiceCargosUsuarios.InsertarCargosUsuarioSinEntidad_Escritorio(_rut_usuario, Convert.ToInt32(_id_cargo), 1);                        
                        //Metodo Carga de GridView
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        //se devuelve al Cuadro de datos
                    }
;                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion BtnGuardar_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtFiltrarUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dgvUsuario.Rows.Clear();
                dgvUsuario.Refresh();
                //instansear web service con seguridad                
                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Usuario.Usuario auxUsuario = new ServiceProcess_Usuario.Usuario();

                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                //capturar dataset
                DataSet ds = auxServiceUsuario.TraerUsuarioConFiltroSinEntidad_Escritorio(txtFiltrarUsuario.Text.ToUpper());
                if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    //Capturar Tabla
                    DataTable dt = ds.Tables[0];
                    //contar cantidad de empresas
                    int _cantidad_usuarios = dt.Rows.Count;
                    //crear array bidimencional
                    string[,] ListaUsuario = new string[_cantidad_usuarios, 2];
                    //Recorrer data table
                    int _fila = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Capturar datos de la fila recorridad en objeto empresa
                        auxUsuario.Rut_usuario = (String)dt.Rows[i]["Rut_usuario"];
                        auxUsuario.Primer_nombre = (String)dt.Rows[i]["Primer_nombre"];
                        auxUsuario.Segundo_nombre = (String)dt.Rows[i]["Segundo_nombre"];
                        auxUsuario.Primer_apellido = (String)dt.Rows[i]["Primer_apellido"];
                        auxUsuario.Segundo_apellido = (String)dt.Rows[i]["Segundo_apellido"];
                        auxUsuario.Direccion = (String)dt.Rows[i]["Direccion"];
                        auxUsuario.Telefono_fijo = Convert.ToInt32(dt.Rows[i]["Telefono_fijo"]);
                        auxUsuario.Telefono_movil = Convert.ToInt32(dt.Rows[i]["Telefono_movil"]);
                        auxUsuario.Id_comuna = Convert.ToInt32(dt.Rows[i]["Id_comuna"]);
                        //cargar array con datos de fila
                        ListaUsuario[_fila, 0] = auxUsuario.Rut_usuario;
                        ListaUsuario[_fila, 1] = auxUsuario.Primer_nombre + " " + auxUsuario.Primer_apellido; ;
                        //agregar lista a gridview
                        dgvUsuario.Rows.Add(ListaUsuario[_fila, 0], ListaUsuario[_fila, 1]);
                        _fila++;

                    }
                    lblPaso1.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Bold);
                    lblPaso2.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Regular);
                    lblPaso3.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Regular);
                    pbSeleccion1.Visible = false;
                    pbSeleccion2.Visible = false;
                    pbSeleccion3.Visible = false;
                    pbFlecha1.Visible = false;
                    pbFlecha2.Visible = false;
                    dgvEmpresas.Rows.Clear();
                    dgvEmpresas.Refresh();
                    dgvCargo.Rows.Clear();
                    dgvCargo.Refresh();
                    _rut_usuario = null;
                    _rut_empresa = null;
                    _id_cargo = null;
                }
                else
                {
                    lblPaso1.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Bold);
                    lblPaso2.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Regular);
                    lblPaso3.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Regular);
                    pbSeleccion1.Visible = false;
                    pbSeleccion2.Visible = false;
                    pbSeleccion3.Visible = false;
                    pbFlecha1.Visible = false;
                    pbFlecha2.Visible = false;
                    dgvEmpresas.Rows.Clear();
                    dgvEmpresas.Refresh();
                    dgvCargo.Rows.Clear();
                    dgvCargo.Refresh();
                    _rut_usuario = null;
                    _rut_empresa = null;
                    _id_cargo = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion TxtFiltrarUsuario_KeyUp, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtFiltrarEmpresa_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dgvEmpresas.Rows.Clear();
                dgvEmpresas.Refresh();
                //instansear web service con seguridad
                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Usuario.Process_UsuarioSoapClient auxServiceUsuario = new ServiceProcess_Usuario.Process_UsuarioSoapClient();
                auxServiceUsuario.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceUsuario.ClientCredentials.UserName.Password = Cuenta.Clave_iis;

                ServiceProcess_Usuario.Usuario auxUsuario = new ServiceProcess_Usuario.Usuario();
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                //capturar dataset
                DataSet ds = auxServiceEmpresa.TraerEmpresaConClaveSinEntidad_Escritorio(txtFiltrarEmpresa.Text.ToUpper());
                if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    //Capturar Tabla
                    DataTable dt = ds.Tables[0];
                    //contar cantidad de empresas
                    int _cantidad_empresas = dt.Rows.Count;
                    //crear array bidimencional
                    string[,] ListaEmpresas = new string[_cantidad_empresas, 2];
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

                        //CAPTURAR DATASET 
                        DataSet dsU = auxServiceUsuario.TraerUsuarioPorRutPorEmpresaSinEntidad_Escritorio(_rut_usuario, auxEmpresa.Rut_empresa);
                        if ((dsU.Tables.Count != 0) && (dsU.Tables[0].Rows.Count > 0))
                        {
                            //no carga nada al gridview por que ya es usuario  de la empresa
                        }
                        else
                        {
                            //cargar array con datos de fila
                            ListaEmpresas[_fila, 0] = auxEmpresa.Rut_empresa;
                            ListaEmpresas[_fila, 1] = auxEmpresa.Nombre;
                            //agregar lista a gridview
                            dgvEmpresas.Rows.Add(ListaEmpresas[_fila, 0], ListaEmpresas[_fila, 1]);
                            _fila++;
                        }
                    }
                    lblPaso1.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Regular);
                    lblPaso2.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Bold);
                    lblPaso3.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Regular);
                    pbSeleccion1.Visible = true;
                    pbSeleccion2.Visible = false;
                    pbSeleccion3.Visible = false;
                    pbFlecha1.Visible = true;
                    pbFlecha2.Visible = false;                    
                    dgvCargo.Rows.Clear();
                    dgvCargo.Refresh();                    
                    _rut_empresa = null;
                    _id_cargo = null;
                }
                else
                {
                    lblPaso1.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Regular);
                    lblPaso2.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Bold);
                    lblPaso3.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Regular);
                    pbSeleccion1.Visible = true;
                    pbSeleccion2.Visible = false;
                    pbSeleccion3.Visible = false;
                    pbFlecha1.Visible = true;
                    pbFlecha2.Visible = false;
                    dgvCargo.Rows.Clear();
                    dgvCargo.Refresh();
                    _rut_empresa = null;
                    _id_cargo = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion TxtFiltrarEmpresa_KeyUp, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtFiltrarCargo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dgvCargo.Rows.Clear();
                dgvCargo.Refresh();
                //instansear web service con seguridad
                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Cargo.Process_CargoSoapClient auxServiceCargo = new ServiceProcess_Cargo.Process_CargoSoapClient();
                auxServiceCargo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCargo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Cargo.Cargo auxCargo = new ServiceProcess_Cargo.Cargo();
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                //capturar dataset
                DataSet dsF = auxServiceCargo.TraerCargoConClaveSinEntidad_Escritorio(txtFiltrarCargo.Text.ToUpper());
                if ((dsF.Tables.Count != 0) && (dsF.Tables[0].Rows.Count > 0))
                {
                    //capturar dataset
                    DataSet ds = auxServiceCargo.TraerCargoConEmpresaSinEntidad_Escritorio(_rut_empresa);
                    //Capturar Tabla
                    DataTable dt = ds.Tables[0];
                    //contar cantidad de empresas
                    int _cantidad_cargos = dt.Rows.Count;
                    //crear array bidimencional
                    string[,] ListaCargos = new string[_cantidad_cargos, 5];
                    //Recorrer data table
                    int _fila = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Capturar datos de la fila recorridad en objeto cargo
                        auxCargo.Id_cargo = Convert.ToInt32(dt.Rows[i]["Id_Cargo"]);
                        auxCargo.Nombre = (String)dt.Rows[i]["Nombre"];
                        auxCargo.Descripcion = (String)dt.Rows[i]["Descripcion"];
                        auxCargo.Rut_empresa = (String)dt.Rows[i]["Rut_empresa"];
                        //variables temporales de apoyo                    
                        string _nombre_empresa = string.Empty;
                        //cargar array con datos de fila
                        ListaCargos[_fila, 0] = auxCargo.Id_cargo.ToString();
                        ListaCargos[_fila, 1] = auxCargo.Nombre;
                        //agregar lista a gridview
                        dgvCargo.Rows.Add(ListaCargos[_fila, 0], ListaCargos[_fila, 1]);
                        _fila++;

                    }
                    lblPaso1.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Regular);
                    lblPaso2.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Regular);
                    lblPaso3.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Bold);
                    pbSeleccion1.Visible = true;
                    pbSeleccion2.Visible = true;
                    pbSeleccion3.Visible = false;
                    pbFlecha1.Visible = true;
                    pbFlecha2.Visible = true;                    
                    _id_cargo = null;
                }
                else
                {
                    lblPaso1.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Regular);
                    lblPaso2.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Regular);
                    lblPaso3.Font = new System.Drawing.Font(lblPaso1.Font, FontStyle.Bold);
                    pbSeleccion1.Visible = true;
                    pbSeleccion2.Visible = true;
                    pbSeleccion3.Visible = false;
                    pbFlecha1.Visible = true;
                    pbFlecha2.Visible = true;
                    _id_cargo = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion TxtFiltrarCargo_KeyUp, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

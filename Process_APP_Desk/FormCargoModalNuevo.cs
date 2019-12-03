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
    public partial class FormCargoModalNuevo : Form
    {
        //VARIABLES
        string _rut_empresa = null;
        public FormCargoModalNuevo()
        {
            InitializeComponent();
            //Se habilita Boton
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
            //se activan txtbox de nombre
            txtNombre.ReadOnly = false;
            txtNombre.Enabled = true;
            //se activan txtbox de descripcion
            txtDescripcion.ReadOnly = false;
            txtDescripcion.Enabled = true;
            //se activan txtbox de empresa
            txtEmpresa.ReadOnly = true;
            txtEmpresa.Enabled = false;
            //se inactiva txtbox de filtro
            txtFiltrar.ReadOnly = false;
            txtFiltrar.Enabled = true;
            //se inactiva foto seleccion
            pbSeleccion.Visible = false;
            cargarDataGridViewPpal();
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
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                //capturar dataset
                DataSet ds = auxServiceEmpresa.TraerTodasEmpresas_Escritorio();
                //Capturar Tabla
                DataTable dt = ds.Tables[0];
                //contar cantidad de empresas
                int _cantidad_empresas = dt.Rows.Count;
                //crear array bidimencional
                string[,] ListaEmpresa = new string[_cantidad_empresas, 2];
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
                    if (auxEmpresa.Estado == 1) // si la empresa esta activa se carga en la lista
                    {
                        // cargar array con datos de fila
                        ListaEmpresa[_fila, 0] = auxEmpresa.Rut_empresa;
                        ListaEmpresa[_fila, 1] = auxEmpresa.Nombre;
                        //agregar lista a gridview
                        dgvEmpresas.Rows.Add(ListaEmpresa[_fila, 0], ListaEmpresa[_fila, 1]);
                        _fila++;
                    }


                }
                pbSeleccion.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo cargarDataGridViewPpal, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //mETODO BOTON CANCELAR
        //private void BtnCancelar_Click(object sender, EventArgs e)
        //{
        //    if (MessageBox.Show("¿Esta seguro de Cancelar?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        this.Close();
        //        System.GC.Collect();
        //        //volver al menu de Mantenedor
        //    }
        //    else
        //    {
        //        //volver al Modal
        //    }
        //}

        private void DgvEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                _rut_empresa = dgvEmpresas.Rows[e.RowIndex].Cells["RUT"].Value.ToString();


                //instansear web service con seguridad
                ServiceProcess_Empresa.Process_EmpresaSoapClient auxServiceEmpresa = new ServiceProcess_Empresa.Process_EmpresaSoapClient();
                auxServiceEmpresa.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceEmpresa.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Empresa.Empresa auxEmpresa = new ServiceProcess_Empresa.Empresa();
                auxEmpresa = auxServiceEmpresa.TraerEmpresaConEntidad_Escritorio(_rut_empresa);

                _rut_empresa = auxEmpresa.Rut_empresa;
                txtEmpresa.Text = auxEmpresa.Nombre;

                pbSeleccion.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion DgvEmpresas_CellClick, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                    string[,] ListaEmpresa = new string[_cantidad_empresas, 2];
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

                        if (auxEmpresa.Estado == 1) // si la empresa esta activa se carga en la lista
                        {
                            // cargar array con datos de fila
                            ListaEmpresa[_fila, 0] = auxEmpresa.Rut_empresa;
                            ListaEmpresa[_fila, 1] = auxEmpresa.Nombre;
                            //agregar lista a gridview
                            dgvEmpresas.Rows.Add(ListaEmpresa[_fila, 0], ListaEmpresa[_fila, 1]);
                            _fila++;
                        }
                    }
                    txtEmpresa.Clear();
                    pbSeleccion.Visible = false;
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

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Instancia de Web service con credenciales NT
                ServiceProcess_Cargo.Process_CargoSoapClient auxServiceCargo = new ServiceProcess_Cargo.Process_CargoSoapClient();
                auxServiceCargo.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceCargo.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
               
                ServiceProcess_Cargo.Cargo auxCargo = new ServiceProcess_Cargo.Cargo();

                //Validacion espacion en blanco y combobox vacios
                if (txtNombre.Text.Equals("") || txtDescripcion.Text.Equals("") || txtEmpresa.Text.Equals(""))
                {
                    if (txtNombre.Text.Equals(""))
                    {
                        MessageBox.Show("El Nombre del Cargo no Puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (txtDescripcion.Text.Equals(""))
                    {
                        MessageBox.Show("La Descripcion del Cargo no Puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (txtEmpresa.Text.Equals(""))
                    {
                        MessageBox.Show("Debe seleccionar una Empresa a la cual pertenece el Cargo, en la Lista de la Izquierda.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //Validacion de longitud de caracteres
                    if (txtNombre.Text.Trim().Length < 4 || txtNombre.Text.Trim().Length > 99
                        || txtDescripcion.Text.Trim().Length < 10 || txtDescripcion.Text.Trim().Length > 250)
                    {
                        if (txtNombre.Text.Trim().Length < 4 || txtNombre.Text.Trim().Length > 99)
                        {
                            MessageBox.Show("El Nombre del Cargo debe tener Minimo 4 caracteres y Maximo 99 .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (txtDescripcion.Text.Trim().Length < 10 || txtDescripcion.Text.Trim().Length > 250)
                        {
                            MessageBox.Show("La Descripcion del cargo debe tener Minimo 10 caracteres y Maximo 250 .", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        auxCargo = auxServiceCargo.TraerCargoPorNombrePorEmpresaConEntidad_Escritorio(txtNombre.Text.ToUpper(), _rut_empresa);
                        //Validar si Nombre Cargo ya existe en la empresa
                        if (auxCargo.Nombre == null)
                        {

                            if (MessageBox.Show("Confirmar La Creacion del Cargo", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //Insertar datos via web service
                                auxServiceCargo.InsertarCargoSinEntidad_Escritorio(txtNombre.Text.ToUpper(), txtDescripcion.Text.ToUpper(), _rut_empresa);                         
                                //Metodo Carga de GridView
                                this.DialogResult = DialogResult.OK;
                                this.Close();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion BtnGuardar_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}

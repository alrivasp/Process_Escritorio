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
    public partial class FormRolModal : Form
    {
        //Variable Titulo
        public static string _titulo_modal;
        //vARIABLE SELECCION DE ACCESO
        public static string _id_acceso_seleccion = null;
        public static string _nombre_acceso_seleccion;
        //Variables para cargar datos desde el gridview
        public static string _id_rol = null;
        public static string _nombre;
        public static string _estado;
        //Variable para interaccion de botones (1 = modificar) - (2 = nuevo) - (3 = Ver)
        public static int _guardar = 0;
        public FormRolModal()
        {
            InitializeComponent();
        }

        public FormRolModal(string tituloModal, int accion, string id_rol, string nombre, string estado)
        {
            InitializeComponent();
            try
            {
                //Modalidad de Modal segun Accion Padre 1 = modificar / 2 = nuevo / 3 = Ver
                if (accion == 1)
                {
                    //Cambiar Titulo de Modal
                    lblTitulo.Text = tituloModal;
                    //Instancia de Web service con credenciales NT
                    ServiceProcess_Acceso.Process_AccesoSoapClient auxServiceAcceso = new ServiceProcess_Acceso.Process_AccesoSoapClient();
                    auxServiceAcceso.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                    auxServiceAcceso.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                    ServiceProcess_Acceso.Acceso auxAcceso = new ServiceProcess_Acceso.Acceso();
                    //Se carga variable de id rol
                    _id_rol = id_rol;
                    //Capturar nombre rol
                    _nombre = nombre;
                    //Capturar estado
                    _estado = estado;
                    //Se habilita Boton
                    btnGuardar.Visible = true;
                    btnCancelar.Visible = true;
                    btnAgregarAcceso.Visible = true;
                    btnQuitarAcceso.Visible = true;
                    //se inactiva txtbox de estado
                    txtEstado.ReadOnly = true;
                    txtEstado.Enabled = false;
                    //se pasan datos a cajas de texto a variables globales
                    txtNombre.Text = _nombre;
                    txtEstado.Text = _estado;
                    if (Convert.ToInt32(_estado) == 1)
                    {
                        txtEstado.Text = "ACTIVO";
                    }
                    else
                    {
                        txtEstado.Text = "DASACTIVADO";
                    }
                    //bloquear combobox
                    cbAcceso.DropDownStyle = ComboBoxStyle.DropDownList;
                    dgvAcceso.ReadOnly = true;
                    pbSeleccion.Visible = false;
                    cargarComboAcceso();
                    cargarDataGridViewPpal();

                    //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar) - (3 = Ver)
                    _guardar = 1;
                }
                else
                {
                    //Cambiar Titulo de Modal
                    lblTitulo.Text = tituloModal;
                    //Instancia de Web service con credenciales NT
                    ServiceProcess_Acceso.Process_AccesoSoapClient auxServiceAcceso = new ServiceProcess_Acceso.Process_AccesoSoapClient();
                    auxServiceAcceso.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                    auxServiceAcceso.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                    ServiceProcess_Acceso.Acceso auxAcceso = new ServiceProcess_Acceso.Acceso();
                    //Vaciar variables
                    _id_rol = null;
                    _nombre = string.Empty;
                    _estado = string.Empty;
                    //Se habilita Boton
                    btnGuardar.Visible = true;
                    btnCancelar.Visible = true;
                    btnAgregarAcceso.Visible = true;
                    btnQuitarAcceso.Visible = true;
                    //se inactiva txtbox de estado
                    txtEstado.Visible = false;
                    lblEstado.Visible = false;
                    //bloquear combobox
                    cbAcceso.DropDownStyle = ComboBoxStyle.DropDownList;
                    dgvAcceso.ReadOnly = true;
                    pbSeleccion.Visible = false;
                    cargarComboAcceso();
                    cargarDataGridViewPpal();
                    //Variable para interaccion de botones (0 = ninguno) (1 = modificar) - (2 = guardar) - (3 = Ver)
                    _guardar = 3;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion Modal Unidad, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarComboAcceso()
        {
            try
            {
                ServiceProcess_Acceso.Process_AccesoSoapClient auxServiceAcceso = new ServiceProcess_Acceso.Process_AccesoSoapClient();
                auxServiceAcceso.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceAcceso.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Acceso.Acceso auxAcceso = new ServiceProcess_Acceso.Acceso();
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
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo cargarComboAcceso, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Metodo Carga GridView 
        public void cargarDataGridViewPpal()
        {
            try
            {
                //instansear web service con seguridad
                ServiceProcess_Acceso.Process_AccesoSoapClient auxServiceAcceso = new ServiceProcess_Acceso.Process_AccesoSoapClient();
                auxServiceAcceso.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceAcceso.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Acceso.Acceso auxAcceso = new ServiceProcess_Acceso.Acceso();
                ServiceProcess_Permisos.Process_PermisosSoapClient auxServicePermisos = new ServiceProcess_Permisos.Process_PermisosSoapClient();
                auxServicePermisos.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServicePermisos.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Permisos.Permisos auxPermisos = new ServiceProcess_Permisos.Permisos();
                //capturar dataset
                DataSet ds = auxServicePermisos.TraerPermisosPorRolSinEntidad_Escritorio(Convert.ToInt32(_id_rol));
                if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    //Capturar Tabla
                    DataTable dt = ds.Tables[0];
                    //contar cantidad de accesos
                    int _cantidad_permisos = dt.Rows.Count;
                    //crear array bidimencional
                    string[,] ListaPermisos = new string[_cantidad_permisos, 2];
                    //Recorrer data table
                    int _fila = 0;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Capturar datos de la fila recorridad en objeto empresa
                        auxPermisos.Id_acceso = Convert.ToInt32(dt.Rows[i]["ID_ACCESO"]);
                        auxPermisos.Id_rol = Convert.ToInt32(dt.Rows[i]["ID_ROL"]);
                        //
                        auxAcceso = auxServiceAcceso.TraerAccesoConEntidad_Escritorio(auxPermisos.Id_acceso);
                        // cargar array con datos de fila
                        ListaPermisos[_fila, 0] = auxAcceso.Id_acceso.ToString();
                        ListaPermisos[_fila, 1] = auxAcceso.Nombre;
                        //agregar lista a gridview
                        dgvAcceso.Rows.Add(ListaPermisos[_fila, 0], ListaPermisos[_fila, 1]);
                        _fila++;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo cargarDataGridViewPpal, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DgvAcceso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                _id_acceso_seleccion = dgvAcceso.Rows[e.RowIndex].Cells["ID_ACCESO"].Value.ToString();
                _nombre_acceso_seleccion = dgvAcceso.Rows[e.RowIndex].Cells["NOMBRE_ACCESO"].Value.ToString();
                pbSeleccion.Visible = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion DgvUnidad_CellClick, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAgregarAcceso_Click(object sender, EventArgs e)
        {
            try
            {
                int valor_repetido = 0;
                if (cbAcceso.SelectedIndex == 0)
                {
                    MessageBox.Show("Debe seleccionar un Acceso antes de Agregar.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Capturo datos de combo acceso
                    _id_acceso_seleccion = cbAcceso.SelectedValue.ToString();
                    _nombre_acceso_seleccion = cbAcceso.GetItemText(cbAcceso.SelectedItem);

                    // validar si acceso seleccionado ya esta en los permisos que tiene el rol
                    for (int i = 0; i < dgvAcceso.Rows.Count; i++)
                    {
                        if (dgvAcceso.Rows[i].Cells[0].Value.ToString().Equals(_id_acceso_seleccion))
                        {
                            valor_repetido = 1;
                            MessageBox.Show("El Acceso ya existe en los Permisos del ROL.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }

                    if (valor_repetido == 0)
                    {
                        int contador = dgvAcceso.Rows.Count;
                        dgvAcceso.Rows.Insert(contador, _id_acceso_seleccion, _nombre_acceso_seleccion);
                        MessageBox.Show("Acceso Agregado a la lista.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    cbAcceso.SelectedValue = 0;
                    pbSeleccion.Visible = false;
                    _id_acceso_seleccion = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en metodo de accion BtnAgregarAcceso_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnQuitarAcceso_Click(object sender, EventArgs e)
        {

            try
            {
                if (_id_acceso_seleccion == null)
                {
                    MessageBox.Show("Debe seleccionar un Acceso de la Lista.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int fila = dgvAcceso.CurrentRow.Index;
                    dgvAcceso.Rows.RemoveAt(fila);
                    pbSeleccion.Visible = false;
                    _id_acceso_seleccion = null;
                    MessageBox.Show("Acceso Eliminado de la lista.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                ServiceProcess_Rol.Process_RolSoapClient auxServiceRol = new ServiceProcess_Rol.Process_RolSoapClient();
                auxServiceRol.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceRol.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Rol.Rol auxRol = new ServiceProcess_Rol.Rol();
                ServiceProcess_Acceso.Process_AccesoSoapClient auxServiceAcceso = new ServiceProcess_Acceso.Process_AccesoSoapClient();
                auxServiceAcceso.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServiceAcceso.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Acceso.Acceso auxAcceso = new ServiceProcess_Acceso.Acceso();
                ServiceProcess_Permisos.Process_PermisosSoapClient auxServicePermisos = new ServiceProcess_Permisos.Process_PermisosSoapClient();
                auxServicePermisos.ClientCredentials.UserName.UserName = Cuenta.Usuario_iis;
                auxServicePermisos.ClientCredentials.UserName.Password = Cuenta.Clave_iis;
                ServiceProcess_Permisos.Permisos auxPermisos = new ServiceProcess_Permisos.Permisos();

                if (_guardar == 1)//Modificar ROL
                {
                    //Validacion espacio en blanco y seleccion de combobox
                    if (txtNombre.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("El campo Nombre No puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        //Validar longitud de caracteres
                        if (txtNombre.Text.Trim().Length < 3 || txtNombre.Text.Trim().Length > 50)
                        {
                            MessageBox.Show("El Nombre, debe tener un minimo de 3 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            //validar que se esta dejando el mismo nombre
                            auxRol = auxServiceRol.TraerRolPorNombreConEntidad_Escritorio(txtNombre.Text);
                            if (txtNombre.Text.ToUpper().Equals(_nombre.ToUpper()))
                            {                             
                                    if (dgvAcceso.Rows.Count < 1)
                                    {
                                        MessageBox.Show("Debe Agregar un Permiso como minimo al Rol.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        //confirmacion de Actualizar  ROL
                                        if (MessageBox.Show("Confirmar La Actualizacion del Rol.", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            //capturar dataset
                                            DataSet ds = auxServicePermisos.TraerPermisosPorRolSinEntidad_Escritorio(Convert.ToInt32(_id_rol));// CAPTURAR REGISTROS SEGUN ROL
                                            if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))//VALIDAR QUE DATASET NO VENGA VACIO SI CON INFORMACION SE BORRAR LOS PERMISOS PARA EL ROL
                                            {
                                                auxServicePermisos.EliminarPermisosSinEntidad_Escritorio(Convert.ToInt32(_id_rol));
                                            }

                                            for (int i = 0; i < dgvAcceso.Rows.Count; i++)//recorrer data gred view
                                            {
                                                string _id_acceso_insertar = dgvAcceso.Rows[i].Cells["ID_ACCESO"].Value.ToString();
                                                auxServicePermisos.InsertarPermisosSinEntidad_Escritorio(Convert.ToInt32(_id_acceso_insertar), Convert.ToInt32(_id_rol));
                                            }

                                            auxServiceRol.ActualizarRolSinEntidad_Escritorio(Convert.ToInt32(_id_rol), txtNombre.Text, Convert.ToInt32(_estado));
                                            _id_rol = null;
                                            this.DialogResult = DialogResult.OK;
                                            this.Close();
                                        }
                                        else
                                        {
                                            //se devuelve al Cuadro de datos
                                            MessageBox.Show("NO se Actualizo Rol.", "ACTUALIZACION DE ROL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                               
                            }
                            else if (auxRol.Nombre == null)
                            {
                                if (dgvAcceso.Rows.Count < 1)
                                {
                                    MessageBox.Show("Debe Agregar un Permiso como minimo al Rol.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    //confirmacion de Actualizar  ROL
                                    if (MessageBox.Show("Confirmar La Actualizacion del Rol.", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        //capturar dataset
                                        DataSet ds = auxServicePermisos.TraerPermisosPorRolSinEntidad_Escritorio(Convert.ToInt32(_id_rol));// CAPTURAR REGISTROS SEGUN ROL
                                        if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))//VALIDAR QUE DATASET NO VENGA VACIO SI CON INFORMACION SE BORRAR LOS PERMISOS PARA EL ROL
                                        {
                                            auxServicePermisos.EliminarPermisosSinEntidad_Escritorio(Convert.ToInt32(_id_rol));
                                        }

                                        for (int i = 0; i < dgvAcceso.Rows.Count; i++)//recorrer data gred view
                                        {
                                            string _id_acceso_insertar = dgvAcceso.Rows[i].Cells["ID_ACCESO"].Value.ToString();
                                            auxServicePermisos.InsertarPermisosSinEntidad_Escritorio(Convert.ToInt32(_id_acceso_insertar), Convert.ToInt32(_id_rol));
                                        }

                                        auxServiceRol.ActualizarRolSinEntidad_Escritorio(Convert.ToInt32(_id_rol), txtNombre.Text, Convert.ToInt32(_estado));
                                        _id_rol = null;
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                    else
                                    {
                                        //se devuelve al Cuadro de datos
                                        MessageBox.Show("NO se Actualizo Rol.", "ACTUALIZACION DE ROL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("El Nombre del Rol Modificado ya Existe.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }

                    }
                }
                else//Nuevo Rol
                {
                    //Validacion espacio en blanco y seleccion de combobox
                    if (txtNombre.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("El campo Nombre No puede estar Vacio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        //Validar longitud de caracteres
                        if (txtNombre.Text.Trim().Length < 3 || txtNombre.Text.Trim().Length > 50)
                        {
                            MessageBox.Show("El Nombre, debe tener un minimo de 3 Caracteres.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            //validar rol no exista
                            auxRol = auxServiceRol.TraerRolPorNombreConEntidad_Escritorio(txtNombre.Text);
                            if (auxRol.Nombre == null)
                            {
                                if (dgvAcceso.Rows.Count < 1)
                                {
                                    MessageBox.Show("Debe Agregar un Permiso como minimo al Rol.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    //confirmacion de Actualizar  ROL
                                    if (MessageBox.Show("Confirmar la Creacion del Nuevo Rol.", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {         
                                        auxServiceRol.InsertarRolSinEntidad_Escritorio(txtNombre.Text.ToUpper(), 1);
                                        auxRol = auxServiceRol.TraerRolPorNombreConEntidad_Escritorio(txtNombre.Text.ToUpper());

                                        for (int i = 0; i < dgvAcceso.Rows.Count; i++)//recorrer data gred view
                                        {
                                            string _id_acceso_insertar = dgvAcceso.Rows[i].Cells["ID_ACCESO"].Value.ToString();
                                            auxServicePermisos.InsertarPermisosSinEntidad_Escritorio(Convert.ToInt32(_id_acceso_insertar), auxRol.Id_rol);
                                        }

                                        
                                        _id_rol = null;
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                    else
                                    {
                                        //se devuelve al Cuadro de datos
                                        MessageBox.Show("NO se Creo Rol.", "Nuevo ROL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("El Nombre del Nuevo Rol ya Existe.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en metodo de accion BtnGuardar_Click, Contactese con el Administrador Detalle de Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }//fin try catch
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
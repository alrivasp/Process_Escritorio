namespace Process_APP_Desk
{
    partial class FormEquipo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEquipo));
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbUnidad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMiembros = new System.Windows.Forms.DataGridView();
            this.dgvEquipo = new System.Windows.Forms.DataGridView();
            this.ID_EQUIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE_EQUIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RUT_EMPRESA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE_EMPRESA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_UNIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE_UNIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFiltrar = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Label();
            this.btnColaborador = new System.Windows.Forms.Button();
            this.btnLider = new System.Windows.Forms.Button();
            this.pbSeleccionUnidad = new System.Windows.Forms.PictureBox();
            this.pbSeleccionEmpresa = new System.Windows.Forms.PictureBox();
            this.btnMiembros = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.pbSeleccionEquipo = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RUT_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MIEMBRO_EQUIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JERARQUIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelContenedor.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMiembros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSeleccionUnidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSeleccionEmpresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSeleccionEquipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.White;
            this.panelContenedor.Controls.Add(this.btnColaborador);
            this.panelContenedor.Controls.Add(this.btnLider);
            this.panelContenedor.Controls.Add(this.panel2);
            this.panelContenedor.Controls.Add(this.dgvMiembros);
            this.panelContenedor.Controls.Add(this.dgvEquipo);
            this.panelContenedor.Controls.Add(this.btnMiembros);
            this.panelContenedor.Controls.Add(this.btnModificar);
            this.panelContenedor.Controls.Add(this.btnNuevo);
            this.panelContenedor.Controls.Add(this.panel1);
            this.panelContenedor.Controls.Add(this.btnCerrar);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1050, 480);
            this.panelContenedor.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cbUnidad);
            this.panel2.Controls.Add(this.pbSeleccionUnidad);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbEmpresa);
            this.panel2.Controls.Add(this.pbSeleccionEmpresa);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(566, 73);
            this.panel2.TabIndex = 41;
            // 
            // cbUnidad
            // 
            this.cbUnidad.FormattingEnabled = true;
            this.cbUnidad.Location = new System.Drawing.Point(201, 40);
            this.cbUnidad.Name = "cbUnidad";
            this.cbUnidad.Size = new System.Drawing.Size(279, 21);
            this.cbUnidad.TabIndex = 44;
            this.cbUnidad.SelectedIndexChanged += new System.EventHandler(this.CbUnidad_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label2.Location = new System.Drawing.Point(32, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 19);
            this.label2.TabIndex = 42;
            this.label2.Text = "SELECCIONE UNIDAD:";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(201, 9);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(279, 21);
            this.cbEmpresa.TabIndex = 41;
            this.cbEmpresa.SelectedIndexChanged += new System.EventHandler(this.CbEmpresa_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label1.Location = new System.Drawing.Point(32, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 19);
            this.label1.TabIndex = 38;
            this.label1.Text = "SELECCIONE EMPRESA:";
            // 
            // dgvMiembros
            // 
            this.dgvMiembros.AllowUserToAddRows = false;
            this.dgvMiembros.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvMiembros.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMiembros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvMiembros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMiembros.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvMiembros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMiembros.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMiembros.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMiembros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMiembros.ColumnHeadersHeight = 30;
            this.dgvMiembros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMiembros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RUT_USUARIO,
            this.MIEMBRO_EQUIPO,
            this.JERARQUIA});
            this.dgvMiembros.EnableHeadersVisualStyles = false;
            this.dgvMiembros.GridColor = System.Drawing.Color.White;
            this.dgvMiembros.Location = new System.Drawing.Point(12, 307);
            this.dgvMiembros.Name = "dgvMiembros";
            this.dgvMiembros.ReadOnly = true;
            this.dgvMiembros.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMiembros.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMiembros.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMiembros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMiembros.Size = new System.Drawing.Size(870, 170);
            this.dgvMiembros.TabIndex = 48;
            this.dgvMiembros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMiembros_CellClick);
            // 
            // dgvEquipo
            // 
            this.dgvEquipo.AllowUserToAddRows = false;
            this.dgvEquipo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvEquipo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEquipo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvEquipo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquipo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvEquipo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEquipo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEquipo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquipo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvEquipo.ColumnHeadersHeight = 30;
            this.dgvEquipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEquipo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_EQUIPO,
            this.NOMBRE_EQUIPO,
            this.RUT_EMPRESA,
            this.NOMBRE_EMPRESA,
            this.ID_UNIDAD,
            this.NOMBRE_UNIDAD});
            this.dgvEquipo.EnableHeadersVisualStyles = false;
            this.dgvEquipo.GridColor = System.Drawing.Color.White;
            this.dgvEquipo.Location = new System.Drawing.Point(12, 137);
            this.dgvEquipo.Name = "dgvEquipo";
            this.dgvEquipo.ReadOnly = true;
            this.dgvEquipo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquipo.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEquipo.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvEquipo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipo.Size = new System.Drawing.Size(870, 170);
            this.dgvEquipo.TabIndex = 47;
            this.dgvEquipo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvEquipo_CellClick);
            // 
            // ID_EQUIPO
            // 
            this.ID_EQUIPO.HeaderText = "ID_EQUIPO";
            this.ID_EQUIPO.Name = "ID_EQUIPO";
            this.ID_EQUIPO.ReadOnly = true;
            this.ID_EQUIPO.Visible = false;
            // 
            // NOMBRE_EQUIPO
            // 
            this.NOMBRE_EQUIPO.HeaderText = "NOMBRE EQUIPO";
            this.NOMBRE_EQUIPO.Name = "NOMBRE_EQUIPO";
            this.NOMBRE_EQUIPO.ReadOnly = true;
            // 
            // RUT_EMPRESA
            // 
            this.RUT_EMPRESA.HeaderText = "RUT_EMPRESA";
            this.RUT_EMPRESA.Name = "RUT_EMPRESA";
            this.RUT_EMPRESA.ReadOnly = true;
            this.RUT_EMPRESA.Visible = false;
            // 
            // NOMBRE_EMPRESA
            // 
            this.NOMBRE_EMPRESA.HeaderText = "NOMBRE EMPRESA";
            this.NOMBRE_EMPRESA.Name = "NOMBRE_EMPRESA";
            this.NOMBRE_EMPRESA.ReadOnly = true;
            // 
            // ID_UNIDAD
            // 
            this.ID_UNIDAD.HeaderText = "ID_UNIDAD";
            this.ID_UNIDAD.Name = "ID_UNIDAD";
            this.ID_UNIDAD.ReadOnly = true;
            this.ID_UNIDAD.Visible = false;
            // 
            // NOMBRE_UNIDAD
            // 
            this.NOMBRE_UNIDAD.HeaderText = "NOMBRE UNIDAD";
            this.NOMBRE_UNIDAD.Name = "NOMBRE_UNIDAD";
            this.NOMBRE_UNIDAD.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pbSeleccionEquipo);
            this.panel1.Controls.Add(this.txtFiltrar);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 43);
            this.panel1.TabIndex = 39;
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFiltrar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFiltrar.Location = new System.Drawing.Point(274, 11);
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Size = new System.Drawing.Size(472, 20);
            this.txtFiltrar.TabIndex = 39;
            this.txtFiltrar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtFiltrar_KeyUp);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label8.Location = new System.Drawing.Point(32, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(236, 19);
            this.label8.TabIndex = 38;
            this.label8.Text = "FILTRAR POR NOMBRE DE EQUIPO:";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.AutoSize = true;
            this.btnCerrar.BackColor = System.Drawing.Color.White;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCerrar.Location = new System.Drawing.Point(1024, 9);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(17, 17);
            this.btnCerrar.TabIndex = 36;
            this.btnCerrar.Text = "X";
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // btnColaborador
            // 
            this.btnColaborador.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnColaborador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnColaborador.FlatAppearance.BorderSize = 0;
            this.btnColaborador.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnColaborador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColaborador.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColaborador.ForeColor = System.Drawing.Color.White;
            this.btnColaborador.Image = global::Process_APP_Desk.Properties.Resources._114_user;
            this.btnColaborador.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColaborador.Location = new System.Drawing.Point(890, 288);
            this.btnColaborador.Name = "btnColaborador";
            this.btnColaborador.Size = new System.Drawing.Size(150, 33);
            this.btnColaborador.TabIndex = 50;
            this.btnColaborador.Text = "COLABORADOR";
            this.btnColaborador.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnColaborador.UseVisualStyleBackColor = false;
            this.btnColaborador.Visible = false;
            this.btnColaborador.Click += new System.EventHandler(this.BtnColaborador_Click);
            // 
            // btnLider
            // 
            this.btnLider.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLider.FlatAppearance.BorderSize = 0;
            this.btnLider.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnLider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLider.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLider.ForeColor = System.Drawing.Color.White;
            this.btnLider.Image = global::Process_APP_Desk.Properties.Resources._119_user_tie;
            this.btnLider.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLider.Location = new System.Drawing.Point(890, 288);
            this.btnLider.Name = "btnLider";
            this.btnLider.Size = new System.Drawing.Size(150, 33);
            this.btnLider.TabIndex = 49;
            this.btnLider.Text = "LIDER EQUIPO ";
            this.btnLider.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLider.UseVisualStyleBackColor = false;
            this.btnLider.Visible = false;
            this.btnLider.Click += new System.EventHandler(this.BtnLider_Click);
            // 
            // pbSeleccionUnidad
            // 
            this.pbSeleccionUnidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbSeleccionUnidad.Image = global::Process_APP_Desk.Properties.Resources._071_pushpin;
            this.pbSeleccionUnidad.Location = new System.Drawing.Point(512, 36);
            this.pbSeleccionUnidad.Name = "pbSeleccionUnidad";
            this.pbSeleccionUnidad.Size = new System.Drawing.Size(24, 25);
            this.pbSeleccionUnidad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSeleccionUnidad.TabIndex = 43;
            this.pbSeleccionUnidad.TabStop = false;
            this.pbSeleccionUnidad.Visible = false;
            // 
            // pbSeleccionEmpresa
            // 
            this.pbSeleccionEmpresa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbSeleccionEmpresa.Image = global::Process_APP_Desk.Properties.Resources._071_pushpin;
            this.pbSeleccionEmpresa.Location = new System.Drawing.Point(512, 5);
            this.pbSeleccionEmpresa.Name = "pbSeleccionEmpresa";
            this.pbSeleccionEmpresa.Size = new System.Drawing.Size(24, 25);
            this.pbSeleccionEmpresa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSeleccionEmpresa.TabIndex = 40;
            this.pbSeleccionEmpresa.TabStop = false;
            this.pbSeleccionEmpresa.Visible = false;
            // 
            // btnMiembros
            // 
            this.btnMiembros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMiembros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnMiembros.FlatAppearance.BorderSize = 0;
            this.btnMiembros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnMiembros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiembros.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMiembros.ForeColor = System.Drawing.Color.White;
            this.btnMiembros.Image = global::Process_APP_Desk.Properties.Resources._115_users;
            this.btnMiembros.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMiembros.Location = new System.Drawing.Point(898, 237);
            this.btnMiembros.Name = "btnMiembros";
            this.btnMiembros.Size = new System.Drawing.Size(130, 33);
            this.btnMiembros.TabIndex = 44;
            this.btnMiembros.Text = "MIEMBROS";
            this.btnMiembros.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMiembros.UseVisualStyleBackColor = false;
            this.btnMiembros.Click += new System.EventHandler(this.BtnMiembros_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Image = global::Process_APP_Desk.Properties.Resources._007_pencil2;
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnModificar.Location = new System.Drawing.Point(898, 187);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(130, 33);
            this.btnModificar.TabIndex = 43;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Image = global::Process_APP_Desk.Properties.Resources._267_plus_White;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevo.Location = new System.Drawing.Point(898, 137);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(130, 33);
            this.btnNuevo.TabIndex = 42;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // pbSeleccionEquipo
            // 
            this.pbSeleccionEquipo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbSeleccionEquipo.Image = global::Process_APP_Desk.Properties.Resources._071_pushpin;
            this.pbSeleccionEquipo.Location = new System.Drawing.Point(827, 6);
            this.pbSeleccionEquipo.Name = "pbSeleccionEquipo";
            this.pbSeleccionEquipo.Size = new System.Drawing.Size(24, 25);
            this.pbSeleccionEquipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSeleccionEquipo.TabIndex = 40;
            this.pbSeleccionEquipo.TabStop = false;
            this.pbSeleccionEquipo.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::Process_APP_Desk.Properties.Resources._348_filter;
            this.pictureBox1.Location = new System.Drawing.Point(768, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // RUT_USUARIO
            // 
            this.RUT_USUARIO.HeaderText = "RUT_USUARIO";
            this.RUT_USUARIO.Name = "RUT_USUARIO";
            this.RUT_USUARIO.ReadOnly = true;
            this.RUT_USUARIO.Visible = false;
            // 
            // MIEMBRO_EQUIPO
            // 
            this.MIEMBRO_EQUIPO.HeaderText = "MIEMBRO EQUIPO";
            this.MIEMBRO_EQUIPO.Name = "MIEMBRO_EQUIPO";
            this.MIEMBRO_EQUIPO.ReadOnly = true;
            // 
            // JERARQUIA
            // 
            this.JERARQUIA.HeaderText = "JERARQUIA";
            this.JERARQUIA.Name = "JERARQUIA";
            this.JERARQUIA.ReadOnly = true;
            // 
            // FormEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 480);
            this.Controls.Add(this.panelContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEquipo";
            this.Text = "PROCESS";
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMiembros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSeleccionUnidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSeleccionEmpresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSeleccionEquipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbUnidad;
        private System.Windows.Forms.PictureBox pbSeleccionUnidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.PictureBox pbSeleccionEmpresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMiembros;
        private System.Windows.Forms.DataGridView dgvEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_EQUIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE_EQUIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn RUT_EMPRESA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE_EMPRESA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_UNIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE_UNIDAD;
        private System.Windows.Forms.Button btnMiembros;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbSeleccionEquipo;
        private System.Windows.Forms.TextBox txtFiltrar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label btnCerrar;
        private System.Windows.Forms.Button btnColaborador;
        private System.Windows.Forms.Button btnLider;
        private System.Windows.Forms.DataGridViewTextBoxColumn RUT_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MIEMBRO_EQUIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn JERARQUIA;
    }
}
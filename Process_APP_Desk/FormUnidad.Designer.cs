namespace Process_APP_Desk
{
    partial class FormUnidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUnidad));
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.btnActivar = new System.Windows.Forms.Button();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.btnVer = new System.Windows.Forms.Button();
            this.dgvUnidad = new System.Windows.Forms.DataGridView();
            this.ID_UNIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE_UNIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMPRESA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RUT_EMPRESA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbSeleccion = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtFiltrar = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Label();
            this.panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnidad)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSeleccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.White;
            this.panelContenedor.Controls.Add(this.btnActivar);
            this.panelContenedor.Controls.Add(this.btnDesactivar);
            this.panelContenedor.Controls.Add(this.btnVer);
            this.panelContenedor.Controls.Add(this.dgvUnidad);
            this.panelContenedor.Controls.Add(this.btnModificar);
            this.panelContenedor.Controls.Add(this.btnNuevo);
            this.panelContenedor.Controls.Add(this.panel1);
            this.panelContenedor.Controls.Add(this.btnCerrar);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1050, 480);
            this.panelContenedor.TabIndex = 0;
            // 
            // btnActivar
            // 
            this.btnActivar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnActivar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnActivar.FlatAppearance.BorderSize = 0;
            this.btnActivar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnActivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivar.ForeColor = System.Drawing.Color.White;
            this.btnActivar.Image = global::Process_APP_Desk.Properties.Resources._273_checkmark;
            this.btnActivar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnActivar.Location = new System.Drawing.Point(898, 230);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(130, 33);
            this.btnActivar.TabIndex = 40;
            this.btnActivar.Text = "ACTIVAR";
            this.btnActivar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnActivar.UseVisualStyleBackColor = false;
            this.btnActivar.Visible = false;
            this.btnActivar.Click += new System.EventHandler(this.BtnActivar_Click);
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDesactivar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDesactivar.FlatAppearance.BorderSize = 0;
            this.btnDesactivar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnDesactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesactivar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesactivar.ForeColor = System.Drawing.Color.White;
            this.btnDesactivar.Image = global::Process_APP_Desk.Properties.Resources._272_cross;
            this.btnDesactivar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDesactivar.Location = new System.Drawing.Point(898, 230);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(130, 33);
            this.btnDesactivar.TabIndex = 39;
            this.btnDesactivar.Text = "DESACTIVAR";
            this.btnDesactivar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDesactivar.UseVisualStyleBackColor = false;
            this.btnDesactivar.Visible = false;
            this.btnDesactivar.Click += new System.EventHandler(this.BtnDesactivar_Click);
            // 
            // btnVer
            // 
            this.btnVer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnVer.FlatAppearance.BorderSize = 0;
            this.btnVer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVer.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVer.ForeColor = System.Drawing.Color.White;
            this.btnVer.Image = global::Process_APP_Desk.Properties.Resources._135_search_white;
            this.btnVer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVer.Location = new System.Drawing.Point(898, 180);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(130, 33);
            this.btnVer.TabIndex = 38;
            this.btnVer.Text = "MOSTRAR";
            this.btnVer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnVer.UseVisualStyleBackColor = false;
            this.btnVer.Click += new System.EventHandler(this.BtnVer_Click);
            // 
            // dgvUnidad
            // 
            this.dgvUnidad.AllowUserToAddRows = false;
            this.dgvUnidad.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvUnidad.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUnidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvUnidad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUnidad.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvUnidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUnidad.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUnidad.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUnidad.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUnidad.ColumnHeadersHeight = 30;
            this.dgvUnidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUnidad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_UNIDAD,
            this.NOMBRE_UNIDAD,
            this.EMPRESA,
            this.RUT_EMPRESA,
            this.ESTADO,
            this.DESCRIPCION});
            this.dgvUnidad.EnableHeadersVisualStyles = false;
            this.dgvUnidad.GridColor = System.Drawing.Color.White;
            this.dgvUnidad.Location = new System.Drawing.Point(12, 80);
            this.dgvUnidad.Name = "dgvUnidad";
            this.dgvUnidad.ReadOnly = true;
            this.dgvUnidad.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUnidad.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgvUnidad.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUnidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUnidad.Size = new System.Drawing.Size(870, 388);
            this.dgvUnidad.TabIndex = 37;
            this.dgvUnidad.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvUnidad_CellClick);
            // 
            // ID_UNIDAD
            // 
            this.ID_UNIDAD.HeaderText = "ID UNIDAD";
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
            // EMPRESA
            // 
            this.EMPRESA.HeaderText = "EMPRESA";
            this.EMPRESA.Name = "EMPRESA";
            this.EMPRESA.ReadOnly = true;
            // 
            // RUT_EMPRESA
            // 
            this.RUT_EMPRESA.HeaderText = "RUT EMPRESA";
            this.RUT_EMPRESA.Name = "RUT_EMPRESA";
            this.RUT_EMPRESA.ReadOnly = true;
            // 
            // ESTADO
            // 
            this.ESTADO.HeaderText = "ESTADO";
            this.ESTADO.Name = "ESTADO";
            this.ESTADO.ReadOnly = true;
            // 
            // DESCRIPCION
            // 
            this.DESCRIPCION.HeaderText = "DESCRIPCION";
            this.DESCRIPCION.Name = "DESCRIPCION";
            this.DESCRIPCION.ReadOnly = true;
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
            this.btnModificar.Location = new System.Drawing.Point(898, 130);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(130, 33);
            this.btnModificar.TabIndex = 36;
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
            this.btnNuevo.Location = new System.Drawing.Point(898, 80);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(130, 33);
            this.btnNuevo.TabIndex = 35;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pbSeleccion);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txtFiltrar);
            this.panel1.Location = new System.Drawing.Point(12, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 43);
            this.panel1.TabIndex = 32;
            // 
            // pbSeleccion
            // 
            this.pbSeleccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbSeleccion.Image = global::Process_APP_Desk.Properties.Resources._071_pushpin;
            this.pbSeleccion.Location = new System.Drawing.Point(827, 6);
            this.pbSeleccion.Name = "pbSeleccion";
            this.pbSeleccion.Size = new System.Drawing.Size(24, 25);
            this.pbSeleccion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSeleccion.TabIndex = 30;
            this.pbSeleccion.TabStop = false;
            this.pbSeleccion.Visible = false;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label8.Location = new System.Drawing.Point(32, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(344, 19);
            this.label8.TabIndex = 29;
            this.label8.Text = "FILTRAR POR NOMBRE DE UNIDAD O RUT EMPRESA:";
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
            // txtFiltrar
            // 
            this.txtFiltrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFiltrar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFiltrar.Location = new System.Drawing.Point(384, 11);
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Size = new System.Drawing.Size(362, 20);
            this.txtFiltrar.TabIndex = 26;
            this.txtFiltrar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtFiltrar_KeyUp);
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
            this.btnCerrar.TabIndex = 27;
            this.btnCerrar.Text = "X";
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // FormUnidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 480);
            this.Controls.Add(this.panelContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormUnidad";
            this.Text = "PROCESS";
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnidad)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSeleccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFiltrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label btnCerrar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvUnidad;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Button btnDesactivar;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.PictureBox pbSeleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_UNIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE_UNIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMPRESA;
        private System.Windows.Forms.DataGridViewTextBoxColumn RUT_EMPRESA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCION;
    }
}
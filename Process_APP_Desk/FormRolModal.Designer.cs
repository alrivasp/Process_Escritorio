namespace Process_APP_Desk
{
    partial class FormRolModal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRolModal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelCuerpo = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.btnQuitarAcceso = new System.Windows.Forms.Button();
            this.dgvAcceso = new System.Windows.Forms.DataGridView();
            this.ID_ACCESO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE_ACCESO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarAcceso = new System.Windows.Forms.Button();
            this.cbAcceso = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pbSeleccion = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panelCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcceso)).BeginInit();
            this.panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSeleccion)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelCuerpo);
            this.panel1.Controls.Add(this.panelTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 389);
            this.panel1.TabIndex = 2;
            // 
            // panelCuerpo
            // 
            this.panelCuerpo.BackColor = System.Drawing.Color.LightGray;
            this.panelCuerpo.Controls.Add(this.pbSeleccion);
            this.panelCuerpo.Controls.Add(this.lblEstado);
            this.panelCuerpo.Controls.Add(this.txtEstado);
            this.panelCuerpo.Controls.Add(this.btnQuitarAcceso);
            this.panelCuerpo.Controls.Add(this.dgvAcceso);
            this.panelCuerpo.Controls.Add(this.btnAgregarAcceso);
            this.panelCuerpo.Controls.Add(this.cbAcceso);
            this.panelCuerpo.Controls.Add(this.btnGuardar);
            this.panelCuerpo.Controls.Add(this.btnCancelar);
            this.panelCuerpo.Controls.Add(this.label1);
            this.panelCuerpo.Controls.Add(this.txtNombre);
            this.panelCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCuerpo.Location = new System.Drawing.Point(0, 49);
            this.panelCuerpo.Name = "panelCuerpo";
            this.panelCuerpo.Size = new System.Drawing.Size(687, 340);
            this.panelCuerpo.TabIndex = 1;
            // 
            // lblEstado
            // 
            this.lblEstado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblEstado.Location = new System.Drawing.Point(359, 129);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(64, 19);
            this.lblEstado.TabIndex = 53;
            this.lblEstado.Text = "ESTADO:";
            // 
            // txtEstado
            // 
            this.txtEstado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEstado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEstado.Location = new System.Drawing.Point(456, 129);
            this.txtEstado.MaxLength = 99;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(210, 20);
            this.txtEstado.TabIndex = 52;
            // 
            // btnQuitarAcceso
            // 
            this.btnQuitarAcceso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnQuitarAcceso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnQuitarAcceso.FlatAppearance.BorderSize = 0;
            this.btnQuitarAcceso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnQuitarAcceso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarAcceso.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarAcceso.ForeColor = System.Drawing.Color.White;
            this.btnQuitarAcceso.Image = global::Process_APP_Desk.Properties.Resources._268_minus;
            this.btnQuitarAcceso.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuitarAcceso.Location = new System.Drawing.Point(222, 297);
            this.btnQuitarAcceso.Name = "btnQuitarAcceso";
            this.btnQuitarAcceso.Size = new System.Drawing.Size(110, 33);
            this.btnQuitarAcceso.TabIndex = 51;
            this.btnQuitarAcceso.Text = "QUITAR";
            this.btnQuitarAcceso.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnQuitarAcceso.UseVisualStyleBackColor = false;
            this.btnQuitarAcceso.Click += new System.EventHandler(this.BtnQuitarAcceso_Click);
            // 
            // dgvAcceso
            // 
            this.dgvAcceso.AllowUserToAddRows = false;
            this.dgvAcceso.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvAcceso.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAcceso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvAcceso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAcceso.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvAcceso.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAcceso.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAcceso.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAcceso.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAcceso.ColumnHeadersHeight = 30;
            this.dgvAcceso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAcceso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_ACCESO,
            this.NOMBRE_ACCESO});
            this.dgvAcceso.EnableHeadersVisualStyles = false;
            this.dgvAcceso.GridColor = System.Drawing.Color.White;
            this.dgvAcceso.Location = new System.Drawing.Point(30, 60);
            this.dgvAcceso.Name = "dgvAcceso";
            this.dgvAcceso.ReadOnly = true;
            this.dgvAcceso.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAcceso.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgvAcceso.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAcceso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAcceso.Size = new System.Drawing.Size(302, 231);
            this.dgvAcceso.TabIndex = 50;
            this.dgvAcceso.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAcceso_CellClick);
            // 
            // ID_ACCESO
            // 
            this.ID_ACCESO.HeaderText = "ID_ACCESO";
            this.ID_ACCESO.Name = "ID_ACCESO";
            this.ID_ACCESO.ReadOnly = true;
            this.ID_ACCESO.Visible = false;
            // 
            // NOMBRE_ACCESO
            // 
            this.NOMBRE_ACCESO.HeaderText = "NOMBRE ACCESO";
            this.NOMBRE_ACCESO.Name = "NOMBRE_ACCESO";
            this.NOMBRE_ACCESO.ReadOnly = true;
            // 
            // btnAgregarAcceso
            // 
            this.btnAgregarAcceso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregarAcceso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnAgregarAcceso.FlatAppearance.BorderSize = 0;
            this.btnAgregarAcceso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnAgregarAcceso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarAcceso.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarAcceso.ForeColor = System.Drawing.Color.White;
            this.btnAgregarAcceso.Image = global::Process_APP_Desk.Properties.Resources._267_plus_White;
            this.btnAgregarAcceso.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarAcceso.Location = new System.Drawing.Point(222, 21);
            this.btnAgregarAcceso.Name = "btnAgregarAcceso";
            this.btnAgregarAcceso.Size = new System.Drawing.Size(110, 33);
            this.btnAgregarAcceso.TabIndex = 49;
            this.btnAgregarAcceso.Text = "AGREGAR";
            this.btnAgregarAcceso.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAgregarAcceso.UseVisualStyleBackColor = false;
            this.btnAgregarAcceso.Click += new System.EventHandler(this.BtnAgregarAcceso_Click);
            // 
            // cbAcceso
            // 
            this.cbAcceso.FormattingEnabled = true;
            this.cbAcceso.Location = new System.Drawing.Point(30, 28);
            this.cbAcceso.Name = "cbAcceso";
            this.cbAcceso.Size = new System.Drawing.Size(177, 21);
            this.cbAcceso.TabIndex = 48;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::Process_APP_Desk.Properties.Resources._099_floppy_disk;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(357, 191);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(147, 33);
            this.btnGuardar.TabIndex = 45;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = global::Process_APP_Desk.Properties.Resources._277_exit;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(530, 191);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(147, 33);
            this.btnCancelar.TabIndex = 42;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label1.Location = new System.Drawing.Point(359, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 28;
            this.label1.Text = "NOMBRE:";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNombre.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNombre.Location = new System.Drawing.Point(456, 87);
            this.txtNombre.MaxLength = 99;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(210, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelTitulo.Controls.Add(this.lblTitulo);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(687, 49);
            this.panelTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitulo.Image = global::Process_APP_Desk.Properties.Resources._036_profile;
            this.lblTitulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitulo.Location = new System.Drawing.Point(217, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(287, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "ROL";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbSeleccion
            // 
            this.pbSeleccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbSeleccion.Image = global::Process_APP_Desk.Properties.Resources._071_pushpin;
            this.pbSeleccion.Location = new System.Drawing.Point(169, 297);
            this.pbSeleccion.Name = "pbSeleccion";
            this.pbSeleccion.Size = new System.Drawing.Size(24, 25);
            this.pbSeleccion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSeleccion.TabIndex = 54;
            this.pbSeleccion.TabStop = false;
            this.pbSeleccion.Visible = false;
            // 
            // FormRolModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 389);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRolModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PROCESS";
            this.panel1.ResumeLayout(false);
            this.panelCuerpo.ResumeLayout(false);
            this.panelCuerpo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcceso)).EndInit();
            this.panelTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSeleccion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelCuerpo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAgregarAcceso;
        private System.Windows.Forms.ComboBox cbAcceso;
        private System.Windows.Forms.DataGridView dgvAcceso;
        private System.Windows.Forms.Button btnQuitarAcceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_ACCESO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE_ACCESO;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.PictureBox pbSeleccion;
    }
}
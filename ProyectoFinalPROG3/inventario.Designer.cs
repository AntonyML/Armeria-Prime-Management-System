namespace ProyectoFinalPROG3
{
    partial class inventario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textFecha = new System.Windows.Forms.TextBox();
            this.textID = new System.Windows.Forms.TextBox();
            this.combotipo = new System.Windows.Forms.ComboBox();
            this.ltipo = new System.Windows.Forms.Label();
            this.lfecha = new System.Windows.Forms.Label();
            this.lid = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.texttotalcosto = new System.Windows.Forms.TextBox();
            this.ltotalcosto = new System.Windows.Forms.Label();
            this.lvalortotal = new System.Windows.Forms.Label();
            this.textvalortotal = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.larticulo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 45);
            this.panel1.TabIndex = 43;
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BackgroundImage = global::ProyectoFinalPROG3.Properties.Resources.icons8_minimize_window_100;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(626, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(39, 40);
            this.button6.TabIndex = 6;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImage = global::ProyectoFinalPROG3.Properties.Resources.icons8_x_1001;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.Color.Black;
            this.button8.Location = new System.Drawing.Point(671, 1);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(39, 40);
            this.button8.TabIndex = 4;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(163, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(337, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "MOVIMIENTO DE INVENTARIO";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::ProyectoFinalPROG3.Properties.Resources.Bg2;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.textFecha);
            this.panel2.Controls.Add(this.textID);
            this.panel2.Controls.Add(this.combotipo);
            this.panel2.Controls.Add(this.ltipo);
            this.panel2.Controls.Add(this.lfecha);
            this.panel2.Controls.Add(this.lid);
            this.panel2.Location = new System.Drawing.Point(5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(680, 170);
            this.panel2.TabIndex = 44;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::ProyectoFinalPROG3.Properties.Resources.icons8_clean_94;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(535, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 63);
            this.button2.TabIndex = 86;
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::ProyectoFinalPROG3.Properties.Resources.icons8_save_94;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(452, 92);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 75);
            this.button3.TabIndex = 85;
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImage = global::ProyectoFinalPROG3.Properties.Resources.icons8_exit_96;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button5.Location = new System.Drawing.Point(607, 94);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(70, 73);
            this.button5.TabIndex = 84;
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textFecha
            // 
            this.textFecha.BackColor = System.Drawing.SystemColors.Window;
            this.textFecha.Enabled = false;
            this.textFecha.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFecha.Location = new System.Drawing.Point(102, 64);
            this.textFecha.Name = "textFecha";
            this.textFecha.Size = new System.Drawing.Size(250, 27);
            this.textFecha.TabIndex = 83;
            // 
            // textID
            // 
            this.textID.BackColor = System.Drawing.SystemColors.Window;
            this.textID.Enabled = false;
            this.textID.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textID.Location = new System.Drawing.Point(102, 28);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(98, 27);
            this.textID.TabIndex = 82;
            // 
            // combotipo
            // 
            this.combotipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combotipo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combotipo.FormattingEnabled = true;
            this.combotipo.Items.AddRange(new object[] {
            "Entrada",
            "Salida"});
            this.combotipo.Location = new System.Drawing.Point(102, 101);
            this.combotipo.Name = "combotipo";
            this.combotipo.Size = new System.Drawing.Size(98, 26);
            this.combotipo.TabIndex = 81;
            this.combotipo.SelectedIndexChanged += new System.EventHandler(this.combotipo_SelectedIndexChanged);
            // 
            // ltipo
            // 
            this.ltipo.AutoSize = true;
            this.ltipo.BackColor = System.Drawing.Color.Transparent;
            this.ltipo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltipo.ForeColor = System.Drawing.Color.White;
            this.ltipo.Location = new System.Drawing.Point(20, 104);
            this.ltipo.Name = "ltipo";
            this.ltipo.Size = new System.Drawing.Size(51, 18);
            this.ltipo.TabIndex = 80;
            this.ltipo.Text = "Tipo ";
            // 
            // lfecha
            // 
            this.lfecha.AutoSize = true;
            this.lfecha.BackColor = System.Drawing.Color.Transparent;
            this.lfecha.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lfecha.ForeColor = System.Drawing.Color.White;
            this.lfecha.Location = new System.Drawing.Point(20, 64);
            this.lfecha.Name = "lfecha";
            this.lfecha.Size = new System.Drawing.Size(60, 18);
            this.lfecha.TabIndex = 79;
            this.lfecha.Text = "Fecha";
            // 
            // lid
            // 
            this.lid.AutoSize = true;
            this.lid.BackColor = System.Drawing.Color.Transparent;
            this.lid.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lid.ForeColor = System.Drawing.Color.White;
            this.lid.Location = new System.Drawing.Point(20, 28);
            this.lid.Name = "lid";
            this.lid.Size = new System.Drawing.Size(29, 18);
            this.lid.TabIndex = 78;
            this.lid.Text = "ID";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Location = new System.Drawing.Point(13, 53);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(690, 179);
            this.panel4.TabIndex = 45;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(13, 289);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(690, 344);
            this.dataGridView1.TabIndex = 47;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column1.HeaderText = "Cantidad";
            this.Column1.Name = "Column1";
            this.Column1.Width = 106;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Descripcion";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "ID Marca";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 105;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "Costo";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "Valor";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 74;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "Existencia";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 116;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 18);
            this.label1.TabIndex = 73;
            this.label1.Text = "DATOS DE MOVIMIENTO";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Location = new System.Drawing.Point(13, 666);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(690, 137);
            this.panel3.TabIndex = 76;
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = global::ProyectoFinalPROG3.Properties.Resources.Bg2;
            this.panel5.Location = new System.Drawing.Point(5, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(680, 126);
            this.panel5.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(23, 659);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 18);
            this.label2.TabIndex = 77;
            this.label2.Text = "TOTALES DEL MOVIMIENTO";
            // 
            // texttotalcosto
            // 
            this.texttotalcosto.BackColor = System.Drawing.SystemColors.Window;
            this.texttotalcosto.Enabled = false;
            this.texttotalcosto.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texttotalcosto.Location = new System.Drawing.Point(433, 690);
            this.texttotalcosto.Name = "texttotalcosto";
            this.texttotalcosto.Size = new System.Drawing.Size(75, 27);
            this.texttotalcosto.TabIndex = 83;
            // 
            // ltotalcosto
            // 
            this.ltotalcosto.AutoSize = true;
            this.ltotalcosto.BackColor = System.Drawing.Color.Transparent;
            this.ltotalcosto.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltotalcosto.ForeColor = System.Drawing.Color.White;
            this.ltotalcosto.Location = new System.Drawing.Point(441, 719);
            this.ltotalcosto.Name = "ltotalcosto";
            this.ltotalcosto.Size = new System.Drawing.Size(58, 18);
            this.ltotalcosto.TabIndex = 86;
            this.ltotalcosto.Text = "Costo";
            // 
            // lvalortotal
            // 
            this.lvalortotal.AutoSize = true;
            this.lvalortotal.BackColor = System.Drawing.Color.Transparent;
            this.lvalortotal.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvalortotal.ForeColor = System.Drawing.Color.White;
            this.lvalortotal.Location = new System.Drawing.Point(521, 719);
            this.lvalortotal.Name = "lvalortotal";
            this.lvalortotal.Size = new System.Drawing.Size(52, 18);
            this.lvalortotal.TabIndex = 88;
            this.lvalortotal.Text = "valor";
            // 
            // textvalortotal
            // 
            this.textvalortotal.BackColor = System.Drawing.SystemColors.Window;
            this.textvalortotal.Enabled = false;
            this.textvalortotal.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textvalortotal.Location = new System.Drawing.Point(511, 690);
            this.textvalortotal.Name = "textvalortotal";
            this.textvalortotal.Size = new System.Drawing.Size(75, 27);
            this.textvalortotal.TabIndex = 87;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::ProyectoFinalPROG3.Properties.Resources.icons8_search_49;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(168, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 26);
            this.button1.TabIndex = 91;
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // larticulo
            // 
            this.larticulo.AutoSize = true;
            this.larticulo.BackColor = System.Drawing.Color.Transparent;
            this.larticulo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.larticulo.ForeColor = System.Drawing.Color.White;
            this.larticulo.Location = new System.Drawing.Point(15, 253);
            this.larticulo.Name = "larticulo";
            this.larticulo.Size = new System.Drawing.Size(147, 18);
            this.larticulo.TabIndex = 90;
            this.larticulo.Text = "Buscar articulos";
            // 
            // inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProyectoFinalPROG3.Properties.Resources.Bg2;
            this.ClientSize = new System.Drawing.Size(715, 815);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.larticulo);
            this.Controls.Add(this.ltotalcosto);
            this.Controls.Add(this.lvalortotal);
            this.Controls.Add(this.texttotalcosto);
            this.Controls.Add(this.textvalortotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "inventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "inventario";
            this.Load += new System.EventHandler(this.inventario_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.articulosEXT_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ltipo;
        private System.Windows.Forms.Label lfecha;
        private System.Windows.Forms.Label lid;
        private System.Windows.Forms.ComboBox combotipo;
        private System.Windows.Forms.TextBox textFecha;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label ltotalcosto;
        private System.Windows.Forms.TextBox texttotalcosto;
        private System.Windows.Forms.Label lvalortotal;
        private System.Windows.Forms.TextBox textvalortotal;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label larticulo;
    }
}
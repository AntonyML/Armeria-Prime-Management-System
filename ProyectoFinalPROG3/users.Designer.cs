namespace ProyectoFinalPROG3
{
    partial class users
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
            this.components = new System.ComponentModel.Container();
            this.textuser = new System.Windows.Forms.TextBox();
            this.lname = new System.Windows.Forms.Label();
            this.lacceso = new System.Windows.Forms.Label();
            this.textid = new System.Windows.Forms.TextBox();
            this.lid = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textlv = new System.Windows.Forms.ComboBox();
            this.textpass = new System.Windows.Forms.TextBox();
            this.lclave = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboboxs = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.botonpass = new System.Windows.Forms.Button();
            this.expcheck = new System.Windows.Forms.CheckBox();
            this.dateTimePickerexp = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.textpersona = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comborol = new System.Windows.Forms.ComboBox();
            this.lrol = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textuser
            // 
            this.textuser.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textuser.Location = new System.Drawing.Point(172, 169);
            this.textuser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textuser.Name = "textuser";
            this.textuser.Size = new System.Drawing.Size(286, 27);
            this.textuser.TabIndex = 1;
            this.textuser.TextChanged += new System.EventHandler(this.textuser_TextChanged);
            this.textuser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textuser_KeyPress);
            // 
            // lname
            // 
            this.lname.AutoSize = true;
            this.lname.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lname.ForeColor = System.Drawing.Color.Black;
            this.lname.Location = new System.Drawing.Point(9, 174);
            this.lname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lname.Name = "lname";
            this.lname.Size = new System.Drawing.Size(75, 18);
            this.lname.TabIndex = 2;
            this.lname.Text = "Usuario";
            // 
            // lacceso
            // 
            this.lacceso.AutoSize = true;
            this.lacceso.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lacceso.ForeColor = System.Drawing.Color.Black;
            this.lacceso.Location = new System.Drawing.Point(9, 372);
            this.lacceso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lacceso.Name = "lacceso";
            this.lacceso.Size = new System.Drawing.Size(102, 18);
            this.lacceso.TabIndex = 3;
            this.lacceso.Text = "Nv. acceso";
            this.lacceso.Click += new System.EventHandler(this.label2_Click);
            // 
            // textid
            // 
            this.textid.Enabled = false;
            this.textid.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textid.Location = new System.Drawing.Point(172, 108);
            this.textid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textid.Name = "textid";
            this.textid.Size = new System.Drawing.Size(169, 27);
            this.textid.TabIndex = 4;
            this.textid.TextChanged += new System.EventHandler(this.textid_TextChanged);
            this.textid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textid_KeyPress);
            // 
            // lid
            // 
            this.lid.AutoSize = true;
            this.lid.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lid.ForeColor = System.Drawing.Color.Black;
            this.lid.Location = new System.Drawing.Point(8, 111);
            this.lid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lid.Name = "lid";
            this.lid.Size = new System.Drawing.Size(29, 18);
            this.lid.TabIndex = 6;
            this.lid.Text = "ID";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gray;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 140);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 60;
            this.dataGridView1.Size = new System.Drawing.Size(750, 472);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            // 
            // textlv
            // 
            this.textlv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textlv.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textlv.FormattingEnabled = true;
            this.textlv.Items.AddRange(new object[] {
            "1",
            "2"});
            this.textlv.Location = new System.Drawing.Point(171, 368);
            this.textlv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textlv.Name = "textlv";
            this.textlv.Size = new System.Drawing.Size(74, 26);
            this.textlv.TabIndex = 22;
            this.textlv.SelectedIndexChanged += new System.EventHandler(this.textlv_SelectedIndexChanged);
            // 
            // textpass
            // 
            this.textpass.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textpass.Location = new System.Drawing.Point(172, 234);
            this.textpass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textpass.Name = "textpass";
            this.textpass.Size = new System.Drawing.Size(286, 27);
            this.textpass.TabIndex = 21;
            // 
            // lclave
            // 
            this.lclave.AutoSize = true;
            this.lclave.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lclave.ForeColor = System.Drawing.Color.Black;
            this.lclave.Location = new System.Drawing.Point(9, 238);
            this.lclave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lclave.Name = "lclave";
            this.lclave.Size = new System.Drawing.Size(56, 18);
            this.lclave.TabIndex = 20;
            this.lclave.Text = "Clave";
            this.lclave.Click += new System.EventHandler(this.lclave_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(140, 85);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(224, 27);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(15, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 18);
            this.label5.TabIndex = 16;
            this.label5.Text = "BUSCAR";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(375, 92);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 18);
            this.label7.TabIndex = 17;
            this.label7.Text = "POR";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // comboboxs
            // 
            this.comboboxs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxs.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboboxs.FormattingEnabled = true;
            this.comboboxs.Items.AddRange(new object[] {
            "Defecto",
            "usuario",
            "ID",
            "nivel de acceso"});
            this.comboboxs.Location = new System.Drawing.Point(450, 85);
            this.comboboxs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboboxs.Name = "comboboxs";
            this.comboboxs.Size = new System.Drawing.Size(260, 26);
            this.comboboxs.TabIndex = 19;
            this.comboboxs.SelectedIndexChanged += new System.EventHandler(this.comboboxs_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.botonpass);
            this.groupBox1.Controls.Add(this.expcheck);
            this.groupBox1.Controls.Add(this.dateTimePickerexp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.textpersona);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comborol);
            this.groupBox1.Controls.Add(this.lrol);
            this.groupBox1.Controls.Add(this.textlv);
            this.groupBox1.Controls.Add(this.lacceso);
            this.groupBox1.Controls.Add(this.textpass);
            this.groupBox1.Controls.Add(this.textuser);
            this.groupBox1.Controls.Add(this.lclave);
            this.groupBox1.Controls.Add(this.lname);
            this.groupBox1.Controls.Add(this.lid);
            this.groupBox1.Controls.Add(this.textid);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(778, 122);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(524, 491);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacion usuario actual";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // botonpass
            // 
            this.botonpass.BackColor = System.Drawing.Color.Transparent;
            this.botonpass.BackgroundImage = global::ProyectoFinalPROG3.Properties.Resources.eye_closed;
            this.botonpass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonpass.FlatAppearance.BorderSize = 0;
            this.botonpass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonpass.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.botonpass.Location = new System.Drawing.Point(470, 234);
            this.botonpass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.botonpass.Name = "botonpass";
            this.botonpass.Size = new System.Drawing.Size(42, 42);
            this.botonpass.TabIndex = 44;
            this.botonpass.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.botonpass.UseVisualStyleBackColor = false;
            this.botonpass.Click += new System.EventHandler(this.botonpass_Click_1);
            // 
            // expcheck
            // 
            this.expcheck.AutoSize = true;
            this.expcheck.Location = new System.Drawing.Point(496, 305);
            this.expcheck.Name = "expcheck";
            this.expcheck.Size = new System.Drawing.Size(15, 14);
            this.expcheck.TabIndex = 43;
            this.expcheck.UseVisualStyleBackColor = true;
            this.expcheck.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // dateTimePickerexp
            // 
            this.dateTimePickerexp.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this.dateTimePickerexp.Enabled = false;
            this.dateTimePickerexp.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerexp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerexp.Location = new System.Drawing.Point(172, 298);
            this.dateTimePickerexp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerexp.Name = "dateTimePickerexp";
            this.dateTimePickerexp.Size = new System.Drawing.Size(319, 26);
            this.dateTimePickerexp.TabIndex = 42;
            this.dateTimePickerexp.ValueChanged += new System.EventHandler(this.dateTimePickerexp_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 305);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.TabIndex = 28;
            this.label2.Text = "Clave exp.";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImage = global::ProyectoFinalPROG3.Properties.Resources.buscar3;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button7.Location = new System.Drawing.Point(471, 48);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(42, 42);
            this.button7.TabIndex = 27;
            this.button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // textpersona
            // 
            this.textpersona.Enabled = false;
            this.textpersona.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textpersona.Location = new System.Drawing.Point(174, 48);
            this.textpersona.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textpersona.Name = "textpersona";
            this.textpersona.Size = new System.Drawing.Size(286, 27);
            this.textpersona.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 25;
            this.label1.Text = "Entidad";
            // 
            // comborol
            // 
            this.comborol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comborol.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comborol.FormattingEnabled = true;
            this.comborol.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comborol.Location = new System.Drawing.Point(171, 431);
            this.comborol.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comborol.Name = "comborol";
            this.comborol.Size = new System.Drawing.Size(286, 26);
            this.comborol.TabIndex = 24;
            this.comborol.SelectedIndexChanged += new System.EventHandler(this.comborol_SelectedIndexChanged);
            // 
            // lrol
            // 
            this.lrol.AutoSize = true;
            this.lrol.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lrol.ForeColor = System.Drawing.Color.Black;
            this.lrol.Location = new System.Drawing.Point(12, 435);
            this.lrol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lrol.Name = "lrol";
            this.lrol.Size = new System.Drawing.Size(36, 18);
            this.lrol.TabIndex = 23;
            this.lrol.Text = "Rol";
            this.lrol.Click += new System.EventHandler(this.lrol_Click);
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
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1434, 69);
            this.panel1.TabIndex = 25;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BackgroundImage = global::ProyectoFinalPROG3.Properties.Resources.MINI_2;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(1300, 2);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(58, 62);
            this.button6.TabIndex = 6;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImage = global::ProyectoFinalPROG3.Properties.Resources.X1;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.Color.Black;
            this.button8.Location = new System.Drawing.Point(1368, 2);
            this.button8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(58, 62);
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
            this.label3.Location = new System.Drawing.Point(426, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(354, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "MANTENIMIENTO DE USUARIOS";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(1311, 122);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(111, 491);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.BackgroundImage = global::ProyectoFinalPROG3.Properties.Resources.plus;
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button9.Location = new System.Drawing.Point(16, 22);
            this.button9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 77);
            this.button9.TabIndex = 25;
            this.button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::ProyectoFinalPROG3.Properties.Resources.save1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(16, 108);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 77);
            this.button1.TabIndex = 0;
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::ProyectoFinalPROG3.Properties.Resources.clean2;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(16, 203);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 77);
            this.button2.TabIndex = 20;
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImage = global::ProyectoFinalPROG3.Properties.Resources.exit1;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button5.Location = new System.Drawing.Point(20, 397);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(68, 77);
            this.button5.TabIndex = 24;
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = global::ProyectoFinalPROG3.Properties.Resources.trash;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.Location = new System.Drawing.Point(16, 297);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 77);
            this.button4.TabIndex = 22;
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::ProyectoFinalPROG3.Properties.Resources.buscar3;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(726, 83);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(44, 42);
            this.button3.TabIndex = 25;
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1434, 631);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboboxs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "users";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de usuarios";
            this.Load += new System.EventHandler(this.users_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.users_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.users_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textuser;
        private System.Windows.Forms.Label lname;
        private System.Windows.Forms.Label lacceso;
        private System.Windows.Forms.TextBox textid;
        private System.Windows.Forms.Label lid;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboboxs;
        private System.Windows.Forms.TextBox textpass;
        private System.Windows.Forms.Label lclave;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox textlv;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lrol;
        private System.Windows.Forms.ComboBox comborol;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textpersona;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox expcheck;
        private System.Windows.Forms.DateTimePicker dateTimePickerexp;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button botonpass;
    }
}
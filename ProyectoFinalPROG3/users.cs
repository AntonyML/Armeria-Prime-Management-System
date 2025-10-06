using Npgsql;
using ProyectoFinalPROG3.Clases;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ProyectoFinalPROG3
{
    public partial class users : Form
    {
        string text2 = "usuario";
        Clases.dbconeccion gestor = new dbconeccion();


        private System.Windows.Forms.ToolTip toolTip;





        public users()
        {
            // Registrar en la auditoría
            Auditoria auditoria = new Auditoria();
            auditoria.RegistrarAuditoria(0, "Abrir user"); // Reemplaza "UsuarioActual" con el ID del usuario actual

            InitializeComponent();
            Clases.dbconeccion.MakeMovable(this);
            this.toolTip1.SetToolTip(this.button9, "Agregar");
            this.toolTip1.SetToolTip(this.button1, "Guardar");
            this.toolTip1.SetToolTip(this.button2, "Limpiar");
            this.toolTip1.SetToolTip(this.button4, "Eliminar");
            this.toolTip1.SetToolTip(this.button5, "Salir");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Chart()
        {
            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            NpgsqlCommand cm = new NpgsqlCommand();
            cm.Connection = cn;
            cm.CommandType = CommandType.Text;
            cm.CommandText = "select usuario,\"usuario_id\",clave,nivel_de_acceso from usuario where activo=true;";
            NpgsqlDataReader dr = cm.ExecuteReader();

            try
            {
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos, error: " + e.ToString());
            }
            finally
            {
                cn.Close(); cm.Dispose();
            }
        }









        //Funcion para crear el registro en caso de NO existir
        private void crear()
        {
            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            DialogResult result = MessageBox.Show("¿Desesas crear un nuevo usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into usuario (usuario, \"usuario_id\", clave, nivel_de_acceso, activo) VALUES ('" + textuser.Text + "','" + textid.Text + "','" + textpass.Text + "','" + textlv.Text + "','" + "true" + "')", cn);
                try
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario creado con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al crear usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { cn.Close(); cmd.Dispose(); }


            }

        }

        //Funcion para actualizar el registro en caso de existir
        private void actualizar()
        {

            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            DialogResult result = MessageBox.Show("¿Se ha encontrado un usuario, deseas actualizarlo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update usuario set usuario ='" + textuser.Text + "',clave = '" + textpass.Text + "',nivel_de_acceso ='" + textlv.Text + "'where \"usuario_id\"='" + textid.Text + "'", cn);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario actualizado con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al actualizar usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { cn.Close(); cmd.Dispose(); }
            }
        }



        //Funcion para borrar el registro en caso de existir
        private void borrar()
        {
            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            if (string.IsNullOrEmpty(textuser.Text) || string.IsNullOrEmpty(textpass.Text) || string.IsNullOrEmpty(textid.Text) || string.IsNullOrEmpty(textlv.Text))
            {
                MessageBox.Show("Los campos en rojo son obligatorios!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cambiarcolorrojo();
            }
            else
            {

                NpgsqlCommand cmd = new NpgsqlCommand("update usuario set activo = false where activo= true and \"usuario_id\"='" + textid.Text + "'", cn);

                try
                {
                    if (Clases.dbconeccion.confirmar(textid.Text, text2))
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Usuario eliminado con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        cambiarcolor();

                    }
                    else { MessageBox.Show("Usuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); cambiarcolor(); }

                }
                catch (Exception)
                {
                    MessageBox.Show("Usuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cambiarcolor();
                }
                finally { cn.Close(); cmd.Dispose(); }




            }


        }

        private void cambiarcolorrojo()
        {
            lname.ForeColor = Color.Red;
            lclave.ForeColor = Color.Red;
            lid.ForeColor = Color.Red;
            lacceso.ForeColor = Color.Red;
        }

        private void cambiarcolor()
        {
            lname.ForeColor = Color.White;
            lclave.ForeColor = Color.White;
            lid.ForeColor = Color.White;
            lacceso.ForeColor = Color.White;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string text = textid.Text;

            string nombreUsuario = textuser.Text;

            if (string.IsNullOrEmpty(textuser.Text) || string.IsNullOrEmpty(textpass.Text) || string.IsNullOrEmpty(textid.Text) || string.IsNullOrEmpty(textlv.Text))
            {


                cambiarcolorrojo();
                MessageBox.Show("Ningun campo en rojo puede quedar vacio!");

            }
            else
            {
                if (Clases.dbconeccion.confirmar(text, text2))
                {

                    actualizar();
                    Chart();
                    if (lname.ForeColor == Color.Red)
                    {
                        cambiarcolor();
                    }

                }
                else if (Clases.dbconeccion.ExisteNombreUsuario(nombreUsuario))
                {
                    MessageBox.Show("Nombre de usuario ya existente, pruebe otro!");
                }
                else
                {
                    crear();
                    Chart();

                    if (lname.ForeColor == Color.Red)
                    {
                        cambiarcolor();
                    }
                }
            }

        }



        private void users_Load(object sender, EventArgs e)
        {


            Chart();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            comboboxs.SelectedIndex = 0;

            // Establece el texto del botón
            textpass.UseSystemPasswordChar = true;

        }


        private void botonbusqueda()
        {
            string textoConGuionesBajos = comboboxs.SelectedItem.ToString().Replace(" ", "_");

            string y = textBox1.Text.ToString();
            string n = textoConGuionesBajos;
            string z = "usuario";
            int x = 1;



            if (comboboxs.SelectedItem.ToString() == "Defecto")
            {
                Chart();

            }

            else if (comboboxs.SelectedItem.ToString() == "ID")
            {
                 n = "usuario_id";
                if (Clases.dbconeccion.ValidarNumeros(textBox1))
                {
                    dataGridView1.DataSource = Clases.dbconeccion.busqueda(n, y, z);
                }
                else
                {
                    MessageBox.Show("Solo se permiten numeros en esta busqueda");
                }


            }
            else if (comboboxs.SelectedItem.ToString() == "nivel de acceso")
            {

                if (Clases.dbconeccion.ValidarNumeros(textBox1))
                {
                    dataGridView1.DataSource = Clases.dbconeccion.busqueda(n, y, z);
                }
                else
                {
                    MessageBox.Show("Solo se permiten numeros en esta busqueda");
                }


            }

            else
            {
                dataGridView1.DataSource = Clases.dbconeccion.busqueda(n, y, z, x);
            }
        }


  

        private void comboboxs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void users_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textid_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.dbconeccion.Validar(e);
        }

        private void textlv_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void limpiar()
        {
            textuser.Text = string.Empty;
            textpass.Text = string.Empty;
            textid.Text = string.Empty;
            textlv.SelectedIndex = 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Deseas eliminar este usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                borrar();
                Chart();
                limpiar();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("¿Deseas salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form Form = new menu();
                this.Hide();
                Form.Focus();
            }
        }

        private void textuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void textuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.dbconeccion.ValidarLetra(e);
        }

        private void button8_Click(object sender, EventArgs e)
        {

            gestor.CerrarForm(this);
        }



        private void button6_Click(object sender, EventArgs e)
        {

            gestor.MinimizarForm(this);
        }

        private void textid_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (comboboxs.SelectedItem.ToString() == "Usuario")
            {
                Clases.dbconeccion.ValidarLetra(e);
            }

            if (comboboxs.SelectedItem.ToString() == "usuario_id")
            {
                Clases.dbconeccion.Validar(e);
            }

            if (comboboxs.SelectedItem.ToString() == "Nivel de acceso")
            {
                Clases.dbconeccion.Validar(e);
            }

        }
        //-----------------------------------------------------Cambiar bordes--------------------------------------
        private void users_Paint(object sender, PaintEventArgs e)
        {

            using (Pen borderPen = new Pen(Color.Black, 5))
            {
                // Lateral izquierdo
                e.Graphics.DrawLine(borderPen, 0, 0, 0, this.Height);
                // Lateral derecho
                e.Graphics.DrawLine(borderPen, this.Width - 1, 0, this.Width - 1, this.Height);
                // Inferior
                e.Graphics.DrawLine(borderPen, 0, this.Height - 1, this.Width, this.Height - 1);
            }

        }
        //------------------------------------------------------------------------------------------------------------


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

               
                textuser.Text = row.Cells[0].Value.ToString();
                textid.Text = row.Cells[1].Value.ToString();
                textpass.Text = row.Cells[2].Value.ToString();
                textlv.Text = row.Cells[3].Value.ToString();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                botonbusqueda();
                e.SuppressKeyPress = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            botonbusqueda();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerexp.Enabled = expcheck.Checked;
        }

        private void dateTimePickerexp_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textlv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comborol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lrol_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void lclave_Click(object sender, EventArgs e)
        {

        }

        private void botonpass_Click(object sender, EventArgs e)
        {
            // Alterna el valor de UseSystemPasswordChar para mostrar u ocultar la contraseña
            textpass.UseSystemPasswordChar = !textpass.UseSystemPasswordChar;

            // Cambia la imagen del botón según el estado de la contraseña
            if (textpass.UseSystemPasswordChar)
            {
                botonpass.BackgroundImage= Properties.Resources.eye_closed;
            }
            else
            {
                botonpass.BackgroundImage = Properties.Resources.eye_open;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void botonpass_Click_1(object sender, EventArgs e)
        {
            this.ActiveControl = null;



                // Alterna el valor de UseSystemPasswordChar para mostrar u ocultar la contraseña
                textpass.UseSystemPasswordChar = !textpass.UseSystemPasswordChar;

                // Cambia la imagen del botón según el estado de la contraseña
                if (textpass.UseSystemPasswordChar)
                {
                    botonpass.BackgroundImage = Properties.Resources.eye_closed;
                }
                else
                {
                    botonpass.BackgroundImage = Properties.Resources.eye_open;
                }
            
        }
    }
}

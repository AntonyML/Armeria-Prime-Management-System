using Npgsql;
using ProyectoFinalPROG3.Clases;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFinalPROG3
{
    public partial class facturador : Form
    {
        public facturador()
        {
            InitializeComponent();
            Clases.dbconeccion.MakeMovable(this);
            // Registrar en la auditoría
            Auditoria auditoria = new Auditoria();
            auditoria.RegistrarAuditoria(0, "Abrir facturador"); // Reemplaza "UsuarioActual" con el ID del usuario actual

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        string text2 = "facturador";
        Clases.dbconeccion gestor = new dbconeccion();

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














        //Funcion para crear el registro en caso de NO existir
        private void Crear()
        {
            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            DialogResult result = MessageBox.Show("¿Desesas crear una nuevo facturador?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                textFecha.Text = DateTime.Now.ToShortDateString();
                NpgsqlCommand cmd = new NpgsqlCommand("insert into facturador (\"ID\",\"Nombre completo\",\"Fecha de ingreso\",\"Estado\",activo) VALUES ('" + textid.Text + "','" + textnombre.Text + "','" + textFecha.Text + "','" + comboestado.Text + "','" + "true" + "')", cn);
                try
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Facturador creado con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al crear facturador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { cn.Close(); cmd.Dispose(); }


            }

        }

        //Funcion para actualizar el registro en caso de existir
        private void Actualizar()
        {

            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            DialogResult result = MessageBox.Show("¿Se ha encontrado un facturador, deseas actualizarlo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update facturador set \"Nombre completo\" ='" + textnombre.Text + "',\"Estado\" ='" + comboestado.Text + "'where \"ID\"='" + textid.Text + "'", cn);
                try
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Facturador actualizado con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al actualizar facturador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { cn.Close(); cmd.Dispose(); }
            }
        }



        //Funcion para borrar el registro en caso de existir
        private void Borrar()
        {
            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            if (string.IsNullOrEmpty(textid.Text))
            {
                MessageBox.Show("Los campos en rojo son obligatorios!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cambiarcolorrojo();
            }
            else
            {

                NpgsqlCommand cmd = new NpgsqlCommand("update facturador set activo = false where activo=true and \"ID\"='" + textid.Text + "'", cn);

                try
                {
                    if (Clases.dbconeccion.confirmar(textid.Text, text2))
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Facturador eliminado con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        cambiarcolor();

                    }
                    else { MessageBox.Show("Facturador no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); cambiarcolor(); }

                }
                catch (Exception)
                {
                    MessageBox.Show("Facturador no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cambiarcolor();
                }
                finally { cn.Close(); cmd.Dispose(); }




            }


        }


        private void Chart()
        {
            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            NpgsqlCommand cm = new NpgsqlCommand();
            cm.Connection = cn;
            cm.CommandType = CommandType.Text;
            cm.CommandText = "select \"ID\",\"Nombre completo\",\"Fecha de ingreso\",\"Estado\" from facturador where activo=true;";
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




        private void cambiarcolorrojo()
        {
            l1.ForeColor = Color.Red;
            l2.ForeColor = Color.Red;
            l3.ForeColor = Color.Red;
            l4.ForeColor = Color.Red;
        }

        private void cambiarcolor()
        {
            l1.ForeColor = Color.White;
            l2.ForeColor = Color.White;
            l3.ForeColor = Color.White;
            l4.ForeColor = Color.White;
        }







        private void facturador_Load(object sender, EventArgs e)
        {
            Chart();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            comboboxs.SelectedIndex = 0;
            comboestado.SelectedIndex = 0;
            textFecha.Text = DateTime.Now.ToShortDateString();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Deseas eliminar esta marca?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Borrar();
                Chart();
                limpiar();
            }
        }


        private void botonbusqueda()
        {


            string y = textBox1.Text.ToString();
            string n = comboboxs.Text.ToString();
            string z = text2;
            int x = 1;



            if (comboboxs.SelectedItem.ToString() == "Defecto")
            {
                Chart();

            }

            else if (comboboxs.SelectedItem.ToString() == "ID")
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
            else if (comboboxs.SelectedItem.ToString() == "Fecha")
            {
                dataGridView1.DataSource = Clases.dbconeccion.busqueda(z, dateTimePicker1.Value, dateTimePicker2.Value);
            }
            else
            {
                dataGridView1.DataSource = Clases.dbconeccion.busqueda(n, y, z, x);


            }
        }








        private void button3_Click(object sender, EventArgs e)
        {
            botonbusqueda();
        }



        private void limpiar()
        {
            textnombre.Text = string.Empty;
            textid.Text = string.Empty;
            textFecha.Text = DateTime.Now.ToShortDateString();
            comboestado.SelectedIndex = 0;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void fechashow()
        {
            dateTimePicker1.Show();
            dateTimePicker2.Show();
            ldesde.Show();
            lhasta.Show();
        }


        private void fechahide()
        {
            if (dateTimePicker1.Visible == true)
            {
                dateTimePicker1.Hide();
                dateTimePicker2.Hide();
                ldesde.Hide();
                lhasta.Hide();
            }
        }

        private void comboboxs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxs.SelectedItem.ToString() == "Fecha")
            {
                fechashow();
            }
            else
            {
                fechahide();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textid.Text;



            if (string.IsNullOrEmpty(textnombre.Text) || string.IsNullOrEmpty(textid.Text) || string.IsNullOrEmpty(textFecha.Text))
            {


                cambiarcolorrojo();
                MessageBox.Show("Ningun campo en rojo puede quedar vacio!");

            }
            else
            {
                if (Clases.dbconeccion.confirmar(text, text2))
                {

                    Actualizar();
                    Chart();
                    if (l1.ForeColor == Color.Red)
                    {
                        cambiarcolor();
                    }

                }
                else
                {
                    Crear();
                    Chart();

                    if (l1.ForeColor == Color.Red)
                    {
                        cambiarcolor();
                    }
                }
            }
        }

        private void lhasta_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Asume que el ID está en la columna 0 y la descripcion en la columna 1

                comboestado.Text = row.Cells[1].Value.ToString();
                DateTime fechaIngreso = Convert.ToDateTime(row.Cells[2].Value.ToString());
                textFecha.Text = fechaIngreso.ToShortDateString();
                textnombre.Text = row.Cells[1].Value.ToString();
                textid.Text = row.Cells[0].Value.ToString();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            gestor.MinimizarForm(this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            gestor.CerrarForm(this);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboboxs.SelectedItem.ToString() == "ID")
            {
                Clases.dbconeccion.Validar(e);
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

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Asume que el ID está en la columna 0 y la descripcion en la columna 1

                comboestado.Text = row.Cells[1].Value.ToString();
                DateTime fechaIngreso = Convert.ToDateTime(row.Cells[2].Value.ToString());
                textFecha.Text = fechaIngreso.ToShortDateString();
                textnombre.Text = row.Cells[1].Value.ToString();
                textid.Text = row.Cells[0].Value.ToString();

            }
        }

        private void textid_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.dbconeccion.Validar(e);
        }
    }
}

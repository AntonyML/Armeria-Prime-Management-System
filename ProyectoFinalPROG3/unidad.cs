using Npgsql;
using ProyectoFinalPROG3.Clases;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFinalPROG3
{
    public partial class unidad : Form
    {
        public unidad()
        {
            InitializeComponent();
            Clases.dbconeccion.MakeMovable(this);
            // Registrar en la auditoría
            Auditoria auditoria = new Auditoria();
            auditoria.RegistrarAuditoria(0, "Abrir unidad"); // Reemplaza "UsuarioActual" con el ID del usuario actual

        }


        string text2 = "unidad";
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
        private void crear()
        {
            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            DialogResult result = MessageBox.Show("¿Desesas crear una nueva unidad?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into unidad (\"ID\",\"Descripcion\",\"Cantidad\",activo) VALUES ('" + textid.Text + "','" + textdescripcion.Text + "','" + textcantidad.Text + "','" + "true" + "')", cn);
                try
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("unidad creada con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al crear unidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { cn.Close(); cmd.Dispose(); }


            }

        }

        //Funcion para actualizar el registro en caso de existir
        private void actualizar()
        {

            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            DialogResult result = MessageBox.Show("¿Se ha encontrado una unidad, deseas actualizarla?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update unidad set \"Descripcion\" ='" + textdescripcion.Text + "',\"Cantidad\" ='" + textcantidad.Text + "'where \"ID\"='" + textid.Text + "'", cn);
                try
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Unidad actualizada con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al actualizar unidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { cn.Close(); cmd.Dispose(); }
            }
        }



        //Funcion para borrar el registro en caso de existir
        private void borrar()
        {
            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            if (string.IsNullOrEmpty(textid.Text))
            {
                MessageBox.Show("Los campos en rojo son obligatorios!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cambiarcolorrojo();
            }
            else
            {

                NpgsqlCommand cmd = new NpgsqlCommand("update unidad set activo = false where activo=true and \"ID\"='" + textid.Text + "'", cn);

                try
                {
                    if (Clases.dbconeccion.confirmar(textid.Text, text2))
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Unidad eliminada con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        cambiarcolor();

                    }
                    else { MessageBox.Show("Unidad no encontrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); cambiarcolor(); }

                }
                catch (Exception)
                {
                    MessageBox.Show("Unidad no encontrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            cm.CommandText = "select \"ID\",\"Descripcion\",\"Cantidad\" from unidad where activo=true;";
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
            lname.ForeColor = Color.Red;
            lid.ForeColor = Color.Red;
            lcantidad.ForeColor = Color.Red;
        }

        private void cambiarcolor()
        {
            lname.ForeColor = Color.White;
            lid.ForeColor = Color.White;
            lcantidad.ForeColor = Color.White;
        }








        private void limpiar()
        {
            textdescripcion.Text = string.Empty;
            textid.Text = string.Empty;
            textcantidad.Text = string.Empty;
        }





        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Deseas eliminar esta unidad?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                borrar();
                Chart();
                limpiar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textid.Text;



            if (string.IsNullOrEmpty(textdescripcion.Text) || string.IsNullOrEmpty(textid.Text) || string.IsNullOrEmpty(textcantidad.Text))
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

            else if (comboboxs.SelectedItem.ToString() == "ID" || comboboxs.SelectedItem.ToString() == "Cantidad")
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


        private void button3_Click(object sender, EventArgs e)
        {
            botonbusqueda();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboboxs.SelectedItem.ToString() == "ID" || comboboxs.SelectedItem.ToString() == "Cantidad")
            {
                Clases.dbconeccion.Validar(e);
            }
        }

        private void unidad_Load(object sender, EventArgs e)
        {
            Chart();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            comboboxs.SelectedIndex = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Asume que el ID está en la columna 0
                textcantidad.Text = row.Cells[2].Value.ToString();
                textdescripcion.Text = row.Cells[1].Value.ToString();
                textid.Text = row.Cells[0].Value.ToString();


            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Asume que el ID está en la columna 0
                textcantidad.Text = row.Cells[2].Value.ToString();
                textdescripcion.Text = row.Cells[1].Value.ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void textcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.dbconeccion.Validar(e);
        }

        private void textid_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.dbconeccion.Validar(e);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                botonbusqueda();
                e.SuppressKeyPress = true;
            }
        }
    }
}

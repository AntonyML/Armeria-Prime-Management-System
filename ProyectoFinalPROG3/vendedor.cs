using Npgsql;
using ProyectoFinalPROG3.Clases;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFinalPROG3
{
    public partial class vendedor : Form
    {
        public vendedor()
        {
            InitializeComponent();
            Clases.dbconeccion.MakeMovable(this);
            // Registrar en la auditoría
            Auditoria auditoria = new Auditoria();
            auditoria.RegistrarAuditoria(0, "Abrir vendedores"); // Reemplaza "UsuarioActual" con el ID del usuario actual

        }




        string text2 = "vendedor";
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
            DialogResult result = MessageBox.Show("¿Desesas crear un nueva vendedor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into vendedor (\"ID\",\"Nombre completo\",activo) VALUES ('" + textid.Text + "','" + textnombre.Text + "','" + "true" + "')", cn);
                try
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("vendedor creado con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al crear vendedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { cn.Close(); cmd.Dispose(); }


            }

        }

        //Funcion para actualizar el registro en caso de existir
        private void actualizar()
        {

            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            DialogResult result = MessageBox.Show("¿Se ha encontrado un nuevo vendedor, deseas actualizarlo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update vendedor set \"Nombre completo\" ='" + textnombre.Text + "'where \"ID\"='" + textid.Text + "'", cn);
                try
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Vendedor actualizado con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al actualizar vendedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                NpgsqlCommand cmd = new NpgsqlCommand("update vendedor set activo = false where activo=true and \"ID\"='" + textid.Text + "'", cn);

                try
                {
                    if (Clases.dbconeccion.confirmar(textid.Text, text2))
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("vendedor eliminado con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        cambiarcolor();

                    }
                    else { MessageBox.Show("Vendedor no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); cambiarcolor(); }

                }
                catch (Exception)
                {
                    MessageBox.Show("Vendedor no ha podido ser eliminado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cambiarcolor();
                }
                finally { cn.Close(); cmd.Dispose(); }




            }


        }












        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Asume que el ID está en la columna 0 y el nombre en la columna 1
                textnombre.Text = row.Cells[1].Value.ToString();
                textid.Text = row.Cells[0].Value.ToString();
            }
        }

        private void Chart()
        {
            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            NpgsqlCommand cm = new NpgsqlCommand();
            cm.Connection = cn;
            cm.CommandType = CommandType.Text;
            cm.CommandText = "select \"ID\",\"Nombre completo\" from vendedor where activo=true;";
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
        }

        private void cambiarcolor()
        {
            l1.ForeColor = Color.White;
            l2.ForeColor = Color.White;
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
            else
            {
                dataGridView1.DataSource = Clases.dbconeccion.busqueda(n, y, z, x);


            }
        }


        private void vendedor_Load(object sender, EventArgs e)
        {
            Chart();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            comboboxs.SelectedIndex = 0;
        }

        private void textid_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.dbconeccion.Validar(e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            botonbusqueda();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                botonbusqueda();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboboxs.SelectedItem.ToString() == "ID")
            {
                Clases.dbconeccion.Validar(e);
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

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textid.Text;



            if (string.IsNullOrEmpty(textnombre.Text) || string.IsNullOrEmpty(textid.Text))
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
                    if (l1.ForeColor == Color.Red)
                    {
                        cambiarcolor();
                    }

                }
                else
                {
                    crear();
                    Chart();

                    if (l1.ForeColor == Color.Red)
                    {
                        cambiarcolor();
                    }
                }
            }
        }

        private void limpiar()
        {
            textnombre.Text = string.Empty;
            textid.Text = string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Deseas eliminar este vendedor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                borrar();
                Chart();
                limpiar();
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Asume que el ID está en la columna 0 y el nombre en la columna 1
                textnombre.Text = row.Cells[1].Value.ToString();
                textid.Text = row.Cells[0].Value.ToString();
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
    }
}

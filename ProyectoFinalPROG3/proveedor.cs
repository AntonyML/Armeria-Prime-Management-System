using Npgsql;
using ProyectoFinalPROG3.Clases;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFinalPROG3
{
    public partial class proveedor : Form
    {
        public proveedor()
        {
            InitializeComponent();
            Clases.dbconeccion.MakeMovable(this);
            // Registrar en la auditoría
            Auditoria auditoria = new Auditoria();
            auditoria.RegistrarAuditoria(0, "Abrir Articulo_con_linea"); // Reemplaza "UsuarioActual" con el ID del usuario actual

        }




        string text2 = "proveedor";
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
            DialogResult result = MessageBox.Show("¿Desesas crear un nuevo proveedor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into proveedor (\"ID\",\"Descripcion\",\"Cedula o RNC\",\"Direccion\",\"Ciudad\",\"Contacto\",\"Telefono\",\"Estado\",activo) VALUES ('" + textid.Text + "','" + textdescripcion.Text + "','" + textcedula.Text + "','" + textdireccion.Text + "','" + textciudad.Text + "','" + textcontacto.Text + "','" + texttelefono.Text + "','" + comboestado.Text + "','" + "true" + "')", cn);
                try
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Proveedor creado con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al crear proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { cn.Close(); cmd.Dispose(); }


            }

        }

        //Funcion para actualizar el registro en caso de existir
        private void actualizar()
        {

            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            DialogResult result = MessageBox.Show("¿Se ha encontrado un proveedor, deseas actualizarlo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update proveedor set \"Descripcion\" ='" + textdescripcion.Text + "',\"Cedula o RNC\" = '" + textcedula.Text + "',\"Direccion\" = '" + textdireccion.Text + "',\"Ciudad\" = '" + textciudad.Text + "',\"Contacto\" = '" + textcontacto.Text + "',\"Telefono\" = '" + texttelefono.Text + "',\"Estado\" = '" + comboestado.Text + "' where \"ID\"='" + textid.Text + "'", cn);
                try
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Proveedor actualizado con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al actualizar Proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { cn.Close(); cmd.Dispose(); }
            }
        }



        //Funcion para borrar el registro en caso de existir
        private void borrar()
        {
            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            if (string.IsNullOrEmpty(textid.Text) || string.IsNullOrEmpty(textdescripcion.Text) || string.IsNullOrEmpty(textcedula.Text) || string.IsNullOrEmpty(textdireccion.Text) || string.IsNullOrEmpty(textciudad.Text) || string.IsNullOrEmpty(textcontacto.Text) || string.IsNullOrEmpty(texttelefono.Text))
            {
                MessageBox.Show("Los campos en rojo son obligatorios!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cambiarcolorrojo();
            }
            else
            {

                NpgsqlCommand cmd = new NpgsqlCommand("update proveedor set activo = false where activo=true and \"ID\"='" + textid.Text + "'", cn);

                try
                {
                    if (Clases.dbconeccion.confirmar(textid.Text, text2))
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Proveedor eliminado con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        cambiarcolor();

                    }
                    else { MessageBox.Show("Proveedor no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); cambiarcolor(); }

                }
                catch (Exception)
                {
                    MessageBox.Show("Proveedor no pudo ser eliminado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            cm.CommandText = "select \"ID\",\"Descripcion\",\"Cedula o RNC\",\"Direccion\",\"Ciudad\",\"Contacto\",\"Telefono\",\"Estado\" from proveedor where activo=true;";
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
            l5.ForeColor = Color.Red;
            l6.ForeColor = Color.Red;
            l7.ForeColor = Color.Red;
            l8.ForeColor = Color.Red;
        }

        private void cambiarcolor()
        {


            l1.ForeColor = Color.White;
            l2.ForeColor = Color.White;
            l3.ForeColor = Color.White;
            l4.ForeColor = Color.White;
            l5.ForeColor = Color.White;
            l6.ForeColor = Color.White;
            l7.ForeColor = Color.White;
            l8.ForeColor = Color.White;

        }






        private void proveedor_Load(object sender, EventArgs e)
        {
            Chart();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            comboboxs.SelectedIndex = 0;
            comboestado.SelectedIndex = 0;
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Asume que el ID está en la columna 0 y la descripcion en la columna 1

                comboestado.Text = row.Cells[7].Value.ToString();
                texttelefono.Text = row.Cells[6].Value.ToString();
                textcontacto.Text = row.Cells[5].Value.ToString();
                textciudad.Text = row.Cells[4].Value.ToString();
                textdireccion.Text = row.Cells[3].Value.ToString();
                textcedula.Text = row.Cells[2].Value.ToString();
                textdescripcion.Text = row.Cells[1].Value.ToString();
                textid.Text = row.Cells[0].Value.ToString();

            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Asume que el ID está en la columna 0 y la descripcion en la columna 1

                comboestado.Text = row.Cells[7].Value.ToString();
                texttelefono.Text = row.Cells[6].Value.ToString();
                textcontacto.Text = row.Cells[5].Value.ToString();
                textciudad.Text = row.Cells[4].Value.ToString();
                textdireccion.Text = row.Cells[3].Value.ToString();
                textcedula.Text = row.Cells[2].Value.ToString();
                textdescripcion.Text = row.Cells[1].Value.ToString();
                textid.Text = row.Cells[0].Value.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textid.Text;

            if (string.IsNullOrEmpty(textid.Text) || string.IsNullOrEmpty(textdescripcion.Text) || string.IsNullOrEmpty(textcedula.Text) || string.IsNullOrEmpty(textdireccion.Text) || string.IsNullOrEmpty(textciudad.Text) || string.IsNullOrEmpty(textcontacto.Text) || string.IsNullOrEmpty(texttelefono.Text))
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
            texttelefono.Text = string.Empty;
            textcontacto.Text = string.Empty;
            textciudad.Text = string.Empty;
            textdireccion.Text = string.Empty;
            textcedula.Text = string.Empty;
            textdescripcion.Text = string.Empty;
            textid.Text = string.Empty;
            comboestado.SelectedIndex = 0;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
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

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Deseas eliminar este proveedor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                borrar();
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
            else
            {
                dataGridView1.DataSource = Clases.dbconeccion.busqueda(n, y, z, x);


            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            botonbusqueda();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            gestor.MinimizarForm(this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            gestor.CerrarForm(this);
        }

        private void textid_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.dbconeccion.Validar(e);
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
    }
}

using Npgsql;
using ProyectoFinalPROG3.Clases;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFinalPROG3
{
    public partial class clientesEXT : Form
    {
        Clases.dbconeccion gestor = new dbconeccion();

        clientes form2 = new clientes();





        public clientesEXT()
        {
            InitializeComponent();
            Clases.dbconeccion.MakeMovable(this);
            // Registrar en la auditoría
            Auditoria auditoria = new Auditoria();
            auditoria.RegistrarAuditoria(0, "Abrir ClienteExt"); // Reemplaza "UsuarioActual" con el ID del usuario actual

        }

        private void clientesEXT_Load(object sender, EventArgs e)
        {

            chart();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            comboboxs.SelectedIndex = 0;
        }


        //-----------------------------------------------------Cambiar bordes------------------------------------------------------------------------------------------
        private void clientesEXT_Paint(object sender, PaintEventArgs e)
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
        //------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void chart()
        {
            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            NpgsqlCommand cm = new NpgsqlCommand();
            cm.Connection = cn;
            cm.CommandType = CommandType.Text;
            cm.CommandText = "select \"Nombre\",\"ID\",\"Fecha de ingreso\",\"Cedula o RNC\",\"Tipo de cliente\",\"Telefono\",\"Status\" from cliente where activo=true";
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
            catch (NpgsqlException)
            {
                MessageBox.Show("ENo se ha podido acceder a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close(); cm.Dispose();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clientes formbase = Owner as clientes;
            NpgsqlConnection cn = Clases.dbconeccion.conectar();

            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];


                try
                {
                    int id = Convert.ToInt32(row.Cells["ID"].Value);







                    // Consulta para obtener los datos. 
                    string query = "select \"Nombre\",\"ID\",\"Razon social\",\"Fecha de ingreso\",\"Cedula o RNC\",\"Tipo de cliente\",\"Direccion\",\"Ciudad\",\"Telefono\",\"Email\",\"Limite de credito\",\"Observacion\",\"Status\",\"rutaimagen\" from cliente where activo=true and \"ID\"=@id";

                    using (var command = new NpgsqlCommand(query, cn))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                formbase.txtnombre.Text = reader["Nombre"].ToString();
                                formbase.txtnumero.Text = reader["ID"].ToString();
                                formbase.txtrazon.Text = reader["Razon social"].ToString();
                                formbase.txtcedula.Text = reader["Cedula o RNC"].ToString();
                                formbase.txttipo.Text = reader["Tipo de cliente"].ToString();
                                formbase.txtdireccion.Text = reader["Direccion"].ToString();
                                formbase.txtciudad.Text = reader["Ciudad"].ToString();
                                formbase.txttelefono.Text = reader["Telefono"].ToString();
                                formbase.txtemail.Text = reader["Email"].ToString();
                                formbase.txtlimite.Text = reader["Limite de credito"].ToString();
                                formbase.txtobservacion.Text = reader["Observacion"].ToString();
                                formbase.txtstatus.Text = reader["Status"].ToString();
                                DateTime fechaIngreso = Convert.ToDateTime(reader["Fecha de ingreso"]);
                                formbase.textFecha.Text = fechaIngreso.ToShortDateString();
                                string rutaImagenGuardada = reader["rutaimagen"].ToString();


                                this.Hide();
                                form2.Focus();
                                gestor.CargarImagenExistente(formbase.pictureBox1, rutaImagenGuardada);
                                formbase.cambiarcolor2();
                                if (rutaImagenGuardada == "")
                                {
                                    formbase.pictureBox1.ImageLocation = null;
                                }
                                formbase.laberconfirmar();
                            }

                        }


                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Has seleccionado un registro vacio!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cn.Close();
                }

            }




        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

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

        private void fechashow()
        {
            dateTimePicker1.Show();
            dateTimePicker2.Show();
            ldesde.Show();
            lhasta.Show();
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

        private void botonbusqueda()
        {

            string y = textBox1.Text.ToString();
            string n = comboboxs.Text.ToString();
            string z = "cliente";



            if (comboboxs.SelectedItem.ToString() == "Defecto")
            {
                chart();

            }

            else if (comboboxs.SelectedItem.ToString() == "ID" || comboboxs.SelectedItem.ToString() == "Cedula o RNC" || comboboxs.SelectedItem.ToString() == "Telefono")
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
            else if (comboboxs.SelectedItem.ToString() == "Status" || comboboxs.SelectedItem.ToString() == "Tipo de cliente")
            {

                if (Clases.dbconeccion.ValidarLetras(textBox1))
                {
                    dataGridView1.DataSource = Clases.dbconeccion.busqueda(n, y, z);
                }
                else
                {
                    MessageBox.Show("Solo se permiten letras en esta busqueda");
                }
            }
            else if (comboboxs.SelectedItem.ToString() == "Nombre")
            {
                int x = 1;
                dataGridView1.DataSource = Clases.dbconeccion.busqueda(n, y, z, x);


            }
            else if (comboboxs.SelectedItem.ToString() == "Fecha")
            {
                dataGridView1.DataSource = Clases.dbconeccion.busqueda(z, dateTimePicker1.Value, dateTimePicker2.Value);
            }



        }


        private void button1_Click(object sender, EventArgs e)
        {

            botonbusqueda();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboboxs.SelectedItem.ToString() == "Tipo de cliente" || comboboxs.SelectedItem.ToString() == "Status")
            {
                Clases.dbconeccion.ValidarLetra(e);
            }

            else if (comboboxs.SelectedItem.ToString() == "ID" || comboboxs.SelectedItem.ToString() == "Cedula o RNC" || comboboxs.SelectedItem.ToString() == "Telefono")
            {
                Clases.dbconeccion.Validar(e);
            }

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

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

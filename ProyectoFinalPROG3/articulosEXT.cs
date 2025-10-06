using Npgsql;
using ProyectoFinalPROG3.Clases;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFinalPROG3
{
    public partial class articulosEXT : Form
    {

        Clases.dbconeccion gestor = new dbconeccion();

        articulos form2 = new articulos();


        public articulosEXT()
        {
            InitializeComponent();
            Clases.dbconeccion.MakeMovable(this);
            // Registrar en la auditoría
            Auditoria auditoria = new Auditoria();
            auditoria.RegistrarAuditoria(0, "Abrir ArticuloExt"); // Reemplaza "UsuarioActual" con el ID del usuario actual

        }



        //-----------------------------------------------------Cambiar bordes------------------------------------------------------------------------------------------
        private void articulosEXT_Paint(object sender, PaintEventArgs e)
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
            cm.CommandText = "select \"ID\",\"Referencia\",\"Descripcion\",\"Numero de marca\",\"Fecha de ingreso\",\"Usuario de ingreso\",\"Usuario MOD\" from articulo where activo=true";
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
                MessageBox.Show("No se ha podido acceder a la base de datos", "Error" + e.ToString());
            }
            finally
            {
                cn.Close(); cm.Dispose();
            }
        }






        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            articulos formbase = Owner as articulos;


            NpgsqlConnection cn = Clases.dbconeccion.conectar();



            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];



                try
                {
                    int id = Convert.ToInt32(row.Cells["ID"].Value);

                    // Consulta para obtener los datos. 
                    string query = "select \"ID\",\"Referencia\",\"Descripcion\",\"Numero de marca\",\"Numero de proveedor\",\"Numero de linea\",\"Precio\",\"Existencia\",\"Fecha de ingreso\",\"rutaimagen\",\"Costo\",\"Numero de unidad\",\"ITBIS\",\"Observaciones\",\"Usuario de ingreso\",\"Usuario MOD\" from articulo where activo=true and \"ID\"=@id";

                    using (var command = new NpgsqlCommand(query, cn))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                formbase.txtnumero.Text = reader["ID"].ToString();
                                formbase.txtreferencia.Text = reader["Referencia"].ToString();
                                formbase.txtdescripcion.Text = reader["Descripcion"].ToString();
                                formbase.txtmarca.Text = reader["Numero de marca"].ToString();
                                formbase.txtproveedor.Text = reader["Numero de proveedor"].ToString();
                                formbase.txtlinea.Text = reader["Numero de linea"].ToString();
                                formbase.txtprecio.Text = reader["Precio"].ToString();
                                formbase.txtexistencia.Text = reader["Existencia"].ToString();
                                formbase.txtcosto.Text = reader["Costo"].ToString();
                                formbase.txtunidad.Text = reader["Numero de unidad"].ToString();
                                formbase.txtitbis.Text = reader["ITBIS"].ToString();
                                formbase.txtobservacion.Text = reader["Observaciones"].ToString();
                                formbase.textuser.Text = reader["Usuario de ingreso"].ToString();
                                formbase.textusermod.Text = reader["Usuario MOD"].ToString();
                                DateTime fechaIngreso = Convert.ToDateTime(reader["Fecha de ingreso"]);
                                formbase.textFecha.Text = fechaIngreso.ToShortDateString();
                                string rutaImagenGuardada = reader["rutaimagen"].ToString();

                                this.Hide();
                                form2.Focus();
                                gestor.CargarImagenExistente(formbase.pictureBox1, rutaImagenGuardada);
                                formbase.cambiarcolor2();
                                formbase.s = 0;

                                if (rutaImagenGuardada == "")
                                {
                                    formbase.pictureBox1.ImageLocation = null;
                                }
                                formbase.laberconfirmar();
                                if (formbase.textusermod.Text == "" || formbase.textusermod.Text == null)
                                {
                                    formbase.textusermod.Text = "Nunca modificado";
                                }
                            }
                            formbase.cambiarcolor2();
                            this.Hide();
                            form2.Focus();
                            formbase.s = 0;
                        }
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Has seleccionado un registro vacio!");
                }
                finally
                {
                    cn.Close();
                }



            }







        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            gestor.MinimizarForm(this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            gestor.CerrarForm(this);
        }

        private void articulosEXT_Load(object sender, EventArgs e)
        {
            chart();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            comboboxs.SelectedIndex = 0;
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
            string z = "articulo";



            if (comboboxs.SelectedItem.ToString() == "Defecto")
            {
                chart();

            }
            else if (comboboxs.SelectedItem.ToString() == "ID" || comboboxs.SelectedItem.ToString() == "Numero de marca")
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
                int x = 1;
                dataGridView1.DataSource = Clases.dbconeccion.busqueda(n, y, z, x);
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            botonbusqueda();
        }






        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboboxs.SelectedItem.ToString() == "ID" || comboboxs.SelectedItem.ToString() == "Numero de marca")
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

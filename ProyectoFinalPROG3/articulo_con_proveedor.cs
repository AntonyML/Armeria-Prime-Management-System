using Npgsql;
using ProyectoFinalPROG3.Clases;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFinalPROG3
{
    public partial class articulo_con_proveedor : Form
    {
        public articulo_con_proveedor()
        {
            InitializeComponent();
            Clases.dbconeccion.MakeMovable(this);
            // Registrar en la auditoría
            Auditoria auditoria = new Auditoria();
            auditoria.RegistrarAuditoria(0, "Abrir Articulo_con_provedor"); // Reemplaza "UsuarioActual" con el ID del usuario actual

        }
        Clases.dbconeccion gestor = new dbconeccion();
        string text2 = "proveedorEXT";
        articulos form2 = new articulos();

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












        private void Chart()
        {
            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            NpgsqlCommand cm = new NpgsqlCommand();
            cm.Connection = cn;
            cm.CommandType = CommandType.Text;
            cm.CommandText = "select \"ID\",\"Descripcion\",\"Cedula o RNC\",\"Ciudad\",\"Contacto\",\"Estado\" from proveedor where activo=true;";
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




        private void articulo_con_proveedor_Load(object sender, EventArgs e)
        {
            Chart();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            comboboxs.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            botonbusqueda();

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
                    string query = "select \"ID\" from proveedor where activo=true and \"ID\"=@id";

                    using (var command = new NpgsqlCommand(query, cn))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                formbase.txtproveedor.Text = reader["ID"].ToString();


                                this.Hide();
                                form2.Focus();

                            }

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

        private void button6_Click(object sender, EventArgs e)
        {
            gestor.MinimizarForm(this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            gestor.CerrarForm(this);
        }
    }
}


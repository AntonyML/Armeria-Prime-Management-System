using Npgsql;
using ProyectoFinalPROG3.Clases;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProyectoFinalPROG3.Buscadores
{
    public partial class Busca_Articulo : Form
    {
        public Busca_Articulo()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]

        public extern static void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Consulta_Click(object sender, EventArgs e)
        {

            dbconeccion obj = new dbconeccion();
            NpgsqlConnection conexion = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=enyer.12 ; Database=armeria prime");

            if (FiltroArticulo.Text == "")
            {
                try
                {
                    conexion.Open();
                    string consulta = "SELECT * FROM articulo";
                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(consulta, conexion);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    dataGridView1.DataSource = dt;
                    NpgsqlCommand ejecutar = new NpgsqlCommand(consulta, conexion);
                    NpgsqlDataReader leer;
                    leer = ejecutar.ExecuteReader();



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos: " + ex);
                }

            }
            else if (comboArticulo.SelectedItem.Equals("No.Articulo"))
            {
                try
                {
                    //Verificar esto en la bd
                    string consulta = "Select * from articulo where ID = " + int.Parse(FiltroArticulo.Text) + "";
                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(consulta, conexion);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    dataGridView1.DataSource = dt;
                    NpgsqlCommand ejecutar = new NpgsqlCommand(consulta, conexion);
                    NpgsqlDataReader leer;
                    leer = ejecutar.ExecuteReader();



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos: " + ex);
                }
            }
            else if (comboArticulo.SelectedItem.Equals("Descripcion"))
            {
                try
                {
                    string consulta = "Select * from articulo where descripcion = '" + FiltroArticulo.Text + "'";
                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(consulta, conexion);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    dataGridView1.DataSource = dt;
                    NpgsqlCommand ejecutar = new NpgsqlCommand(consulta, conexion);
                    NpgsqlDataReader leer;
                    leer = ejecutar.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos: " + ex);
                }
            }
            conexion.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Ventas ar = Owner as Ventas;
            Entrada_Salida ES = Owner as Entrada_Salida;

            if (e.RowIndex >= 0)
            {

                try
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    ar.Articulo.Text = selectedRow.Cells[1].Value.ToString();
                    ar.txtExistencia.Text = selectedRow.Cells[7].Value.ToString();
                    ar.txtPrecio.Text = selectedRow.Cells[6].Value.ToString();

                    if (selectedRow.Cells[11].Value.ToString().Equals("X"))
                    {
                        ar.ImpuestoProd.Checked = true;
                    }


                    this.Dispose();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al Ejecutar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            if (e.RowIndex >= 0)
            {

                try
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    ES.Articulo.Text = selectedRow.Cells[1].Value.ToString();
                    ES.txtValor.Text = selectedRow.Cells[7].Value.ToString();
                    ES.txtCosto.Text = selectedRow.Cells[10].Value.ToString();
                    this.Dispose();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al Ejecutar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void Busca_Articulo_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
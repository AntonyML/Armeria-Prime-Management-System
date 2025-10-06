using Npgsql;
using ProyectoFinalPROG3.Clases;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProyectoFinalPROG3.Buscadores
{
    public partial class Busca_Marca : Form
    {
        public Busca_Marca()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]

        public extern static void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Busca_Marca_Load(object sender, EventArgs e)
        {

        }
        private void Consulta_Click(object sender, EventArgs e)
        {
            dbconeccion obj = new dbconeccion();
            NpgsqlConnection conexion = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=enyer.12 ; Database=armeria prime");

            if (FiltroMarca.Text == "")
            {
                try
                {
                    conexion.Open();
                    string consulta = "SELECT * FROM marca";
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
            else if (comboMarca.SelectedItem.Equals("No.Marca"))
            {
                try
                {

                    string consulta = "Select * from marca where ID = '" + FiltroMarca.Text + "'";
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
            else if (comboMarca.SelectedItem.Equals("Descripcion"))
            {
                try
                {
                    string consulta = "Select * from marca where Descripcion = '" + FiltroMarca.Text + "'";
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
            articulos ar = Owner as articulos;

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    ar.txtmarca.Text = selectedRow.Cells[1].Value.ToString();

                    this.Dispose();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al Ejecutar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

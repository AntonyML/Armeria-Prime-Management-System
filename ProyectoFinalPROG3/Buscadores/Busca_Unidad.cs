using Npgsql;
using ProyectoFinalPROG3.Clases;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoFinalPROG3.Buscadores
{
    public partial class Busca_Unidad : Form
    {
        public Busca_Unidad()
        {
            InitializeComponent();
        }

        private void Busca_Unidad_Load(object sender, EventArgs e)
        {

        }

        private void Consulta_Click(object sender, EventArgs e)
        {

            dbconeccion obj = new dbconeccion();
            NpgsqlConnection conexion = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=enyer.12 ; Database=armeria prime");

            if (FiltroUnidad.Text == "")
            {
                try
                {
                    conexion.Open();
                    string consulta = "SELECT * FROM unidad";
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
            else if (comboUnidad.SelectedItem.Equals("No.Unidad"))
            {
                try
                {
                    string consulta = "Select * from unidad where ID = '" + FiltroUnidad.Text + "'";
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

            else if (comboUnidad.SelectedItem.Equals("Descripcion"))
            {
                try
                {

                    string consulta = "Select * from unidad where descripcion = '" + FiltroUnidad.Text + "'";
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
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                ar.txtunidad.Text = selectedRow.Cells[1].Value.ToString();
                this.Dispose();
            }
        }
    }
}

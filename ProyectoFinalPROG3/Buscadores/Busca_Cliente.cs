using Npgsql;
using ProyectoFinalPROG3.Clases;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProyectoFinalPROG3.Buscadores
{
    public partial class Busca_Cliente : Form
    {
        public Busca_Cliente()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]

        public extern static void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void FiltroUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void Consulta_Click(object sender, EventArgs e)
        {

            dbconeccion obj = new dbconeccion();
            NpgsqlConnection conexion = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=enyer.12 ; Database=armeria prime");

            if (FiltroUser.Text == "")
            {
                try
                {
                    conexion.Open();
                    string consulta = "SELECT * FROM cliente";
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
            else if (comboCliente.SelectedItem.Equals("No.Cliente"))
            {
                try
                {

                    string consulta = "Select * from cliente where ID = " + int.Parse(FiltroUser.Text);
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
            else if (comboCliente.SelectedItem.Equals("Nombre"))
            {
                try
                {

                    string consulta = "Select * from cliente where Nombre = '" + FiltroUser.Text + "'";
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

            else if (comboCliente.SelectedItem.Equals("RNC"))
            {
                try
                {

                    string consulta = "Select * from cliente where cedula o RNC = '" + FiltroUser.Text + "'";
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

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    ar.NoCliente.Text = selectedRow.Cells[6].Value.ToString();
                    ar.NombreCliente.Text = selectedRow.Cells[2].Value.ToString();

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

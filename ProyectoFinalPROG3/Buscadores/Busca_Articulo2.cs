using Npgsql;
using ProyectoFinalPROG3.Clases;
using System;
using System.Data;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProyectoFinalPROG3.Buscadores
{
    public partial class Busca_Articulo2 : Form
    {
        Clases.dbconeccion gestor = new dbconeccion();
        public Busca_Articulo2()
        {
            InitializeComponent();
            Clases.dbconeccion.MakeMovable(this);
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
            Entrada_Salida ES = Owner as Entrada_Salida;

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    ES.Articulo.Text = selectedRow.Cells[1].Value.ToString();
                    ES.txtValor.Text = selectedRow.Cells[6].Value.ToString();
                    ES.txtExistencia.Text = selectedRow.Cells[7].Value.ToString();
                    ES.txtCosto.Text = selectedRow.Cells[10].Value.ToString();

                    this.Dispose();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al Ejecutar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Busca_Articulo2_Load(object sender, EventArgs e)
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

        //-----------------------------------------------------Cambiar bordes--------------------------------------
        private void Busca_Articulo2_Paint_1(object sender, PaintEventArgs e)
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
    }
}

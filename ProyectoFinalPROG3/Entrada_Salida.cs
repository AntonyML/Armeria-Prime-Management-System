using Npgsql;
using ProyectoFinalPROG3.Buscadores;
using ProyectoFinalPROG3.Clases;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoFinalPROG3
{
    public partial class Entrada_Salida : Form
    {
        public Entrada_Salida()
        {
            InitializeComponent();
            // Registrar en la auditoría
            Auditoria auditoria = new Auditoria();
            auditoria.RegistrarAuditoria(0, "Abrir Entrada/Salida"); // Reemplaza "UsuarioActual" con el ID del usuario actual

        }

        dbconeccion obj = new dbconeccion();
        private void Articulo_Click(object sender, EventArgs e)
        {
            Busca_Articulo2 BA = new Busca_Articulo2();
            AddOwnedForm(BA);
            BA.Show();
            BA.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (validator())
            {
                decimal exitenciaArticulo = 0;

                if (comboTipo.SelectedItem.Equals("Entrada"))
                {
                    exitenciaArticulo = decimal.Parse(txtExistencia.Text) + NumCantidad.Value;
                }
                else if (comboTipo.SelectedItem.Equals("Salida"))
                {
                    exitenciaArticulo = decimal.Parse(txtExistencia.Text) - NumCantidad.Value;


                    if (exitenciaArticulo < 0)
                    {
                        MessageBox.Show("La exitencia de este producto es menor que la canidad", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        NumCantidad.Value = 0;
                        return;

                    }
                }

                string update = "UPDATE articulo SET " +
                                "existencia = " + exitenciaArticulo +
                                "WHERE descripcion = '" + Articulo.Text + "'";


                try
                {
                    // obj.EjecutaQuery(update);
                    MessageBox.Show("Ejecuto Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al Ejecutar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string consulta = "INSERT INTO ajuste_d VALUES (" +
                                  int.Parse(NoInventario.Text) + ",'" +
                                  Articulo.Text + "'," +
                                  NumCantidad.Value + "," +
                                  decimal.Parse(txtCosto.Text) + "," +
                                  decimal.Parse(txtValor.Text) + ")";



                try
                {
                    //  obj.EjecutaQuery(consulta);
                    MessageBox.Show("Ejecuto Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)

                {
                    MessageBox.Show("Error al Ejecutar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



                NpgsqlConnection conexion = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=enyer.12 ; Database=armeria prime");

                try
                {
                    conexion.Open();

                    string select = "select * from ajuste_d where InventarioNo = " + NoInventario.Text;
                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(select, conexion);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    dataGridView1.DataSource = dt;
                    NpgsqlCommand ejecutar = new NpgsqlCommand(select, conexion);
                    NpgsqlDataReader leer;
                    leer = ejecutar.ExecuteReader();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos: " + ex);
                }

                conexion.Close();


            }



            txtExistencia.Clear();
            txtValor.Clear();
            Articulo.Clear();
            txtCosto.Clear();

            NumCantidad.Value = 0;



            decimal TotalCosto = 0;
            decimal TotalValor = 0;


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                TotalCosto += Convert.ToDecimal(row.Cells["Column4"].Value);
                TotalValor += Convert.ToDecimal(row.Cells["Column5"].Value);
            }
            txtCostoTotal.Text = Convert.ToString(TotalCosto);
            txtValorTotal.Text = Convert.ToString(TotalValor);
        }

        private Boolean validator()
        {
            if (NoInventario.Text.Equals(""))
            {
                NoInventario.Focus();
                return false;
            }
            else if (NumCantidad.Value == 0)
            {
                NumCantidad.Focus();
                return false;
            }
            else if (comboTipo.SelectedItem == null)
            {
                NumCantidad.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void limpiaTabla()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            txtValorTotal.Clear();
            txtCostoTotal.Clear();
        }

        private void llenarTabla()
        {
            dbconeccion obj = new dbconeccion();
            NpgsqlConnection conexion = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=enyer.12 ; Database=armeria prime");


            try
            {
                conexion.Open();
                string consulta = "select * from ajuste_d where InventarioNo = " + NoInventario.Text;
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


            conexion.Close();
        }

        private void Quitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                string idToDelete = dataGridView1.Rows[rowIndex].Cells["Column1"].Value.ToString();
                int cantToDelete = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["Column3"].Value);

                using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=enyer.12 ; Database=armeria prime")) //Agregar la bd si me sigue dando error.
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM ajuste_d WHERE ArticuloNo = @ID and Cantidad = @Cant";
                    NpgsqlCommand deleteCommand = new NpgsqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@ID", idToDelete);
                    deleteCommand.Parameters.AddWithValue("@Cant", cantToDelete);
                    deleteCommand.ExecuteNonQuery();

                    connection.Close();
                }

                dataGridView1.Rows.RemoveAt(rowIndex);
            }
        }

        private void Grabar_Click(object sender, EventArgs e)
        {
            dbconeccion obj = new dbconeccion();
            if (string.IsNullOrWhiteSpace(NoInventario.Text))
            {
                MessageBox.Show("El No.Inventario no puede estar vacío.", "Error de validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else if (string.IsNullOrWhiteSpace(comboTipo.Text))
            {
                MessageBox.Show("El Tipo no puede estar vacío.", "Error de validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            string tipo = "";

            if (comboTipo.SelectedItem.Equals("Entrada"))
            {
                tipo = "E";
            }
            else
            {
                tipo = "S";
            }


            string consulta = "INSERT INTO ajuste_m VALUES (" +
                               int.Parse(NoInventario.Text) + ", " +
                               "GetDate(), '" + tipo + "', " +
                               decimal.Parse(txtCostoTotal.Text) + ", " +
                               decimal.Parse(txtValorTotal.Text) + ", " +
                               "'P'" + ")";

            try
            {
                // obj.EjecutaQuery(consulta);
                MessageBox.Show("Ejecuto Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiaTabla();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al Ejecutar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            llenarTabla();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limpiaTabla();

            foreach (Control item in panel1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";

                }
            }
        }

        private void txtCostoTotal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
